using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HollywoodTest.Domain.IRepositories;
using HollywoodTest.Domain.IServices;
using HollywoodTest.Domain.IServices.Communication;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUnitOfWork _unitOfWork;


        public TournamentService(ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork)
        {
            _tournamentRepository = tournamentRepository;
            _unitOfWork = unitOfWork;
        }
        public  Task<IEnumerable<Tournament>> ListAsync()
        {
            return  Task.FromResult(_tournamentRepository.ListAsync());
        }

        public async Task<TournamentResponse> SaveAsync(Tournament tournament)
        {
            try
            {
                await _tournamentRepository.AddAsync(tournament);
                await _unitOfWork.CompleteAsync();

                return new TournamentResponse(tournament);
            }
            catch (Exception ex)
            {
                return new TournamentResponse($"An error occured while saving the tournament: {ex.Message}");
            }
        }

        public async Task<TournamentResponse> UpdateAsync(int id, Tournament tournament)
        {
            var existingTournament = await _tournamentRepository.FindByIdAsync(id);

            if (existingTournament == null)
                return new TournamentResponse("Tournament not found");

            existingTournament.Name = tournament.Name;

            try
            {
                await _unitOfWork.CompleteAsync();
                return  new TournamentResponse(existingTournament);
            }
            catch (Exception ex)
            {
                return new TournamentResponse($"An error occured while updating the tournament: {ex.Message}");
            }

        }

        public async Task<TournamentResponse> DeleteAsync(int id)
        {
            var existingTournament = await _tournamentRepository.FindByIdAsync(id);

            if (existingTournament == null)
                return new TournamentResponse("Tournament not found");

            try
            { 
                _tournamentRepository.Delete(existingTournament);
               await _unitOfWork.CompleteAsync();
                return new TournamentResponse(existingTournament);
            }
            catch (Exception ex)
            {
                return new TournamentResponse($"An error occured while deleting the tournament: {ex.Message}");
            }
        }
    }
}

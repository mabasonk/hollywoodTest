using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HollywoodTest.Domain.IServices;
using HollywoodTest.Domain.Models;
using HollywoodTest.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodTest.Controllers
{
    [Route("/api/tournaments")]
    [ApiController]
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IMapper mapper)
        {
            _tournamentService = tournamentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            
            var tournaments = await _tournamentService.ListAsync();
            return tournaments;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TournamentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> PostAsync([FromBody] TournamentResource resource)
        {
            var tournament = _mapper.Map<TournamentResource, Tournament>(resource);
            var result = await _tournamentService.SaveAsync(tournament);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TournamentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TournamentResource resource)
        {
            var tournament = _mapper.Map<TournamentResource, Tournament>(resource);
            var result = await _tournamentService.UpdateAsync(id, tournament);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TournamentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _tournamentService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);
        }
    }
}
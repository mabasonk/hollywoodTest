using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.IRepositories;
using HollywoodTest.Domain.IServices;
using HollywoodTest.Domain.IServices.Communication;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Services
{
    public class EventDetailService : IEventDetailService
    {
        private readonly IEventDetailRepository _eventDetailRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventDetailService(IEventDetailRepository eventDetailRepository, IEventRepository eventRepository, IUnitOfWork unitOfWork)
        {
            _eventDetailRepository = eventDetailRepository;
            _eventRepository = eventRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EventDetail> List()
        {
            throw new NotImplementedException();
        }

        public async Task<EventDetailResponse> AddAsync(EventDetail eventDetailToAdd)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(eventDetailToAdd.EventId);

            try
            {
                if (existingEvent == null)
                    return new EventDetailResponse("Invalid Event.");

                await _eventDetailRepository.Add(eventDetailToAdd);
                await _unitOfWork.CompleteAsync();

                return new EventDetailResponse(eventDetailToAdd);
            }
            catch (Exception ex)
            {
                return new EventDetailResponse($"An error occured when saving Event Details: {ex.Message}");
            }
        }

        public async Task<EventDetailResponse> Update(int id, EventDetail eventToUpdate)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(eventToUpdate.EventId);
            if (existingEvent == null)
                return new EventDetailResponse("Invalid Event.");

            var existingEventDetails = await _eventDetailRepository.FindByIdAsync(eventToUpdate.EventDetailId);
            if (existingEventDetails == null)
                return new EventDetailResponse("Invalid Event Details");

            existingEventDetails.EventDetailName = eventToUpdate.EventDetailName;
            existingEventDetails.EventDetailNumber = eventToUpdate.EventDetailNumber;
            existingEventDetails.EventDetailOdd = eventToUpdate.EventDetailOdd;
            existingEventDetails.FinishingPosition = eventToUpdate.FinishingPosition;
            existingEventDetails.FirstTimer = eventToUpdate.FirstTimer;
            existingEventDetails.EventId = eventToUpdate.EventId;
            existingEventDetails.EventDetailStatus = eventToUpdate.EventDetailStatus;

            try
            {
                
                _eventDetailRepository.Update(existingEventDetails);
                await _unitOfWork.CompleteAsync();

                return new EventDetailResponse(existingEventDetails);

            }
            catch (Exception ex)
            {
                return new EventDetailResponse($"An error occured when updating Event Details: {ex.Message}");
            }

        }

        public async Task<EventDetailResponse> Delete(int id)
        {
            var existingEventDetails = await _eventDetailRepository.FindByIdAsync(id);

            if (existingEventDetails == null)
                return new EventDetailResponse("Invalid Event Details");

            try
            {
                _eventDetailRepository.Delete(existingEventDetails);
                await _unitOfWork.CompleteAsync();

                return new EventDetailResponse(existingEventDetails);
            }
            catch (Exception ex)
            {
                return new EventDetailResponse($"An error occured when Deleting Event Details: {ex.Message}");
            }

        }
    }
}

using AutoMapper;
using HollywoodTest.Domain.Models;
using HollywoodTest.Resources;

namespace HollywoodTest.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Tournament, TournamentResource>();

            CreateMap<Event, EventResource>();
        }
    }
}

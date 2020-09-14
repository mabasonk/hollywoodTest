using AutoMapper;
using HollywoodTest.Domain.Models;
using HollywoodTest.Resources;

namespace HollywoodTest.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<TournamentResource, Tournament>();

            CreateMap<EventResource, Event>();
            //.ForMember(src => src.TournamentId,
            //    opt => opt.MapFrom(src => src.TournamentId));
        }
    }
}
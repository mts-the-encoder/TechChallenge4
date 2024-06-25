using Application.Communication.Requests;
using Application.Communication.Responses;
using AutoMapper;
using Domain.Entities;
using HashidsNet;

namespace Application.Services.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    private readonly IHashids _hashids;

    public AutoMapperConfiguration(IHashids hashids)
    {
        _hashids = hashids;
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<UserRequest, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());

        CreateMap<MovieRequest, Movie>();
        CreateMap<LoginRequest, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Movie, MovieResponse>()
            .ForMember(dest => dest.Id, config => config.MapFrom(x => _hashids.EncodeLong(x.Id)));

        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.Id, config => config.MapFrom(x => _hashids.EncodeLong(x.Id)));
    }
}
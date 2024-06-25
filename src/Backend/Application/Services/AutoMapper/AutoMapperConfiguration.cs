using AutoMapper;
using HashidsNet;

namespace Application.Services.AutoMapper;

public class AutoMapperConfiguration(IHashids hashids) : Profile
{
    private readonly IHashids _hashids = hashids;
}
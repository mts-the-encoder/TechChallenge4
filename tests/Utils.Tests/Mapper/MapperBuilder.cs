using Application.Services.AutoMapper;
using AutoMapper;
using Utils.Tests.Hashids;

namespace Utils.Tests.Mapper;

public class MapperBuilder
{
    public static IMapper Instance()
    {
        var hashids = HashidsBuilder.Instance().Build();

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperConfiguration(hashids));
        });
        return mockMapper.CreateMapper();
    }
}
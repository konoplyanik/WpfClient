using AutoMapper;
using WpfClient.Core.Mapping;

namespace WpfClient.Core.Services;

public class MapperInitializer
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
        });

        return config.CreateMapper();
    }
}

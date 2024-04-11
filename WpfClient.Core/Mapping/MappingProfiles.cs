using AutoMapper;
using WpfClient.Core.Models;
using WpfClient.Infrastructure.Model;

namespace WpfClient.Core.Mapping
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ImageTextData, ImageTextDto>();
            CreateMap<ImageTextDto, ImageTextData>();
        }
    }
}

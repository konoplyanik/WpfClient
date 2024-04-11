using AutoMapper;
using WpfClient.Core.Models;
using WpfClient.Infrastructure.Model;
using WpfClient.Infrastructure.Repositories;

namespace WpfClient.Core.Services;

public class ImageTextService : IImageTextService
{
    private readonly IImageTextRepository _repository;
    private readonly IMapper _mapper;

    public ImageTextService(IImageTextRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task UploadImageTextDataAsync(ImageTextData data)
    {
        var textImage = _mapper.Map<ImageTextDto>(data);
        await _repository.UploadImageTextDataAsync(textImage);
    }

    public async Task<List<ImageTextData>> GetImageTextDataAsync()
    {
        var imageDtos = await _repository.GetImageTextDataAsync();
        return _mapper.Map<List<ImageTextData>>(imageDtos);
    }
}

using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class SliderService(SliderRepository sliderRepository)
{
    private readonly SliderRepository _sliderRepository = sliderRepository;

    public async Task<ResponseResult> GetAllSliderAsync()
    {
        try
        {
            var result = await _sliderRepository.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}

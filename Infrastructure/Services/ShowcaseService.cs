using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ShowcaseService(ShowcaseRepository showcaseRepository, BrandRepository brandsRepository)
{
    private readonly ShowcaseRepository _showcaseRepository = showcaseRepository;
    private readonly BrandRepository _brandsRepository = brandsRepository;

    public async Task<ResponseResult> GetAllShowcaseAsync()
    {
        try
        {
            var result = await _showcaseRepository.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}

using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class TopToolService(TopToolRepository topToolRepository, ToolRepository toolRepository)
{
    private readonly TopToolRepository _topToolRepository = topToolRepository;
    private readonly ToolRepository _toolRepository = toolRepository;

    public async Task<ResponseResult> GetAllTopToolsAsync()
    {
        try
        {
            var result = await _topToolRepository.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}

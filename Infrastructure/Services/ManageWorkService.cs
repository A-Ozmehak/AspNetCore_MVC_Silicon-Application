using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ManageWorkService(ManageWorkRepository manageWorkRepository, TextIconRepository textIconRepository)
{
    private readonly ManageWorkRepository _manageWorkRepository = manageWorkRepository;
    private readonly TextIconRepository _textIconRepository = textIconRepository;

    public async Task<ResponseResult> GetAllManageWorkAsync()
    {
        try
        {
            var result = await _manageWorkRepository.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}

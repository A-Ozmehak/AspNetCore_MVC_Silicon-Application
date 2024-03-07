using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class DownloadAppService(DownloadAppRepository downloadAppRepository, AppRepository appRepository)
{
    private readonly DownloadAppRepository _downloadAppRepository = downloadAppRepository;
    private readonly AppRepository _appRepository = appRepository;

    public async Task<ResponseResult> GetAllDownloadAppAsync()
    {
        try
        {
            var result = await _downloadAppRepository.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}

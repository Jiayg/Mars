using System;
using System.Threading.Tasks;
using Mars.Application.Contracts.Features;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Features;

namespace Mars.Application.Services;

public class DemoAppService : MarsAppService, IDemoAppService
{
    private readonly IAbpDistributedLock _distributedLock;
    private readonly IStringLocalizer<MarsResource> _localizer;
    private readonly IFeatureChecker _featureChecker;
    private readonly IFeatureManager _featureManager;

    public DemoAppService(IAbpDistributedLock distributedLock,
        IStringLocalizer<MarsResource> localizer,
        IFeatureChecker featureChecker,
        IFeatureManager featureManager)
    {
        _distributedLock = distributedLock;
        _localizer = localizer;
        _featureChecker = featureChecker;
        _featureManager = featureManager;
    }

    public async Task Lock()
    {
        //var userCount = (await FeatureChecker.GetOrNullAsync(MarsFeatures.UserCount)).To<int>();
        var isPdfReporting = (await _featureChecker.GetAsync<bool>(MarsFeatures.PdfReporting));
        if (isPdfReporting)
        {
            throw new UserFriendlyException(_localizer["Feature:UserCount.Maximum"]);
        }

        var handle = await _distributedLock.TryAcquireAsync("MyLockName");
        if (handle is not null)
        {
            // code
        }
    }

    public async Task EnablePdfReporting(Guid tenantId)
    {
        await _featureManager.SetForTenantAsync(
            tenantId,
            nameof(MarsFeatures.PdfReporting),
            true.ToString()
        );

        var feature = _featureManager.GetOrNullForTenantAsync(nameof(MarsFeatures.PdfReporting), tenantId);
    }
}
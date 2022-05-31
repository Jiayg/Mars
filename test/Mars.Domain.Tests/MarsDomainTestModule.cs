using Mars.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Mars;

[DependsOn(
    typeof(MarsEntityFrameworkCoreTestModule)
    )]
public class MarsDomainTestModule : AbpModule
{
}
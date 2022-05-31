using Mars.Application;
using Volo.Abp.Modularity;

namespace Mars;

[DependsOn(
    typeof(MarsApplicationModule),
    typeof(MarsDomainTestModule)
    )]
public class MarsApplicationTestModule : AbpModule
{
}
using System.Collections.Generic;

namespace Volo.Abp.FeatureManagement.Dtos;

public class GetFeatureListResultDto
{
    public List<FeatureGroupDto> Groups { get; set; }
}
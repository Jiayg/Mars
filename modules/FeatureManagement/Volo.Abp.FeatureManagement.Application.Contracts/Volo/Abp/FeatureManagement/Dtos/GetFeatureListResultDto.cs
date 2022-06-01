using System.Collections.Generic;

namespace Volo.Abp.FeatureManagement.Dtos;

public class GetFeatureListResultDto
{
    /// <summary>
    /// 特征集合
    /// </summary>
    public List<FeatureGroupDto> Groups { get; set; }
}
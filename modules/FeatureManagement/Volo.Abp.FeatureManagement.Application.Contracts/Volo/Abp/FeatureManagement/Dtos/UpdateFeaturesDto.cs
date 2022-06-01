using System.Collections.Generic;

namespace Volo.Abp.FeatureManagement.Dtos;

public class UpdateFeaturesDto
{
    /// <summary>
    /// 特征集合
    /// </summary>
    public List<UpdateFeatureDto> Features { get; set; }
}
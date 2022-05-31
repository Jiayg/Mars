using System.Collections.Generic;

namespace Volo.Abp.FeatureManagement.Dtos;

public class UpdateFeaturesDto
{
    public List<UpdateFeatureDto> Features { get; set; }
}
﻿namespace Volo.Abp.PermissionManagement.Dtos;

public class UpdatePermissionDto
{
    public string Name { get; set; }

    public bool IsGranted { get; set; }
}
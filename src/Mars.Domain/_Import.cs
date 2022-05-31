﻿global using System;
global using System.Collections.Generic;
global using System.Diagnostics;
global using System.IO;
global using System.Linq;
global using System.Runtime.InteropServices;
global using System.Threading.Tasks;
global using IdentityServer4.Models;
global using Mars.Domain.Shared;
global using Mars.Domain.Shared.MultiTenancy;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;
global using Volo.Abp.Authorization.Permissions;
global using Volo.Abp.Data;
global using Volo.Abp.DependencyInjection;
global using Volo.Abp.Emailing;
global using Volo.Abp.FeatureManagement;
global using Volo.Abp.Guids;
global using Volo.Abp.Identity;
global using Volo.Abp.IdentityServer;
global using Volo.Abp.IdentityServer.ApiResources;
global using Volo.Abp.IdentityServer.ApiScopes;
global using Volo.Abp.IdentityServer.Clients;
global using Volo.Abp.IdentityServer.IdentityResources;
global using Volo.Abp.Modularity;
global using Volo.Abp.MultiTenancy;
global using Volo.Abp.PermissionManagement;
global using Volo.Abp.PermissionManagement.Identity;
global using Volo.Abp.PermissionManagement.IdentityServer;
global using Volo.Abp.SettingManagement;
global using Volo.Abp.Settings;
global using Volo.Abp.TenantManagement;
global using Volo.Abp.Uow;
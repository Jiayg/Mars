global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq;
global using System.Threading.Tasks;
global using Mars.Application;
global using Mars.Application.Contracts;
global using Mars.Domain;
global using Mars.Domain.Shared;
global using Mars.Domain.Shared.MultiTenancy;
global using Mars.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Cors;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using Serilog.Events;
global using Volo.Abp;
global using Volo.Abp.AspNetCore.Mvc;
global using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
global using Volo.Abp.AspNetCore.Serilog;
global using Volo.Abp.Autofac;
global using Volo.Abp.Caching;
global using Volo.Abp.Caching.StackExchangeRedis;
global using Volo.Abp.Localization;
global using Volo.Abp.Modularity;
global using Volo.Abp.Swashbuckle;
global using Volo.Abp.VirtualFileSystem;
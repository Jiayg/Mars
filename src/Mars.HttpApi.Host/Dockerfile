#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Mars.HttpApi.Host/Mars.HttpApi.Host.csproj", "src/Mars.HttpApi.Host/"]
COPY ["src/Mars.EntityFrameworkCore/Mars.EntityFrameworkCore.csproj", "src/Mars.EntityFrameworkCore/"]
COPY ["src/Mars.Domain/Mars.Domain.csproj", "src/Mars.Domain/"]
COPY ["src/Mars.Domain.Shared/Mars.Domain.Shared.csproj", "src/Mars.Domain.Shared/"]
COPY ["src/Mars.Application/Mars.Application.csproj", "src/Mars.Application/"]
COPY ["src/Mars.Application.Contracts/Mars.Application.Contracts.csproj", "src/Mars.Application.Contracts/"]
COPY ["modules/FeatureManagement/Volo.Abp.FeatureManagement.Application.Contracts/Volo.Abp.FeatureManagement.Application.Contracts.csproj", "modules/FeatureManagement/Volo.Abp.FeatureManagement.Application.Contracts/"]
COPY ["modules/SettingManagement/Volo.Abp.SettingManagement.Application.Contracts/Volo.Abp.SettingManagement.Application.Contracts.csproj", "modules/SettingManagement/Volo.Abp.SettingManagement.Application.Contracts/"]
COPY ["modules/PermissionManagement/Volo.Abp.PermissionManagement.Application.Contracts/Volo.Abp.PermissionManagement.Application.Contracts.csproj", "modules/PermissionManagement/Volo.Abp.PermissionManagement.Application.Contracts/"]
COPY ["modules/TenantManagement/Volo.Abp.TenantManagement.Application.Contracts/Volo.Abp.TenantManagement.Application.Contracts.csproj", "modules/TenantManagement/Volo.Abp.TenantManagement.Application.Contracts/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.Application.Contracts/Volo.Abp.Account.Application.Contracts.csproj", "modules/AccountManagement/Volo.Abp.Account.Application.Contracts/"]
COPY ["modules/IdentityManagement/Volo.Abp.Identity.Application.Contracts/Volo.Abp.Identity.Application.Contracts.csproj", "modules/IdentityManagement/Volo.Abp.Identity.Application.Contracts/"]
COPY ["modules/SettingManagement/Volo.Abp.SettingManagement.Application/Volo.Abp.SettingManagement.Application.csproj", "modules/SettingManagement/Volo.Abp.SettingManagement.Application/"]
COPY ["modules/PermissionManagement/Volo.Abp.PermissionManagement.Application/Volo.Abp.PermissionManagement.Application.csproj", "modules/PermissionManagement/Volo.Abp.PermissionManagement.Application/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.Application/Volo.Abp.Account.Application.csproj", "modules/AccountManagement/Volo.Abp.Account.Application/"]
COPY ["modules/IdentityManagement/Volo.Abp.Identity.Application/Volo.Abp.Identity.Application.csproj", "modules/IdentityManagement/Volo.Abp.Identity.Application/"]
COPY ["modules/FeatureManagement/Volo.Abp.FeatureManagement.Application/Volo.Abp.FeatureManagement.Application.csproj", "modules/FeatureManagement/Volo.Abp.FeatureManagement.Application/"]
COPY ["modules/TenantManagement/Volo.Abp.TenantManagement.Application/Volo.Abp.TenantManagement.Application.csproj", "modules/TenantManagement/Volo.Abp.TenantManagement.Application/"]
COPY ["src/Mars.HttpApi/Mars.HttpApi.csproj", "src/Mars.HttpApi/"]
COPY ["modules/TenantManagement/Volo.Abp.TenantManagement.HttpApi/Volo.Abp.TenantManagement.HttpApi.csproj", "modules/TenantManagement/Volo.Abp.TenantManagement.HttpApi/"]
COPY ["modules/FeatureManagement/Volo.Abp.FeatureManagement.HttpApi/Volo.Abp.FeatureManagement.HttpApi.csproj", "modules/FeatureManagement/Volo.Abp.FeatureManagement.HttpApi/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.HttpApi/Volo.Abp.Account.HttpApi.csproj", "modules/AccountManagement/Volo.Abp.Account.HttpApi/"]
COPY ["modules/IdentityManagement/Volo.Abp.Identity.HttpApi/Volo.Abp.Identity.HttpApi.csproj", "modules/IdentityManagement/Volo.Abp.Identity.HttpApi/"]
COPY ["modules/PermissionManagement/Volo.Abp.PermissionManagement.HttpApi/Volo.Abp.PermissionManagement.HttpApi.csproj", "modules/PermissionManagement/Volo.Abp.PermissionManagement.HttpApi/"]
COPY ["modules/SettingManagement/Volo.Abp.SettingManagement.HttpApi/Volo.Abp.SettingManagement.HttpApi.csproj", "modules/SettingManagement/Volo.Abp.SettingManagement.HttpApi/"]
RUN dotnet restore "src/Mars.HttpApi.Host/Mars.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Mars.HttpApi.Host"
RUN dotnet build "Mars.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mars.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mars.HttpApi.Host.dll"]
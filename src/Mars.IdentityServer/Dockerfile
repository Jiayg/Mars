#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Mars.IdentityServer/Mars.IdentityServer.csproj", "src/Mars.IdentityServer/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.HttpApi/Volo.Abp.Account.HttpApi.csproj", "modules/AccountManagement/Volo.Abp.Account.HttpApi/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.Application.Contracts/Volo.Abp.Account.Application.Contracts.csproj", "modules/AccountManagement/Volo.Abp.Account.Application.Contracts/"]
COPY ["modules/IdentityManagement/Volo.Abp.Identity.Application.Contracts/Volo.Abp.Identity.Application.Contracts.csproj", "modules/IdentityManagement/Volo.Abp.Identity.Application.Contracts/"]
COPY ["modules/PermissionManagement/Volo.Abp.PermissionManagement.Application.Contracts/Volo.Abp.PermissionManagement.Application.Contracts.csproj", "modules/PermissionManagement/Volo.Abp.PermissionManagement.Application.Contracts/"]
COPY ["modules/IdentityManagement/Volo.Abp.Identity.HttpApi/Volo.Abp.Identity.HttpApi.csproj", "modules/IdentityManagement/Volo.Abp.Identity.HttpApi/"]
COPY ["src/Mars.EntityFrameworkCore/Mars.EntityFrameworkCore.csproj", "src/Mars.EntityFrameworkCore/"]
COPY ["src/Mars.Domain/Mars.Domain.csproj", "src/Mars.Domain/"]
COPY ["src/Mars.Domain.Shared/Mars.Domain.Shared.csproj", "src/Mars.Domain.Shared/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.Application/Volo.Abp.Account.Application.csproj", "modules/AccountManagement/Volo.Abp.Account.Application/"]
COPY ["modules/IdentityManagement/Volo.Abp.Identity.Application/Volo.Abp.Identity.Application.csproj", "modules/IdentityManagement/Volo.Abp.Identity.Application/"]
COPY ["modules/PermissionManagement/Volo.Abp.PermissionManagement.Application/Volo.Abp.PermissionManagement.Application.csproj", "modules/PermissionManagement/Volo.Abp.PermissionManagement.Application/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.Web.IdentityServer/Volo.Abp.Account.Web.IdentityServer.csproj", "modules/AccountManagement/Volo.Abp.Account.Web.IdentityServer/"]
COPY ["modules/AccountManagement/Volo.Abp.Account.Web/Volo.Abp.Account.Web.csproj", "modules/AccountManagement/Volo.Abp.Account.Web/"]
RUN dotnet restore "src/Mars.IdentityServer/Mars.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/Mars.IdentityServer"
RUN dotnet build "Mars.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mars.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mars.IdentityServer.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["service/Ioutility.Franquia.Api/Ioutility.Franquia.Api.csproj", "service/Ioutility.Franquia.Api/"]
COPY ["service/Ioutility.Franquia.Repository/Ioutility.Franquia.Repository.csproj", "service/Ioutility.Franquia.Repository/"]
COPY ["core/Pulsati.Core.Domain/Pulsati.Core.Domain.csproj", "core/Pulsati.Core.Domain/"]
COPY ["service/Ioutility.Franquia.Domain/Ioutility.Franquia.Domain.csproj", "service/Ioutility.Franquia.Domain/"]
COPY ["core/Pulsati.Core.Repository/Pulsati.Core.Repository.csproj", "core/Pulsati.Core.Repository/"]
COPY ["service/Ioutility.Franquia.DI/Ioutility.Franquia.DI.csproj", "service/Ioutility.Franquia.DI/"]
COPY ["core/Pulsati.Core.DI/Pulsati.Core.DI.csproj", "core/Pulsati.Core.DI/"]
COPY ["core/Pulsati.Core.Api/Pulsati.Core.Api.csproj", "core/Pulsati.Core.Api/"]
RUN dotnet restore "service/Ioutility.Franquia.Api/Ioutility.Franquia.Api.csproj"
COPY . .
WORKDIR "/src/service/Pulsati.Ioutility.Cadastro.Api"
RUN dotnet build "Ioutility.Franquia.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ioutility.Franquia.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ioutility.Franquia.Api.dll"]

# executar na pasta da solution
# docker build -t ioutility-cadastro-service .
# docker run -p 5233:80 -e "ASPNETCORE_ENVIRONMENT=Development"  ioutility-cadastro-service
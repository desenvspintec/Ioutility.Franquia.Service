#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["servico/Ioutility.Franquia.Api/Ioutility.Franquias.Api.csproj", "servico/Ioutility.Franquia.Api/"]
COPY ["servico/Ioutility.Franquia.DI/Ioutility.Franquias.DI.csproj", "servico/Ioutility.Franquia.DI/"]
COPY ["core/Pulsati.Core.DI/Pulsati.Core.DI.csproj", "core/Pulsati.Core.DI/"]
COPY ["core/Pulsati.Core.Repository/Pulsati.Core.Repository.csproj", "core/Pulsati.Core.Repository/"]
COPY ["core/Pulsati.Core.Domain/Pulsati.Core.Domain.csproj", "core/Pulsati.Core.Domain/"]
COPY ["servico/Ioutility.Franquias.Repository/Ioutility.Franquias.Repository.csproj", "servico/Ioutility.Franquias.Repository/"]
COPY ["servico/Ioutility.Franquia.Domain/Ioutility.Franquias.Domain.csproj", "servico/Ioutility.Franquia.Domain/"]
COPY ["core/Pulsati.Core.Api/Pulsati.Core.Api.csproj", "core/Pulsati.Core.Api/"]
RUN dotnet restore "servico/Ioutility.Franquia.Api/Ioutility.Franquias.Api.csproj"
COPY . .
WORKDIR "/src/servico/Ioutility.Franquia.Api"
RUN dotnet build "Ioutility.Franquias.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ioutility.Franquias.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ioutility.Franquias.Api.dll"]
# executar na pasta da solution
# docker build -t ioutility-cadastro-service .
# docker run -p 5233:80 -e "ASPNETCORE_ENVIRONMENT=Development"  ioutility-cadastro-service
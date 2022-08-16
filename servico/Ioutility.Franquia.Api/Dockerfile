#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["servico/Ioutility.Franquia.Api/Ioutility.Franquia.Api.csproj", "servico/Ioutility.Franquia.Api/"]
RUN dotnet restore "servico/Ioutility.Franquia.Api/Ioutility.Franquia.Api.csproj"
COPY . .
WORKDIR "/src/servico/Ioutility.Franquia.Api"
RUN dotnet build "Ioutility.Franquia.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ioutility.Franquia.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ioutility.Franquia.Api.dll"]
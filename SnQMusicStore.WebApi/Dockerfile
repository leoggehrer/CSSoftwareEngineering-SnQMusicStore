#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SnQMusicStore.WebApi/SnQMusicStore.WebApi.csproj", "SnQMusicStore.WebApi/"]
COPY ["SnQMusicStore.Logic/SnQMusicStore.Logic.csproj", "SnQMusicStore.Logic/"]
COPY ["SnQMusicStore.Contracts/SnQMusicStore.Contracts.csproj", "SnQMusicStore.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["SnQMusicStore.Transfer/SnQMusicStore.Transfer.csproj", "SnQMusicStore.Transfer/"]
RUN dotnet restore "SnQMusicStore.WebApi/SnQMusicStore.WebApi.csproj"
COPY . .
WORKDIR "/src/SnQMusicStore.WebApi"
RUN dotnet build "SnQMusicStore.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnQMusicStore.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnQMusicStore.WebApi.dll"]

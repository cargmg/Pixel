#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Storage.Api/Storage.Api.csproj", "Storage.Api/"]
COPY ["Storage.Application.Messaging/Storage.Application.Messaging.csproj", "Storage.Application.Messaging/"]
COPY ["Pixel.Events/Pixel.Events.csproj", "Pixel.Events/"]
COPY ["Storage.Application.Services/Storage.Application.Services.csproj", "Storage.Application.Services/"]
COPY ["Storage.Application.Dto/Storage.Application.Dto.csproj", "Storage.Application.Dto/"]
COPY ["Storage.Data/Storage.Data.Repositories.csproj", "Storage.Data/"]
COPY ["Storage.CrossCutting/Storage.CrossCutting.csproj", "Storage.CrossCutting/"]
RUN dotnet restore "Storage.Api/Storage.Api.csproj"
COPY . .
WORKDIR "/src/Storage.Api"
RUN dotnet build "Storage.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Storage.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 9888
ENTRYPOINT ["dotnet", "Storage.Presentation.Api.dll"]
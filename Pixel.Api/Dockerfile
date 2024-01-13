#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pixel.Api/Pixel.Api.csproj", "Pixel.Api/"]
COPY ["Pixel.Api/pixel.gif", "Pixel.Api/"]
COPY ["Pixel.Application.Services/Pixel.Application.Services.csproj", "Pixel.Application.Services/"]
COPY ["Pixel.Application.Dto/Pixel.Application.Dto.csproj", "Pixel.Application.Dto/"]
COPY ["Pixel.Application.Messaging/Pixel.Application.Messaging.csproj", "Pixel.Application.Messaging/"]
COPY ["Pixel.Events/Pixel.Events.csproj", "Pixel.Events/"]
COPY ["Pixel.CrossCutting/Pixel.CrossCutting.csproj", "Pixel.CrossCutting/"]
RUN dotnet restore "Pixel.Api/Pixel.Api.csproj"
COPY . .
WORKDIR "/src/Pixel.Api"
RUN dotnet build "Pixel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pixel.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 9666
ENTRYPOINT ["dotnet", "Pixel.Api.dll"]
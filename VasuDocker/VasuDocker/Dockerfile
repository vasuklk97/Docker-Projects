#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY VasuDocker/VasuDocker/VasuDocker.csproj VasuDocker/
COPY VasuDocker/VasuDocker2/VasuDocker2.csproj VasuDocker2/
RUN dotnet restore "VasuDocker/VasuDocker.csproj"
COPY ./VasuDocker .
RUN dotnet build "VasuDocker/VasuDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VasuDocker/VasuDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VasuDocker.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Telepath.Worker/Telepath.Worker.csproj", "Telepath.Worker/"]
RUN dotnet restore "Telepath.Worker/Telepath.Worker.csproj"
COPY . .
WORKDIR "/src/Telepath.Worker"
RUN dotnet build "Telepath.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Telepath.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Telepath.Worker.dll"]
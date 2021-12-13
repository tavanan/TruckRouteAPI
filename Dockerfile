
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TruckRouteAPI.csproj", "./"]
RUN dotnet restore "./TruckRouteAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TruckRouteAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TruckRouteAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TruckRouteAPI.dll"]
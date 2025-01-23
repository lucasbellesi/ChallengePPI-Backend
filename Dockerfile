FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./ChallengePPI.Backend.csproj"
RUN dotnet build "./ChallengePPI.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ChallengePPI.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengePPI.Backend.dll"]
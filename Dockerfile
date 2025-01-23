# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY . ./

# Restaurar dependencias y compilar
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Etapa 2: Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /out .

# Exponer el puerto de la aplicación
EXPOSE 5000

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "ChallengePPI.Backend.dll"]

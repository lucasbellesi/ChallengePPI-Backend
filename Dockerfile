# Imagen base: Runtime de ASP.NET para producción
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copiar los archivos publicados al contenedor
COPY ./out/ .

# Exponer el puerto interno que la aplicación utiliza
EXPOSE 8080

# Configurar el comando de inicio
ENTRYPOINT ["dotnet", "ChallengePPI.Backend.dll"]

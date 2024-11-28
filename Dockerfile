# 1. Imagen dase de .NET SDK para compilar y ejecutar pruebas
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 2. Directorio de trabajo dentro del contenedor
WORKDIR /app

# 3. Copiar los archivos de la solución y restaurar dependencias
COPY EmployeeWebSiteExample.sln ./
COPY src/ ./src/
# COPY tests/ ./tests/

# Restaurar paquetes de NuGet
RUN dotnet restore

# 4. Construir solución
RUN dotnet build --no-restore -c Release

# 5. Ejecutar pruebas unitarias

# 6. Ejecutar pruebas de integración 

#7. Publicar prouecto Web en carpeta temporal
RUN dotnet publish ./src/EmpleadosWebSiteExample/EmpleadosWebSiteExample.csproj -c Release -o /publish

#8. Imagen base para la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

#9. Directorio de trabajo en el contenedor final
WORKDIR /app

# 10. Copiar archivos piblicados desde la etapa anterior
COPY --from=build /publish .

# 11. Exponer el puerto de aplicación
EXPOSE 80

# 12. Comando para ejecutar l aaplicación
ENTRYPOINT ["dotnet", "EmpleadosWebSiteExample.dll"]

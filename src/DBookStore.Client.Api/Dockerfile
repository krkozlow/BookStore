FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish DBookStore.Client.Api -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/DBookStore.Client.Api/out .

ENTRYPOINT ["dotnet", "DBookStore.Client.Api.dll"]

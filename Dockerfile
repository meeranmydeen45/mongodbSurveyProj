FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o pub

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
EXPOSE 80
COPY --from=build /app/pub .
ENTRYPOINT [ "dotnet", "Survey.Api.Cloud.Core.dll" ]
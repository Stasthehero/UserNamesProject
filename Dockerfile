FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore && dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /publish
COPY --from=build /publish .
EXPOSE 80
ENTRYPOINT [ "dotnet", "UserNamesProject.Api.dll" ]
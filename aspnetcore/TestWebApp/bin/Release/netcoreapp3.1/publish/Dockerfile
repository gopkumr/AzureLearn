FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY . .
ENV ASPNETCORE_URLS "http://+:5000"
ENTRYPOINT ["dotnet", "TestWebApp.dll"]
FROM mcr.microsoft.com/dotnet/core/sdk:latest AS backend-build

WORKDIR /app AS backend-build

COPY . ./

RUN dotnet build

EXPOSE 5000

ENTRYPOINT [ "dotnet", "run" ]

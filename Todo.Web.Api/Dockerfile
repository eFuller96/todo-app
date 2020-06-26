FROM mcr.microsoft.com/dotnet/core/sdk:latest AS backend-build

WORKDIR /app

COPY . ./

RUN dotnet build

EXPOSE 5000

ENTRYPOINT [ "dotnet", "run" ]

# wip
# RUN dotnet publish -o /out

# FROM 
# COPY --from='' ./out 

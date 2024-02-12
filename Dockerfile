FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildbase
WORKDIR /formAPI

COPY . .

RUN dotnet restore
RUN dotnet tool install --version 8.0.1 --global dotnet-ef

ENV PATH="$PATH:/root/.dotnet/tools"

ENV ASPNETCORE_URLS=http://+:5001


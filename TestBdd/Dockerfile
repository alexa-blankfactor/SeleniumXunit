#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestBdd/TestBdd.csproj", "TestBdd/"]
COPY ["SeleniumXUnit/EATestFramework.csproj", "EATestFramework/"]
COPY ["ProductAPI/ProductAPI.csproj", "ProductAPI/"]
RUN dotnet restore "TestBdd/TestBdd.csproj"
COPY . .
WORKDIR "/src/TestBdd"
RUN dotnet build "TestBdd.csproj" -c Release -o /app/build

FROM build AS TestBdd
WORKDIR "/src/TestBdd"
CMD [ "dotnet","test" ]
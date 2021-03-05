#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["RVezy.Test.WebAPI/RVezy.Test.WebAPI.csproj", "RVezy.Test.WebAPI/"]
RUN dotnet restore "RVezy.Test.WebAPI/RVezy.Test.WebAPI.csproj"
COPY . .
WORKDIR "/src/RVezy.Test.WebAPI"
RUN dotnet build "RVezy.Test.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RVezy.Test.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RVezy.Test.WebAPI.dll"]
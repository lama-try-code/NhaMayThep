#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NhaMayThep.Api/NhaMayThep.Api.csproj", "NhaMayThep.Api/"]
COPY ["NhaMapThep.Domain/NhaMapThep.Domain.csproj", "NhaMapThep.Domain/"]
COPY ["NhaMayThep.Application/NhaMayThep.Application.csproj", "NhaMayThep.Application/"]
COPY ["NhaMayThep.Infrastructure/NhaMayThep.Infrastructure.csproj", "NhaMayThep.Infrastructure/"]
RUN dotnet restore "NhaMayThep.Api/NhaMayThep.Api.csproj"
COPY . .
WORKDIR "/src/NhaMayThep.Api"
RUN dotnet build "NhaMayThep.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NhaMayThep.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir -p /app/uploads
VOLUME /app/uploads
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NhaMayThep.Api.dll"]

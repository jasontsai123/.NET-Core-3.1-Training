#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Training2020WithNorthwind.Application/Training2020WithNorthwind.Application.csproj", "Training2020WithNorthwind.Application/"]
COPY ["Training2020WithNorthwind.Service/Training2020WithNorthwind.Service.csproj", "Training2020WithNorthwind.Service/"]
COPY ["Training2020WithNorthwind.Repository/Training2020WithNorthwind.Repository.csproj", "Training2020WithNorthwind.Repository/"]
COPY ["Training2020WithNorthwind.Common/Training2020WithNorthwind.Common.csproj", "Training2020WithNorthwind.Common/"]
RUN dotnet restore "Training2020WithNorthwind.Application/Training2020WithNorthwind.Application.csproj"
COPY . .
WORKDIR "/src/Training2020WithNorthwind.Application"
RUN dotnet build "Training2020WithNorthwind.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Training2020WithNorthwind.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Training2020WithNorthwind.Application.dll"]
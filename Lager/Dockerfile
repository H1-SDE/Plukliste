#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Lager/Lager.csproj", "./"]
COPY ["./Lager_dal/Lager_dal.csproj", "/Lager_dal/Lager_dal.csproj"]
RUN dotnet restore "Lager.csproj"
COPY "./Lager" .
COPY "./Lager_dal" .
WORKDIR "./"
RUN dotnet build "Lager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lager.dll"]
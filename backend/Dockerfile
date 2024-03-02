FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Int20h.WebApi/Int20h.WebApi.csproj", "./Int20h.WebApi/"]
COPY ["./Int20h.Common/Int20h.Common.csproj", "./Int20h.Common/"]
COPY ["./Int20h.BLL/Int20h.BLL.csproj", "./Int20h.BLL/"]
COPY ["./Int20h.DAL/Int20h.DAL.csproj", "./Int20h.DAL/"]

RUN dotnet restore "./Int20h.WebApi/Int20h.WebApi.csproj"
COPY . .
WORKDIR "/src/Int20h.WebApi"
RUN dotnet build "Int20h.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Int20h.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_HTTP_PORTS 80
ENTRYPOINT ["dotnet", "Int20h.WebApi.dll"]
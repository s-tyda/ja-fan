FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ja-fan/ja-fan.csproj", "ja-fan/"]
RUN dotnet restore "ja-fan/ja-fan.csproj"
COPY . .
WORKDIR "/src/ja-fan"
RUN dotnet build "ja-fan.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ja-fan.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ja-fan.dll"]

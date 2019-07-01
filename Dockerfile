FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Gcloud.Api/Gcloud.Api.csproj", "src/Gcloud.Api/"]
RUN dotnet restore "src/Gcloud.Api/Gcloud.Api.csproj"
COPY . .
WORKDIR "/src/src/Gcloud.Api"
RUN dotnet build "Gcloud.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gcloud.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gcloud.Api.dll"]

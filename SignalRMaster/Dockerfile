FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /signalr_master
COPY . .
RUN dotnet restore

WORKDIR /signalr_master/
RUN dotnet publish -c Release -o /signalr_master/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /signalr_master/publish
COPY --from=build /signalr_master/publish ./
ENTRYPOINT ["dotnet", "SignalRMaster.dll"]
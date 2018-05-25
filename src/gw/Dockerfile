FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY cNeuro.ApiGateway.csproj .
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
RUN dotnet build -c Release -o /dist

FROM build AS publish
RUN dotnet publish -c Release -o /dist

FROM microsoft/aspnetcore-build:2.0
WORKDIR /dist
COPY --from=publish /dist .
EXPOSE 80
ENTRYPOINT ["dotnet", "cNeuro.ApiGateway.dll"]

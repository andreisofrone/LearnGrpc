#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Grpc/Grpc.csproj", "Grpc/"]
RUN dotnet restore "Grpc/Grpc.csproj"
COPY . .
WORKDIR "/src/Grpc"
RUN dotnet build "Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Grpc.csproj" -c Release -o /app/publish

EXPOSE 5003

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Grpc.dll"]

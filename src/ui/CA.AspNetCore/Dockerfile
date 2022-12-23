#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ui/CA.AspNetCore/CA.AspNetCore.csproj", "src/ui/CA.AspNetCore/"]
RUN dotnet restore "src/ui/CA.AspNetCore/CA.AspNetCore.csproj"
COPY . .
WORKDIR "/src/src/ui/CA.AspNetCore"
RUN dotnet build "CA.AspNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CA.AspNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CA.AspNetCore.dll"]
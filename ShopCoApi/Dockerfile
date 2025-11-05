# Giai ?o?n 1: Build ?ng d?ng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy file .sln (n?u c?) v? c?c file .csproj
# ?i?u n?y gi?p t?i ?u h?a Docker layer caching
COPY ["ShopCoApi.sln", "."]
COPY ["ShopCoApi/ShopCoApi.csproj", "ShopCoApi/"]
# N?u c? c?c project kh?c, v? d? Class Library, h?y copy c? ch?ng
# COPY ["ShopCo.Core/ShopCo.Core.csproj", "ShopCo.Core/"]

# Ch?y restore cho project c? th?
RUN dotnet restore "ShopCoApi/ShopCoApi.csproj"

# Copy to?n b? m? ngu?n c?n l?i
COPY . .

# Build project
WORKDIR "/src/ShopCoApi"
RUN dotnet build "ShopCoApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Giai ?o?n 2: Publish ?ng d?ng
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShopCoApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Giai ?o?n 3: T?o image cu?i c?ng ?? ch?y
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopCoApi.dll"]
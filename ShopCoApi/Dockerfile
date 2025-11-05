# Giai ?o?n 1: Build ?ng d?ng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# V? build context ?? l? 'ShopCoApi', c?c file n?y n?m ngay ? th? m?c g?c c?a context.
COPY ["ShopCoApi.csproj", "."]

# Ch?y restore
RUN dotnet restore "./ShopCoApi.csproj"

# Copy to?n b? m? ngu?n (t? context 'ShopCoApi') v?o th? m?c /src trong image
COPY . .
WORKDIR "/src/"
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
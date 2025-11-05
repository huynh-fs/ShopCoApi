# Giai ?o?n 1: Build ?ng d?ng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy c?c file project. ???ng d?n ???c t?nh t? th? m?c g?c c?a repo (build context).
COPY ["ShopCoApi/ShopCoApi.csproj", "ShopCoApi/"]

# Ch?y restore cho project c? th?
RUN dotnet restore "ShopCoApi/ShopCoApi.csproj"

# Copy to?n b? m? ngu?n c?n l?i
COPY . .

# ??t th? m?c l?m vi?c l? th? m?c c?a project API
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
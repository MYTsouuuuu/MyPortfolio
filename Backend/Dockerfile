# --- 第一階段：建置 (Build Stage) ---
# 使用含有 .NET SDK 的映像檔來編譯程式碼
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 先複製 .csproj 檔案並還原套件 (利用 Docker 快取機制)
COPY ["PortfolioApi.csproj", "./"]
RUN dotnet restore "PortfolioApi.csproj"

# 複製其餘程式碼並進行發布
COPY . .
RUN dotnet publish "PortfolioApi.csproj" -c Release -o /app/publish

# --- 第二階段：執行 (Runtime Stage) ---
# 使用輕量級的 Runtime 映像檔來執行 (不含 SDK，體積較小)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# 開放 8080 Port (這是 .NET 10 容器預設 Port)
EXPOSE 8080

# 設定容器啟動時執行的指令
ENTRYPOINT ["dotnet", "PortfolioApi.dll"]
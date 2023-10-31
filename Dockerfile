# Sử dụng image có chứa .NET SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

# Copy mã nguồn vào thư mục /app trong container
COPY . ./

# Build ứng dụng
RUN dotnet publish -c Release -o out

# Chuyển sang image ASP.NET Core Runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .

# Chạy ứng dụng khi container được khởi động
ENTRYPOINT ["dotnet", "MvcMusic.dll"]

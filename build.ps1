Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

Write-Host "=== Banking Transaction System Build Script ===" -ForegroundColor Cyan

Write-Host ""
Write-Host ">>> Restoring dependencies..." -ForegroundColor Yellow
dotnet restore

Write-Host ""
Write-Host ">>> Building Debug..." -ForegroundColor Yellow
dotnet build --configuration Debug --no-restore

Write-Host ""
Write-Host ">>> Building Release..." -ForegroundColor Yellow
dotnet build --configuration Release --no-restore

Write-Host ""
Write-Host ">>> Running tests with coverage..." -ForegroundColor Yellow
dotnet test --no-build --collect:"XPlat Code Coverage"

Write-Host ""
Write-Host "=== Build completed successfully ===" -ForegroundColor Green

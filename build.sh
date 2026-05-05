#!/bin/bash
set -e

echo "=== Banking Transaction System Build Script ==="

echo ""
echo ">>> Restoring dependencies..."
dotnet restore

echo ""
echo ">>> Building Debug..."
dotnet build --configuration Debug --no-restore

echo ""
echo ">>> Building Release..."
dotnet build --configuration Release --no-restore

echo ""
echo ">>> Running tests with coverage..."
dotnet test --no-build --collect:"XPlat Code Coverage"

echo ""
echo "=== Build completed successfully ==="

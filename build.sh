#! /bin/bash

MODE=${1:-Debug}
NAME=$(basename $(ls *.sln | head -n 1) .sln)

dotnet build --configuration $MODE

find ./src -iname "*.Tests.csproj" -type f -exec \
  dotnet test --configuration $MODE --no-build --no-restore "{}" \;

dotnet publish \
  --configuration $MODE --no-build --no-restore \
  --runtime linux-x64 \
  --output publish

find ./src -iname "Dockerfile" -exec ./docker.sh {} \;
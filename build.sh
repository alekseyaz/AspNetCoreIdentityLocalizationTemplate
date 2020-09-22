#!/bin/bash

set -e

dotnet --info
dotnet --list-sdks
dotnet restore

echo "🤖 Attempting to build..."
for path in src/*.csproj; do
    dotnet pack -c Release ${path} -o ..\artifacts
done

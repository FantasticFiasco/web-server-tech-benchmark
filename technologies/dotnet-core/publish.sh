#!/bin/bash
dotnet restore
dotnet publish -c Release -o dist

docker build -t fantasticfiasco/web-server-benchmark-dotnet-core:latest .
docker push fantasticfiasco/web-server-benchmark-dotnet-core:latest
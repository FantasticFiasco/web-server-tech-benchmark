# Web Server Technology Benchmark - .NET Core

## Usage

Restore NuGet packages
```
dotnet restore
```

Run application
```
dotnet run
```

Publish application
```
dotnet publish -c Release -o dist
```

Build Docker image
```
docker build -t fantasticfiasco/web-server-benchmark-dotnet-core:latest .
```

Start container
```
docker run -it --rm -P fantasticfiasco/web-server-benchmark-dotnet-core:latest
```

Push container
```
docker push fantasticfiasco/web-server-benchmark-dotnet-core:latest
```

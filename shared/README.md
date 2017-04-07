# Web Server Technology Benchmark - Shared Service

## Usage

Get dependencies
```
go get github.com/julienschmidt/httprouter
```

Build application
```
go build
```

Build Docker image
```
docker build -t fantasticfiasco/web-server-benchmark-shared:latest .
```

Start container
```
docker run -it --rm -P fantasticfiasco/web-server-benchmark-shared
```

Push container
```
docker push fantasticfiasco/web-server-benchmark-shared:latest
```

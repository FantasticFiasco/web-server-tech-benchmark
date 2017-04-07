# Web Server Technology Benchmark - Go

## Usage

Get dependencies
```
go get github.com/julienschmidt/httprouter
go get github.com/lib/pq
```

Build application
```
go build
```

Build Docker image
```
docker build -t fantasticfiasco/web-server-benchmark-go:latest .
```

Start container
```
docker run -it --rm -P fantasticfiasco/web-server-benchmark-go
```

Push container
```
docker push fantasticfiasco/web-server-benchmark-go:latest
```

# Web Server Technology Benchmark - Clojure

## Usage

Run application
```
lein run
```

Build Docker image
```
docker build -t fantasticfiasco/web-server-benchmark-clojure:latest .
```

Start container
```
docker run -it --rm -P fantasticfiasco/web-server-benchmark-clojure:latest
```

Push container
```
docker push fantasticfiasco/web-server-benchmark-clojure:latest
```
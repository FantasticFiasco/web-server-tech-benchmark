# Web Server Technology Benchmark - Clojure

## Usage

Run application
```
lein run
```

Build Docker image
```
docker build -t mcloone/web-server-benchmark-clojure:latest .
```

Start container
```
docker run -it --rm -P mcloone/web-server-benchmark-clojure
```

Push container
```
docker push mcloone/web-server-benchmark-clojure:latest
```
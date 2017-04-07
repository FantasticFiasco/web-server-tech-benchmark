# Web Server Technology Benchmark - NodeJS

## Usage

Restore packages
```
npm install
```

Run application
```
npm start
```

Build Docker image
```
docker build -t fantasticfiasco/web-server-benchmark-nodejs:latest .
```

Start container
```
docker run -it --rm -P fantasticfiasco/web-server-benchmark-nodejs:latest
```

Push container
```
docker push fantasticfiasco/web-server-benchmark-nodejs:latest
```

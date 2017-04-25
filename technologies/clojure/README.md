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

The environment variables to be set are (colon is not valid in a variable in Linux):
Contacts_DatabaseHost
Contacts_DatabaseName
Contacts_DatabaseUsername
Contacts_DatabasePassword
Relay_KeyValueServiceHostname
Relay_KeyValueServicePort

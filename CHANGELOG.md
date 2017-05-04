# Change Log

All notable changes to this project will be documented in this file.

This project adheres to [Semantic Versioning](http://semver.org/) and is following the [change log format](http://keepachangelog.com/).

## 2.0.0 2017-05-04

### Changed

- EC2 instance types changed from t2.micro to m3.medium for improved stability
- The same EC2 instance was targeted indifferent of benchmarked technology
- Instead of showing individual graphs for each technology, all technologies are compared within the same graph

### Added

- Benchmarks for programming language Clojure (contribution by [McLoone](https://github.com/McLoone))

## 1.1.0 2017-04-18

### Changed

- [Relay Benchmark] The HTTP API of the key/value service has changed. Its response format no longer matches the response format of the relay service, forcing the relay service to deserialize and serialize data. This pattern of reformatting the response is better aligned with how services would consume data from other services.

## 1.0.0 2017-04-17

Initial version.
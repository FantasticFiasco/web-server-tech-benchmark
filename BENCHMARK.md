# Benchmark

## Test Driver

The system driving the benchmark is a desktop computer connected to a wired network.

| Parameter             | Value                        |
| --------------------- | ---------------------------- |
| OS                    | Windows 10 Pro               |
| Processor             | Intel Core i5 750 @ 2.67 GHz |
| System type           | x64                          |
| Installed memory (GB) | 8                            |
| Download speed (Mbps) | 84                           |
| Upload speed (Mbps)   | 92                           |

## System Under Test

All benchmarks are targeting a web server running in a Docker container on a EC2 instace in Amazon Web Services (AWS).

| Parameter              | Value               |
| ---------------------- | ------------------- |
| AWS region             | eu-west-1 (Ireland) |
| EC2 instance type      | t2.micro            |
| CPU units              | 512                 |
| Hard memory limit (MB) | 512                 |

## Duration And Threads

Every benchmark is designed to run for 300 seconds. A benchmark starts with one thread and then continuously creates a new thread every second. This means that at the end of the benchmark the web server is handling 300 concurrent requests. This linear load ramp up will hopefully show the performant range of the web server, and at what point it starts to struggle.

## Results

### Health

| Technology | Error     | Average Response Time (ms) | 90th Percentile (ms) | 95th Percentile (ms) | 99th Percentile (ms) | Throughput  |
| ---------- | --------- | -------------------------- | -------------------- | -------------------- | -------------------- | ----------- |
| .NET Core  | __0.00%__ | 33.77                      | 39                   | 42                   | __69__               | 4445.11     |
| Go         | __0.00%__ | __33.13__                  | __35__               | __37__               | 70                   | __4530.46__ |
| NodeJS     | __0.00%__ | 34.81                      | 44                   | 48                   | 82                   | 4312.82     |

#### Response Time Over Threads

##### .NET Core

![.NET Core Response Time Over Threads](./results/dotnet-core/health/flotTimesVsThreads.png)

##### Go

![Go Response Time Over Threads](./results/go/health/flotTimesVsThreads.png)

##### NodeJS

![NodeJS Response Time Over Threads](./results/nodejs/health/flotTimesVsThreads.png)

#### Response Times Over Time

##### .NET Core

![.NET Core Response Time Over Time](./results/dotnet-core/health/flotResponseTimesOverTime.png)

##### Go

![Go Response Time Over Time](./results/go/health/flotResponseTimesOverTime.png)

##### NodeJS

![NodeJS Response Time Over Time](./results/nodejs/health/flotResponseTimesOverTime.png)

#### Hits Per Second

##### .NET Core

![.NET Core Hits Per Second](./results/dotnet-core/health/flotHitsPerSecond.png)

##### Go

![Go Hits Per Second](./results/go/health/flotHitsPerSecond.png)

##### NodeJS

![NodeJS Hits Per Second](./results/nodejs/health/flotHitsPerSecond.png)

### Echo

| Technology | Error     | Average Response Time (ms) | 90th Percentile (ms) | 95th Percentile (ms) | 99th Percentile (ms) | Throughput  |
| ---------- | --------- | -------------------------- | -------------------- | -------------------- | -------------------- | ----------- |
| .NET Core  | __0.00%__ | 38.73                      | 55                   | 57                   | 84                   | 3792.15     |
| Go         | __0.00%__ | __33.37__                  | __35__               | __38__               | __69__               | __4473.00__ |
| NodeJS     | __0.00%__ | 38.58                      | 56                   | 66                   | 114                  | 3887.36     |

#### Response Time Over Threads

##### .NET Core

![.NET Core Response Time Over Threads](./results/dotnet-core/echo/flotTimesVsThreads.png)

##### Go

![Go Response Time Over Threads](./results/go/echo/flotTimesVsThreads.png)

##### NodeJS

![NodeJS Response Time Over Threads](./results/nodejs/echo/flotTimesVsThreads.png)

#### Response Times Over Time

##### .NET Core

![.NET Core Response Time Over Time](./results/dotnet-core/echo/flotResponseTimesOverTime.png)

##### Go

![Go Response Time Over Time](./results/go/echo/flotResponseTimesOverTime.png)

##### NodeJS

![NodeJS Response Time Over Time](./results/nodejs/echo/flotResponseTimesOverTime.png)

#### Hits Per Second

##### .NET Core

![.NET Core Hits Per Second](./results/dotnet-core/echo/flotHitsPerSecond.png)

##### Go

![Go Hits Per Second](./results/go/echo/flotHitsPerSecond.png)

##### NodeJS

![NodeJS Hits Per Second](./results/nodejs/echo/flotHitsPerSecond.png)

### Relay

| Technology | Error     | Average Response Time (ms) | 90th Percentile (ms) | 95th Percentile (ms) | 99th Percentile (ms) | Throughput  |
| ---------- | --------- | -------------------------- | -------------------- | -------------------- | -------------------- | ----------- |
| .NET Core  | __0.00%__ | 69.56                      | 134                  | 141                  | __159__              | 2160.11     |
| Go         | 0.01%     | __50.83__                  | __57__               | __67__               | 3081                 | __2908.68__ |
| NodeJS     | __0.00%__ | 119.25                     | 280                  | 324                  | 363                  | 1261.04     |

#### Response Time Over Threads

##### .NET Core

![.NET Core Response Time Over Threads](./results/dotnet-core/relay/flotTimesVsThreads.png)

##### Go

![Go Response Time Over Threads](./results/go/relay/flotTimesVsThreads.png)

##### NodeJS

![NodeJS Response Time Over Threads](./results/nodejs/relay/flotTimesVsThreads.png)

#### Response Times Over Time

##### .NET Core

![.NET Core Response Time Over Time](./results/dotnet-core/relay/flotResponseTimesOverTime.png)

##### Go

![Go Response Time Over Time](./results/go/relay/flotResponseTimesOverTime.png)

##### NodeJS

![NodeJS Response Time Over Time](./results/nodejs/relay/flotResponseTimesOverTime.png)

#### Hits Per Second

##### .NET Core

![.NET Core Hits Per Second](./results/dotnet-core/relay/flotHitsPerSecond.png)

##### Go

![Go Hits Per Second](./results/go/relay/flotHitsPerSecond.png)

##### NodeJS

![NodeJS Hits Per Second](./results/nodejs/relay/flotHitsPerSecond.png)

### Contacts

The benchmarks have been run against a database pre-populated with 1,000,000 contacts.

| Technology | Error     | Average Response Time (ms) | 90th Percentile (ms) | 95th Percentile (ms) | 99th Percentile (ms) | Throughput  |
| ---------- | --------- | -------------------------- | -------------------- | -------------------- | -------------------- | ----------- |
| .NET Core  | __0.00%__ | __70.49__                  | __132__              | __142__              | __163__              | __2129.40__ |
| Go         | __0.00%__ | 248.14                     | 951                  | 1016                 | 606.16               | 592.79      |
| NodeJS     | __0.00%__ | 80.74                      | 176                  | 204                  | 239                  | 1861.20     |

#### Response Time Over Threads

##### .NET Core

![.NET Core Response Time Over Threads](./results/dotnet-core/contacts/flotTimesVsThreads.png)

##### Go

![Go Response Time Over Threads](./results/go/contacts/flotTimesVsThreads.png)

##### NodeJS

![NodeJS Response Time Over Threads](./results/nodejs/contacts/flotTimesVsThreads.png)

#### Response Times Over Time

##### .NET Core

![.NET Core Response Time Over Time](./results/dotnet-core/contacts/flotResponseTimesOverTime.png)

##### Go

![Go Response Time Over Time](./results/go/contacts/flotResponseTimesOverTime.png)

##### NodeJS

![NodeJS Response Time Over Time](./results/nodejs/contacts/flotResponseTimesOverTime.png)

#### Hits Per Second

##### .NET Core

![.NET Core Hits Per Second](./results/dotnet-core/contacts/flotHitsPerSecond.png)

##### Go

![Go Hits Per Second](./results/go/contacts/flotHitsPerSecond.png)

##### NodeJS

![NodeJS Hits Per Second](./results/nodejs/contacts/flotHitsPerSecond.png)

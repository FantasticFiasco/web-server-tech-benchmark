# Comparison

## System Driving Load Test

The system driving the load test is a desktop computer connected to a wired network.

| Parameter             | Value                        |
| --------------------- | ---------------------------- |
| OS                    | Windows 10 Pro               |
| Processor             | Intel Core i5 750 @ 2.67 GHz |
| System type           | x64                          |
| Installed memory (GB) | 8.00                         |
| Download speed (Mbps) | 88                           |
| Upload speed (Mbps)   | 93                           |

## System Under Test

All load tests have targeted a web server running in a Docker container on a EC2 instace in Amazon Web Services (AWS).

| Parameter              | Value               |
| ---------------------- | ------------------- |
| AWS region             | eu-west-1 (Ireland) |
| EC2 instance type      | t2.micro            |
| CPU units              | 512                 |
| Hard memory limit (MB) | 512                 |

## Results

### Echo

#### Response Time Over Threads
![Response time over threads](./results/dotnet-core/echo/TimesVsThreads.png)

#### Response Time Over Time
![Response time over time](./results/dotnet-core/echo/ResponseTimesOverTime.png)

#### Response Time Distribution
![Response time distribution](./results/dotnet-core/echo/ResponseTimesDistribution.png)

#### Latencies Over Time
![Latencies over time](./results/dotnet-core/echo/LatenciesOverTime.png)

#### Throughput Over Threads
![Throughput over threads](./results/dotnet-core/echo/ThroughputVsThreads.png)

### Relay

#### Response Time Over Threads
![Response time over threads](./results/dotnet-core/relay/TimesVsThreads.png)

#### Response Time Over Time
![Response time over time](./results/dotnet-core/relay/ResponseTimesOverTime.png)

#### Response Time Distribution
![Response time distribution](./results/dotnet-core/relay/ResponseTimesDistribution.png)

#### Latencies Over Time
![Latencies over time](./results/dotnet-core/relay/LatenciesOverTime.png)

#### Throughput Over Threads
![Throughput over threads](./results/dotnet-core/relay/ThroughputVsThreads.png)

### Contacts

The load test has been run against a database pre-populated with 1,000,000 contacts.

#### Response Time Over Threads
![Response time over threads](./results/dotnet-core/contacts/TimesVsThreads.png)

#### Response Time Over Time
![Response time over time](./results/dotnet-core/contacts/ResponseTimesOverTime.png)

#### Response Time Distribution
![Response time distribution](./results/dotnet-core/contacts/ResponseTimesDistribution.png)

#### Latencies Over Time
![Latencies over time](./results/dotnet-core/contacts/LatenciesOverTime.png)

#### Throughput Over Threads
![Throughput over threads](./results/dotnet-core/contacts/ThroughputVsThreads.png)
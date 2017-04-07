# Workbench

## Introduction

This directory contain files used when load testing the application on the web server.

[jMeter](http://jmeter.apache.org/) is running the load tests and `LoadTest.jmx` is a pre-configured file to test the following aspects of the application running on the web server:

- Echo
- Relay
- Contacts

## Prerequisites

1. Download and unpack [jMeter](https://drive.google.com/file/d/0B0opfJpdbO8fcDh4UlFFVVdCTFk)
1. Unpack jMeter
1. Add the jMeter `bin` directory as an environment variable

## Edit load test

Run the following from a command prompt in this directory:

```bash
jmeter -t LoadTest.jmx
```

## Run load test

Run the following from a command prompt in this directory:

```bash
jmeter -n -t LoadTest.jmx -Jhostname=[HOSTNAME] -Jport=[PORT]
```

where `[HOSTNAME]` and `[PORT]` points to the web server.

After a run, the results can be found in a sub-directory called `results`.


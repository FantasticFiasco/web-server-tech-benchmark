# Workbench

## Introduction

This directory contain files used when load testing the application on the web server.

[jMeter](http://jmeter.apache.org/) is running the load tests and `LoadTest.jmx` is a pre-configured file to test the following aspects of the application running on the web server:

- Health
- Echo
- Relay
- Contacts

## Prerequisites

1. Download a preconfigured version of [jMeter](https://drive.google.com/open?id=0B0opfJpdbO8fYXlLbFhzMFpTSTA)
1. Unpack jMeter
1. Add the jMeter `bin` directory to the environment variables

## Edit Load Test

Run the following from a command prompt in this directory:

```bash
jmeter -t LoadTest.jmx
```

## Run Load Test

Run the following from a command prompt in this directory:

```bash
jmeter -n -t LoadTest.jmx -Jhostname="[HOSTNAME]" -Jport="[PORT]"
```

where `[HOSTNAME]` and `[PORT]` points to the web server.

After a run, the results can be found in a sub-directory called `results`.
# Web Server Technology Benchmark

## Introduction

This project is focused on comparing the performance of web servers implemented in a small subset of programming languages. The project currently has benchmarks for:

- .NET Core
- Go
- NodeJS

A comparison between languages can be found [here](./BENCHMARK.md).

## Web Server

The HTTP API of the web server is defined in the following chapters, and the benchmark will run each of these API aspects in sequence.

## Health Benchmark

Route returning empty responses back to the client. This benchmark is focused on determining the performance of the web server and its efficiency in handling the request and response pipeline.

![Health benchmark UML](https://g.gravizo.com/source/custom_health_uml?https%3A%2F%2Fraw.githubusercontent.com%2FFantasticFiasco%2Fweb-server-tech-benchmark%2Fmaster%2Fdesign%2FUML.md)

### Health Service

The following HTTP API should be implemented by the web server.

#### Request

```
GET /health HTTP/1.1
```

#### Response

```
204 No Content
```

## Echo Benchmark

Route echoing a text back to the client. This benchmark is focused on reading incoming requests and return responses based on the parameters in the request URI.

![Echo benchmark UML](https://g.gravizo.com/source/custom_echo_uml?https%3A%2F%2Fraw.githubusercontent.com%2FFantasticFiasco%2Fweb-server-tech-benchmark%2Fmaster%2Fdesign%2FUML.md)

### Echo Service

The following HTTP API should be implemented by the web server.

#### Request

```
GET /echo/{text} HTTP/1.1
```

#### Response

```
200 OK
Content-Type: text/plain

{text}
```

## Relay Benchmark

Route acting as a relay between a client and another service on the network. This benchmark reads URI parameters, i.e. keys, from incoming requests, passes the keys on to a key/value service, and then responds with the keys and their values to the client. It highlights latency penalties associated with service dependencies.

![Relay benchmark UML](https://g.gravizo.com/source/custom_relay_uml?https%3A%2F%2Fraw.githubusercontent.com%2FFantasticFiasco%2Fweb-server-tech-benchmark%2Fmaster%2Fdesign%2FUML.md)

### Key/Value Service

The key/value service is already implemented, and has the following HTTP API.

#### Request

```
GET /store/{key} HTTP/1.1
```

#### Response

```
200 OK
Content-Type: application/json

{
    "key": "{key}",
    "value": "{value}"
}
```

### Relay Service

The following HTTP API should be implemented by the web server. 

#### Environment Variables

The relay service is dependent on the key/value service, and the implementation of the relay service should expect that the following environment variables are set.

| Name                          | Description                                         |
| ----------------------------- | --------------------------------------------------- |
| Relay:KeyValueServiceHostname | The hostname or IP address of the key/value service |
| Relay:KeyValueServicePort     | The port of the key/value service                   |

#### Request

```
GET /relay/{key} HTTP/1.1
```

The key should be used in a request to the key/value service.

#### Response

```
200 OK
Content-Type: application/json

{
    "key": "{key}",
    "value": "{value}"
}
```

## Contacts Benchmark

Routes describing a standard CRUD application that stores its state in a PostgreSQL database. This benchmark is focused on database operations, and highlights the latency penalties associated with using a database.

![Contacts benchmark UML](https://g.gravizo.com/source/custom_contacts_uml?https%3A%2F%2Fraw.githubusercontent.com%2FFantasticFiasco%2Fweb-server-tech-benchmark%2Fmaster%2Fdesign%2FUML.md)

### Database

The database has the following schema.

```
CREATE TABLE contact
(
  id integer NOT NULL DEFAULT nextval('contact_id_seq'::regclass),
  firstname character varying,
  surname character varying,
  CONSTRAINT contact_pkey PRIMARY KEY (id)
)
```

### Contacts Service

The following HTTP API should be implemented by the web server. 

#### Environment Variables

The contacts service is dependent on a database, and the implementation of the service should expect that the following environment variables are set.

| Name                      | Description                                       |
| ------------------------- | ------------------------------------------------- |
| Contacts:DatabaseHost     | The host of the database                          |
| Contacts:DatabaseName     | The name of the database                          |
| Contacts:DatabaseUsername | The username used when connecting to the database |
| Contacts:DatabasePassword | The password used when connecting to the database |

#### Create Contact Request

```
POST /contacts HTTP/1.1
Content-Type: application/json

{
    "firstName": "{firstName}",
    "surname": "{surname}"
}
```

#### Create Contact Response

```
201 Created
Content-Type: application/json
Location: http://{hostname}:{port}/contacts/{id}

{
    "id": {id},
    "firstName": "{firstName}",
    "surname": "{surname}"
}
```

#### Get Contact Request

```
GET /contacts/{id} HTTP/1.1
```

#### Get Contact Response

```
200 OK
Content-Type: application/json

{
    "id": {id},
    "firstName":"{firstName}",
    "surname":"{surname}"
}
```

#### Get Contacts Request

```
GET /contacts HTTP/1.1
```

#### Get Contacts Response

```
200 OK
Content-Type: application/json

[
    {
        "id": {id},
        "firstName":"{firstName}",
        "surname":"{surname}"
    }
]
```

#### Remove Contact Request

```
DELETE /contacts/{id} HTTP/1.1
```

#### Remove Contact Response

```
204 No Content
```
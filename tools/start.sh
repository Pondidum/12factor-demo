#! /bin/bash

# Setup containers

docker run \
    -d --rm \
    --name twelve_consul \
    -p 8600:8600 \
    -p 8500:8500 \
    -p 8300:8300 \
    -e CONSUL_UI_BETA=1 \
    -e CONSUL_BIND_INTERFACE=eth0 \
    consul

docker run \
    -d --rm \
    --name twelve_postgres \
    -p 5432:5432 \
    -e 'POSTGRES_PASSWORD=postgres' \
    postgres:alpine


# add required data

curl \
    -X PUT \
    --data 'host=localhost;port=5432;database=postgres;user id=postgres;password=postgres' \
    localhost:8500/v1/kv/appsettings/twelve/PostgresConnection

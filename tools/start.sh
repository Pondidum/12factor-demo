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

# add required data
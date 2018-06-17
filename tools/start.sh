#! /bin/bash

# Setup containers

TOOLS_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

MSYS_NO_PATHCONV=1 docker run \
    -d --rm \
    --name twelve_elk \
    -p 5044:5044 \
    -p 5601:5601 \
    -p 9200:9200 \
    -v $TOOLS_DIR/logstash/app.conf:/etc/logstash/conf.d/app.conf \
    sebp/elk

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
    -s \
    --data 'host=localhost;port=5432;database=postgres;user id=postgres;password=postgres' \
    localhost:8500/v1/kv/appsettings/twelve/PostgresConnection

counter=0
while [ ! "$(curl http://localhost:5601 2> /dev/null)" -a $counter -lt 30  ]; do
    sleep 5
    ((counter++))
    echo "waiting for Kibana to be up ($counter/30)"
done

# configure elasticsearch and kibana
$TOOLS_DIR/filebeat/filebeat.exe setup -c $TOOLS_DIR/filebeat/init.yml

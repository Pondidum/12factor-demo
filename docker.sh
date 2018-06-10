#! /bin/bash

pushd $(dirname $1) > /dev/null

NAME=$(basename $(ls *.csproj | head -n 1 | tr '[:upper:]' '[:lower:]') .csproj)

docker build -t $NAME .

popd > /dev/null
#!/bin/bash
# MSYS_NO_PATHCONV=1
filename=$1 # ex:   index.adoc
root=$(pwd)

DOCKER=$(which /usr/bin/podman || echo docker)

$DOCKER run --rm \
  -v ${root}/doc:/document \
  yozian/docker-asciidoctor-pdf \
  "/document/${filename}"

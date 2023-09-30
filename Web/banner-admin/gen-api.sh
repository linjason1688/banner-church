#!/bin/bash

DOCKER=$(which /usr/bin/podman || echo docker)

sed(){

  case "${OSTYPE}" in
  # osx
  darwin*)
    command sed '' "$@"
    ;;
  *)
    command sed "$@"
    ;;
  esac
}

# in windows IDE integrated env docker volume may not working... try use the following cmd
# MSYS_NO_PATHCONV=1 sh gen-api.sh
gen_api() {
  swaggerJsonUrl=""
  folder="impl"

  # if [ -n "$1" ]; then
  #   output=$1
  # fi

  if [ -n "$1" ]; then
    swaggerJsonUrl=$1
  fi

  if [ -n "$2" ]; then
    folder=$2
  fi

  output="src/api/${folder}"

  echo "output: ${output}"

  # current version
  echo "fetch api schema from : ${swaggerJsonUrl}"

  $DOCKER run --rm -v "${PWD}/${output}:/local" openapitools/openapi-generator-cli:v5.3.0 \
    generate -i ${swaggerJsonUrl} \
    -g typescript-axios \
    -o /local \
    --skip-validate-spec \
    --additional-properties supportsES6=true \
    --additional-properties withInterfaces=true

  # remove files
  cd "${PWD}/${output}"
  rm -rf .openapi-generator \
    .gitignore \
    .openapi-generator-ignore \
    git_push.sh

  cd -

  # generation doc
  echo "generation doc..."

  $DOCKER run --rm -v "${PWD}/doc/${folder}:/local" openapitools/openapi-generator-cli:v5.3.0 \
    generate -i ${swaggerJsonUrl} \
    -g asciidoc \
    -o /local \
    --skip-validate-spec

  cd "${PWD}/doc/${folder}"
  rm -rf .openapi-generator \
    .gitignore \
    .openapi-generator-ignore
  cd -

  #
  echo "post processing files..."

  # making some changes to api

  echo "running os : ${OSTYPE}"

  apiFile="${PWD}/${output}/api.ts"

  sed -i 's/AxiosPromise,//g' "${apiFile}"
  sed -i 's/AxiosPromise</Promise</g' "${apiFile}"
  #
}
##

host=$1

if [ -z "${host}" ]; then
  host="http://host.docker.internal:5000"
  echo "use default host: ${host}"
fi

managementUrl=${host}/swagger/management/swagger.json
featureUrl=${host}/swagger/feature/swagger.json

gen_api $managementUrl management
gen_api $featureUrl feature

#
# dump codes
bash dump-apis.sh

yarn prettier:api

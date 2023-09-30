#!/bin/sh
# Author yozian
# this script is for Features usage
# sh gen-cqrs.sh Entities EntityName

feature=$1
name=$2
folder="Features"

if [ -n "$3" ]; then
  folder=$3
fi

dotnet run --project Tool.CodeGenerator/ -t cqrs -e ${feature} -n ${name} -o App.Application/${folder}/${feature}

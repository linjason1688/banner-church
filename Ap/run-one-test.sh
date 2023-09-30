#!/bin/sh

target=$1

# use

if [ -z "$target" ]; then
  exit 1
fi

dotnet test App.Application.Test/App.Application.Test.csproj \
  --filter "FullyQualifiedName~${target}"

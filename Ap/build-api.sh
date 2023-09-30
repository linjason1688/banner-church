#!/bin/sh

# sh build-api.sh "App.Api" prod win
# $1: prod  $2: win  $3:  "./packages"
sh build.sh "App.Api" $1 $2 $3

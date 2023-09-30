#!/bin/sh

# sh build-web.sh "App.Api" prod win
# $1: prod  $2: win $3:  "./packages"
sh build.sh "App.Job" $1 $2 $3

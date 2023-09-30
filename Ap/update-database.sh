#!/bin/sh
# Author yozian
project="App.Infrastructure"
dotnet ef database update -p ${project}/ "$@" --context AppDbContext

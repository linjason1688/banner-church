#!/bin/sh
# Author yozian
project="App.Infrastructure"
name=$1

if [ -z "${name}" ]; then
  echo "please specify the migration name"
  exit
fi

dotnet ef migrations add "${name}" -p ${project}/ -o Persistence/Migrations/ --context AppDbContext

# update migrations.sql
sh gen-migrations.sh

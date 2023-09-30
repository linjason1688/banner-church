#!/bin/sh
# Author: yozian

# ex:  sh reset-migration-dev.sh Original Features y

base=$1
name=$2
applyMigration=$3

echo "###### reset to ${base}, add migration with ${name}"

project="App.Infrastructure"

echo "###### revert database migrations to ${base}"
dotnet ef database update "${base}" --project ${project} --context AppDbContext

echo "###### remove migrations...."
dotnet ef migrations remove --project ${project} --context AppDbContext

if [ -n "${name}" ]; then
  echo "###### create new migrations: ${name}"
  sh add-migration.sh "${name}"

  if [ "${applyMigration}" == "y" ]; then
    echo "apply new migration"
    sh update-database.sh
  fi

fi

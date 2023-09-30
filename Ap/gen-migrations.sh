#!/bin/sh
# Author yozian
project="App.Infrastructure"
dotnet ef migrations script --idempotent --project ${project}/ --output ${project}/Persistence/Migrations-Scripts/migrations.sql --context AppDbContext

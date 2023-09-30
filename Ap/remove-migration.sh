#!/bin/sh
# Author: yozian

project="App.Infrastructure"

echo "###### remove migrations...."
dotnet ef migrations remove --project ${project} --context AppDbContext




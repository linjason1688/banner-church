#!/bin/sh
# Author yozian

dotnet ef database update init --project App.Infrastructure/ --context AppDbContext
dotnet ef migrations remove  --project App.Infrastructure/ --context AppDbContext
sh add-migration.sh Init 
sh update-database.sh

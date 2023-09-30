@echo off
 
SET project=App.Infrastructure
SET name=%~1

dotnet ef migrations remove -p %project% --context AppDbContext


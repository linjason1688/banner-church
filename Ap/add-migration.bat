@echo off
 
SET project=App.Infrastructure
SET name=%~1
IF "" == "%name%" (
    echo "please specify the migration name"
    exit
)
dotnet ef migrations add "%name%" -p "%project%" -o Persistence\Migrations\ --context AppDbContext

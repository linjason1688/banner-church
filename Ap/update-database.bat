@echo off

set mssql_conn="Server=119.14.168.195,1433;Database=bch_classapp;User Id=gamma;Password=2022@gamma;TrustServerCertificate=true"
set project="App.Infrastructure"
dotnet ef database update -p %project% --connection=%mssql_conn%

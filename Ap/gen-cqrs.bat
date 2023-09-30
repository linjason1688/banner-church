@echo off
@REM example: gen-cqrs ModClasses ModClass Managements\Class

SET feature=%~1
SET name=%~2
SET %~1%~2folder="Features"
IF "" NEQ "%~3" (
  SET folder=%~3
)
IF "" == "%~3" (
  SET folder=%feature%
)

dotnet "run" "--project" "Tool.CodeGenerator" "-t" "cqrs" "-e" "%feature%" "-n" "%name%" "-o" "App.Application\%folder%" -y

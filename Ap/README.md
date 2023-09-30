# Api

## Environment

### Develop Environment

* SDK: .NET 6.* ↑

* Target Framework: NET 6.0

* Runtime NET 6.

* Sql server: 2016 ↑

### Production Preparation

* Installation

    * https://dotnet.microsoft.com/download/dotnet/6.0

    * ASP.NET Core Runtime & (Hosting Bundle)

* IIS

    * grant write access to applicationPool identity (Logs & File Upload)

    * specify [shared folder] for upload usage

### Database Migrations

* Set up environment depending on the environment you used
  * Windows Command Prompt
    ```
    SET DATABASE_CONNECTION="Server=127.0.0.1,1433;Database=bch_classapp;User Id=sa;Password=SaPassword;TrustServerCertificate=true;"
    ```
  * PowerShell
    ```
    $env:DATABASE_CONNECTION="Server=127.0.0.1,1433;Database=bch_classapp;User Id=sa;Password=SaPassword;TrustServerCertificate=true;"
    ```
  * Bash
    ```shell
    export DATABASE_CONNECTION="Server=127.0.0.1,1433;Database=bch_classapp;User Id=sa;Password=SaPassword;TrustServerCertificate=true;"
    ```
* add new migration
  > $ dotnet ef migrations add {migration-name-here} -p App.Infrastructure/

* create migrations scripts
  > $ dotnet ef migrations script {previous-migrations-name-here} -p App.Infrastructure/

* apply migrations
  > $ dotnet ef database update -p App.Infrastructure/

* apply migrations with cli

  modify the connection string in `update-database.bat`
  ```
  ./update-database.bat
  ```

* generate all migrations scripts
  > $ sh gen-migrations.sh

* Remove the latest migrations
  ```shell
  dotnet ef migrations remove --project .\App.Infrastructure\ --context AppDbContext
  ```

### Development

* 產生基本的 CRUD
  > $ sh gen-cqrs.sh Area Area  # in Linux
  > $ gen-cqrs.bat Area Area  # in windows

### Build

* Build API
  > $ sh build-api.sh prod

### Testing

* Run Tests
  > $ sh run-test.sh

### Vendor Environment

* SIT Environment

    - note:

### Configuration

#### AP

* 設定檔

    * appsettings.{env}.json
    * appsettings-sql.{env}.json
    * appsettings-job.{env}.json
    * appsettings-logger.{env}.json

### Docker

* build
  > $ sh docker-build.sh

* dev
  > $ sh docker-run

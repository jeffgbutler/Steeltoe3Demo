# Steeltoe Demo

Demoe application showing Steeltoe integration with Cloud Foundry. Shows the following aspects of Steeltoe:

- Managament Endpoints
- Service bindings for Redis and SQL Server
- Cloud Foundry Options

When running in "Development" mode (local), the app will conect to SQL Server and will use a hit counter defined with an
in-memory cache. When running in "Production" mode (on Cloud Fundry in this case), the app will conect to both Redis and SQL Server.

## Prerequisites

This app needs to connect to a SQL Server database. If you are running on Windows, and have `localdb` setup, you can use it by changing
the settings in appsettings.Development.json as follows:

```json
"SqlServer": {
  "Credentials": {
    "ConnectionString": "Server=(localdb)\\MSSQLLocalDB;database=Steeltoe;Trusted_Connection=True;"
  }
}
```

In other enviroments, and on Cloud Foundry, the app needs to connect to SQL server somewhere. It is easy to run SQL Server
in Docker following the instructions here: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker

## Cloud Foundry Setup

1. Create a redis service named "jgb-redis"

1. Create a SQL Server instance named "jgb-sqlserver". If you have a SQL Server on your network somewhere, you can define a user provided service
   like this:

   ```bash
   cf cups jgb-sqlserver -p '{"pw": "<YourStrong@Passw0rd>","uid": "SA","uri": "jdbc:sqlserver://192.168.128.19:1433;databaseName=Steeltoe"}'
   ```

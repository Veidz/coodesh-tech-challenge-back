# Coodesh Tech Challenge (Back-end)

The application goal is to build a web interface that allows uploading a file
transactions of products sold, normalize the data and store it in a
relational database.

## Stacks used
- ASP.NET Core
- C#
- EntityFramework
- Sql Server
- Nunit

## How to run the application

Our first step then is to get the SQL Server image. To do this, run the command below.
```
docker pull mcr.microsoft.com/mssql/server
```

After that we will run the Sql Server container
- WSL
    ```
    docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
    ```
- Windows
    ```
    docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
    ```
- Mac M1
    ```
    docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sqlserver mcr.microsoft.com/azure-sql-edg
    ```

We need to migrate the database to have the default values to the application run

```
cd CoodeshTechChallenge/CoodeshTechChallenge.API && dotnet ef database update
```

Now we run the application

```
cd CoodeshTechChallenge/CoodeshTechChallenge.API && dotnet run
```

Access swagger docs [here](http://localhost:5254/swagger/index.html)

>  This is a challenge by [Coodesh](https://coodesh.com/)

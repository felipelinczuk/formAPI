# formAPI

### Commands to run

* Downloading docker image MSSQL:

        docker pull mcr.microsoft.com/mssql/server:2022-latest

* Building image on a new container:

        docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password123" -p 1433:1433 --name sqlserver --hostname sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

* Building and running project:
        
        dotnet run


### Commands to run

* Downloading docker image MSSQL:

        docker pull mcr.microsoft.com/mssql/server:2022-latest

* Building image on a new container:

        docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<SENHA>" -p 1433:1433 --name sqlserver --hostname sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

* 


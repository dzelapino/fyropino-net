# Docker config

## MSSQL

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=#SuperAdmin1" -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server
```


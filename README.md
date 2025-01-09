# Docker config

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=#SuperAdmin1" \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
   
   
   
export PATH="$PATH:/home/dzelapino/.dotnet/tools"


export PATH="$PATH:/home/dzelapino/.dotnet/tools"


dotnet ef migrations add InitialCreate


dotnet ef database update "InitialCreate"

dotnet ef migrations list --json 

# Chat Sample

## Frontend

## Install front-end project dependencies

```bash
cd ./chat-ui
npm install
```

## Run front-end project

```bash
cd ./chat-ui
ng serve
```

## Backend


>First you need to configure the appsettings.json and appsettings.development.json connection string.
Set Data Source to your DB configuration (e.g. if your DB name is ``database`` the connection string should look like this:
``"Data Source=database;Initial Catalog=ChatDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"``).
After that run ``Update-Database`` command.

Run the program.

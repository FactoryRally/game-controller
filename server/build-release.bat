:: Generated by: https://openapi-generator.tech
::

@echo off

dotnet restore src\Tgm.Roborally.Server

dotnet publish src\Tgm.Roborally.Server -c Release -r win-x86 --no-restore
dotnet publish src\Tgm.Roborally.Server -c Release -r win-x64 --no-restore
dotnet publish src\Tgm.Roborally.Server -c Release -r linux-x64 --no-restore
dotnet publish src\Tgm.Roborally.Server -c Release -r linux-arm --no-restore
dotnet publish src\Tgm.Roborally.Server -c Release -r linux-arm64 --no-restore
dotnet publish src\Tgm.Roborally.Server -c Release -r osx-x64 --no-restore
echo Now, run the following to start the project: dotnet run -p src\Tgm.Roborally.Server\Tgm.Roborally.Server.csproj --launch-profile web. OR use the generated executeable src\Tgm.Roborally.Server\bin\Release\netcore3.1\release
echo.
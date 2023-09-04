dotnet publish --no-self-contained Flow.Launcher.Plugin.Ryot.sln -c Debug -r win-x64
Stop-Process -Name "Flow.Launcher" -ErrorAction SilentlyContinue
Start-Sleep -Seconds 1
Copy-Item -Recurse -Force -Path Flow.Launcher.Plugin.Ryot\bin\Debug\win-x64\publish\* -Destination $env:APPDATA\FlowLauncher\Plugins\ryot\
Start-Process -FilePath $env:LOCALAPPDATA\FlowLauncher\Flow.Launcher.exe

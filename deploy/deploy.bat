set root=%localappdata%\Tick42\Demos
set cfgDir=%localappdata%\Tick42\GlueDesktop\config\apps
set webDirName=WebAppHost
set wpfDirName=WPFToHostWebAppLoader
set webdir=%root%\Web\%webDirName%
set wpfDir=%root%\%wpfDirName%

del %cfgDir%\WebAppHost.json
copy WebAppHost.json %cfgDir%

del %cfgDir%\WPFWebAppLoader.json
copy WPFWebAppLoader.json %cfgDir%

rd /S /Q %webdir%
mkdir %webdir%
xcopy /Y ..\WebHost\index.html %webdir%
xcopy /E /R /Y /I ..\WebHost\lib %webdir%\lib

rd /S /Q %wpfDir%
mkdir %wpfDir%
xcopy /Y ..\DotNetCaller\bin\Debug\*.* %wpfDir%

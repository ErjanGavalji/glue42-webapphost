set root=%localappdata%\Tick42\Demos\Web
set cfgDir=%localappdata%\Tick42\GlueDesktop\config\apps
set dirName=WebAppHost
set dir=%root%\%dirName%

del %cfgDir%\WebAppHost.json
copy WebAppHost.json %cfgDir%

rd /S /Q %dir%
mkdir %dir%
xcopy /Y ..\index.html %dir%
xcopy /E /R /Y /I ..\lib %dir%\lib

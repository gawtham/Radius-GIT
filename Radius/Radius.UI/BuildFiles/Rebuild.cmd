@echo off
if "%KBld_LogDir%x"=="x" set "KBld_LogDir=%~dp0..\BuildLog\"
if not exist "%KBld_LogDir%" mkdir "%KBld_LogDir%"
msbuild.exe "%~dp0build.proj" @"%~dp0build.options" /t:rebuild %*
call "%~dp0findbuilderrors.cmd" "%KBld_LogDir%BuildMagSourceConnectHmnzn.log"

@echo off
if not "%_echo%" == "" echo on

rem Searches for errors in a build log file
rem Returns 0 if no errors found, 1 if errors found
rem Usage: findbuilderrors <logfile>

if "%~1" == "" goto usage
if not "%~2" == "" goto usage
goto skipusage

:usage
echo Usage: findbuilderrors.cmd ^<logfile^>
exit /b 1

:skipusage
echo Searching %1 for build errors ...
echo.

@rem check if its accessible
type "%~1" >nul
if /I %ERRORLEVEL% NEQ 0 (
    echo findbuilderrors.cmd: error : unable to open %1
    exit /b 1
)

rem the regular expression search takes a while, 
rem so we reduce the size of the regex search by
rem filtering with a non-regex search
findstr /c:" error " "%~1" | findstr /rc:":.* error .*:" | findstr /rvc:": warning.*:.* error " | findstr /rvc:"Warn:.* error "

if /I %ERRORLEVEL% EQU 0 (
    echo.
    echo Kalido Build FAILED
    exit /b 1
) else (
    echo No errors found.
    echo Kalido Build SUCCEEDED
    exit /b 0
)

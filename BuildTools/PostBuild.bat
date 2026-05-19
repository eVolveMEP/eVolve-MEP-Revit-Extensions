SET "ConfigName=%~1"
SET "TargetDir=%~2"
SET "TargetPath=%~3"
SET "ElectricalId=%~4"
SET "MechanicalId=%~5"

SET "VersionYear=Unknown"
IF NOT "%ConfigName:2024=%"=="%ConfigName%" SET "VersionYear=2024"
IF NOT "%ConfigName:2025=%"=="%ConfigName%" SET "VersionYear=2025"
IF NOT "%ConfigName:2026=%"=="%ConfigName%" SET "VersionYear=2026"
IF NOT "%ConfigName:2027=%"=="%ConfigName%" SET "VersionYear=2027"

SET "ProductName=Unknown"
IF NOT "%ConfigName:eE=%"=="%ConfigName%" (
    SET "ProductName=eVolveElectrical"
    SET "AssemblyId=%ElectricalId%"
    SET "ApplicationClassName=ApplicationElectrical"
)
IF NOT "%ConfigName:eM=%"=="%ConfigName%" (
    SET "ProductName=eVolveMechanical"
    SET "AssemblyId=%MechanicalId%"
    SET "ApplicationClassName=ApplicationMechanical"
)
SET Product=%ProductName:eVolve=%

FOR /F "tokens=* delims=" %%A IN ('DIR /B "%TargetDir%_*.addin"') DO SET "AddinTemplateFile=%%~nxA"
SET "AddinFileName=ext_%ProductName%%AddinTemplateFile%"
SET "AddinFilePath="%TargetDir%%AddinFileName%""
MOVE /Y "%TargetDir%%AddinTemplateFile%" %AddinFilePath%
COPY /Y %AddinFilePath% %AddinFilePath%.deploy >nul

"%~dp0fart.exe" %AddinFilePath% "~Product~" "%Product%" >nul
"%~dp0fart.exe" %AddinFilePath% "~AssemblyLocation~" "%TargetPath%" >nul
"%~dp0fart.exe" %AddinFilePath% "~AssemblyId~" "%AssemblyId%" >nul
"%~dp0fart.exe" %AddinFilePath% "~ApplicationClassName~" "%ApplicationClassName%" >nul

REM Copy to the correct Revit location.
REM Note, this action may require admin rights.
IF %VersionYear% GEQ 2027 (
	SET "AddinLocation=%ProgramFiles%\Autodesk\Revit\Addins\%VersionYear%"
) ELSE (
	SET "AddinLocation=%ALLUSERSPROFILE%\Autodesk\Revit\Addins\%VersionYear%"
)
powershell.exe -ExecutionPolicy Bypass -File "%~dp0\MakeWritableIfNeeded.ps1" "%AddinLocation%"
COPY /Y %AddinFilePath% "%AddinLocation%\%AddinFileName%"

REM Revit API references.
DEL /Q "%TargetDir%Revit*"
DEL /Q "%TargetDir%UIFramework*"
DEL /Q "%TargetDir%AdWindows.*"

REM Misc references.
DEL /Q "%TargetDir%JetBrains.Annotations.*"

ECHO.
ECHO %ConfigName%
SET "ConfigName=%~1"
SET "TargetDir=%~2"
SET "TargetPath=%~3"
SET "ElectricalId=%~4"
SET "MechanicalId=%~5"

SET "VersionYear=Unknown"
IF NOT "%ConfigName:2021=%"=="%ConfigName%" SET "VersionYear=2021"
IF NOT "%ConfigName:2022=%"=="%ConfigName%" SET "VersionYear=2022"
IF NOT "%ConfigName:2023=%"=="%ConfigName%" SET "VersionYear=2023"
IF NOT "%ConfigName:2024=%"=="%ConfigName%" SET "VersionYear=2024"

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
COPY /Y %AddinFilePath% "%ALLUSERSPROFILE%\Autodesk\Revit\Addins\%VersionYear%\%AddinFileName%" >nul

REM Revit API references.
DEL /Q "%TargetDir%Revit*"
DEL /Q "%TargetDir%UIFramework*"
DEL /Q "%TargetDir%AdWindows.*"

REM Misc references.
DEL /Q "%TargetDir%JetBrains.Annotations.*"

ECHO.
ECHO %ConfigName%
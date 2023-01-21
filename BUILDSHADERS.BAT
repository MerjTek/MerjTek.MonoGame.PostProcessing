@ECHO OFF
REM -+====================================================================+-
REM DOS BATCH File designed to build all .FX files write a C# effect
REM
REM Argument 1: The Solution Folder
REM Argument 2: Profile Name
REM
REM -+====================================================================+-

SET BINFOLDER=%1obj\Shaders\%2\

if not exist %BINFOLDER% md %BINFOLDER%

SET NAMESPACE=MerjTek.MonoGame.PostProcessing.Effects
SET CSOUTPUTFOLDER=%1Effects\%2\

if not exist %CSOUTPUTFOLDER% md %CSOUTPUTFOLDER%

SETLOCAL EnableDelayedExpansion

FOR /R %1Shaders %%G IN (*.fx) do (
    @ECHO OFF
    SET stop=

    if "%%~nG" == "PostProcessingCrosshatching" ( 
        if "%2" == "OpenGL" (
            ECHO "Skipping PostProcessingCrosshatching (OpenGL)..."
            SET stop=1 
        )
    )
    
    if not defined stop (
        REM Build the shader into a .BIN
        mgfxc %1Shaders\%%~nG.fx %BINFOLDER%%%~nG.bin /Profile:%2 > nul

        REM Convert .BIN into a .CS file
        %1Shaders\BIN2CS %NAMESPACE% %%~nGEffect %BINFOLDER% %CSOUTPUTFOLDER% %2
    )
)

ENDLOCAL

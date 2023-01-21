@ECHO OFF
REM -+====================================================================+-
REM DOS BATCH File designed to take a MGFXO and write a C# effect
REM
REM Argument 1: C# namespace
REM Argument 2: C# class name
REM Argument 3: The .BIN input folder
REM Argument 4: Output folder name
REM Argument 5: Platform name
REM
REM -+====================================================================+-

SET OutputFolder=.\
if [%4] == [] GOTO NoOutputFolder
SET OutputFolder=%4%\
:NoOutputFolder

REM Remove quotes from the string
SET OutputFolder=%OutputFolder:"=%

REM Set our folder plus filename
SET FileName=%OutputFolder%%2.cs

REM Set our bin file
SET BinFile=%3%2.bin
SET BinFile=%BinFile:Effect=%

REM Set our temp text file
SET TempFile=%3%2.txt
SET TempFile=%TempFile:Effect=%

ECHO Writing "%FileName%"...

@ECHO //+--------+-------+--------+--------+--------+--------+--------+ > "%FileName%"
@ECHO // This file is auto-generated. Please do not update. >> "%FileName%"
@ECHO //+--------+--------+--------+--------+--------+--------+--------+ >> "%FileName%"
@ECHO using Microsoft.Xna.Framework; >> "%FileName%"
@ECHO using Microsoft.Xna.Framework.Graphics; >> "%FileName%"
@ECHO; >> "%FileName%"
@ECHO namespace %1 >> "%FileName%"
@ECHO { >> "%FileName%"
@ECHO     /// ^<summary^> >> "%FileName%"
@ECHO     /// A class that performs a Post Process Effect. >> "%FileName%"
@ECHO     /// ^</summary^> >> "%FileName%"
@ECHO     internal class %2 : Effect >> "%FileName%"
@ECHO     { >> "%FileName%"
@ECHO         #region Protected Variable (Effect Code) >> "%FileName%"
@ECHO; >> "%FileName%"
@ECHO         static protected byte[] effectCode = >> "%FileName%"
@ECHO         { >> "%FileName%"

REM Load effect code binary and convert it to the bytes of the C# array
certutil -f -encodehex %BinFile% %TempFile% 4 > nul

SETLOCAL enabledelayedexpansion

REM Load the bytes temp file and convert it to the C# array line format
for /f "delims=" %%s in (%TempFile%) do (
   SET inputLine=%%s 
   SET noDoubleSpace=!inputLine:  = !
   SET str=            0x!noDoubleSpace: =, 0x!
   SET str=!str:~0,-3!
   ECHO !str! >> "%FileName%"
   
   SET inputLine=
   SET noDoubleSpace=
   SET str=
)

ENDLOCAL

@ECHO         }; >> "%FileName%"
@ECHO; >> "%FileName%"
@ECHO         #endregion >> "%FileName%"
@ECHO;  >> "%FileName%"
@ECHO         /// ^<summary^> >> "%FileName%"
@ECHO         /// Initializes an instance of the %2 class. >> "%FileName%"
@ECHO         /// ^</summary^> >> "%FileName%"
@ECHO         public %2(GraphicsDevice graphicsDevice^) : >> "%FileName%"
@ECHO             base(graphicsDevice, effectCode, 0, effectCode.Length^) >> "%FileName%"
@ECHO         { >> "%FileName%"
@ECHO         } >> "%FileName%"
@ECHO     } >> "%FileName%"
@ECHO } >> "%FileName%"
@ECHO; >> "%FileName%"
@ECHO //+--------+-------+--------+--------+--------+--------+--------+ >> "%FileName%"
@ECHO // This file is auto-generated. Please do not update. >> "%FileName%"
@ECHO //+--------+--------+--------+--------+--------+--------+--------+ >> "%FileName%"
@ECHO; >> "%FileName%"

del /F /Q %BinFile%
del /F /Q %TempFile%
@Echo OFF
set prog="Z:\BF2\Bf2 Sound Tools\oggenc.exe" 
set /p serial=Enter the desired serialnumber:
%prog% -b 56.000 -s %serial% %1
pause

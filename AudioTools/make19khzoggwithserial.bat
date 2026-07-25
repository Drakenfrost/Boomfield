set prog="Z:\BF2\Bf2 Sound Tools\oggenc.exe" 
set /p serial=Enter the desired serialnumber:
%prog% -b 19.6000 -s %serial% %1
pause

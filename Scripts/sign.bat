echo off
cls
cd C:\Program Files (x86)\Windows Kits\10\bin\10.0.26100.0\x64\
signtool.exe sign /f "D:\Certificados\GustavoSilva.pfx" /td sha256 /fd sha256 C:\Users\gusta\source\repos\BlocoDeNotas\BlocoDeNotas\bin\x64\Debug\net9.0-windows10.0.26100.0\BlocoDeNotas.exe
signtool.exe sign /f "D:\Certificados\GustavoSilva.pfx" /td sha256 /fd sha256 C:\Users\gusta\source\repos\BlocoDeNotas\BlocoDeNotas\bin\x64\Debug\net9.0-windows10.0.26100.0\BlocoDeNotas.dll
exit 0
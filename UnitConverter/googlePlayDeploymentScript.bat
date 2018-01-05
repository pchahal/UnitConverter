echo off
REM First clean the Release target.
msbuild.exe UnitConverter.csproj /p:Configuration=Release /t:Clean

REM Now build the project, using the Release target.
msbuild.exe UnitConverter.csproj /p:Configuration=Release /t:PackageForAndroid


REM At this point there is only the unsigned APK - sign it.
jarsigner.exe -verbose -sigalg MD5withRSA -digestalg SHA1 -keystore unitconverter.keystore -signedjar bin\Release\ca.pocketguru.voiceunitconverter.signed.apk bin\Release\ca.pocketguru.voiceunitconverter.apk unitconverter




REM Now zipalign it. The -v parameter tells zipalign to verify the APK afterwards.
C:\Users\par\AppData\Local\Android\android-sdk\tools\zipalign.exe -f -v 4 bin\Release\ca.pocketguru.voiceunitconverter.signed.apk bin\Release\ca.pocketguru.voiceunitconverter.zipaligned.apk
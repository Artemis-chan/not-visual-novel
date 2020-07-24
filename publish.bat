dotnet publish -r win-x64 -c Release -p:PublishTrimmed=true -p:PublishSingleFile=true --self-contained 
copy defaultconfig.ini Z:\Documents\programmin\cs\nvn\bin\Release\netcoreapp3.1\win-x64\publish\config.ini
echo write your story here> Z:\Documents\programmin\cs\nvn\bin\Release\netcoreapp3.1\win-x64\publish\story.txt
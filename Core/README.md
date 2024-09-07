app-secrets - https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets

dotnet publish --configuration Release - create 'Release' file

using System.Linq;


Redeploy website after some files were added/altered:
dotnet publish (from the project's root)
sudo systemctl restart montiepy.service
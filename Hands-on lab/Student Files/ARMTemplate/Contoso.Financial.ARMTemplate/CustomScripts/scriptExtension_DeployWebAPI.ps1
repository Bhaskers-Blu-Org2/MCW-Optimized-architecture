Param(
  [string]$artifactLocation,
  [string]$dbservername,
  [string]$dbname,
  [string]$dbadmin,
  [string]$dbpassword
)

### Install IIS and ASP.NET 4.5
Import-module ServerManager
Add-WindowsFeature Web-Server, Web-Mgmt-Console, web-asp-net45

### Unzip file contents
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory($artifactLocation, "C:\inetpub\wwwroot");


### Update Web.Config Connection String to correct value
$connString = "Server=tcp:$dbservername.database.windows.net,1433;Initial Catalog=$dbname;Persist Security Info=False;User ID=$dbadmin;Password=$dbpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
$webConfigLocation = "C:\inetpub\wwwroot\web.config"  

# Load config file
$xml = [xml](get-content $webConfigLocation) 
$root = $xml.get_DocumentElement();
    
# Replace the Connection String
$root.connectionStrings.add.connectionString = $connString
    
# Save config file
$xml.Save($webConfigLocation)
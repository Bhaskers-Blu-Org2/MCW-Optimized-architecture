Param(
  [string]$artifactLocation,
  [string]$apiipaddress
)

### Install IIS and ASP.NET 4.5
Import-module ServerManager
Add-WindowsFeature Web-Server, Web-Mgmt-Console, web-asp-net45

### Unzip file contents
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory($artifactLocation, "C:\inetpub\wwwroot");




### Update Web.Config with correct location for API
$apiurl = "http://$apiipaddress"

$webConfigLocation = "documents/testpowershellsql/web.config"  
   
# Load config file
$xml = [xml](get-content $webConfigLocation) 
$root = $xml.get_DocumentElement();

# update "transactionAPIUrl" AppSetting   
$root.SelectNodes("appSettings/add['transactionAPIUrl'=@key]/@value")[0].Value = $apiurl
    
# Save config file
$xml.Save($webConfigLocation)
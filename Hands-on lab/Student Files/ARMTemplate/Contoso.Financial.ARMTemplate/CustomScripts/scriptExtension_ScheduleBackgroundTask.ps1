Param(
  [string]$artifactLocation,
  [string]$dbservername,
  [string]$dbadmin,
  [string]$dbname,
  [string]$dbpassword
)

### Unzip file contents
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory($artifactLocation, "C:\OpsgilityTraining\BG");


### Update Web.Config Connection String to correct value
$connString = "Server=tcp:$dbservername.database.windows.net,1433;Initial Catalog=$dbname;Persist Security Info=False;User ID=$dbadmin;Password=$dbpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
$webConfigLocation = "C:\OpsgilityTraining\BG\Contoso.Financial.Background.exe.config"  

# Load config file
$xml = [xml](get-content $webConfigLocation) 
$root = $xml.get_DocumentElement();
  � 
# Replace the Connection String
$root.connectionStrings.add.connectionString = $connString
  � 
# Save config file
$xml.Save($webConfigLocation)


### Schedule Background Task

# Name of task
$taskName = "Contoso Financial Background Process"

# file location of EXE
$fileLocation = "C:\OpsgilityTraining\BG\Contoso.Financial.Background.exe"

$action = New-ScheduledTaskAction -Execute $fileLocation

$trigger = New-ScheduledTaskTrigger -Once -At (Get-Date) -RepetitionInterval (New-TimeSpan -Minutes 1) -RepetitionDuration ([System.TimeSpan]::MaxValue)

$settings = New-ScheduledTaskSettingsSet

$inputObject = New-ScheduledTask -Action $action -Trigger $trigger -Settings $settings

Register-ScheduledTask -TaskName $taskName -InputObject $inputObject -User SYSTEM

Start-ScheduledTask -TaskName $taskName

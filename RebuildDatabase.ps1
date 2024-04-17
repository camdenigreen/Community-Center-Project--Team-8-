Param(
   [string] $Server = "(localdb)\MSSQLLocalDb",
   [string] $Database = "communitycenter"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name SqlServer;

# Install the SQL Server Module
# Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

<#
   If on your local machine, you can drop and re-create the database.
#>
& ".\DropDatabase.ps1" -Database $Database
& ".\CreateDatabase.ps1" -Database $Database

<#
   If on the department's server, you don't have permissions to drop or create databases.
   In this case, maintain a script to drop all tables.
#>
#Write-Host "Dropping tables..."
#Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\DropTables.sql"

Write-Host "Creating schemas..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Schemas\People.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Schemas\Events.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\People.People.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\People.Groups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\People.PeopleGroups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\Events.Events.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\Events.EventAttendance.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\People.Payments.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Tables\People.Charges.sql"

Write-Host "Storing procedures..."

Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\People.People.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\People.Groups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\People.PeopleGroups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\Events.Events.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\Events.EventAttendance.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\People.Charges.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\Data\People.Payments.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive

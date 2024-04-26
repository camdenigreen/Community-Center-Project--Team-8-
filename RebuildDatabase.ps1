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
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.CreateEvent.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.InsertEventAttendance.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.RetrieveEventAttendanceByPersonID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.RetrieveEvents.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.RetrieveEventsByPersonID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.RetrievePersonEvents.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.UpcomingEventsAggregated.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.UpdateEventAttendance.sql"

Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.AddPersonToGroup.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.AggregatedPreviousEvents.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.CreateCharge.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.CreateGroup.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.CreatePayment.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.CreatePerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.LeaveEvent.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.LeaveGroup.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.NegativeBalance.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveActiveMembers.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveAllMembers.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveBalance.sql"


Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveChargesAndPayments.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveChargesByPersonID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveGroups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveGroupsByPersonID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveOtherEvents.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveOtherGroups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrievePaymentsByPersonID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrievePersonGroups.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrieveTransactions.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdateAddress.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdateFirstName.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdateGroupMembership.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdateInformation.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdateLastName.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdateMembership.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.UpdatePhoneNumber.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\People.RetrievePeopleByGroupID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.RetrieveEventsByGroupID.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DatabaseData\Sql\StoredProcedures\Events.RetrievePeopleByEventID.sql"

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

<#Script for getting Collection daily reports
Created by tbikbaiev 03-03-2015#>

<#defining variables#>
$dataSource = "t-imb-mdtel"
$user = "mcc"
$pwd = "mcc"
$database = "Server_test"
$connectionString = "Server=$dataSource;uid=$user; pwd=$pwd;Database=$database;Integrated Security=False;"
$filename = "PredictiveBuffer_"+(Get-Date).ToString('dd-MM-yyyy_hh_mm')+".csv"

<#DB connection#>
$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString
$connection.Open()

<#first query running#>
$query = "SELECT top 1000 * FROM calltrace"
$command = $connection.CreateCommand()
$command.CommandText = $query
$result = $command.ExecuteReader()

<#putting data to in-memory table#>
$table = new-object "System.Data.DataTable"
$table.Load($result)

<#data export to predefined file#>
$table | Export-Csv $filename

$connection.Close()
$dataSource = "imb-mssqlprod"
$user = "mcc"
$pwd = "mcc"
$database = "Server"
$connectionString = "Server=$dataSource;uid=$user; pwd=$pwd;Database=$database;Integrated Security=False;"
$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString
$connection.Open()
$query = "select CALLCODEDETAILS from callcodes"
$command = $connection.CreateCommand()
$command.CommandText = $query
$result = $command.ExecuteReader()
$table = new-object "System.Data.DataTable"
$table.Load($result)
$table
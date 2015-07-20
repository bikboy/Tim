#defining variables
$dataSource = "imb-mssqlst"
$user = "mcc"
$pwd = "mcc"
$database = "Server"
$connectionString = "Server=$dataSource;uid=$user; pwd=$pwd;Database=$database;Integrated Security=False;"
$queue = "TM Predictive Pt Click"
$queue = "test"

#DB connection
$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString
$connection.Open()

Invoke-WebRequest -Uri "http://10.155.126.58/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/Connect"

#get all agents from group CC_specialists
$query = "select AGENTNAME
from groupsbindings 
join agents on groupsbindings.AGENTID=agents.AGENTID
where GROUPID = 28"
$command = $connection.CreateCommand()
$command.CommandText = $query
$result = $command.ExecuteReader()

#putting data to in-memory table
$table = new-object "System.Data.DataTable"
$table.Load($result)
foreach ($agent in $table)
	{
		$uri = "http://10.155.126.58/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/AddBinding?Agent="+$agent.ItemArray+"&OldQueue=&Queue=$queue&Skill=5&OutgoingQueue=false"
		invoke-WebRequest -Uri "$uri"	
	}

Invoke-WebRequest -Uri "http://10.155.126.58/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/Logoff"
<#$request = [System.Net.WebRequest]::Create('http://10.155.101.57/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/Connect')
$response = $request.GetResponse()
$response.StatusCode
$response.Close#>
$request = [System.Net.WebRequest]::Create('http://10.155.101.57/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/Logoff')
$response = $request.GetResponse()
$response.StatusCode
$response.Close
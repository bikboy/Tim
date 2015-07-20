

 [wmi]$os = Get-WmiObject -Class win32_operatingsystem

 [wmi]$cs = Get-WmiObject -Class win32_computersystem

 [hashtable]$osProperties = @{

    'OSVersion'=$os.version;

    'OSBuild'=$os.buildnumber;

    'SPVersion'=$os.servicepackmajorversion;

    'Model'=$cs.model;

    'Manufacturer'=$cs.manufacturer;

    'RAM'=$cs.totalphysicalmemory / 1GB -as [int];

    'Sockets'=$cs.numberofprocessors;

    'Cores'=$cs.numberoflogicalprocessors;

    'SystemType'=$cs.SystemType}
	<#New-Object -TypeName PSCustomObject -Property $osProperties#>

   
  

  [hashtable]$osproperties.Add('disks',$disks)

  New-Object -TypeName PSCustomObject -Property $osProperties |Format-Table
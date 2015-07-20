Import-Module ActiveDirectory

$pingConfig = @{

    "count" = 1

    "bufferSize" = 15

    "delay" = 1

    "EA" = 0 }

$computer = $cn = $null

$cred = Get-Credential

 Get-ADComputer -filter * -Credential $cred -searchbase "OU=HeadOffice,OU=Workstations,DC=imb,DC=local"|

 ForEach-Object {

                 if(Test-Connection -ComputerName $_.dnshostname @pingconfig)

                   { $computer += $_.dnshostname + "`r`n"} }

$computer = $computer -split "`r`n"

$property =  "systemname","Name"<#"systemname","maxclockspeed","addressWidth",

            "numberOfCores", "NumberOfLogicalProcessors"#>

foreach($cn in $computer)

{

 if($cn -match $env:COMPUTERNAME)

   {

   $proc = Get-WmiObject -class win32_processor -ErrorAction SilentlyContinue -Property  $property |

   Select-Object -Property $property
   $video = Get-WmiObject -Class Win32_VideoController -ErrorAction SilentlyContinue -Property systemname,VideoProcessor,VideoModeDescription | Select-Object VideoProcessor,VideoModeDescription
   echo $proc,$video 
   }

 elseif($cn.Length -gt 0)

  {

   $proc = Get-WmiObject -class win32_processor -ErrorAction SilentlyContinue -Property $property -cn $cn -cred $cred |

   Select-Object -Property $property 
   $video = Get-WmiObject -Class Win32_VideoController -ErrorAction SilentlyContinue -Property systemname,VideoProcessor,VideoModeDescription -cn $cn -cred $cred| Select-Object VideoProcessor,VideoModeDescription
   echo $proc,$video 
   } } 
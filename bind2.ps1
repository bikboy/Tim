Invoke-WebRequest -Uri "http://10.155.126.58/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/Connect"
Invoke-WebRequest -Uri "http://10.155.126.58/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/AddBinding3?EntityID=28&QueueID=95&OldQueueID=-1&Skill=5&OutgoingQueue=FALSE&IsGroup=FALSE"
Invoke-WebRequest -Uri "http://10.155.126.58/MdtRemoteSupervisorWS/RemoteSupervisorWS.asmx/Logoff"
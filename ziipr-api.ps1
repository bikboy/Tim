#Create first user
$firstuser_email = "firstuser@somemail.com";
$seconduser_email = "seconduser@somemail.com";
$password = "12345";
$hash = @{  api_key = "nPAcobUJB1lmzM2xOEVsL1kPF7Vu8r4N";
            app_type_id = "100302";
            email = $firstuser_email;
            name = "test_user1";
            password = $password;
            skip_qbx = "1";
            location = @{lat = "50.469954"; lon = "30.3569466";}
         }
$json = $hash | ConvertTo-Json
$url = "http://api.stage.ziipr.com/v1/users"
$r = Invoke-Webrequest -uri $url -Method POST -Body $json
$u = $r.Content | ConvertFrom-Json | select user
$user_id1 = $u.user.user_id
"Created first user with ID : "+$user_id1

# Authorization of first user
$url = "http://api.stage.ziipr.com/v1/auth"
$hash = @{  api_key = "nPAcobUJB1lmzM2xOEVsL1kPF7Vu8r4N";
            app_type_id = "100302";
            email = $firstuser_email;
            password = $password;
         }
$json = $hash | ConvertTo-Json
$r = Invoke-Webrequest -uri $url -Method POST -Body $json


# Getting security token of this session for next steps 
$token = $r.Content | ConvertFrom-Json | select token
$token = $token.Substring(8,88)


#Putting user test to online state
$url = "http://api.stage.ziipr.com/v1/keep-alive"
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token }

#Create second user
$hash = @{  api_key = "nPAcobUJB1lmzM2xOEVsL1kPF7Vu8r4N";
            app_type_id = "100302";
            email = $seconduser_email;
            name = "test_user2";
            password = $password;
            skip_qbx = "1";
            location = @{lat = "50.469954"; lon = "30.3569466";}
         }
$json = $hash | ConvertTo-Json
$url = "http://api.stage.ziipr.com/v1/users"
$r = Invoke-Webrequest -uri $url -Method POST -Body $json
$u = $r.Content | ConvertFrom-Json | select user
$user_id2 = $u.user.user_id
"Created second user with ID : "+$user_id2

#Authorization of second user
$url = "http://api.stage.ziipr.com/v1/auth"
$hash = @{  api_key = "nPAcobUJB1lmzM2xOEVsL1kPF7Vu8r4N";
            app_type_id = "100302";
            email = $seconduser_email;
            password = $password
         }
$json = $hash | ConvertTo-Json
$r = Invoke-Webrequest -uri $url -Method POST -Body $json 

#Getting security token for second user session
$token2 = $r.Content | ConvertFrom-Json | select token
$token2 = $token2.token
<#
#Putting second user to online state
$url = "http://api.stage.ziipr.com/v1/keep-alive"
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token2 }

#Checking from second user if first user still alive
$url = "http://api.stage.ziipr.com/v1/users?online=1"
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token2 } 
$users = $r.Content | ConvertFrom-Json | select users
"Who is online(check from second user) :";
"Mail : "+$users.users.email+ " IP : " +$users.users.ip+ " User_id : "+$users.users.user_id

$url = "http://api.stage.ziipr.com/v1/users/"+$user_id1
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token2 }
$user = $r.Content | ConvertFrom-Json | select user
"User : " + $user.user.profile_meta_data.name + " is online? " + $user.user.is_online

#Checking from first user if second user still alive
$url = "http://api.stage.ziipr.com/v1/users?online=1"
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token } 
$users = $r.Content | ConvertFrom-Json | select users
"Who is online(check from first user) : ";
"Mail : "+$users.users.email+ " IP : " +$users.users.ip+ " User_id : "+$users.users.user_id

$url = "http://api.stage.ziipr.com/v1/users/"+$user_id2
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token }
$user = $r.Content | ConvertFrom-Json | select user
"User : " + $user.user.profile_meta_data.name + " is online? " + $user.user.is_online
#>
#Relationships: Favorite
$hash = @{  
            type = "200902";
            user_id = $user_id1;
         }
$json = $hash | ConvertTo-Json
$url = "http://api.stage.ziipr.com/v1/users/"+$user_id2+"/relationships"
$r = Invoke-WebRequest -Uri $url -Method POST -Headers @{ "X-AUTH-TOKEN" = $token2 } -Body $json
$relationship = $r.Content | ConvertFrom-Json | select relationship
"Second user added first one to favorite at : "+$relationship.relationship.created_at+" with ID : "+$relationship.relationship.relationship_id
#Delete favorite relationship
$url = "http://api.stage.ziipr.com/v1/users/"+$user_id2+"/relationships/"+$relationship.relationship.relationship_id
$r = Invoke-WebRequest -Uri $url -Method DELETE -Headers @{ "X-AUTH-TOKEN" = $token2 }
"Relationship with ID : "+$relationship.relationship.relationship_id+" deleted!"
$hash = @{  
            type = "200902";
            user_id = $user_id2;
         }
$json = $hash | ConvertTo-Json
$url = "http://api.stage.ziipr.com/v1/users/"+$user_id1+"/relationships"
$r = Invoke-WebRequest -Uri $url -Method POST -Headers @{ "X-AUTH-TOKEN" = $token } -Body $json
$relationship = $r.Content | ConvertFrom-Json | select relationship
"First user added second one to favorite at : "+$relationship.relationship.created_at+" with ID : "+$relationship.relationship.relationship_id
#Delete favorite relationship
$url = "http://api.stage.ziipr.com/v1/users/"+$user_id2+"/relationships/"+$relationship.relationship.relationship_id
$r = Invoke-WebRequest -Uri $url -Method DELETE -Headers @{ "X-AUTH-TOKEN" = $token }
"Relationship with ID : "+$relationship.relationship.relationship_id+" deleted!"

#Delete first user
$url = "http://api.stage.ziipr.com/v1/users/"+$user_id1+"?api_key=nPAcobUJB1lmzM2xOEVsL1kPF7Vu8r4N&app_type_id=100302"
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token } -Method Delete
"User with ID : "+$user_id1+" deleted!"
#Delete second user
$url = "http://api.stage.ziipr.com/v1/users/"+$user_id2+"?api_key=nPAcobUJB1lmzM2xOEVsL1kPF7Vu8r4N&app_type_id=100302"
$r = Invoke-WebRequest -Uri $url -Headers @{ "X-AUTH-TOKEN" = $token2 } -Method Delete
"User with ID : "+$user_id2+" deleted!"
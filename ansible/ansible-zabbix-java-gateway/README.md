
full provisioning for zabbix server located at folder ansible-zabbix-server. Current version is 0.2 , will be updated later
ansible-zabbix-proxy folder is about creating zabbix proxy from scratch. Current is alpha version 0.1 , will be tested and updated

Prerequisites:
For provisioning you will need to install ansible on  Linux or Mac OSX  version 2.3.1+ ( zabbix_host module not work with old versions)
zabbix-api library 
pip install zabbix-api
You need to create encrypted password file pass.yml : Instruction
Public SSH key installed on server(s) which will be provisioned ($HOME/.ssh/authorized_keys file)
sudo access on server(s) which will be provisioned
add IP addresses or hostnames of server which will be updated to /etc/ansible/hosts file

Go:
Zabbix server:
open subfolder zabbix/ansible-zabbix-server
put there your pass.yml (generated on prerequisites step 3)
run zabbix-server.yml with command : 
ansible-playbook zabbix_server.yml -e "variable_host=<Server IP/hostname> server=<Server IP/hostname>" --ask-vault-pass
after you need to enter your SUDO password and Vault password (prerquisites step 3)
Check output for possible errors
check zabbix UI at : http://<Server IP/hostname>/zabbix with your current zabbix login and password
Zabbix proxy:
open subfolder zabbix/ansible-zabbix-proxy
put there your pass.yml (generated on prerequisites step 3)
run zabbix-proxy.yml with command: 
ansible-playbook zabbix_proxy.yml -e "variable_host=<IP/hostname> server=<Zabbix server IP/hostname> name=<proxy name>" --ask-vault-pass
after you need to enter your SUDO password and Vault password (prerquisites step 3)
Check output for possible errors
check zabbix UI at : http://<Server IP/hostname>/zabbix with your current zabbix login and password → Administration → Proxy for new proxy status
Zabbix agent:
open subfolder zabbix/ansible-zabbix-agent
put there your pass.yml (generated on prerequisites step 3)
run zabbix-agent.yml with command(if you need connect agent to proxy , just add proxy name, if you dont - agent will be connected directly to server): 
ansible-playbook zabbix_agent.yml -e "variable_host=<IP/hostname> server=<Zabbix server IP/hostname> name=<agent name> proxy=<proxy_name>" --ask-vault-pass
after you need to enter your SUDO password and Vault password (prerquisites step 3)
Check output for possible errors
check zabbix UI at : http://<Server IP/hostname>/zabbix with your current zabbix login and password → Configuration → Hosts for new host status

#!/bin/bash
aws ec2 describe-instances --region $1 --filters "Name=tag:Name , Values=$2" | jq -r '.Reservations[].Instances[].NetworkInterfaces[].Association[]' | grep ec2

"""
This file contains the method related to loading a file from the CSS490 bucket 
and storing it into my bucket, as well, it can parse the file into the DynamoDB. 
copyFileFromS3 is the method responsible for moving the input.txt file between 
buckets. parseFileToDB will parse the file in my S3 bucket and store the elements 
in DynamoDB
"""

import boto3
import re
from boto3.dynamodb.conditions import Key, Attr

s3 = boto3.resource('s3')
dynamodb = boto3.resource('dynamodb', region_name='us-west-2')
table = dynamodb.Table('Program4Table')

def copyFileFromS3():
	#get from Professor S3
	data = s3.Object('css490', 'input.txt').get()
	#store in my S3
	s3.Object('css490assignment12','input.txt').put(Body=data['Body'].read())

def parseFileToDB():
	firstLastName = re.compile('([A-Za-z]+) +([A-Za-z]+)')
	keyValue = re.compile('(?:[ ]+)?\w+=\w+(?:[ ]+)?')

	#get file from S3
	obj = s3.Object('css490assignment12', 'input.txt')
	list = obj.get()['Body'].read().decode('utf-8').splitlines()

	#for each tuple
	for line in list:
		#add primary key to temp dictionary
		entry={'ID_NUMBER_PRIMARY':table.scan()['Count']}
		#pull the name using Regex
		name = re.search(firstLastName, line.strip())
		entry["FirstName"]=name.group(2)
		entry["LastName"]=name.group(1)
		response = table.scan(FilterExpression=Attr('FirstName').contains(name.group(2)) & Attr('LastName').contains(name.group(1)))
		if(response['Count']==1):
			updateCommand = "SET"
			updateSet = {}
			keys = re.findall(keyValue, line.strip())
			for key in keys:
				val1, val2 = key.strip().split('=')
				updateCommand = updateCommand + " " + val1 + "=:" + val1 + ","
				updateSet[':'+val1]=val2
			updateCommand = updateCommand[:-1]
			print(updateCommand)
			table.update_item(
			Key={'ID_NUMBER_PRIMARY':response['Items'][0]['ID_NUMBER_PRIMARY']},
			UpdateExpression = updateCommand,
			ExpressionAttributeValues=updateSet,
			ReturnValues="UPDATED_NEW"
			)
		else:
			#pull all the key:value pairs using regex
			keys = re.findall(keyValue, line.strip())
			for key in keys:
				val1, val2 = key.strip().split('=')
				entry[val1]=val2
			table.put_item(Item=entry)

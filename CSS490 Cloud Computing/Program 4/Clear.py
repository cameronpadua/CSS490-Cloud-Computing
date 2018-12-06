"""
This file contains the methods related to clearing the table and S3 storage. 
The clearTable method will empty the DynamoDB table and leave the existing 
primary key.  deleteS3File will remove the input.txt file from my S3 bucket.
"""

import boto3

s3 = boto3.resource('s3')
dynamodb = boto3.resource('dynamodb', region_name='us-west-2')
table = dynamodb.Table('Program4Table')

def clearTable():
	#removes all items by Primary key
	for i in range(0, table.scan()['Count']):
		response = table.delete_item(Key={'ID_NUMBER_PRIMARY':i})

def deleteS3File():
	#removes file from bucket.
	s3.Object('css490assignment12', 'input.txt').delete()
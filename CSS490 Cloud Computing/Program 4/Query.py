"""
This file contains the method to query DynamoDB. The method 
is called getData. It will return a HTML table of the results 
found or return a h1 tagged notification that no data was found.
"""

import boto3
from boto3.dynamodb.conditions import Key, Attr
from json2html import *

dynamodb = boto3.resource('dynamodb', region_name='us-west-2')
table = dynamodb.Table('Program4Table')
client = boto3.client('dynamodb', region_name='us-west-2')

def getData(first, last):
	#query response
	response = {}

	if(first != "" and last != ""):
		response = table.scan(FilterExpression=Attr('FirstName').contains(first) & Attr('LastName').contains(last))
	elif(first == "" and last == ""):
		print("nothing")
		response['Count']=0;
	elif(last == ""):
		response = table.scan(FilterExpression=Attr('FirstName').eq(first))
	else:
		response = table.scan(FilterExpression=Attr('LastName').eq(last))
		print(response)
	for i in response['Items']:
		del i['ID_NUMBER_PRIMARY']
	#no data, no problem 
	if(response['Count']==0):
		return "<h1>No data found</h1>"
	#returns HTML table based on Json recieved
	return json2html.convert(json = response['Items'])

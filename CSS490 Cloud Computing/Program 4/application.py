"""
This file is the main driver of the program. It uses the Flask 
framework to dynamically load HTML files and associated with them. 
In addition, this file tells a client what file/method to use when 
going to different links.
"""

from flask import Flask, render_template, request, redirect
import Load
import Clear
import Query



application = Flask(__name__)
name = "Hello"
queryData = ""
@application.route('/')
def default():
	global name
	name = "Hello"
	return redirect('/index')

@application.route('/index')
def defaultLanding():
	return render_template('index.html', name=name)

@application.route('/clear', methods = ['POST'])
def clear():
	global name, queryData

	Clear.clearTable()
	Clear.deleteS3File()
	
	queryData = ""
	name = "Table Cleared"
	return redirect('/index')

@application.route('/load', methods = ['POST'])
def loadData():
	global name, queryData

	Load.copyFileFromS3()
	Load.parseFileToDB()
	
	queryData = ""
	name = "Data Loaded"
	return redirect('/index')

@application.route('/query', methods = ['POST'])
def Queries():
	global name, queryData

	#get information for text fields.
	firstName = request.form['firstName']
	lastName = request.form['lastName']

	#house work for custom HTML table
	header_text = '''
    <html>\n<head> <title>EB Flask Test</title> </head>\n<body>'''
	home_link = '<p><a href="/">Back</a></p>\n'
	footer_text = '</body>\n</html>'

	#if query fields are empty
	if(firstName == "" and lastName == ""):
		name = "Please enter data to Query"
		return redirect('/index')

	queryData = Query.getData(firstName, lastName)
	name = "Query complete"

	#returns a custom HTML page with the HTML table embedded
	return (header_text + queryData  + home_link + footer_text)

if __name__ == '__main__':
	application.run()
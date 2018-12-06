"""
Cameron Padua
CSS490
Program 3: Back Up
Program Description: This program will make a back up of a directory and all sub-directories to the AWS E3 cloud. In addition, if a file is no longer in the directory, the file will be deleted from the S3 bucket

Notes:
Libraries that are needed
	boto3
	botocore
	argparse
	hashlib
	sys
	os
	configparser from six.moves

	If you are missing one of the libraries above, use the command pip install <lib> in command prompt to install
	Please note that many of these libraries are included with python, but you will most likely need to install boto3
Built and Tested on Python 3.6

_________________________________________________________________________________________________________________________________

MAKE SURE AWS CREDENTIALS ARE SET UP. You can do this by following the manual sets in the link below or use aws configure if you have a CLI installed:
https://docs.aws.amazon.com/sdk-for-php/v3/developer-guide/guide_credentials_profiles.html
https://docs.aws.amazon.com/cli/latest/userguide/cli-config-files.html
Note:
Home Directory for Windows is C:\Users\<USER>\
For Linux: home/<user>/
_________________________________________________________________________________________________________________________________

How to build an EXE
Before you start, you will need a python library called PyInstaller. To install, type the command 'pip install pyinstaller' into command prompt. You will also need Python 3.6 installed to run.
In addition, you will also need boto3. Use the command 'pip install boto3'. If pip is not working, your python environment may not be set up properly. See this link: https://stackoverflow.com/questions/23708898/pip-is-not-recognized-as-an-internal-or-external-command
Steps:
1. Open command Prompt/Terminal
2. Change directory to the location of the .py file. Use the command cd <location>
3. Run the command 'pyinstaller.exe -F --debug all backup.py'. This will create three new folders
4. Open the folder called dist and you will find the backup.exe file

How to Run the program
You have two choices when running this program. Using the EXE file or running the source code.
Please ensure that your AWS credentials are set up. Also ensure your config file is set to region us-west-1
Built and Tested on Python 3.6. Please use Python 3.6

To run the EXE:
1.Double click it. This is not recommended because the window will not stay open if successful or if it encounters errors
RECOMMEDED
1. Open command Prompt/Terminal
2. Change directory to the location of the EXE file. Use the command cd <location>
3. Type 'backup.exe' to run default parameters or ' backup.exe [-h] [--bucket BUCKET] [--path PATH]' to run with command line arguements
	Note: The Default bucket is css490program3defaultbucketname. If someone else is using this, it will cause an error
	BUCKET: This should be an existing bucket in your S3
	PATH: The absolute path to the folder you want to back up
4. Click enter. Done

To run Python code file:
1. Open command Prompt/Terminal
2. Change directory to the location of the .py file. Use the command cd <location>
3. Type 'python backup.py' to run default parameters or 'python backup.py [-h] [--bucket BUCKET] [--path PATH]' to run with command line arguements
	Note: The Default bucket is css490program3defaultbucketname. If someone else is using this, it will cause an error and ask you to re-run using a different bucket.
	BUCKET: This should be an existing bucket in your S3
	PATH: The absolute path to the folder you want to back up
4. Click enter. Done


____________________________________________________________________________________________________________________
Troubleshooting
If pip is not working, your python environment may not be set up properly. See this link: https://stackoverflow.com/questions/23708898/pip-is-not-recognized-as-an-internal-or-external-command
‘python’ is not recognized as an internal or external command. See this link:https://stackoverflow.com/questions/7054424/python-not-recognised-as-a-command
Multiple versions of python? See this link: https://stackoverflow.com/questions/4583367/how-to-run-multiple-python-versions-on-windows

"""

import os
from os import walk
import boto3
import botocore
import hashlib
import argparse
import sys
from six.moves import configparser

#Globals
currentDir = './'
s3 = boto3.resource('s3')
bucketname = 'css490program3defaultbucketname'
ItemsRemoved = 0
filesAdded = 0
filesUntouched = 0

"""
This method will back up files to a specific S3 bucket. It will only back up
files if the MD5 hash of the file is different from the hash in the bucket.
This is also a recursive function that calls itself for each directory
"""
def storeFiles(parentDir = ""):
    global filesAdded
    global filesUntouched
    #If directory is not in the bucket, add it
    if(parentDir!=""):
        s3.Object(bucketname, parentDir).put()
    #get all the files and sub directories in the current directory
    files = [f for f in os.listdir(currentDir + parentDir) ]
    dirs = [d for d in os.listdir(currentDir + parentDir)]
    #loop through all the files
    for filename in files:
        #checks if the file is a file and the MD5 hash is different from the
        #file in the bucket
        if os.path.isfile(currentDir + parentDir +filename):
            if fileExists(parentDir +filename) != fileCheckSum(currentDir + parentDir +filename):
                filesAdded = filesAdded +1
                s3.Object(bucketname, parentDir+filename).put(Body=open(currentDir + parentDir+filename, 'rb'), Metadata = { "hash": ""+fileCheckSum(currentDir + parentDir+filename)})
            else:
                filesUntouched = filesUntouched + 1
    #Loop through all the directories
    for directory in dirs:
        if os.path.isdir(currentDir + parentDir +directory):
            #Recursive call
            storeFiles(parentDir+directory+'/')
"""
The next two methods are from the link below. It allows me to get a checksum of
a file.
https://stackoverflow.com/questions/3431825/generating-an-md5-checksum-of-a-file
"""
def file_as_bytes(file):
    with file:
        return file.read()
def fileCheckSum(path):
    return hashlib.md5(file_as_bytes(open(path, 'rb'))).hexdigest();

#checks if a file exists in the S3 bucket. If it does, return the hash of the
#file. Otherwise return an empty string
def fileExists(path):
    try:
        return s3.Object(bucketname, path).get()['Metadata']['hash']
    except:
        return ""
"""
Loops through all the files in the bucket, and checks if they exist in the
current directory
"""
def removeOldFiles():
    global ItemsRemoved
    my_bucket = s3.Bucket(bucketname)
    for object in my_bucket.objects.all():
        if not os.path.isfile(currentDir + object.key) and not os.path.isdir(currentDir + object.key):
            ItemsRemoved +=1
            s3.Object(bucketname, object.key).delete()
"""
Tests whether the two paramters given are valid. If any paramter is bad,
the program exits with a print of what went wrong
"""
def testParamters(path, bucket):
    global currentDir
    global bucketname
    #Tests the path parameter to the directory being backed up
    if path == None:
        currentDir = './'
    elif not os.path.isdir(path):
        print('Path should be a directory. The path {} was not valid'.format(path))
        sys.exit()
    else:
        currentDir = path
    #Test if the bucket given is valid
    if args.bucket == None:
        #This if tests if the default bucket can be used. If not, exit.
        bucketname = 'css490program3defaultbucketname'
        try:
            s3.create_bucket(Bucket=bucketname, CreateBucketConfiguration={
            'LocationConstraint': 'us-west-1'})
            s3.meta.client.head_bucket(Bucket=bucketname)
        except botocore.exceptions.ClientError as e:
            error_code = e.response['Error']['Code']
            if error_code == 'BucketAlreadyOwnedByYou':
                print("Bucket Exists already. Chive on")
            else:
                print("Default bucket name does not work. Please specify bucket name using --bucket <bucketname> when running code. This bucket should already exist")
                sys.exit()
    else:
        #This else deals with user given bucket names
        try:
            s3.meta.client.head_bucket(Bucket=bucket)
            s3.Object(bucket, "test.txt").put()
            bucketname = bucket
        except botocore.exceptions.ClientError as e:
            # If a client error is thrown, then check that it was a 404 error.
            # If it was a 404 error, then the bucket does not exist.
            error_code = e.response['Error']['Code']
            if(error_code == '404'):
                print("Bucket does not exist. Enter valid bucket name")
                sys.exit()
            elif(error_code == '403'):
                print("Bucket access is Forbidden. Enter a different bucket")
                sys.exit()
            else:
                print("Error: " + error_code + ". Try different bucket")
                sys.exit()
"""
This method is responsible for taking input from the user and passing it to
check method. In addition, it calls the other methods to back up and delete
old files
"""
if __name__ == '__main__':
    #Takes arguements from command line
    parser = argparse.ArgumentParser()
    parser.add_argument('--bucket', help='This should be an existing bucket name in your S3 storage')
    parser.add_argument('--path', help ='This should be the absolute path to the folder you want to backup.' )
    args = parser.parse_args()
    #Checks if they are valid parameters
    testParamters(args.path, args.bucket)
    print(currentDir , bucketname)
    # Backs up and deletes files
    storeFiles()
    removeOldFiles()
    #Print Results of file back ups and deletions
    print("Files modified: " + str(filesAdded))
    print("Files not modified: " + str(filesUntouched))
    print("Files removed: " + str(ItemsRemoved))

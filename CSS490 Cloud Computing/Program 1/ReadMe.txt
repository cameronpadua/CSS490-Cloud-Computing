To Compile:
 *  Open the Developer Command prompt for VS 2017
 *  Navigate to the the folder where the Program.cs file is. You can do this by typing cd and then the path to the file location. ie cd <file>
 *  Assuming you have .Net 4.6.1, use the following command to compile: csc.exe Program.cs -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Net.Http.dll"
 *      Please note: You can use .Net version 4.5, but I have not tested it and cannot gurantee that the program will work
 *  After running the command, an executable file will be created in the working directory
 *
 * NOTE: If you would like to have additional information about the program running. Edit the variable in the code called verbose. By default it is false, change to true for additional information. After change, recompile and run code.
 *  
 *  To run:
 *  *****Follow the step above for compiling or use the included exe file.*******
 *  Open the Developer Command prompt for VS 2017
 *  Navigate to the location of the exe file
 *  Type Program.exe <URL> <hops> with <URL> being the start URL and <hops> being the number of hops from the start.
 *	URL must begin with http:// or https://, hops must be an int greater than 0
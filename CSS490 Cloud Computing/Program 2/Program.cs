/*  Name: Cameron Padua
 *  Program 2
 *  CSS490
 *  
 *  To Compile:
 *  Open the Developer Command prompt for VS 2017
 *  Navigate to the the folder where the Program.cs file is. You can do this by typing cd and then the path to the file location. ie cd <file>
 *  To compile, you will need to compile all the cs file and three dependancies. Those are .Net 4.6.1, Newtonsoft.Json.dll, and Microsoft.VisualBasic.dll. All of these are include in folder. Your compile command may vary, but you will need these files in the same folder to use the command below. If they are not YMMV
 *  	csc.exe *.cs -r:"System.Net.Http.dll","Newtonsoft.Json.dll","Microsoft.VisualBasic.dll"
 *      Please note: You can use .Net version 4.5, but I have not tested it and cannot gurantee that the program will work
 *  After running the command, an executable file will be created in the working directory
 *
 *  
 *  To run:
 *  *****Follow the step above for compiling or use the included exe file.*******
 *  Open the Developer Command prompt for VS 2017
 *  Navigate to the location of the exe file
 *  Type Program.exe
 *  	Please note that you will need the .dll files to be in the same folder as the exe
 *
 * 
 * 
 * */
using System;
using System.Windows.Forms;

namespace Program2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Runs teh GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
           
        }
}

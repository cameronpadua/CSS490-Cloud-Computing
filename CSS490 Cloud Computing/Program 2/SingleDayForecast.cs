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
namespace Program2
{
    class SingleDayForecast
    {
        public class SingleDayWeather
        {
            public Coord coord { get; set; }
            public Weather[] weather { get; set; }
            public string _base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Coord
        {
            public float lon { get; set; }
            public float lat { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public float deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public float message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
    }
}

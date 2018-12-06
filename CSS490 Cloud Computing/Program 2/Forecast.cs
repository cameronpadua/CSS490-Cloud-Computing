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
using System.Collections.Generic;
namespace Program2
{
    class Forecast
    {
        public class Day
        {
            public string date = "";
            public List<float> tempMin = new List<float>();
            public List<float> tempMax = new List<float>();
            public string condition;
            public List<float> humidity = new List<float>();
        }
        public class Rootobject
        {
            public List<Day> days = new List<Day>();
            public string cod { get; set; }
            public float message { get; set; }
            public int cnt { get; set; }
            public List[] list { get; set; }
            public City city { get; set; }
            public void computeFiveDay()
            {
                
                Day current = new Day();
                current.date = list[0].dt_txt.Split(null)[0];
                current.condition = list[0].weather[0].main;
                foreach (List item in list)
                {
                    if (!current.date.Equals(item.dt_txt.Split(null)[0]))
                    {
                        days.Add(current);
                        current = new Day();
                        current.date = item.dt_txt.Split(null)[0];
                        current.condition = item.weather[0].main;
                    }
                    current.tempMin.Add(item.main.temp_min);
                    current.tempMax.Add(item.main.temp_max);
                    current.humidity.Add(item.main.humidity);
                }
                days.Add(current);
            }
        }
        

        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
            public int population { get; set; }
        }

        public class Coord
        {
            public float lat { get; set; }
            public float lon { get; set; }
        }

        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public Weather[] weather { get; set; }
            public Clouds clouds { get; set; }
            public Wind wind { get; set; }
            public Sys sys { get; set; }
            public string dt_txt { get; set; }
            public Rain rain { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public float pressure { get; set; }
            public float sea_level { get; set; }
            public float grnd_level { get; set; }
            public int humidity { get; set; }
            public float temp_kf { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public float deg { get; set; }
        }

        public class Sys
        {
            public string pod { get; set; }
        }

        public class Rain
        {
            public float _3h { get; set; }
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

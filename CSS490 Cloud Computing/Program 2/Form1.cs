/*  Name: Cameron Padua
 *  Program 2
 *  CSS490
 *  
 *  To Compile:
 *  Open the Developer Command prompt for VS 2017
 *  Navigate to the the folder where the Program.cs file is. You can do this by 
		typing cd and then the path to the file location. ie cd <file>
 *  To compile, you will need to compile all the cs file and three dependancies.
		Those are .Net 4.6.1, Newtonsoft.Json.dll, and Microsoft.VisualBasic.dll. 
		All of these are include in folder. Your compile command may vary, but you 
		will need these files in the same folder to use the command below. If 
		they are not YMMV
 *  	csc.exe *.cs -r:"System.Net.Http.dll","Newtonsoft.Json.dll","Microsoft.VisualBasic.dll"
 *      Please note: You can use .Net version 4.5, but I have not tested it 
		and cannot gurantee that the program will work
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
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        //API key, do not edit unless you have another
        private string id = "8a277023fa36881a23384874747e07e0";
        //loads the form
        public Form1()
        {
            InitializeComponent();
        }

        private void updateCurrentWeather(string SingleDayJson)
        {
            //Converts Json into objects
            SingleDayForecast.SingleDayWeather generalInformation = 
			JsonConvert.DeserializeObject<SingleDayForecast.SingleDayWeather>(SingleDayJson);

            //Updates Fields on GUI
            locationPlaceholder.Text = ("Location: " + generalInformation.name);
            country.Text = "Country: " + generalInformation.sys.country;
            temperature.Text = generalInformation.main.temp + "°F";
            Condition.Text = generalInformation.weather[0].main;
            tempMax.Text = "Temp. Max: " + generalInformation.main.temp_max + "°F";
            tempMin.Text = "Temp. Min: " + generalInformation.main.temp_min + "°F";
            Humidity.Text = "Humidity: " + generalInformation.main.humidity + "%";
            latitude.Text = "Lat: " + generalInformation.coord.lat;
            longitutde.Text = "Lat: " + generalInformation.coord.lon;
            Sunrise.Text = "Sunrise: " 
			+ DateTimeOffset.FromUnixTimeSeconds(generalInformation.sys.sunrise).DateTime.ToLocalTime().TimeOfDay;
            Sunset.Text = "Sunset: " 
			+ DateTimeOffset.FromUnixTimeSeconds(generalInformation.sys.sunset).DateTime.ToLocalTime().TimeOfDay;

        }
        
        private void updateFiveDay(string fiveDayJson){
            //Converts Json into objects
            Forecast.Rootobject generalInformation = 
			JsonConvert.DeserializeObject<Forecast.Rootobject>(fiveDayJson);
            //converts 3 hour increments into Day objects in days
            generalInformation.computeFiveDay();
            //Loops through day objects
            foreach (Forecast.Day current in generalInformation.days)
            {
                //If date is blank, skip. Edge case fix
                if (current.date.Equals("")) continue;
                //Add averages of day data to table
                this.dataGridView1.Rows.Add(
				DateTimeOffset.Parse(current.date).DayOfWeek, current.condition, 
				string.Format("{0:0.00}", current.tempMax.Average()) + "°F", 
				string.Format("{0:0.00}", current.tempMin.Average()) + "°F", 
				string.Format("{0:0.00}", current.humidity.Average()) + "%");
            }
        }
        private string getCurrentWeatherJson(string location)
        {
            //Cleans up input
            location = location.Trim();   
            //Calls API for current weather data
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                HttpResponseMessage response;
                if (location.Contains(','))
                {
                    string test = location.Replace(" ", string.Empty);
                    //gets Json, also removes spaces from input
                    response = client.GetAsync("weather?q=" + 
					location.Replace(" ", string.Empty) + 
					"&units=imperial&mode=json&APPID="+id).Result;
                }
                else
                {
                    //get Json
                    response = client.GetAsync("weather?q=" + location + 
					"&units=imperial&mode=json&APPID="+id).Result;
                }
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
        private string getFiveDayJson(string location)
        {
            //trims unnessary information
            location = location.Trim();
            //gets 5 day forecast data from API
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                HttpResponseMessage response;
                if (location.Contains(','))
                {
                    //gets Json, also removes spaces from input
                    response = client.GetAsync("forecast?q=" + 
					location.Replace(" ", string.Empty) + 
					"&units=imperial&mode=json&APPID=" + id).Result;
                }
                else
                {
                    //gets Json
                    response = client.GetAsync("forecast?q=" + location + 
					"&units=imperial&mode=json&APPID=" + id).Result;
                }
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            changeLocation();
        }

        private void changeCity_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            changeLocation();
        }
        private void changeLocation()
        {
            string input = "";
            //gets location from user
            input = Microsoft.VisualBasic.Interaction.InputBox("Enter a" +
			"\"<City name>\" or \"<City>, <ISO 3166 country codes>\" with no " 
			+ "quotes. Enter nothing to Exit. See example in field. There may " 
			+ "be a slight delay in the results appearing.", 
			"Enter a City name", "Seattle", 0, 0);
            if (input.Equals("")) Environment.Exit(1);
            while (!input.Equals(""))
            {
                try
                {
                    //updates the GUI and gets the Json data
                    updateCurrentWeather(getCurrentWeatherJson(input));
                    updateFiveDay(getFiveDayJson(input));
                    break;
                }
                catch
                {
                    //if any error happens from user input, go here to ask for input again
                    //gets location from user
                    input = Microsoft.VisualBasic.Interaction.InputBox("Enter a" +
					"\"<City name>\" or \"<City>, <ISO 3166 country codes>\" with no " 
					+ "quotes. Enter nothing to Exit. See example in field. There may " 
					+ "be a slight delay in the results appearing.", 
					"Enter a City name", "Seattle", 0, 0);
			if (input.Equals("")) Environment.Exit(1);
                }
            }
        }
    }
}

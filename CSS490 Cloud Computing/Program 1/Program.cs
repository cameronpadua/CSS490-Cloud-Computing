/*  Name:   Cameron Padua
 *  Course: CSS490 Cloud Computing
 *  Assignemnt 1: Web Crawler
 *  
 *  Assignment Description:
 *  Your application will download the html from the starting URL which is 
 *	provided as the first argument to the program.  It will parse the html 
 *	finding the first <a href  > reference to other absolute URLs, for instance
 *	https://www.w3schools.com/tags/att_a_href.asp .  Make sure that you have 
 *	not previously visited this page (if you have then skip and find the next 
 *	reference). The application will then download the html from that page and 
 *	repeat the operation.  You will do this NumHops times.  Your app will print
 * 	out to the console the value of the final URL you landed on as well as the 
 *	html.  If you encounter a page without any embedded references you should 
 *	stop there and print out the result.
 * 
 *  Notes:
 *  Compiled and tested in .Net 4.6.1
 *  
 * Dependancies:
 * .Net 4.6.1
 *  
 *  To Compile:
 *  *Open the Developer Command prompt for VS 2017
 *  *Navigate to the the folder where the Program.cs file is. You can do this 
 *		by typing cd and then the path to the file location. ie cd <file>
 *  *Assuming you have .Net 4.6.1, use the following command to compile: 
 *		csc.exe Program.cs 
 *		-r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\
 *				.NETFramework\v4.6.1\System.Net.Http.dll"
 *      **Please note: You can use .Net version 4.5, but I have not tested it 
 *		and cannot gurantee that the program will work. Also make sure there is
 *		no new lines in commands
 *  *After running the command, an executable file will be created in the 
 *		working directory
 *  
 * NOTE: If you would like to have additional information about the program 
 *	running. Edit the variable in the code called verbose. By default it is false, 
 *	change to true for additional information.
 *  
 *  To run:
 *  *****Follow the step above for compiling or use the included exe file.*******
 *  *Open the Developer Command prompt for VS 2017
 *  *Navigate to the location of the exe file
 *  *Type Program.exe <URL> <hops> with <URL> being the start URL and <hops> being 
 *      the number of hops from the start
 *       *	URL must begin with http:// or https://, hops must be an int greater than 0
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Program1
{
    class Program
    {
        static List<string> visitedWebsites = new List<string>();//Stores a 
                                                                 //list of websites visited
        static string currentURL = "";//Placeholders for the URLs
        static string lastURL = "";
        static string currentHTML = "";//Placeholders for the HTML files
        static string lastHTML = "";
        static Boolean verbose = false;// Set to true if you want additional 
                                      //information about hop history and other information
        static void Main(string[] args)
        {
            checkParameters(args);//Checks whether the arguements given are valid

            int numHops = Int32.Parse(args[1]);//stores the number of hops
            currentURL = args[0];//stores the base URL
            lastURL = currentURL;
            visitedWebsites.Add(currentURL);//Adds base URL to list of visited
                                            //websites

            while (numHops > 0 && !currentURL.Equals(""))//Loop until number of 
                                                         //hops are over or no URL is found in HTML
            {
                lastURL = currentURL;
                lastHTML = currentHTML;

                currentHTML = getHTML(new Uri(currentURL));//Attempts to get
                                                           //the HTML of the current URL
                currentURL = findNextURL(currentHTML);//Attenpts to find 
                                                      //the next URL
                if (!currentURL.Equals("")) visitedWebsites.Add(currentURL);
                numHops--;
            }
            printResults(); //Print the results

        }
        private static void printResults()
        {
            if (verbose == true) //Prints the hop history if verbose is on
            {
                int hop = 0;
                foreach (string site in visitedWebsites)
                {
                    Console.Write($"Hop {hop}: ");
                    hop++;
                    Console.WriteLine(site);

                }
                if (currentURL.Equals("")) Console.WriteLine($"Did not complete" +
                " all hops, no more absolute links found. Stopped at hop {hop-1}");
                else Console.WriteLine($"Successful {hop - 1} hops");
            }

            Console.WriteLine("");
            Console.WriteLine("Last site Visited");
            if (currentURL.Equals(""))//If currentURL was bad, print the last 
                                      //visited website URL
            {
                Console.WriteLine(lastURL);
            }
            else
            {
                //else print the current URL
                Console.WriteLine(currentURL);
            }
            Console.WriteLine("");
            Console.WriteLine("HTML:");
            Console.WriteLine(currentHTML);
        }

        private static void checkParameters(string[] parameters)
        {
            if (parameters.Length != 2) //Not valid amount of arguements
            {
                Console.Error.WriteLine("Incorrent amount of parameters!" + 
                "You should provide two parameters. \nThe first should be the" +
                "URL that you want to start at and the second \n" +
                    "should be the number of hops from the beginning URL.");
                Environment.Exit(-1);
            }
            else
            {
                //Checks if URL given is valid
                if (IsAbsoluteUrl(parameters[0]) == false)
                {
                    Console.Error.WriteLine("URL provided is not valid");
                    Environment.Exit(-1);
                }
                else
                {
                    try
                    {
                        //Tests the base URL to see if HTML is good
                        getHTML(new Uri(parameters[0]));
                    }
                    catch (Exception error)
                    {
                        Console.Error.WriteLine("URL provided is not valid");
                        Environment.Exit(-1);
                    }
                    //checks if the second value is an int and is greater than 0
                    if (Int32.TryParse(parameters[1], out int n) == true &&
                        Int32.Parse(parameters[1]) <= 0)
                    {
                        Console.Error.WriteLine("Number of hops needs to be" +
                        " greater than 0 and an integer");
                        Environment.Exit(-1);
                    }
                    else
                    {
                        if (verbose == true)//additional information if enabled
                        {
                            Console.WriteLine("Input is good");
                            Console.WriteLine("URL:" + parameters[0]);
                            Console.WriteLine("Hops: " + parameters[1]);
                        }
                    }
                }
            }
        }
        private static string findNextURL(String HTML)
        {
            //Regualr Expression for <a href> tags for http and https links
            Regex rr = new Regex("<a href=(?:\"{1}|'{1})(https?://.*?)/?\"{1}|'{1}(\\s.*)?>");
            Match match = rr.Match(HTML); //finds first match
            String URL = "";
            while (match.Success) //if match found
            {
                URL = match.Groups[1].ToString();//Get Match URL
                                                 //check if the URL has been visited
                if (visitedWebsites.Contains(URL) == false && IsAbsoluteUrl(URL))
                {
                    try
                    {
                        getHTML(new Uri(URL));
                        return URL; //If not, return URL
                    }
                    catch (HttpRequestException fourHundredError)
                    {
                        match = match.NextMatch();  //Else find next match
                    }
                }
                else
                {
                    match = match.NextMatch(); //Else find next match
                }

            }
            return "";
        }

        private static string getHTML(Uri currentURI)
        {
            using (var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate |
                DecompressionMethods.GZip
            }))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //For SSL exception errors. Ignores certificates
                ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

                client.BaseAddress = currentURI;//Sets URL for HTTPCLient
                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                string result = System.Text.Encoding.UTF8.GetString(
                response.Content.ReadAsByteArrayAsync().Result);

                return result; //returns HTML
            }

        }


        private static bool IsAbsoluteUrl(string url)
        {
            Uri uriResult;
            //Checks if link is an Absolute link, but does not check if it live
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp ||
                uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}

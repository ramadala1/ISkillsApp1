using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Owin;
using ISkillsApp;
using Microsoft.Owin.Hosting;

namespace ISkillsAppHost
{
	class Program
	{
		static void Main(string[] args)
		{
			string baseAddress = "http://localhost:9001/";
			StartOptions options = new StartOptions(baseAddress);

			// Start OWIN host 
			try
			{
				using (WebApp.Start<WebApiStartup>(options))
				{
					// Create HttpCient and make a request to api/values 
					//HttpClient client = new HttpClient();

					//var response = client.GetAsync(baseAddress + "api/values").Result;

					Console.WriteLine("service hosted");
					//Console.WriteLine(response.Content.ReadAsStringAsync().Result);
					Console.ReadLine();
				}
			}
			catch (Exception ex)
			{

			}
			
			}
		}
	}


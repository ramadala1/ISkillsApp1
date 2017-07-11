using ISkillsApp;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ISkillsServer
{
	public partial class IskillsApp : ServiceBase
	{
		IDisposable WebApiHost = null;
		public IskillsApp()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			string baseAddress = "http://localhost:9000/";
			StartOptions options = new StartOptions(baseAddress);
			// Start OWIN host 
			WebApiHost = WebApp.Start<WebApiStartup>(options);
		}

		protected override void OnStop()
		{
			WebApiHost.Dispose();
		}
	}
}

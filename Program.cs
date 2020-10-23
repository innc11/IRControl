using flyfire.IO.Ports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace IRControl
{
	static class Program
	{
		static void Main()
		{
			/*
			MySerial ms = new MySerial("COM3", 115200);

			if (ms.IsOpen)
			{
				Console.WriteLine("串口被占用");
				Environment.Exit(0);
			}

			ms.RtsEnable = false;
			ms.DtrEnable = false;
			ms.ReceiveTimeoutEnable = true;
			ms.ReceiveTimeout = 5;
			ms.Open();
			//ms.startListener();

			AppDomain.CurrentDomain.ProcessExit += new EventHandler(delegate (object sender, EventArgs e)
			{
				ms.Close();
			});

			*/
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());

			//Console.ReadKey();
		}

	}
}

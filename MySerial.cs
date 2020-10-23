using flyfire.IO.Ports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IRControl
{
	class MySerial : CustomSerialPort
	{
		public MySerial() : base("COM0", 115200)
		{ }

		public const int KEYEVENTF_KEYUP = 2;

		[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
		public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

		/*
		public void startListener()
		{
			ReceivedEvent += delegate (object sender, byte[] bytes)
			{
				string text = System.Text.Encoding.UTF8.GetString(bytes);
				Console.Write(text);
				JObject root = JsonConvert.DeserializeObject<JObject>(text);

				if ((int)root["command"] == 69)
				{
					//keybd_event(Keys.Vol, 0, 0, 0);
					MessageBox.Show("Text", "Title");
				}
			};
		}
		*/
	}
}

using flyfire.IO.Ports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace IRControl
{
	public struct RulePair
	{
		public string keyCode;
		public string lable;
	}
	public partial class Form1 : Form
	{
		MySerial serial = new MySerial();

		public Dictionary<int, RulePair> pairs = new Dictionary<int, RulePair>();

		readonly string[] exception = { "Up", "Down", "Left", "Right" };

		int lastIRCode = 0;

		int blockCount = 0;

		TimeSpan lastSpan;

		public Form1()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;

			lastSpan = getTimeStamp();

			serial.ReceivedEvent += delegate (object sender, byte[] bytes)
			{
				string text = Encoding.UTF8.GetString(bytes);
				Console.Write(text);
				JObject root = JsonConvert.DeserializeObject<JObject>(text);
				
				int key = Int32.Parse((string)root["command"]);
				console.AppendText(String.Format("{0:X2}\r\n", key));

				if (pairs.ContainsKey(key) && state.Checked && !catchIR.Checked && key != 0)
				{
					PressKey(key);
					blockCount = 0;
					lastSpan = getTimeStamp();
				}

				if (key == 0 && lastIRCode != 0 && state.Checked && !catchIR.Checked && (getTimeStamp() - lastSpan).TotalMilliseconds < 800)
				{
					lastSpan = getTimeStamp();
					if (blockCount++ > 0)
						PressKey(lastIRCode);
				}

				if (catchIR.Checked && key != 0)
				{
					IRCode.Text = String.Format("{0:X2}", key);
					if (pairs.ContainsKey(key))
					{
						lable.Text = pairs[key].lable;

						rulesList.SelectedIndex = -1;
						for (int i = 0; i < rulesList.Items.Count; i++)
						{
							if(rulesList.Items[i] is MyRow)
							{
								var mr = rulesList.Items[i] as MyRow;
								if(key==mr.irCode)
								{
									rulesList.SelectedIndex = i;
									console.AppendText("catched\r\n");
									break;
								}
							}
						}

					}
					else
					{
						lable.Text = "";
					}
				}
			};

			console.TextChanged += (object sender, EventArgs e)=>
			{
				if(console.TextLength>4096)
				{
					console.ResetText();
				}
			};
		}


		TimeSpan getTimeStamp()
		{
			return DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
		}

		bool IsException(string text)
		{
			foreach (var item in exception)
			{
				if (item == text)
					return true;
			}

			return false;
		}

		void PressKey(int irCode)
		{
			string Keycode = pairs[irCode].keyCode;
			string Lable = pairs[irCode].lable;

			foreach (var item in typeof(Keys).GetFields())
			{
				keyCode.Items.Add(item.Name);
			}

			if(Enum.IsDefined(typeof(Keys), Keycode))
			{
				Keys targetKey = (Keys)Enum.Parse(typeof(Keys), Keycode);

				if (IsException(Keycode))
				{
					SendKeys.SendWait("{" + targetKey.ToString() + "}");
				}else{
					MySerial.keybd_event(targetKey, 0, 0, 0);
					MySerial.keybd_event(targetKey, 0, MySerial.KEYEVENTF_KEYUP, 0);
				}
			}
			else
			{
				SendKeys.SendWait(Keycode);
			}

			console.AppendText($"{Keycode}({Lable})!\r\n");

			lastIRCode = irCode;
		}

		void openSerial()
		{
			if (serial.IsOpen) return;

			string com = comSelect.Text;
			string baud = baudrate.Text;

			if (com.Length == 0 || baud.Length == 0)
			{
				console.AppendText("串口和波特率都不能为空\r\n");
				return;
			}

			serial.PortName = com;
			serial.BaudRate = Int32.Parse(baud);

			serial.RtsEnable = false;
			serial.DtrEnable = false;
			serial.ReceiveTimeoutEnable = true;
			serial.ReceiveTimeout = 5;
			try
			{
				serial.Open();
			}
			catch(UnauthorizedAccessException e)
			{
				new Thread(new ThreadStart(() => { Thread.Sleep(300); MessageBox.Show(e.Message, "串口无法打开", MessageBoxButtons.OK, MessageBoxIcon.Warning);  })).Start();
				console.AppendText($"串口无法打开\r\n{e.Message}\r\n");
				return;
			}

			opencloseCom.Text = "关闭";
			comSelect.Enabled = false;
			baudrate.Enabled = false;
		}

		void closeSerial()
		{
			if (!serial.IsOpen) return;

			serial.Close();

			opencloseCom.Text = "打开";
			comSelect.Enabled = true;
			baudrate.Enabled = true;
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Visible = !Visible;
		}

		private void updateComList()
		{
			comSelect.Items.Clear();

			comSelect.Items.AddRange(CustomSerialPort.GetPortNames());

			foreach (var item in typeof(Keys).GetFields())
			{
				keyCode.Items.Add(item.Name);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			updateComList();

			FileInfo fi = new FileInfo("config.json");
			if (fi.Exists)
			{
				string fileContent = File.ReadAllText("config.json", Encoding.UTF8);

				JObject root = JsonConvert.DeserializeObject<JObject>(fileContent);

				state.Checked = (bool)root["enable"];
				var lastBaudrate = (int)root["last_baudrate"];
				var lastCom = (string)root["last_com"];
				startMinimun.Checked = (bool)root["start_minimun"];
				startOpen.Checked = (bool)root["start_open"];

				if (lastBaudrate != 0)
				{
					baudrate.Text = lastBaudrate.ToString();
				}
				else
				{
					baudrate.SelectedIndex = 2;
				}

				if (comSelect.Items.Count == 1 && lastCom.Length == 0)
				{
					comSelect.SelectedIndex = 0;
				}
				else
				{
					foreach (var item in CustomSerialPort.GetPortNames())
					{
						if (item == lastCom)
						{
							comSelect.Text = lastCom;
							break;
						}

					}
				}

				if (startMinimun.Checked)
				{
					Thread thread = new Thread(new ThreadStart(() =>
					{
						Thread.Sleep(1000);
						Visible = false;
					}));
					thread.Start();
				}

				if (startOpen.Checked)
				{
					openSerial();
				}

				JArray ja = (JArray)root["pairs"];
				foreach (var item in ja)
				{
					RulePair rp = new RulePair();
					rp.keyCode = (string)item["keycode"];
					rp.lable = (string)item["lable"];

					pairs.Add(Int32.Parse((string)item["ircode"]), rp);
				}

				updateRulesList();

				//rulesList.Items.
			}



		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (serial != null)
			{
				closeSerial();
			}

			saveConfig();
		}

		void saveConfig()
		{
			JObject root = new JObject();
			root.Add("enable", state.Checked);
			root.Add("last_baudrate", baudrate.Text.Length == 0 ? 0 : Int32.Parse(baudrate.Text));
			root.Add("last_com", comSelect.Text);
			root.Add("start_minimun", startMinimun.Checked);
			root.Add("start_open", startOpen.Checked);
			JArray ja = new JArray();

			foreach (var item in pairs)
			{
				JObject jo = new JObject();
				jo.Add("ircode", item.Key);
				jo.Add("keycode", item.Value.keyCode);
				jo.Add("lable", item.Value.lable);
				ja.Add(jo);
			}
			root.Add("pairs", ja);

			File.WriteAllText("config.json", root.ToString(), Encoding.UTF8);
		}

		private void opencloseCom_Click(object sender, EventArgs e)
		{
			if (serial.IsOpen)
			{
				closeSerial();
			}
			else
			{
				openSerial();
			}
		}

		void updateRulesList()
		{
			rulesList.Items.Clear();
			foreach (var item in pairs)
			{
				string temp = $"{item.Key} : {item.Value}";
				temp = String.Format("{0,-8}|{1,-2:X2}|{2}", item.Value.lable, item.Key, item.Value.keyCode); // 25 | CTRL+A
				MyRow mr = new MyRow();
				mr.irCode = item.Key;
				mr.str = temp;
				rulesList.Items.Add(mr);
			}
		}

		private void IRCode_TextChanged(object sender, EventArgs e)
		{

		}

		private void addRule_Click(object sender, EventArgs e)
		{
			string ircode = IRCode.Text;
			string keycode = keyCode.Text;
			string lableText = lable.Text;

			if (ircode.Length == 0 || keycode.Length == 0 || lableText.Length == 0)
			{
				console.AppendText("红外、键值、标签都不能为空\r\n");
				return;
			}

			if (!Regex.IsMatch(ircode, "^[0-9a-fA-F]+$"))
			{
				console.AppendText("红外码只能是十六进制数字\r\n");
				return;
			}

			if (Int32.Parse(ircode) == 0)
			{
				console.AppendText("红外码不能是0\r\n");
				return;
			}

			if (pairs.ContainsKey(Int32.Parse(ircode)))
			{
				console.AppendText(ircode + "已经在列表中了\r\n");
				return;
			}

			RulePair rp = new RulePair();
			rp.keyCode = keycode;
			rp.lable = lableText;

			pairs.Add(Convert.ToInt32("0x"+ircode, 16), rp);
			IRCode.Text = "";
			keyCode.Text = "";
			lable.Text = "";

			updateRulesList();
		}

		private void removeRule_Click(object sender, EventArgs e)
		{
			if (rulesList.SelectedIndex != -1)
			{
				if (rulesList.SelectedItem is MyRow)
				{
					MyRow mr = rulesList.SelectedItem as MyRow;
					pairs.Remove(mr.irCode);
					rulesList.Items.RemoveAt(rulesList.SelectedIndex);
				}
			}
		}

		private void editRule_Click(object sender, EventArgs e)
		{
			if (rulesList.SelectedIndex != -1)
			{
				if (rulesList.SelectedItem is MyRow)
				{
					MyRow mr = rulesList.SelectedItem as MyRow;
					IRCode.Text = mr.irCode.ToString("x");
					keyCode.Text = pairs[mr.irCode].keyCode;
					lable.Text = pairs[mr.irCode].lable;
					rulesList.Items.RemoveAt(rulesList.SelectedIndex);
					pairs.Remove(mr.irCode);
				}
			}
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void comSelect_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void clear_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{
			console.Text = "";
		}

		private void label2_Click(object sender, EventArgs e)
		{
			new Form2().Show();
		}

		private void rulesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rulesList.SelectedIndex != -1)
			{
				MyRow mr = rulesList.SelectedItem as MyRow;
				preview.Text = pairs[mr.irCode].keyCode;
			}

		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				WindowState = FormWindowState.Normal;
				Visible = false;

				saveConfig();
			}

		}
		private void ComSelect_GotFocus(object sender, System.EventArgs e)
		{
			updateComList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ripasso_pre_rientro_form
{
	public partial class Form1 : Form
	{
		public string path = @"..\..\..\file\caslini.csv";
		public int l = 0;

		Funzioniesterne a;
		public  Form1()
		{
			InitializeComponent();
			a = new Funzioniesterne();
		}

		private void Form1_Load(object sender, EventArgs e)
		{ 

		}

		private void button1_Click(object sender, EventArgs e)
		{
			a.miovalore();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			a.Contacampi();

			int nc = a.Contacampi();

			MessageBox.Show("Il numero dei campi è:" + nc);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (StreamReader sw = new StreamReader(path))
			{
				int d = 0;

				string a = sw.ReadLine();

				string[] campi = a.Split(';');

				int[] arr = new int[(campi.Length) + 1];

				for (int i = 0; i < campi.Length; i++)
				{
					arr[d] = campi[i].Length;
					d++;
				}
				arr[(arr.Length) - 1] = a.Length;

				while (a != null)
				{
					d= 0;

					string[] campi2 = a.Split(';');

					for (int i = 0; i < campi2.Length; i++)
					{
						if (arr[d] < campi2[i].Length)
						{
							arr[d] = campi2[i].Length;
						}

						d++;
					}

					if (arr[(arr.Length) - 1] < a.Length)
					{
						arr[(arr.Length) - 1] = a.Length;
					}

					a = sw.ReadLine();

				}

				d = 0;

				

				for (int i = 0; i < arr.Length; i++)
				{
					if (i != arr.Length - 1)
					{
					  MessageBox.Show("Lunghezza campo " + d.ToString() + ": " + arr[i]);
					}
					else
					{
						MessageBox.Show("Lunghezza record " + d.ToString() + ": " + (arr[arr.Length - 1] + 1));
					}
					d++;
				}

				l = arr[arr.Length - 1];
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (l == 0)
			{

				MessageBox.Show("Calcolare prima lunghezza del record più lungo ");
			}
			else
			{
				
				a.LunghezzaFIX(l);
				MessageBox.Show("Tutti i record hanno la stessa lunghezza");
			}


		}
		private void button5_Click(object sender, EventArgs e)
		{
			a.Aggiuntarecord(textBox1.Text, textBox2.Text, textBox3.Text);
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";

		}

		private void button6_Click(object sender, EventArgs e)
		{
			string y = textBox4.Text;
			string x = textBox5.Text;
			string z = textBox6.Text;

			int y1 = 0;
			int x1 = 0;
			int z1 = 0;

			bool y2 = false;
			bool x2 = false;
			bool z2 = false;

			using (StreamReader sw = new StreamReader(path))
			{
				string d = sw.ReadLine();

				string[] c = d.Split(';');

				int dim = 0;

				for (int i = 0; i < c.Length; i++)
				{
					if (y == c[dim])
					{
						y1 = dim;
					}
					if (x == c[dim])
					{
						x1 = dim;
					}
					if (z == c[dim])
					{
						z1 = dim;
					}

					if (y == "")
					{
						y2 = true;
					}
					if (x == "")
					{
						x2 = true;
					}
					if (z == "")
					{
						z2 = true;
					}

					dim++;
				}

			}

			using (StreamReader sw = new StreamReader(path))
			{
				string d = sw.ReadLine();

				while (d != null)
				{

					string[] campi = d.Split(';');

					if (y2 == true)
					{
						listView1.Items.Add("Campo1: ");
					}
					else
					{
						listView1.Items.Add("Campo1: " + campi[y1]);
					}

					if (x2 == true)
					{
						listView1.Items.Add("Campo2: ");
					}
					else
					{
						listView1.Items.Add("Campo2: " + campi[x1]);
					}

					if (z2 == true)
					{
						listView1.Items.Add("Campo3: ");
					}
					else
					{
						listView1.Items.Add("Campo3: " + campi[z1]);
					}

					listView1.Items.Add("");

					d = sw.ReadLine();

				}
			}

			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
		}

		private void button7_Click(object sender, EventArgs e)
		{
			MessageBox.Show(a.ricerca());
		}

		private void button8_Click(object sender, EventArgs e)
		{
			a.Modifica(textBox10.Text, textBox11.Text, textBox12.Text);
			
		}
		private void button9_Click(object sender, EventArgs e)
		{
			a.Cancellazionelogica(textBox8.Text);
			
		}
	}
}

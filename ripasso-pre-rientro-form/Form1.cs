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





	}
}

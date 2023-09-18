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
using static ripasso_pre_rientro_form.Funzioniesterne;
namespace ripasso_pre_rientro_form
{
	public partial class Form1 : Form
	{
		public string path = @"..\..\..\file\caslini.csv";
		public int l = 0, fisso=0;

		
		public  Form1()
		{
			InitializeComponent();
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			miovalore(fisso, path);
		}
		private void button2_Click(object sender, EventArgs e)
		{
			Contacampi( fisso, path);

			int nc = Contacampi(fisso, path);

			MessageBox.Show("Il numero dei campi è:" + nc);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			  int []arr=LunghezzaMaxRecord(path);
			  int d = 0;
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

		private void button4_Click(object sender, EventArgs e)
		{
			if (l == 0)
			{

				MessageBox.Show("Calcolare prima lunghezza del record più lungo ");
			}
			else
			{
				
				fisso=LunghezzaFIX(fisso,l,path)+2;
				MessageBox.Show("Tutti i record hanno la stessa lunghezza");
			}


		}
		private void button5_Click(object sender, EventArgs e)
		{
			Aggiuntarecord(textBox1.Text, textBox2.Text, textBox3.Text,path,fisso);
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";

		}

		private void button6_Click(object sender, EventArgs e)
		{
			Visualizza();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			
			MessageBox.Show("L'elemento ricercato si trova nella posizione:" + ricerca(checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, textBox7.Text, textBox8.Text, textBox9.Text, path, fisso));
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Modifica(textBox10.Text, textBox11.Text, textBox12.Text,path);
			
		}
		private void button9_Click(object sender, EventArgs e)
		{
			Cancellazionelogica(textBox13.Text,path);
			
		}

		public void Visualizza()
		{
			string[]lines = File.ReadAllLines(path);
			dataGridView1.Rows.Clear();
			string y = textBox4.Text;
			string x = textBox5.Text;
			string z = textBox6.Text;

			int y1 = 0;
			int x1 = 0;
			int z1 = 0;

			bool y2 = false;
			bool x2 = false;
			bool z2 = false;


			byte[] bytes = new byte[fisso];
			UTF8Encoding e = new UTF8Encoding(true);
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				int dim = 0;
				fs.Read(bytes, 0, fisso);
				fs.Position += 2;
				string line = e.GetString(bytes);
				string[] campi = line.Split(';');

				for (; dim < campi.Length; dim++)
				{


					if (y == campi[dim])
					{
						y1 = dim;
					}
					if (x == campi[dim])
					{
						x1 = dim;
					}
					if (z == campi[dim])
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
				}

				
				while (fs.Read(bytes, 0, fisso) > 0)
				{
					fs.Position += 2;
					line = e.GetString(bytes);
					campi = line.Split(';');
					string[] row = new string[3];

					if (!y2)
					{
						row[0] = campi[y1];
					}


					if (!x2)
					{
						row[1] = campi[x1];
					}


					if (!z2)
					{
						row[2] = campi[z1];
					}


					dataGridView1.Rows.Add(row[0], row[1], row[2]);
				}
			}
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
		}


		

	}
}

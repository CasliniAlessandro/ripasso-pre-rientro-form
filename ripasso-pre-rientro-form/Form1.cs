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

			fisso=LunghezzaFIX(fisso, path) + 2;
			miovalore(fisso, path);
			Visualizza();
			
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
			int[] arr = LunghezzaMaxRecord(path);
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
				fisso=LunghezzaFIX(fisso,path)+2;
				MessageBox.Show("Tutti i record hanno la stessa lunghezza");
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
			if (int.Parse(txtLine.Text) > 0)
			{
				Modifica(txtLine.Text, txtRegione.Text, txtAnno.Text, txtStalli.Text, txtMiovalore.Text, fisso, path);

			}
			else 
		  {
				MessageBox.Show(" deve essere maggiore di 0");
			}

			
			
		}
		private void button9_Click(object sender, EventArgs e)
		{
			Cancellazionelogica(txtCanclog.Text,fisso,path);
			
		}


		public void Visualizza()
		{
			listView1.Clear();
		  
			byte[] bytes = new byte[fisso];
			UTF8Encoding e = new UTF8Encoding(true);
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				fs.Read(bytes, 0, fisso);
				string line = e.GetString(bytes).TrimEnd();
				string[]campi=line.Split(';');
				ColumnHeader[] ch = new ColumnHeader[campi.Length];

				ch[0] = new ColumnHeader
				{
					Text = "linea",
					Width = -2,
					TextAlign = HorizontalAlignment.Center
				};
				for (int i = 0; i < campi.Length - 1; i++) //salta logic
					ch[i + 1] = new ColumnHeader
					{
						Text = campi[i],
						Width = -2,
						TextAlign = HorizontalAlignment.Center
					};
				listView1.Columns.AddRange(ch);



				ListViewItem item;

				for(int i=1;fs.Read(bytes, 0, fisso) > 0;i++)
				{
					line = e.GetString(bytes).TrimEnd();
					if (line.EndsWith("1")) continue; //skippa le linee cancellate.

					campi = line.Split(';');
					item = new ListViewItem($"{i}");
					for(int j = 0;j<campi.Length-1;j++)
					{
						item.SubItems.Add(campi[j]);							
					}
					listView1.Items.Add(item);	
				}
				for (int i = 0; i < campi.Length; i++)
				{
					ch[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

				}
			}
		}
		


		

	}
}

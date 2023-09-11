using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ripasso_pre_rientro_form
{
	
	internal class Funzioniesterne
	{
		public string path = @"..\..\..\file\caslini.csv";
		

		//funzione
		public void miovalore(char sep = ';')
		{
			string[] linea = File.ReadAllLines(path);
			if (File.Exists(path))
			{
				using (StreamWriter sw = new StreamWriter(path))
				{
					Random r = new Random();
					linea[0] += ";miovalore";
					sw.WriteLine(linea[0]);
					for (int i = 1; i < linea.Length; i++)
					{
						linea[i] += sep + r.Next(10, 21).ToString();
						sw.WriteLine(linea[i]);
					}
				}
			}
		}

		//funzione

		public int Contacampi()
		{

			using (StreamReader sw = new StreamReader(path))
			{
				string nc = sw.ReadLine();

				string[] campi = nc.Split(';');

				int y = campi.Length;

				return y;
			}

		}

		//funzione

		public void LunghezzaFIX(int lung)
		{

			int[] c = new int[1000];

			string[] c2 = new string[1000];

			int dim = 0;

			using (StreamReader sw = new StreamReader(path))
			{
				string a;

				a = sw.ReadLine();

				while (a != null)
				{
					int b = a.Length;

					c[dim] = lung - b;

					c2[dim] = a;

					dim++;

					a = sw.ReadLine();
				}

			}

			using (StreamWriter sw = new StreamWriter(path))
			{
				dim = 0;

				while (c2[dim] != null)
				{

					string a = null;

					for (int j = 0; j < c[dim]; j++)
					{
						a = a + " ";
					}

					sw.WriteLine(c2[dim] + a);

					dim++;
				}
			}

		}

		//funzione

		public void Aggiuntarecord(string coda1, string coda2, string coda3)
		{
			bool[] a = new bool[1000];

			string[] p = new string[1000];

			int dim = 0;

			using (StreamReader sw = new StreamReader(path))
			{
				string b = sw.ReadLine();

				while (b != null)
				{
					a[dim] = true;

					p[dim] = b;

					b = sw.ReadLine();

					dim++;
				}

				if (b == null)
				{
					a[dim] = false;
				}

			}

			using (StreamWriter sw = new StreamWriter(path))
			{
				dim = 0;

				while (dim < 1000)
				{

					if (a[dim] == false)
					{
						sw.WriteLine(coda1 + ";" + coda2 + ";" + coda3 + ";");
						break;
					}
					sw.WriteLine(p[dim]);
					dim++;
				}
			}
		}
		//funzione

		public string ricerca( bool checkBox1, bool checkBox2, bool checkBox3,string textBox7, string textBox8,string textBox9)
		{
			
			string[] record = File.ReadAllLines(path);
			for (int i = 0; i < record.Length; i++)
			{
			
				string[] campi = record[i].Split(';');
				if (checkBox1 == true)
				{
					if (campi[0].ToLower() == textBox7.ToLower())
					{
						return record[i];

					}
					if (checkBox2 == true)
					{
						if (campi[1].ToLower() == textBox8.ToLower())
						{
							return record[i];

						}
					}
					if (checkBox3 == true)
					{
						if (campi[2].ToLower() == textBox9.ToLower())
						{
							return record[i];
						}
					}
				}

			}
			return "";
		}
		//funzione
		public void Modifica(string a1, string a2, string a3)
		{
			string a = a1;

			string[] ele = new string[1000];

			int dim = 0;

			int control = 0;

			using (StreamReader sw = new StreamReader(path))
			{
				string b = sw.ReadLine();

				while (b != null)
				{
					ele[dim] = b;

					string[] campi = ele[dim].Split(';');

					for (int i = 0; i < campi.Length; i++)
					{
						if (campi[i] == a)
						{
							control = dim;
						}
					}

					dim++;

					b = sw.ReadLine();
				}
			}

			using (StreamWriter sw = new StreamWriter(path))
			{
				dim = 0;

				string r = "";

				while (ele[dim] != null)
				{
					if (dim == control)
					{
						string[] campi2 = ele[dim].Split(';');

						if (a2 != null)
						{
							r = r + a2;
						}
						else
						{
							string[] campi3 = ele[dim].Split(';');
							r = r + campi3[dim];
						}

						if (a3 != null)
						{
							r = r + ";" + a3;
						}
						else
						{
							string[] campi4 = ele[dim].Split(';');
							r = r + ";" + campi4[dim];
						}



						sw.WriteLine(r);
					}
					else
					{
						sw.WriteLine(ele[dim]);
					}

					dim++;
				}
			}
		}

		//funzione
		public void Cancellazionelogica(string a1)
		{
			bool[] a = new bool[1000];

			string[] a2 = new string[1000];

			string c = a1;

			int dim = 0;

			using (StreamReader sw = new StreamReader(path))
			{
				string b = sw.ReadLine();

				while (b != null)
				{
					a2[dim] = b;

					string[] campi = b.Split(';');

					if (campi[0] == c)
					{
						a[dim] = false;
					}
					else
					{
						a[dim] = true;
					}
					dim++;

					b = sw.ReadLine();
				}
			}

			using (StreamWriter sw = new StreamWriter(path))
			{
				dim = 0;

				while (a2[dim] != null)
				{

					if (a[dim] == true)
					{
						sw.WriteLine(a2[dim]);
					}
					dim++;
				}
			}
		}
	}

}



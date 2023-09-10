using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		


	}

}



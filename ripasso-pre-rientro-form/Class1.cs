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

	static public class Funzioniesterne
	{



		//funzione
		static public bool miovalore(int fisso, string path)
		{
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
			{
				byte[] b = new byte[fisso];
				UTF8Encoding enc = new UTF8Encoding(true);
				fs.Read(b, 0, fisso);
				string line = enc.GetString(b).TrimEnd();

				string[] split = line.Split(';');
				for (int i = 0; i < split.Length; i++)
					if (split[i] == "miovalore") return false;

				fs.Position = enc.GetBytes(line).Length;
				m
				byte[] info = enc.GetBytes(";miovalore");
				fs.Write(info, 0, info.Length);

				fs.Position = fisso + 2;
				for (int lin = 2, pos; fs.Read(b, 0, fisso) > 0; lin++)
				{
					line = enc.GetString(b);
					pos = enc.GetBytes(line.TrimEnd()).Length;
					fs.Position = fs.Position - fisso + pos;


					line = $";{new Random(lin * Environment.TickCount).Next(10, 20 + 1)}";
					info = enc.GetBytes(line);
					fs.Write(info, 0, info.Length);

					fs.Position = (fisso + 2) * lin;
				}
			}
			return true;
		}

		//funzione

		static public int Contacampi(int fisso, string path)
		{

			using (FileStream sw = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				byte[] b = new byte[fisso];
				sw.Read(b, 0, fisso);
				return new UTF8Encoding(true).GetString(b).Split(';').Length;
			}

		}

    //funzione
		static public int[] LunghezzaMaxRecord(string path)
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
					d = 0;

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
				return arr;
			}
		}

		//funzione

		static public int LunghezzaFIX(int fisso, int l, string path)
		{
			int nfdi;
			if (l < 100) nfdi = 200; else nfdi = l / 100 * 100 + 200;


			if (fisso != nfdi)
			{
				string tpath = Path.GetDirectoryName(path) + "\\temp.csv";
				File.Copy(path, tpath, true);
				using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None))
				{
					using (FileStream temp = new FileStream(tpath, FileMode.Open, FileAccess.Read, FileShare.None))
					{
						UTF8Encoding enc = new UTF8Encoding(true);
						int b;
						string line = "";
						while ((b = temp.ReadByte()) > 0)
							if ((char)b == '\n')
							{

								Byte[] info = enc.GetBytes(line.TrimEnd(' ', '\r').PadRight(nfdi) + "\r\n");
								fs.Write(info, 0, info.Length);
								line = "";
							}
							else
								line += (char)b;


						fs.SetLength(fs.Position);
					}
					File.Delete(tpath);
				}
			}
			return nfdi;
		}

		//funzione

		static public void Aggiuntarecord(string coda1, string coda2, string coda3, string path, int fisso)
		{
			bool[] a = new bool[1000];

			string[] p = new string[1000];

			int dim = 0;
			byte[] bytes = new byte[1000];
			UTF8Encoding e = new UTF8Encoding(true);
			string line = null;

			using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
			{
				line = $"{coda1};{coda2};{coda3};{new Random().Next(10, 21)};0".PadRight(fisso) + Environment.NewLine;
				bytes = e.GetBytes(line);

				fs.Write(bytes, 0, bytes.Length);
			}
		}

		//funzione

		static public string ricerca(bool checkBox1, bool checkBox2, bool checkBox3, string textBox7, string textBox8, string textBox9, string path, int fisso)
		{
			byte[] bytes = new byte[fisso];
			UTF8Encoding e = new UTF8Encoding(true);
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				while (fs.Read(bytes, 0, fisso) > 0)
				{
					string line = e.GetString(bytes);
					string[] campi = line.Split(';');
					if (checkBox1)
					{
						if (campi[0].ToLower() == textBox7.ToLower())
						{
							return line;

						}
						if (checkBox2)
						{
							if (campi[1].ToLower() == textBox8.ToLower())
							{
								return line;

							}
						}
						if (checkBox3)
						{
							if (campi[2].ToLower() == textBox9.ToLower())
							{
								return line;
							}
						}
					}

				}
			}
			return "";
		}
		//funzione
		static public void Modifica(string a1, string a2, string a3, string path)
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
		static public void Cancellazionelogica(string a1, string path)
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



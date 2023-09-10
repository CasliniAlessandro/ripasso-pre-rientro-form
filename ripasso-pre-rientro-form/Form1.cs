using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ripasso_pre_rientro_form
{
	public partial class Form1 : Form
	{
		public string path = @"../../caslini.csv";
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
	}
}

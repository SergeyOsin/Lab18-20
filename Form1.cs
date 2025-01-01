using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Осин_23ВП2 : Form
    {
        const int SIZE = 15;
        int[] array = new int[SIZE];
        Random rd = new Random();
        public Осин_23ВП2()
        {
            InitializeComponent();
        }

        private void Осин_23ВП2_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 15;
            for (int i = 0; i < 15; i++)
            {
                array[i] = rd.Next(10, 100);
                dataGridView1.Columns[i].Width = 35;
        }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[0].Cells[i].Value = array[i];
        }
    }
}

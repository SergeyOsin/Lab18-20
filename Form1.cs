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
        void CreateTable()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView3.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 15;
            for (int i = 0; i < 15; i++)
                dataGridView1.Columns[i].Width = 40;
            dataGridView2.RowCount = 4;
            dataGridView2.ColumnCount = 15;
            for (int i = 0; i < 15; i++)
                dataGridView2.Columns[i].Width = 40;
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = 15;
            for (int k = 0; k < 15; k++)
                dataGridView3.Columns[k].Width = 40;
        }
        private void Осин_23ВП2_Load(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                array[i] = rd.Next(0, 100);
                if (array[i] == 0)
                    dataGridView1.Rows[0].Cells[i].Value = " ";
                else dataGridView1.Rows[0].Cells[i].Value = array[i];
            }
        }
        private void deletequeue()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[0].Cells[i].Value = " ";
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            deletequeue();
        }
    }
}

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
        private void become_to_heap(int[]arr,int SIZE,int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // левый = 2*i + 1
            int r = 2 * i + 2; // правый = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < SIZE && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < SIZE && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                become_to_heap(arr, SIZE, largest);
            }
        }
        private void print(int[] array1)
        {
            int number_str = 0;
            int pos = SIZE / 2;
            int step = SIZE;
            int index = 0;
            while (step > 0)
            {
                for(int pos1=pos;pos1<SIZE;pos1+=step+1)
                {
                    dataGridView2.Rows[number_str].Cells[pos1].Value = array[index++];
                }
                step /= 2;
                pos /= 2;
                number_str++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                array[i] = rd.Next(0, 100);
            }
            for (int i = SIZE / 2 - 1; i >= 0; i--)
                become_to_heap(array, SIZE, i);
            for (int i = 0; i < SIZE; i++)
                dataGridView1.Rows[0].Cells[i].Value = array[i];
            print(array);
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

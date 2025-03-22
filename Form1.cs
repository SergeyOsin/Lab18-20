using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
        int[] array_max = new int[SIZE+1];
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
            Application.Exit();
        }
        private void print(int[] array1)
        {
            for (int i = 0; i < SIZE; i++)
                dataGridView1.Rows[0].Cells[i].Value = (array1[i] == 0) ? " " : array[i].ToString();
            int number_str = 0;
            int pos = SIZE / 2;
            int step = SIZE;
            int index = 0;
            while (step > 0)
            {
                for (int pos1 = pos; pos1 < SIZE; pos1 += step + 1)
                    dataGridView2.Rows[number_str].Cells[pos1].Value = dataGridView1.Rows[0].Cells[index++].Value;
                step /= 2;
                pos /= 2;
                number_str++;
            }
        }
        private void toDown(int[]array3,int index,int size_array)
        {
            while (2 * index+1 < size_array)
            {
                int index_j = 2 * index + 1;
                if (index_j < size_array && array3[index_j] < array3[index_j + 1]) index_j++;
                if (array3[index] >= array3[index_j]) break;
                (array3[index], array3[index_j]) = (array3[index_j], array3[index]);
                index = index_j;
            }
        }
        private void toUP(int[]array2,int index)
        {
            while (index>0 && array2[(index-1)/ 2] < array2[index])
            {
                (array2[index], array2[(index - 1) / 2]) = (array2[(index - 1) / 2], array2[index]);
                index = (index - 1) / 2;
            }
        }
        private void InsertElement(int index_i)
        {
            array[index_i] = rd.Next(10, 99);
            toUP(array, index_i);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SIZE; i++)
                InsertElement(i);
            print(array);
        }
        private void Clear_Tab()
        {
            if (array.Count(i=>i==0) == SIZE)
            {
                MesBox("Очередь пуста!");
                return;
            }
            array = Enumerable.Repeat(0, SIZE).ToArray(); //Обнуление массива А.
            array_max = Enumerable.Repeat(0, SIZE).ToArray(); 
            for (int i = 0; i < dataGridView1.ColumnCount; i++) {
                dataGridView1.Rows[0].Cells[i].Value = " ";
                dataGridView3.Rows[0].Cells[i].Value = " ";
            }
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                for (int j = 0; j < dataGridView2.RowCount; j++)
                    dataGridView2.Rows[j].Cells[i].Value = " ";
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clear_Tab();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (array.Count(i => i == 0) == 0)
            {
                MesBox("Очередь переполнена!");
                return;
            }
            int new_element = Convert.ToInt32(numericUpDown1.Value);
            int index_zero = Array.IndexOf(array, 0);
            array[index_zero] = new_element;
            toUP(array, index_zero);
            print(array);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (array.Count(i => i == 0) == SIZE)
            {
                MesBox("Очередь пуста!");
                return;
            }
            int ind_empty;
            for (ind_empty = 0; array_max[ind_empty] != 0; ind_empty++) ;
            if (ind_empty == SIZE)
            {
                MesBox("Результат выборки переполнен!");
                return;
            }
            array_max[ind_empty] = array[0];
            dataGridView3.Rows[0].Cells[ind_empty].Value = array[0];
            int index_zero = Array.IndexOf(array, 0);
            index_zero = (index_zero < 0) ? SIZE - 1 : index_zero - 1;
            array[0] = array[index_zero];
            array[index_zero] = 0;
            toDown(array, 0, SIZE);
            print(array);
        }
        private void MesBox(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (array.Count(i => i == 0)==SIZE)
            {
                MesBox("Очередь пустая!");
                return;
            }  
            int element = Convert.ToInt32(numericUpDown3.Value);
            int index_element = Array.IndexOf(array, element);
            if (index_element == -1)
            {
                MesBox("Элемент отсутствует в массиве!");
                return; 
            }
            int new_element = Convert.ToInt32(numericUpDown2.Value);
            array[index_element] = new_element;
            if (element > new_element) toDown(array, index_element, SIZE);
            else toUP(array, index_element);
            print(array);
        }
    }
}

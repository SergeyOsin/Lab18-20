using System;
using System.Collections;
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
            int left = 2 * i + 1; // левый = 2*i + 1
            int right = 2 * i + 2; // правый = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (left<SIZE && arr[left] > arr[largest])
                largest = left;
            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (right<SIZE && arr[right] > arr[largest])
                largest = right;
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
            for (int i = 0; i < SIZE; i++)
            {
                if (array1[i] == 0)
                    dataGridView1.Rows[0].Cells[i].Value = " ";
                else dataGridView1.Rows[0].Cells[i].Value = array1[i];
            }
            int number_str = 0;
            int pos = SIZE / 2;
            int step = SIZE;
            int index = 0;
            while (step > 0)
            {
                for (int pos1 = pos; pos1 < SIZE; pos1 += step + 1)
                {
                    if (array1[index] == 0)
                        dataGridView2.Rows[number_str].Cells[pos1].Value = " ";
                    else dataGridView2.Rows[number_str].Cells[pos1].Value = array1[index];
                    index++;
                }
                step /= 2;
                pos /= 2;
                number_str++;
            }
        }
        private void toDown(int[]array3,int index,int size_array)
        {
            while (2 * index <= size_array)
            {
                int index_j = 2 * index;
                if (index_j < size_array && array3[index_j] < array3[index_j + 1]) index_j++;
                if (array3[index] >= array3[index_j]) break;
                (array3[index], array3[index_j]) = (array3[index_j], array3[index]);
                index = index_j;
            }
        }
        private void toUP(int[]array2,int index)
        {
            while (index>0 && array2[index/ 2] <= array2[index])
            {
                (array2[index], array2[index / 2]) = (array2[index / 2], array2[index]);
                index /= 2;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < SIZE; i++)
            {
                array[i] = rd.Next(10, 99);
                toUP(array, i);
            }
            print(array);
        }
        private void Clear_Tab()
        {
            array = Enumerable.Repeat(0, SIZE).ToArray(); //Обнуление массива А.
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[0].Cells[i].Value = " ";
            print(array);
            for (int j = 0; j < dataGridView3.ColumnCount; j++)
                dataGridView3.Rows[0].Cells[j].Value = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear_Tab();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace ЛР_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            for(int i = 0; i<checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    CreateSerie(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовые файлы(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            filename = openFileDialog1.FileName;
            ReadFile(filename);
        }
        private double[,] Coords;
 
        public void ReadFile(string file)
        {
            Coords = new double[15,2];
            var sr = new StreamReader (file);
            string line;
            int point = 0;
            int ser = 1;

            while ((line = sr.ReadLine()) != null)
            {
                string[] splitLine = line.Split(' ');
                Coords[point,0] = Convert.ToDouble(splitLine[0]);
                Coords[point,1] = Convert.ToDouble(splitLine[1]);


                if (point % 5 == 0)
                {
                    string NameSeire = "Серия" + Convert.ToString(ser);
                    checkedListBox1.Items.Add(NameSeire);
                    ser++;
                }
                point++;
            }
        }
        public void CreateSerie(int NumSerie)
        {
         double x, y;
         string NameSerie = "Серия" + Convert.ToString(NumSerie + 1);
         chart1.Series.Add(new Series (NameSerie));
         chart1.Series[NameSerie].ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)4;
         chart1.Series[NameSerie].Enabled = true;
         chart1.Series[NameSerie].BorderWidth = 2;

            for (int p = 0; p<5;p++)
            {
                x = Coords[p+NumSerie*5,0];
                y = Coords[p+NumSerie*5,1];
                chart1.Series[NameSerie].Points.AddXY(x, y);
            }


        
        }

        private void comboBox1_SelectionChangeCommitted (object sender, EventArgs e)
        {
            int var = comboBox1.SelectedIndex;
            if (var == 1) var = 3;
            else
            if (var == 2) var = 4;

            foreach (Series ser in chart1.Series)

                ser.ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)var;
            
        }
        private void Form1_Resize (Object sender, EventArgs e)
        {
            button1.Location = new Point(splitContainer1.Panel1.Width / 2 - 60, splitContainer1.Panel1.Height / 20 - 8);
            label1.Location = new Point(splitContainer1.Panel1.Width / 2 - 67, splitContainer1.Panel1.Height / 10 + 9);
            checkedListBox1.Location = new Point(splitContainer1.Panel1.Width / 2 - 57, splitContainer1.Panel1.Height / 5 - 8);
            checkedListBox1.Height = splitContainer1.Panel1.Width / 2;
            button2.Location = new Point(splitContainer1.Panel1.Width / 2 - 62, splitContainer1.Panel1.Height - splitContainer1.Panel1.Height / 4 - 6);
            label2.Location = new Point(splitContainer1.Panel1.Width / 2 - 60, splitContainer1.Panel1.Height - splitContainer1.Panel1.Height / 5 + 13);
            comboBox1.Location = new Point(splitContainer1.Panel1.Width / 2 - 60, splitContainer1.Panel1.Height - splitContainer1.Panel1.Height / 5 + 40);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


    }
}

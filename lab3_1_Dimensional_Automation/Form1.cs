using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_1_Dimensional_Automation
{
    public partial class Form1 : Form
    {
        int sizeCells = 10;
        int[,] fieldColors;
        int countRows = 1;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            ClientSize = new Size(750, 600);
            MouseDown += Draw;
            DoubleBuffered = true;
            fieldColors = new int[(ClientSize.Width - 150) / sizeCells, ClientSize.Height / sizeCells];

            
        }
        protected override void OnPaint(PaintEventArgs e) 
        {
            InitCells(e.Graphics);
            InitGrid(e.Graphics);
        }
        
        private void Draw(object sender, MouseEventArgs e) 
        {
            var thisX = e.X;
            fieldColors[0, thisX / sizeCells] = fieldColors[0, thisX / sizeCells] == 1 ? 0 : 1;
            Invalidate();
        }

        string Converter()
        {
            int number = int.Parse(Number.Text);
            string binary = Convert.ToString(number, 2);
            int l = binary.Length;

            for (int i = 0; i < 8 - l; i++)
                binary = 0 + binary;
            return binary;
        }
        void Executor()
        {
            string rule = Converter();
            countRows = ClientSize.Height / sizeCells;
            for (int i = 1; i < countRows; i++) 
            {
                for (int j = 0; j < (ClientSize.Width - 150) / sizeCells; j++) 
                {
                    var l = j - 1;
                    var r = j + 1;
                    if (j==(ClientSize.Width-150)/sizeCells-1)
                    {
                        r = 0;
                    }
                    if (j==0)
                    {
                        l = (ClientSize.Width - 150) / sizeCells - 1;
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "111")
                    {
                        fieldColors[i, j] = int.Parse(rule[0].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "110")
                    {
                        fieldColors[i, j] = int.Parse(rule[1].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "101")
                    {
                        fieldColors[i, j] = int.Parse(rule[2].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "100")
                    {
                        fieldColors[i, j] = int.Parse(rule[3].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "011")
                    {
                        fieldColors[i, j] = int.Parse(rule[4].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "010")
                    {
                        fieldColors[i, j] = int.Parse(rule[5].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "001")
                    {
                        fieldColors[i, j] = int.Parse(rule[6].ToString());
                    }
                    if (fieldColors[i - 1, l].ToString() + fieldColors[i - 1, j].ToString() + fieldColors[i - 1, r].ToString() == "000")
                    {
                        fieldColors[i, j] = int.Parse(rule[7].ToString());
                    }
                } 
                    
            }
            Invalidate();
        }
        private void InitGrid(Graphics g)
        {
            for (int i = 0; i<= countRows; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(0, sizeCells * i), new Point(ClientSize.Width - 150, sizeCells*i));
            }
            for (int i = 0; i <= (ClientSize.Width - 150) / sizeCells; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(sizeCells * i,0), new Point(sizeCells * i,sizeCells*countRows));
            }
        }

        private void InitCells(Graphics g) 
        {
            for (int i = 0; i < (ClientSize.Width - 150) / sizeCells; i++)
            {
                    for (int j = 0; j < ClientSize.Height/sizeCells; j++)
                {
                    g.DrawLine(new Pen(fieldColors[i, j] == 1 ? Color.Black : Color.White, sizeCells), sizeCells * j, sizeCells * i + sizeCells/2, sizeCells * j + sizeCells, sizeCells * i + sizeCells/2);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Executor();
        }
    }
}

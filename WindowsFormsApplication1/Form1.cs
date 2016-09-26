using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;
       
        Button[] btn = new Button[9];

        private void WhoWin()
        {
            //[0][1][2]
            //[3][4][5]
            //[6][7][8]
            if((btn[0].Text=="X" && btn[1].Text == "X" && btn[2].Text == "X") ||
                (btn[3].Text == "X" && btn[4].Text == "X" && btn[5].Text == "X")||
                (btn[6].Text == "X" && btn[7].Text == "X" && btn[8].Text == "X")||
                (btn[0].Text == "X" && btn[3].Text == "X" && btn[6].Text == "X") ||
                (btn[1].Text == "X" && btn[4].Text == "X" && btn[7].Text == "X") ||
                (btn[2].Text == "X" && btn[5].Text == "X" && btn[8].Text == "X") ||
                (btn[0].Text == "X" && btn[4].Text == "X" && btn[8].Text == "X") ||
                (btn[6].Text == "X" && btn[4].Text == "X" && btn[2].Text == "X") )
            {
                MessageBox.Show("Player wins");
                reset();
            }else if((btn[0].Text == "O" && btn[1].Text == "O" && btn[2].Text == "O") ||
                (btn[3].Text == "O" && btn[4].Text == "O" && btn[5].Text == "O") ||
                (btn[6].Text == "O" && btn[7].Text == "O" && btn[8].Text == "O") ||
                (btn[0].Text == "O" && btn[3].Text == "O" && btn[6].Text == "O") ||
                (btn[1].Text == "O" && btn[4].Text == "O" && btn[7].Text == "O") ||
                (btn[2].Text == "O" && btn[5].Text == "O" && btn[8].Text == "O") ||
                (btn[0].Text == "O" && btn[4].Text == "O" && btn[8].Text == "O") ||
                (btn[6].Text == "O" && btn[4].Text == "O" && btn[2].Text == "O")){
                MessageBox.Show("Maquina wins");
                reset();
            }
        }

        private void Machine()
        {

            for (int i = 0; i <= 1; i++)
            {
                Random random = new Random();
                int numero = random.Next(1, 9);
                if (btn[numero].Text == "")
                {
                    btn[numero].Text = "O";
                    btn[numero].Enabled = false;
                    count++;
                    i = 1;
                }else
                {
                    i = 0;
                }

            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                btn[i] = new Button();
                btn[i].Width = 100;
                btn[i].Height = 100;
                btn[i].Click += new EventHandler(Form1_Click);
                flowLayoutPanel1.Controls.Add(btn[i]);
            }
        }
        void reset()
        {
            for (int i = 0; i < 9; i++)
            {
                btn[i].Enabled = true;
                btn[i].Text = "";
                count = 0;
            }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            
            Button boton = (Button)sender;
            count++;
            if (count == 9)
            {
                boton.Text = "X";
             
                WhoWin();
               
                MessageBox.Show("Game Draw");
                reset();
                
            }else if(count < 9)
            {  
                boton.Text = "X";
                boton.Enabled = false;
                Machine();
                WhoWin();
                
            }
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

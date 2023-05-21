using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ADB
{
    public partial class Secondavto : Form
    {
        public Secondavto()
        {
            InitializeComponent();
        }
        string q = "";
        int x = 0;
        int sum = 0;
        
        
        
        private void Secondavto_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("Select av_foto from avtomobiles WHERE av_name = @id.n ", db.getConnection());
            command.Parameters.Add("@id.n", MySqlDbType.String).Value = id.n;
            MySqlDataReader Reader = command.ExecuteReader();
            Reader.Read();
            if (Reader.HasRows)
            {

                byte[] img = (byte[])(Reader[0]);
                if (img == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {

                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else { MessageBox.Show(" Конец "); }
            db.closeConnection();
            DB d = new DB();
            d.openConnection();
            MySqlCommand comman = new MySqlCommand("Select av_name,av_dvig,av_complectaction,av_c_opic,av_color,av_trans,av_price,av_id FROM avtomobiles WHERE av_name = @id.n and av_status = 'В наличии'", d.getConnection());
            comman.Parameters.Add("@id.n", MySqlDbType.String).Value = id.n;
            MySqlDataReader reade = comman.ExecuteReader();
            reade.Read();
            if (reade.HasRows)
            {
                label1.Text = reade[0].ToString();
                label2.Text = reade[1].ToString();
                label3.Text = reade[2].ToString();
                label7.Text = reade[3].ToString();
                label4.Text = reade[4].ToString();
                label9.Text = reade[5].ToString();
                label5.Text = reade[6].ToString();
                sum = Int32.Parse(reade[7].ToString());
                
                
            }
            
            d.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x != 0 )
            {
                x--;
                sum--;
                while (true)
                {
                    DB db = new DB();
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("Select av_name, av_dvig, av_complectaction, av_c_opic, av_color, av_trans, av_price FROM avtomobiles WHERE av_id = @sum and av_status = 'В наличии'", db.getConnection());
                    command.Parameters.Add("@sum", MySqlDbType.String).Value = sum;
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {

                        label1.Text = reader[0].ToString();
                        label2.Text = reader[1].ToString();
                        label3.Text = reader[2].ToString();
                        label7.Text = reader[3].ToString();
                        label4.Text = reader[4].ToString();
                        label9.Text = reader[5].ToString();
                        label5.Text = reader[6].ToString();
                        DB d = new DB();
                        d.openConnection();
                        MySqlCommand comman = new MySqlCommand("Select av_foto from avtomobiles WHERE av_id = @sum ", d.getConnection());
                        comman.Parameters.Add("@sum", MySqlDbType.Int32).Value = sum;
                        MySqlDataReader Reade = comman.ExecuteReader();
                        Reade.Read();
                        if (Reade.HasRows)
                        {

                            byte[] img = (byte[])(Reade[0]);
                            if (img == null)
                            {
                                pictureBox1.Image = null;
                            }
                            else
                            {

                                MemoryStream ms = new MemoryStream(img);
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else { MessageBox.Show(" Конец "); }
                        d.closeConnection();
                    }
                    if (q == id.n)
                    {
                        
                        return;
                    }
                    else if (sum == 1) { return; }
                    else { sum--; };

                }
            }
            else { MessageBox.Show("Конец"); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string y = "";
            int count = 0;
            DB d = new DB();
            d.openConnection();
            MySqlCommand comman = new MySqlCommand("SELECT COUNT(*) FROM avtomobiles", d.getConnection());
            //comman.Parameters.Add("@id.n",MySqlDbType.String).Value = id.n;
            MySqlDataReader reade = comman.ExecuteReader();
            reade.Read();
            if (reade.HasRows)
            {
                
                y = reade[0].ToString();
                 count = Int32.Parse(y);
            }
            if (x < count-1)
            {
                x++;
                sum++;
                while (true)
                {
                    DB db = new DB();
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("Select av_name, av_dvig, av_complectaction, av_c_opic, av_color, av_trans, av_price FROM avtomobiles WHERE av_id = @sum and av_status = 'В наличии'", db.getConnection());
                    command.Parameters.Add("@sum", MySqlDbType.String).Value = sum;
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {

                        label1.Text = reader[0].ToString();
                        label2.Text = reader[1].ToString();
                        label3.Text = reader[2].ToString();
                        label7.Text = reader[3].ToString();
                        label4.Text = reader[4].ToString();
                        label9.Text = reader[5].ToString();
                        label5.Text = reader[6].ToString();
                        DB dbd = new DB();
                        dbd.openConnection();
                        MySqlCommand commandd = new MySqlCommand("Select av_foto from avtomobiles WHERE av_id = @sum ", dbd.getConnection());
                        commandd.Parameters.Add("@sum", MySqlDbType.Int32).Value = sum;
                        MySqlDataReader Readedd = commandd.ExecuteReader();
                        Readedd.Read();
                        if (Readedd.HasRows)
                        {

                            byte[] img = (byte[])(Readedd[0]);
                            if (img == null)
                            {
                                pictureBox1.Image = null;
                            }
                            else
                            {

                                MemoryStream ms = new MemoryStream(img);
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else { MessageBox.Show(" Конец "); }
                        dbd.closeConnection();
                    }
                    if (q == id.n)
                    {
                        
                        return;
                    }
                    else if (sum > count + 1) { return; }
                    else { sum++; };
                }
            }
            else { MessageBox.Show("Конец"); }
            
        }
    }
}

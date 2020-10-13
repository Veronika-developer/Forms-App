using Microsoft.VisualBasic;
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

namespace FormsApp
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl, kysimus;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2, t1, t2, t3;
        TextBox textbox;
        PictureBox pic_box;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox _listbox;
        bool fullScreen = true;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            //label
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            //
            tn.Nodes.Add(new TreeNode("Markeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstast-TextBox"));
            tn.Nodes.Add(new TreeNode("PictureBox-Pildikast"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                lbl = new Label();
                lbl.Text = "Tarkvara arendajad";
                lbl.Size = new Size(150, 30);
                lbl.Location = new Point(150, 200);
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Markeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;

            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(310, 30);
                r1.CheckedChanged += new EventHandler(RadioButton_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(310, 70);
                r2.CheckedChanged += new EventHandler(RadioButton_Changed);


                this.Controls.Add(r1);
                this.Controls.Add(r2);

            }
            else if (e.Node.Text == "Tekstast-TextBox")
            {
                string text;
                try
                {
                    text = File.ReadAllText("text.txt");
                }
                catch (FileNotFoundException)
                {
                    text = "Tekst puudub";
                }
                textbox = new TextBox();
                textbox.Multiline = true;
                textbox.Text = text;
                textbox.Location = new Point(300, 300);
                textbox.Width = 200;
                textbox.Height = 200;
                Controls.Add(textbox);
            }
            else if (e.Node.Text == "PictureBox-Pildikast")
            {
                pic_box = new PictureBox();
                pic_box.Image = new Bitmap("simson.jpg");
                pic_box.Location = new Point(450, 5);
                pic_box.Size = new Size(100, 100);
                pic_box.SizeMode = PictureBoxSizeMode.Zoom;
                pic_box.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pic_box);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                kysimus = new Label();
                kysimus.Text = "Millist vahelehte avada?";
                kysimus.Size = new Size(150, 20);
                kysimus.Location = new Point(350, 130);
                t1 = new RadioButton();
                t1.Text = "Esimene";
                t1.Location = new Point(350, 150);
                t1.CheckedChanged += new EventHandler(TabControlRadio);
                t2 = new RadioButton();
                t2.Text = "Teine";
                t2.Location = new Point(350, 170);
                t2.CheckedChanged += new EventHandler(TabControlRadio);
                t3 = new RadioButton();
                t3.Text = "Kolmas";
                t3.Location = new Point(350, 190);
                t3.CheckedChanged += new EventHandler(TabControlRadio);
                this.Controls.Add(t1);
                this.Controls.Add(t2);
                this.Controls.Add(t3);
                this.Controls.Add(kysimus);
            }
            else if (e.Node.Text == "-MessageBox")
            {
                MessageBox.Show("MessageBox","Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupu", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string tekstLBL = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekstkastisse?", "Teksti salvestamine",MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = tekstLBL;
                        Controls.Add(lbl);
                    }
                }
            }
            else if (e.Node.Text == "ListBox")
            {
                string [] listItems = new string[] { "Sinine", "Kollane", "Roheline", "Punane" };

                _listbox = new ListBox();

                for (int i = 0; i < listItems.Length; i++)
                {
                    _listbox.Items.Add(listItems[i]);
                }

                _listbox.Location = new Point(150,300);
                _listbox.Width = listItems.Length * 20;
                _listbox.Height = listItems.Length*15;
                _listbox.SelectedIndexChanged += _listbox_SelectedIndexChanged;
                this.Controls.Add(_listbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet _dataset = new DataSet("Näide");
                _dataset.ReadXml("..//..//XMLFile.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(200, 200);
                dgv.Width = 500;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "PLANT";
                dgv.DataSource = _dataset;
                this.Controls.Add(dgv);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem item = new MenuItem("File");
                item.MenuItems.Add("EXIT", new EventHandler(item_exit));
                MenuItem my = new MenuItem("My");
                my.MenuItems.Add("New", new EventHandler(item_new));
                my.MenuItems.Add("In full screen", new EventHandler(item_FullScreen));
                my.MenuItems.Add("Random backcolor", new EventHandler(item_random));
                menu.MenuItems.Add(item);
                menu.MenuItems.Add(my);
                this.Menu = menu;
            }
        }

        private void item_random(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int R = rnd.Next(0, 255);
            int G = rnd.Next(0, 255);
            int B = rnd.Next(0, 255);

            this.BackColor = Color.FromArgb(R,G,B);

        }

        private void item_FullScreen(object sender, EventArgs e)
        {
            if (fullScreen == true)
            {
                this.WindowState = FormWindowState.Maximized;
                fullScreen = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                fullScreen = true;
            }
            
        }

        private void item_new(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(tree);
        }

        private void item_exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas sa oled kindel?","Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void _listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = _listbox.SelectedItem.ToString();

            if (item == "Sinine")
            {
                _listbox.BackColor = Color.Blue;
            }
            if (item == "Kollane")
            {
                _listbox.BackColor = Color.Yellow;
            }
            if (item == "Roheline")
            {
                _listbox.BackColor = Color.Green;
            }
            if (item == "Punane")
            {
                _listbox.BackColor = Color.Red;
            }
        }

        private void TabControlRadio(object sender, EventArgs e)
        {
            tabControl = new TabControl();
            tabControl.Location = new Point(350, 150);
            tabControl.Size = new Size(200, 100);
            page1 = new TabPage("Esimene");
            page1.BackColor = Color.Red;
            page2 = new TabPage("Teine");
            page2.BackColor = Color.Purple;
            page3 = new TabPage("Kolmas");
            page3.BackColor = Color.Yellow;
            tabControl.Controls.Add(page1);
            tabControl.Controls.Add(page2);
            tabControl.Controls.Add(page3);
            this.Controls.Add(tabControl);
            if (t1.Checked)
            {
                this.tabControl.SelectedTab = page1;
            }
            if (t2.Checked)
            {
                this.tabControl.SelectedTab = page2;
            }
            if (t3.Checked)
            {
                this.tabControl.SelectedTab = page3;
            }
            t1.Dispose();
            t2.Dispose();
            t3.Dispose();
            kysimus.Dispose();
            
        }

        private void RadioButton_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}

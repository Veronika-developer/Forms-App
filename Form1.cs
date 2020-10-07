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
            tn.Nodes.Add(new TreeNode("-MessageBox"));
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

namespace elemendid_vormid
{
    public partial class StartForm : Form
    {
        List<string> elemendid = new List<string> { "Nupp", "Silt", "Pilt", "Märkeruut" };
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pbox;
        CheckBox chk1, chk2;

        public StartForm()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            foreach (var element in  elemendid)
            {
                tn.Nodes.Add(new TreeNode(element));
            }



            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Height = 50;
            btn.Width = 70;
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;

            lbl = new Label();
            lbl.Text = "Aknade alemendid c# abil";
            lbl.Font = new Font("Arial", 30, FontStyle.Underline);
            lbl.Size = new Size(200, 50);
            lbl.Location = new Point(150, 0);
            lbl.BackColor = Color.White;
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;

            pbox = new PictureBox();
            pbox.Size = new Size(150, 150);
            pbox.Location = new Point(150, btn.Height+lbl.Height+5);
            pbox.SizeMode = PictureBoxSizeMode.Zoom;
            pbox.Image = Image.FromFile(@"..\..\..\The_Old_Duke.png");
            pbox.DoubleClick += Pbox_DoubleClick;



        }
        int tt = 0;
        private void Pbox_DoubleClick(object? sender, EventArgs e)
        {
            string[] pildid = { "The_Old_Duke.png", "anahitagif.png", "Cryogen.png" };
            string fail = pildid[tt];
            pbox.Image = Image.FromFile(@"..\..\"+fail);
            //end this part of code

        }



        private void Lbl_MouseLeave(object? sender, EventArgs e)
        {
            lbl.Font = new Font("Arial", 30, FontStyle.Underline);
            lbl.BackColor = Color.White;
        }






        private void Lbl_MouseHover(object? sender, EventArgs e)
        {
            lbl.Font = new Font("Arial", 32, FontStyle.Bold);
            lbl.BackColor = Color.Red;
        }






        int t = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            t++;
            if (t % 2 == 0)
            {
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.BackColor = Color.Blue;
            }

        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pbox);
            }
            else if (e.Node.Text == "Märkeruut")
            {
                chk1 = new CheckBox();
                chk1.Checked = false;
                chk1.Text = e.Node.Text;
                chk1.Size = new Size(chk1.Text.Length*10, chk1.Size.Height);
                chk1.Location = new Point(150, btn.Height + lbl.Height + pbox.Height+ 5);
                Controls.Add(chk1);
                chk2 = new CheckBox();
                chk2.Checked = false;
                chk2.BackgroundImage = Image.FromFile(@"..\..\..\The_Old_Duke.png");
                chk2.BackgroundImageLayout = ImageLayout.Zoom;
                chk2.Size = new Size(100, 100);
                chk2.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + chk1.Height + 15);
                Controls.Add(chk1);
                Controls.Add(chk2);

                if ((chk1.Checked = false) && (chk2.Checked = true))
                { 
                    this.BackColor = Color.Green;
                }
            }
        }
    }
}

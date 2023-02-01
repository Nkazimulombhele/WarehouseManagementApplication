using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementApplication.Login;
using WarehouseManagementApplication.Manager_Controls;

namespace WarehouseManagementApplication.Dashboard
{
    public partial class Manager_Dashboard : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public Manager_Dashboard()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnProducts);
            UC_ManageProducts mp = new UC_ManageProducts();
            AddControlsToPanel(mp);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSuppliers);
            UC_ManageSuppliers ms = new UC_ManageSuppliers();
            AddControlsToPanel(ms);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCategories);
            UC_ManageCategories mc = new UC_ManageCategories();
            AddControlsToPanel(mc);
        }
        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            moveSidePanel(btnLogout);
            ManagerLogin login = new ManagerLogin();
            login.ShowDialog();
        }
    }
}

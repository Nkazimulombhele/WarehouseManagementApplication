using BusinessAccessLayer;
using BusinessEntityLayer;
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
using WarehouseManagementApplication.Dashboard;

namespace WarehouseManagementApplication.Edit
{
    public partial class Edit_Categories : Form
    {
        public CategoryEntity _categoryEntity = new CategoryEntity();
        public CategoryBusinessAccess _categoryBusinessAccess = new CategoryBusinessAccess();
        public Edit_Categories()
        {
            InitializeComponent();
        }
        string imgLocation = "";
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|all files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofd.FileName.ToString();
                PictureUploadBox.ImageLocation = imgLocation;

            }

        }
     

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCategoryId.Text.Equals(string.Empty))
            {
                MessageBox.Show("Category Id Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnUpdate.Text == "Update")
            {
                byte[] images = null;
                FileStream Streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Streem);
                images = brs.ReadBytes((int)Streem.Length);

                _categoryEntity.categoryId = Convert.ToInt32(txtCategoryId.Text);
                    _categoryEntity.categoryname = txtCategoryName.Text;
                    _categoryEntity.description = txtDescription.Text;
                _categoryEntity.picture = images;

                    if (_categoryBusinessAccess.categoryupdateDetails(_categoryEntity) > 0)
                    {
                       
                        MessageBox.Show("Category Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

            }
            Manager_Dashboard home = new Manager_Dashboard();
            home.ShowDialog();
            this.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

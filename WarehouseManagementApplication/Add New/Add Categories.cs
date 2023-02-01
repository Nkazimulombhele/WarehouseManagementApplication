using BusinessAccessLayer;
using BusinessEntityLayer;
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

namespace WarehouseManagementApplication.Add_New
{
    public partial class Add_Categories : Form
    {

        public CategoryEntity _categoryEntity = new CategoryEntity();
        public CategoryBusinessAccess _categoryBusinessAccess = new CategoryBusinessAccess();
        public Add_Categories()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            
            //try
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        //PictureUploadBox.Image = Bitmap(ofd.FileName);
            //    }

                   
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error occured!");

            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Category Name Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDescription.Text.Equals(string.Empty))
            {
                MessageBox.Show("Description Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PictureUploadBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Category Picture not Uploaded!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnSave.Text == "Save")
            {
                _categoryEntity.categoryname = txtCategoryName.Text;
                _categoryEntity.description = txtDescription.Text;
                _categoryEntity.picture = PictureUploadBox.Text;

                if (_categoryBusinessAccess.categoryinsertDetails(_categoryEntity) > 0)
                {
                    MessageBox.Show("Category Inserted Successfully");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

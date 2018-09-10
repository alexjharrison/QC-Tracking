using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QCTracking
{
    public partial class FirstScreenForm : Form
    {
        List<SingleBatch> fullList = new List<SingleBatch>();

        public FirstScreenForm(List<SingleBatch> passedList)
        {
            fullList = passedList;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newItemForm = new NewItemForm(fullList);
            this.Hide();
            newItemForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form modifyForm = new ItemListForm(fullList);
            this.Hide();
            modifyForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form tvForm = new TVDisplayForm(fullList);
            this.Hide();
            tvForm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form tvForm = new TVDisplayPierce(fullList);
            this.Hide();
            tvForm.ShowDialog();
            this.Close();
        }

        
    }
}

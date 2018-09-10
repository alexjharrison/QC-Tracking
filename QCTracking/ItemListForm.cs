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

namespace QCTracking
{
    public partial class ItemListForm : Form
    {
        List<SingleBatch> fullList = new List<SingleBatch>();
        int numInList = -1;

        public ItemListForm(List<SingleBatch> passedList)
        {
            fullList = passedList;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            List<string> datalist = new List<string>();
            List<int> deleteThese = new List<int>();
            for (int i = 0; i < fullList.Count; i++)
            {
                if (fullList[i].FinalApprovalStatus == "Conform")
                {
                    AddToArchive(fullList[i]);
                    deleteThese.Add(i);
                }
                else
                {
                    datalist.Add(fullList[i].BatchNum.ToString() + " | " + fullList[i].Material.ToString() + " " + fullList[i].SizeShade.ToString());
                }

                
            }

            for (int i = deleteThese.Count-1; i>=0; i--)
            {
                fullList.RemoveAt(deleteThese[i]);
            }
                listBox1.DataSource = datalist;
            saveToFile();
        }

        private void AddToArchive(SingleBatch singleBatch)
        {
            var csv = new StringBuilder();
            var newLine = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},0", singleBatch.Material, singleBatch.BatchNum, singleBatch.ReceivedDate, singleBatch.TargetEndDate, singleBatch.StrengthStatus, singleBatch.StrengthDate, singleBatch.PSHardnessStatus, singleBatch.PSHardnessDate, singleBatch.DimensionStatus, singleBatch.DimensionDate, singleBatch.DTStatus, singleBatch.DTDate, singleBatch.ArchimedesStatus, singleBatch.ArchimedesDate, singleBatch.ShadeStatus, singleBatch.ShadeDate, singleBatch.HomogeneityStatus, singleBatch.HomogeneityDate, singleBatch.XRFStatus, singleBatch.XRFDate, singleBatch.XRDStatus, singleBatch.XRDDate, singleBatch.MinoltaStatus, singleBatch.MinoltaDate, singleBatch.ShearStatus, singleBatch.ShearDate, singleBatch.PackagingStatus, singleBatch.PackagingDate, singleBatch.FinalApprovalStatus, singleBatch.FinalApprovalDate, singleBatch.LeadTime, singleBatch.Comments, singleBatch.Quantity, singleBatch.SizeShade, singleBatch.PowderStatus, singleBatch.PowderDate, singleBatch.DiscRingStatus, singleBatch.DiscRingDate, "0");
            csv.AppendLine(newLine);
            File.AppendAllText("G:\\QC\\QC Milling Ceramics\\QC Archive Orders.csv", csv.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numInList = listBox1.SelectedIndex;
            if (numInList==-1)
            {
                MessageBox.Show("No Batch Selected", "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            Form modifyPage = new ModifyItemForm(fullList,numInList);
            this.Hide();
            modifyPage.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frontPage = new FirstScreenForm(fullList);
            this.Hide();
            frontPage.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numInList = listBox1.SelectedIndex;
            if (numInList == -1)
            {
                MessageBox.Show("No Batch Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult input = MessageBox.Show("Are you sure you want to delete\n" + fullList[numInList].Material + " " + fullList[numInList].BatchNum + "?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if(input==DialogResult.OK)
            {
                fullList.RemoveAt(numInList);
                saveToFile();
                Form reload = new ItemListForm(fullList);
                this.Hide();
                reload.ShowDialog();
                this.Close();
            }


        }


        //FIX THIS
        private bool saveToFile()
        {
            var csv = new StringBuilder();
            csv.AppendLine("Material,Batch #,Received Date,Target End Date,Strength Status,Strength Date,PS/Hardness Status,PS/Hardness Date,Dimension Status,Dimension Date,DT Status,DT Date,Archimedes Status,Archimedes Date,Shade Status,Shade Date,Homogeneity Status,Homogeneity Date,XRF Status,XRF Date,XRD Status,XRD Date,Minolta Status,Minolta Date,Shear Status ,Shear Date,Packaging Status,Packaging Date,Final Approval Status,Final Approval Date,Lead Time ,Comments,Quantity,SizeShade,Powder Status,Powder Date,Disc w/Ring Status,Disc w/Ring Date,Ignore");
            for (int i = 0; i < fullList.Count; i++)
            {
                var newLine = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},0", fullList[i].Material, fullList[i].BatchNum, fullList[i].ReceivedDate, fullList[i].TargetEndDate, fullList[i].StrengthStatus, fullList[i].StrengthDate, fullList[i].PSHardnessStatus, fullList[i].PSHardnessDate, fullList[i].DimensionStatus, fullList[i].DimensionDate, fullList[i].DTStatus, fullList[i].DTDate, fullList[i].ArchimedesStatus, fullList[i].ArchimedesDate, fullList[i].ShadeStatus, fullList[i].ShadeDate, fullList[i].HomogeneityStatus, fullList[i].HomogeneityDate, fullList[i].XRFStatus, fullList[i].XRFDate, fullList[i].XRDStatus, fullList[i].XRDDate, fullList[i].MinoltaStatus, fullList[i].MinoltaDate, fullList[i].ShearStatus, fullList[i].ShearDate, fullList[i].PackagingStatus, fullList[i].PackagingDate, fullList[i].FinalApprovalStatus, fullList[i].FinalApprovalDate, fullList[i].LeadTime, fullList[i].Comments, fullList[i].Quantity, fullList[i].SizeShade, fullList[i].PowderStatus, fullList[i].PowderDate, fullList[i].DiscRingStatus, fullList[i].DiscRingDate, "0");
                csv.AppendLine(newLine);
            }

            DialogResult result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    File.WriteAllText("G:\\QC\\QC Milling Ceramics\\QC Open Orders.csv", csv.ToString());
                    return true;
                }
                catch
                {
                    result = MessageBox.Show("G:\\QC\\QC Milling Ceramics\\QC Open Orders_temp.csv\nFile in Use\nClose File & Retry", "Yo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Cancel)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        void listBox1_MouseDoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}

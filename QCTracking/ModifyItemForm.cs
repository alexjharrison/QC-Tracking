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
using Microsoft.Office.Interop.Excel;




namespace QCTracking
{
    public partial class ModifyItemForm : Form
    {
        List<SingleBatch> fullList = new List<SingleBatch>();
        int numIndex;
        public ModifyItemForm(List<SingleBatch> passedList, int numInList)
        {
            numIndex = numInList;
            fullList = passedList;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            label2.Text = fullList[numInList].Material.ToString() + " " + fullList[numInList].SizeShade.ToString() + " " + fullList[numInList].BatchNum.ToString();
            string[] status1 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status2 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status3 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status4 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status5 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status6 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status7 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status8 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status9 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status10 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status11 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status12 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status13 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };
            string[] status14 = { "In Process", "Conform", "Non-Conform" };
            string[] status15 = { "In Process", "Conform", "Non-Conform", "Warning", "N/A" };

            comboBox1.DataSource = status1; comboBox1.Text = fullList[numInList].XRFStatus.ToString();
            comboBox2.DataSource = status2; comboBox2.Text = fullList[numInList].XRDStatus.ToString();
            comboBox3.DataSource = status3; comboBox3.Text = fullList[numInList].HomogeneityStatus.ToString();
            comboBox4.DataSource = status4; comboBox4.Text = fullList[numInList].ShadeStatus.ToString();
            comboBox5.DataSource = status5; comboBox5.Text = fullList[numInList].DimensionStatus.ToString();
            comboBox6.DataSource = status6; comboBox6.Text = fullList[numInList].PSHardnessStatus.ToString();
            comboBox7.DataSource = status7; comboBox7.Text = fullList[numInList].MinoltaStatus.ToString();
            comboBox8.DataSource = status8; comboBox8.Text = fullList[numInList].StrengthStatus.ToString();
            comboBox9.DataSource = status9; comboBox9.Text = fullList[numInList].ArchimedesStatus.ToString();
            comboBox10.DataSource = status10; comboBox10.Text = fullList[numInList].PowderStatus.ToString();
            comboBox11.DataSource = status11; comboBox11.Text = fullList[numInList].ShearStatus.ToString();
            comboBox12.DataSource = status12; comboBox12.Text = fullList[numInList].PackagingStatus.ToString();
            comboBox13.DataSource = status13; comboBox13.Text = fullList[numInList].DTStatus.ToString();
            comboBox14.DataSource = status14; comboBox14.Text = fullList[numInList].FinalApprovalStatus.ToString();
            comboBox15.DataSource = status15; comboBox15.Text = fullList[numInList].DiscRingStatus.ToString();

            label18.Text = fullList[numInList].XRFDate.ToString();
            label19.Text = fullList[numInList].XRDDate.ToString();
            label20.Text = fullList[numInList].HomogeneityDate.ToString();
            label21.Text = fullList[numInList].ShadeDate.ToString();
            label22.Text = fullList[numInList].DimensionDate.ToString();
            label23.Text = fullList[numInList].PSHardnessDate.ToString();
            label24.Text = fullList[numInList].MinoltaDate.ToString();
            label25.Text = fullList[numInList].StrengthDate.ToString();
            label26.Text = fullList[numInList].ArchimedesDate.ToString();
            label27.Text = fullList[numInList].PowderDate.ToString();
            label28.Text = fullList[numInList].ShearDate.ToString();
            label29.Text = fullList[numInList].PackagingDate.ToString();
            label30.Text = fullList[numInList].DTDate.ToString();
            label32.Text = fullList[numInList].FinalApprovalDate.ToString();
            textBox1.Text = fullList[numInList].Comments;
            label34.Text = fullList[numInList].DiscRingDate.ToString();

            if (comboBox1.Text.Equals("N/A")) { comboBox1.Hide(); label3.Hide(); }
            if (comboBox2.Text.Equals("N/A")) { comboBox2.Hide(); label4.Hide(); }
            if (comboBox3.Text.Equals("N/A")) { comboBox3.Hide(); label5.Hide(); }
            if (comboBox4.Text.Equals("N/A")) { comboBox4.Hide(); label6.Hide(); }
            if (comboBox5.Text.Equals("N/A")) { comboBox5.Hide(); label7.Hide(); }
            if (comboBox6.Text.Equals("N/A")) { comboBox6.Hide(); label8.Hide(); }
            if (comboBox7.Text.Equals("N/A")) { comboBox7.Hide(); label9.Hide(); }
            if (comboBox8.Text.Equals("N/A")) { comboBox8.Hide(); label10.Hide(); }
            if (comboBox9.Text.Equals("N/A")) { comboBox9.Hide(); label11.Hide(); }
            if (comboBox10.Text.Equals("N/A")) { comboBox10.Hide(); label12.Hide(); }
            if (comboBox11.Text.Equals("N/A")) { comboBox11.Hide(); label13.Hide(); }
            if (comboBox12.Text.Equals("N/A")) { comboBox12.Hide(); label14.Hide(); }
            if (comboBox13.Text.Equals("N/A")) { comboBox13.Hide(); label31.Hide(); }
            if (comboBox14.Text.Equals("N/A")) { comboBox14.Hide(); label16.Hide(); }
            if (comboBox15.Text.Equals("N/A")) { comboBox15.Hide(); label33.Hide(); }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            fullList[numIndex].Comments = textBox1.Text;
            if(saveToFile())
            {
                Form itemListForm = new ItemListForm(fullList);
                this.Hide();
                itemListForm.ShowDialog();
                this.Close();
            }
        }

       

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].XRFStatus = comboBox1.Text;
            if(comboBox1.Text.Equals("Conform")|| comboBox1.Text.Equals("Non-Conform") || comboBox1.Text.Equals("Warning"))
            {
                fullList[numIndex].XRFDate = DateTime.Now.ToString();
                label18.Text = fullList[numIndex].XRFDate.ToString();
            }
        }
        
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].XRDStatus = comboBox2.Text;
            if (comboBox2.Text.Equals("Conform") || comboBox2.Text.Equals("Non-Conform") || comboBox2.Text.Equals("Warning"))
            {
                fullList[numIndex].XRDDate = DateTime.Now.ToString();
                label19.Text = fullList[numIndex].XRDDate.ToString();
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].HomogeneityStatus = comboBox3.Text;
            if (comboBox3.Text.Equals("Conform") || comboBox3.Text.Equals("Non-Conform") || comboBox3.Text.Equals("Warning"))
            {
                fullList[numIndex].HomogeneityDate = DateTime.Now.ToString();
                label20.Text = fullList[numIndex].HomogeneityDate.ToString();
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].ShadeStatus = comboBox4.Text;
            if (comboBox4.Text.Equals("Conform") || comboBox4.Text.Equals("Non-Conform") || comboBox4.Text.Equals("Warning"))
            {
                fullList[numIndex].ShadeDate = DateTime.Now.ToString();
                label21.Text = fullList[numIndex].ShadeDate.ToString();
            }
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].DimensionStatus = comboBox5.Text;
            if (comboBox5.Text.Equals("Conform") || comboBox5.Text.Equals("Non-Conform") || comboBox5.Text.Equals("Warning"))
            {
                fullList[numIndex].DimensionDate = DateTime.Now.ToString();
                label22.Text = fullList[numIndex].DimensionDate.ToString();
            }
        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].PSHardnessStatus = comboBox6.Text;
            if (comboBox6.Text.Equals("Conform") || comboBox6.Text.Equals("Non-Conform") || comboBox6.Text.Equals("Warning"))
            {
                fullList[numIndex].PSHardnessDate = DateTime.Now.ToString();
                label23.Text = fullList[numIndex].PSHardnessDate.ToString();
            }
        }

        private void comboBox7_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].MinoltaStatus = comboBox7.Text;
            if (comboBox7.Text.Equals("Conform") || comboBox7.Text.Equals("Non-Conform") || comboBox7.Text.Equals("Warning"))
            {
                fullList[numIndex].MinoltaDate = DateTime.Now.ToString();
                label24.Text = fullList[numIndex].MinoltaDate.ToString();
            }
        }

        private void comboBox8_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].StrengthStatus = comboBox8.Text;
            if (comboBox8.Text.Equals("Conform") || comboBox8.Text.Equals("Non-Conform") || comboBox8.Text.Equals("Warning"))
            {
                fullList[numIndex].StrengthDate = DateTime.Now.ToString();
                label25.Text = fullList[numIndex].StrengthDate.ToString();
            }
        }

        private void comboBox9_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].ArchimedesStatus = comboBox9.Text;
            if (comboBox9.Text.Equals("Conform") || comboBox9.Text.Equals("Non-Conform") || comboBox9.Text.Equals("Warning"))
            {
                fullList[numIndex].ArchimedesDate = DateTime.Now.ToString();
                label26.Text = fullList[numIndex].ArchimedesDate.ToString();
            }
        }

        private void comboBox10_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].PowderStatus = comboBox10.Text;
            if (comboBox10.Text.Equals("Conform") || comboBox10.Text.Equals("Non-Conform") || comboBox10.Text.Equals("Warning"))
            {
                fullList[numIndex].PowderDate = DateTime.Now.ToString();
                label27.Text = fullList[numIndex].PowderDate.ToString();
            }
        }

        private void comboBox11_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].ShearStatus = comboBox11.Text;
            if (comboBox11.Text.Equals("Conform") || comboBox11.Text.Equals("Non-Conform") || comboBox11.Text.Equals("Warning"))
            {
                fullList[numIndex].ShearDate = DateTime.Now.ToString();
                label28.Text = fullList[numIndex].ShearDate.ToString();
            }
        }

        private void comboBox12_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].PackagingStatus = comboBox12.Text;
            if (comboBox12.Text.Equals("Conform") || comboBox12.Text.Equals("Non-Conform") || comboBox12.Text.Equals("Warning"))
            {
                fullList[numIndex].PackagingDate = DateTime.Now.ToString();
                label29.Text = fullList[numIndex].PackagingDate.ToString();
            }
        }

        private void comboBox13_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].DTStatus = comboBox13.Text;
            if (comboBox13.Text.Equals("Conform") || comboBox13.Text.Equals("Non-Conform") || comboBox13.Text.Equals("Warning"))
            {
                fullList[numIndex].DTDate = DateTime.Now.ToString();
                label30.Text = fullList[numIndex].DTDate.ToString();
            }
        }

        private void comboBox14_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].FinalApprovalStatus = comboBox14.Text;
            if (comboBox14.Text.Equals("Conform") || comboBox14.Text.Equals("Non-Conform") || comboBox14.Text.Equals("Warning"))
            {
                fullList[numIndex].FinalApprovalDate = DateTime.Now.ToString();
                label32.Text = fullList[numIndex].FinalApprovalDate.ToString();
            }
        }
        private void comboBox15_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fullList[numIndex].DiscRingStatus = comboBox15.Text;
            if (comboBox15.Text.Equals("Conform") || comboBox15.Text.Equals("Non-Conform") || comboBox15.Text.Equals("Warning"))
            {
                fullList[numIndex].DiscRingDate = DateTime.Now.ToString();
                label34.Text = fullList[numIndex].DiscRingDate.ToString();
            }
        }
        private bool saveToFile()
        {
            try
            {
                DateTime dtEnd = Convert.ToDateTime(fullList[numIndex].ReceivedDate);
                DateTime dtBegin = Convert.ToDateTime(fullList[numIndex].FinalApprovalDate);
                fullList[numIndex].LeadTime = dtBegin.Subtract(dtEnd).TotalDays.ToString();
            }
            catch { }
            var csv = new StringBuilder();
            csv.AppendLine("Material,Batch #,Received Date,Target End Date,Strength Status,Strength Date,PS/Hardness Status,PS/Hardness Date,Dimension Status,Dimension Date,DT Status,DT Date,Archimedes Status,Archimedes Date,Shade Status,Shade Date,Homogeneity Status,Homogeneity Date,XRF Status,XRF Date,XRD Status,XRD Date,Minolta Status,Minolta Date,Shear Status ,Shear Date,Packaging Status,Packaging Date,Final Approval Status,Final Approval Date,Lead Time ,Comments,Quantity,SizeShade,Powder Status,Powder Date,Disc w/Ring Status,Disc w/Ring Date,Ignore");
            for(int i = 0;i<fullList.Count;i++)
            {
                var newLine = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},0",fullList[i].Material,fullList[i].BatchNum,fullList[i].ReceivedDate,fullList[i].TargetEndDate,fullList[i].StrengthStatus,fullList[i].StrengthDate,fullList[i].PSHardnessStatus,fullList[i].PSHardnessDate,fullList[i].DimensionStatus,fullList[i].DimensionDate,fullList[i].DTStatus,fullList[i].DTDate,fullList[i].ArchimedesStatus,fullList[i].ArchimedesDate,fullList[i].ShadeStatus,fullList[i].ShadeDate,fullList[i].HomogeneityStatus,fullList[i].HomogeneityDate,fullList[i].XRFStatus,fullList[i].XRFDate,fullList[i].XRDStatus,fullList[i].XRDDate,fullList[i].MinoltaStatus,fullList[i].MinoltaDate,fullList[i].ShearStatus,fullList[i].ShearDate,fullList[i].PackagingStatus,fullList[i].PackagingDate,fullList[i].FinalApprovalStatus,fullList[i].FinalApprovalDate,fullList[i].LeadTime,fullList[i].Comments,fullList[i].Quantity,fullList[i].SizeShade,fullList[i].PowderStatus,fullList[i].PowderDate,fullList[i].DiscRingStatus,fullList[i].DiscRingDate, "0");
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
                        Form reset = new ModifyItemForm(fullList,numIndex);
                        this.Hide();
                        reset.ShowDialog();
                        return false;
                    }
                }
                
            }
            return true;
        }

        private void writeToXL()
        {

        }

        
    }
    class AdvancedComboBox : ComboBox
    {
        new public System.Windows.Forms.DrawMode DrawMode { get; set; }
        public Color HighlightColor { get; set; }

        public AdvancedComboBox()
        {
            base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HighlightColor = Color.Gray;
            this.DrawItem += new DrawItemEventHandler(AdvancedComboBox_DrawItem);
        }

        void AdvancedComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(HighlightColor),
                                         e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                                         e.Bounds);

            e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font,
                                  new SolidBrush(combo.ForeColor),
                                  new System.Drawing.Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }
    }
}

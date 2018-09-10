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

namespace QCTracking
{
    public partial class NewItemForm : Form
    {
        List<SingleBatch> fullList = new List<SingleBatch>();
        SingleBatch newBatch = new SingleBatch();

        public NewItemForm(List<SingleBatch> passedList)
        {
            fullList = passedList;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            label8.Hide(); label9.Hide();
            textBox3.Hide(); comboBox5.Hide();
            if (DateTime.Now.Year.ToString() == "2016") textBox1.Text = "V";
            else if (DateTime.Now.Year.ToString() == "2017") textBox1.Text = "W";
            else if (DateTime.Now.Year.ToString() == "2018") textBox1.Text = "X";
            else if (DateTime.Now.Year.ToString() == "2019") textBox1.Text = "Y";
            else if (DateTime.Now.Year.ToString() == "2020") textBox1.Text = "Z";
            textBox1.SelectionStart = 1;
            string[] materials = { "","Zircad", "ZenostarMO", "Zirlux","Emax Mandrel","Empress Mandrel","Zircad Mandrel","Powder","Emax Glassblock","Emax Single","Procad Single","Procad Multi" };
            string[] fullDyn = { "Dynamic", "Full" };
            comboBox4.DataSource = fullDyn;
            comboBox1.DataSource = materials;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Please choose a Material Type", "Yo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(saveToFile())
            {
                Form itemListForm = new ItemListForm(fullList);
                this.Hide();
                itemListForm.ShowDialog();
                this.Close();
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form goHome = new FirstScreenForm(fullList);
            this.Hide();
            goHome.ShowDialog();
            this.Close();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label4.Show(); label5.Show(); 
            comboBox2.Show(); comboBox3.Show();
            label10.Hide(); comboBox6.Hide(); comboBox5.Hide(); label9.Hide();
            label8.Hide(); textBox3.Hide(); label6.Hide(); comboBox4.Hide();
            string[] zirluxSize = { "98.5 x 10", "98.5 x 12", "98.5 x 14", "98.5 x 16", "98.5 x 18", "98.5 x 20", "98.5 x 25" };
            string[] zirluxShade = { "U1", "U2", "U3", "U4", "U5" };
            string[] zircadSize = { "C13", "C15", "C15L", "B40", "B40L", "B55", "B65", "B65L", "B85L" };
            string[] zircadShade = { "MO0","MO1", "MO2", "MO3", "MO4" };
            string[] emaxSize = { "I12", "C14", "C16", "B32" };
            string[] proCadSize = { "C14", "C14L", "I12", "I10", "I8", "V8" };
            string[] translucency = { "HT", "LT", "MT", "Multi" };
            string[] zenostarMOSize = { "98.5 x 10","98.5 x 14","98.5 x 18","98.5 x 20","98.5 x 25" };
            string[] emaxProcadShade = { "A1", "A2", "A3", "A3.5", "A4", "B1", "B2", "B3", "BL1", "BL2", "BL3", "BL4", "C1", "C2", "C3", "C4", "D1", "D2", "D3", "D4", "100", "200", "300", "400" };
            string[] mandrelType = { "Sirona", "Planmill" };
            
            
            if (comboBox1.SelectedItem.ToString().Equals("Zirlux"))
            {
                comboBox2.DataSource = zirluxSize;
                comboBox3.DataSource = zirluxShade;
                
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Powder"))
            {
                label4.Hide();label5.Hide();label6.Hide();label5.Hide();comboBox5.Hide();
                comboBox2.Hide();comboBox3.Hide();comboBox4.Hide();
                label8.Show(); textBox3.Show();
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Emax Single"))
            {
                label6.Show(); comboBox4.Show(); label5.Show(); comboBox5.Show(); label9.Show();
                comboBox2.DataSource = emaxSize;
                comboBox5.DataSource = translucency;
                comboBox3.DataSource = emaxProcadShade;

            }
            else if (comboBox1.SelectedItem.ToString().Equals("Emax Glassblock"))
            {
                label5.Show(); comboBox5.Show(); label9.Show();
                comboBox2.DataSource = emaxSize;
                comboBox5.DataSource = translucency;
                comboBox3.DataSource = emaxProcadShade;

            }
            else if (comboBox1.SelectedItem.ToString().Equals("Procad Single"))
            {
                label6.Show(); comboBox4.Show(); label5.Show(); comboBox5.Show(); label9.Show();
                comboBox5.DataSource = translucency;
                comboBox3.DataSource = emaxProcadShade;
                comboBox2.DataSource = proCadSize;

            }
            else if (comboBox1.SelectedItem.ToString().Equals("Procad Multi"))
            {
                label6.Show(); comboBox4.Show(); label5.Show(); comboBox5.Show(); label9.Show();
                comboBox5.DataSource = translucency;
                comboBox3.DataSource = emaxProcadShade;
                comboBox2.DataSource = emaxSize;

            }
            else if(comboBox1.SelectedItem.ToString().Equals("Zircad"))
            {
                comboBox3.DataSource = zircadShade;
                comboBox2.DataSource = zircadSize;

            }
            else if (comboBox1.SelectedItem.ToString().Equals("ZenostarMO"))
            {
                comboBox2.DataSource = zenostarMOSize;
                comboBox3.DataSource = zircadShade;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Emax Mandrel"))
            {
                label5.Show(); comboBox5.Show(); label10.Show(); comboBox6.Show(); label9.Show();
                comboBox5.DataSource = translucency;
                comboBox3.DataSource = emaxProcadShade;
                comboBox6.DataSource = mandrelType;
                comboBox2.DataSource = emaxSize;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Empress Mandrel"))
            {
                label5.Show(); comboBox5.Show(); label10.Show(); comboBox6.Show(); label9.Show();
                comboBox5.DataSource = translucency;
                comboBox3.DataSource = emaxProcadShade;
                comboBox6.DataSource = mandrelType;
                comboBox2.DataSource = proCadSize;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Zircad Mandrel"))
            {
                comboBox3.DataSource = zircadShade;
                comboBox2.DataSource = zircadSize;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Please choose a Material Type", "Yo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(saveToFile())
            {
                Form resetPage = new NewItemForm(fullList);
                this.Hide();
                resetPage.ShowDialog();
                this.Close();
            }
            

        }

        public bool saveToFile()
        {
            string na = "N/A";
            string ip = "In Process";
            try
            {
                if (comboBox1.SelectedItem.ToString().Equals("Zircad"))
                {
                    newBatch.SizeShade = comboBox2.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString();
                    newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.DimensionStatus = newBatch.DTStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = ip;
                    newBatch.DiscRingStatus = newBatch.HomogeneityStatus = newBatch.PowderStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Zirlux"))
                {
                    newBatch.SizeShade = comboBox2.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString();
                    newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ShadeStatus = newBatch.ArchimedesStatus = ip;
                    newBatch.DimensionStatus = newBatch.PowderStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("ZenostarMO"))
                {
                    newBatch.SizeShade = comboBox2.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString();
                    newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ShadeStatus = ip;
                    newBatch.ArchimedesStatus = newBatch.DiscRingStatus = newBatch.DimensionStatus = newBatch.PowderStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Powder"))
                {
                    newBatch.SizeShade = textBox3.Text;
                    newBatch.PowderStatus = ip;
                    newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DimensionStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Emax Glassblock"))
                {
                    newBatch.SizeShade = comboBox5.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();
                    newBatch.XRFStatus = ip;
                    newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DimensionStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.PowderStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Emax Single"))
                {
                    newBatch.SizeShade = comboBox5.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();
                    if (comboBox4.SelectedItem.ToString().Equals("Full"))
                    {
                        newBatch.StrengthStatus = newBatch.DTStatus = newBatch.MinoltaStatus = newBatch.XRDStatus = newBatch.StrengthStatus = newBatch.DimensionStatus = newBatch.HomogeneityStatus = ip;
                        newBatch.DiscRingStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.PowderStatus = newBatch.ShearStatus = newBatch.PackagingStatus = newBatch.XRFStatus = na;
                    }
                    else if (comboBox4.SelectedItem.ToString().Equals("Dynamic"))
                    {
                        newBatch.MinoltaStatus = newBatch.XRDStatus = newBatch.StrengthStatus = newBatch.DimensionStatus = newBatch.HomogeneityStatus = ip;
                        newBatch.DiscRingStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DTStatus = newBatch.PowderStatus = newBatch.ShearStatus = newBatch.PackagingStatus = newBatch.XRFStatus = newBatch.StrengthStatus = na;
                    }
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Procad Single"))
                {
                    newBatch.SizeShade = comboBox5.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();
                    if (comboBox4.SelectedItem.ToString().Equals("Full"))
                    {
                        newBatch.StrengthStatus = newBatch.DimensionStatus = newBatch.HomogeneityStatus = ip;
                        newBatch.DiscRingStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DTStatus = newBatch.PowderStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = newBatch.XRFStatus = na;
                    }
                    else if (comboBox4.SelectedItem.ToString().Equals("Dynamic"))
                    {
                        newBatch.DimensionStatus = newBatch.HomogeneityStatus = ip;
                        newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DTStatus = newBatch.PowderStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = newBatch.XRFStatus = na;
                    }
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Procad Multi"))
                {
                    newBatch.SizeShade = comboBox5.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();
                    newBatch.DTStatus = newBatch.DimensionStatus = newBatch.HomogeneityStatus = ip;
                    newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.PowderStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.ShearStatus = newBatch.PackagingStatus = newBatch.XRFStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Emax Mandrel") || comboBox1.SelectedItem.ToString().Equals("Empress Mandrel"))
                {
                    newBatch.SizeShade = comboBox5.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();
                    newBatch.ShearStatus = newBatch.PackagingStatus = ip;
                    newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DimensionStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.PowderStatus = na;
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Zircad Mandrel"))
                {
                    newBatch.SizeShade = comboBox2.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString();
                    if (comboBox2.SelectedItem.ToString().Equals("B55") || comboBox2.SelectedItem.ToString().Equals("B65") || comboBox2.SelectedItem.ToString().Equals("B65L") || comboBox2.SelectedItem.ToString().Equals("B85"))
                    {
                        newBatch.PackagingStatus = ip;
                        newBatch.DiscRingStatus = newBatch.ShearStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DimensionStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.PowderStatus = na;
                    }
                    else
                    {
                        newBatch.ShearStatus = newBatch.PackagingStatus = ip;
                        newBatch.DiscRingStatus = newBatch.StrengthStatus = newBatch.PSHardnessStatus = newBatch.ArchimedesStatus = newBatch.ShadeStatus = newBatch.DimensionStatus = newBatch.DTStatus = newBatch.HomogeneityStatus = newBatch.XRFStatus = newBatch.XRDStatus = newBatch.MinoltaStatus = newBatch.PowderStatus = na;
                    }
                }

                newBatch.FinalApprovalStatus = ip;
                newBatch.ReceivedDate = DateTime.Now.ToString();
                newBatch.TargetEndDate = dateTimePicker1.Value.ToShortDateString();
                newBatch.Material = comboBox1.SelectedItem.ToString();
                newBatch.BatchNum = textBox1.Text;
                newBatch.Quantity = textBox2.Text;
            }
            catch
            {
                MessageBox.Show("Please enter all data","Watch out",MessageBoxButtons.OK);
                Form resetPage = new NewItemForm(fullList);
                this.Hide();
                resetPage.ShowDialog();
                this.Close();
            }
            
            

            fullList.Add(newBatch);
            var csv = new StringBuilder();
            csv.AppendLine("Material,Batch #,Received Date,Target End Date,Strength Status,Strength Date,PS/Hardness Status,PS/Hardness Date,Dimension Status,Dimension Date,DT Status,DT Date,Archimedes Status,Archimedes Date,Shade Status,Shade Date,Homogeneity Status,Homogeneity Date,XRF Status,XRF Date,XRD Status,XRD Date,Minolta Status,Minolta Date,Shear Status ,Shear Date,Packaging Status,Packaging Date,Final Approval Status,Final Approval Date,Lead Time ,Comments,Quantity,SizeShade,Powder Status,Powder Date,Disc w/Ring Status,Disc w/Ring Date,Ignore");
            for (int i = 0; i < fullList.Count; i++)
            {
                var newLine = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},0", fullList[i].Material, fullList[i].BatchNum, fullList[i].ReceivedDate, fullList[i].TargetEndDate, fullList[i].StrengthStatus, fullList[i].StrengthDate, fullList[i].PSHardnessStatus, fullList[i].PSHardnessDate, fullList[i].DimensionStatus, fullList[i].DimensionDate, fullList[i].DTStatus, fullList[i].DTDate, fullList[i].ArchimedesStatus, fullList[i].ArchimedesDate, fullList[i].ShadeStatus, fullList[i].ShadeDate, fullList[i].HomogeneityStatus, fullList[i].HomogeneityDate, fullList[i].XRFStatus, fullList[i].XRFDate, fullList[i].XRDStatus, fullList[i].XRDDate, fullList[i].MinoltaStatus, fullList[i].MinoltaDate, fullList[i].ShearStatus, fullList[i].ShearDate, fullList[i].PackagingStatus, fullList[i].PackagingDate, fullList[i].FinalApprovalStatus, fullList[i].FinalApprovalDate, fullList[i].LeadTime, fullList[i].Comments, fullList[i].Quantity, fullList[i].SizeShade, fullList[i].PowderStatus, fullList[i].PowderDate,fullList[i].DiscRingStatus,fullList[i].DiscRingDate, "0");
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
                        fullList.Remove(fullList.Last());
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

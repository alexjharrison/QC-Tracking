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
using System.Timers;
using System.Threading;


namespace QCTracking
{
    public partial class TVDisplayForm : Form
    {
        List<SingleBatch> fullList = new List<SingleBatch>();
        public string status = "";
        public string whereAreWe = "Memorial";
        int pierceOrders = 0;
        int memorialOrders = 0;
        List<List<string>> whichCheck = new List<List<string>>();
        List<List<string>> whichTests = new List<List<string>>();
        List<int> locations = new List<int>();
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public TVDisplayForm(List<SingleBatch> passedList)
        {
            //fullList = PullList();
            InitializeComponent();
            label1.Text = "Memorial Orders";
            button2.Text = "Switch to Pierce";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);


            refreshTable();
        
            
            // Create a timer
            
            // Tell the timer what to do when it elapses
            myTimer.Interval = 120000;
            myTimer.Tick += new EventHandler(tmrOneSec_Tick);
            myTimer.Start();
            
        }
        
        // Implement a call with the right signature for events going off
        private void tmrOneSec_Tick(object sender, System.EventArgs e)
        {
            refreshTable();
        }
           
        void refreshTable()
        {
            fullList.Clear(); 
            fullList = PullList();
            int numBatches = fullList.Count;
            countOrders();
            GenerateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form homePage = new FirstScreenForm(fullList);
            this.Hide();
            homePage.ShowDialog();
            this.Close();
        }
        private void GenerateTable()
        {
            //Clear out the existing controls, we are generating a new table layout
            tableLayoutPanel1.Controls.Clear();

            //Clear out the existing row and column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            int columnCount = 0;
            int rowCount = 13;

            //Now we will generate the table, setting up the row and column counts first
            if(whereAreWe.Equals("Memorial"))
                columnCount = memorialOrders*2;
            else
                columnCount = pierceOrders*2;

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            

            for (int x = 0; x < columnCount; x++)
            {
                
                populateTests();

                //Column only with checkboxes
                if (x % 2 == 0)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / (5 * columnCount)));
                    if (x == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 206F));
                    }
                    
                    
                    for (int y = 0; y < whichCheck[x/2].Count; y++)
                    {
                        PictureBox check = new PictureBox();
                        if(whichCheck[x/2][y].Equals("Green"))
                            check.Image = Properties.Resources.green_checkbox;
                        else if (whichCheck[x/2][y].Equals("Yellow"))
                            check.Image = Properties.Resources.yellow_checkbox;
                        else if (whichCheck[x/2][y].Equals("Red"))
                            check.Image = Properties.Resources.Red_Checkbox;
                        else
                            check.Image = Properties.Resources.Empty_Checkbox;
                        check.SizeMode = PictureBoxSizeMode.Zoom;
                        check.Anchor = AnchorStyles.Right;
                        tableLayoutPanel1.Controls.Add(check, x, y+4);
                    }
                }
                //column with list of tests and batch info
                else
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 400 / (5 * columnCount)));

                    for (int y = 0; y < whichCheck[(x-1)/2].Count; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        if(y==0)
                        {
                            Label lab1 = new Label();
                            lab1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lab1.AutoSize = true;
                            lab1.Text = string.Format(fullList[locations[(x-1)/2]].Material);
                            Label lab2 = new Label();
                            lab2.Text = string.Format(fullList[locations[(x - 1) / 2]].SizeShade);
                            lab2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lab2.AutoSize = true;
                            Label lab3 = new Label();
                            lab3.Text = string.Format(fullList[locations[(x - 1) / 2]].BatchNum);         //Finally, add the control to the correct location in the table
                            lab3.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lab3.AutoSize = true;
                            
                            



                            PictureBox logo = new PictureBox();
                            logo.SizeMode = PictureBoxSizeMode.Zoom;
                            logo.Anchor = AnchorStyles.Left;
                            logo.AutoSize = true;
                            if (fullList[locations[(x-1)/2]].Material.Equals("Zircad"))  logo.Image = Properties.Resources.zircad; 
                            else if (fullList[locations[(x-1)/2]].Material.Equals("ZenostarMO"))  logo.Image = Properties.Resources.zenostar;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Zirlux"))  logo.Image = Properties.Resources.zirlux;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Emax Mandrel"))  logo.Image = Properties.Resources.emaxmandrel;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Empress Mandrel"))  logo.Image = Properties.Resources.empressmandrel;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Zircad Mandrel"))  logo.Image = Properties.Resources.zircadmandrel;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Powder"))  logo.Image = Properties.Resources.img11b;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Emax Glassblock"))  logo.Image = Properties.Resources.emax_cad;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Emax Single"))  logo.Image = Properties.Resources.emax_cad;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Procad Single"))  logo.Image = Properties.Resources.procad;
                            else if (fullList[locations[(x-1)/2]].Material.Equals("Procad Multi"))  logo.Image = Properties.Resources.procad;

                            tableLayoutPanel1.Controls.Add(logo, x, y);
                            tableLayoutPanel1.Controls.Add(lab1, x, y + 1);
                            tableLayoutPanel1.Controls.Add(lab2, x, y + 2);
                            tableLayoutPanel1.Controls.Add(lab3, x, y + 3);
                        }
                        //Create the control, in this case we will add a button
                        Label cmd = new Label();
                        cmd.Anchor = AnchorStyles.Left;
                        cmd.Text = string.Format(whichTests[(x - 1) / 2][y]);         //Finally, add the control to the correct location in the table
                        cmd.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        tableLayoutPanel1.Controls.Add(cmd, x, y + 4);
                        cmd.AutoSize = true;
                        
                    }

                    //Add comments and date to last two rows
                    Label startDate = new Label();
                    startDate.Anchor = AnchorStyles.Left;
                    startDate.Text = string.Format("Received:" + fullList[locations[(x - 1) / 2]].ReceivedDate);         //Finally, add the control to the correct location in the table
                    startDate.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    tableLayoutPanel1.Controls.Add(startDate, x, 11);
                    startDate.AutoSize = true;


                    Label endDate = new Label();
                    endDate.Anchor = AnchorStyles.Left;
                    endDate.Text = string.Format("Target End Date:" + fullList[locations[(x - 1) / 2]].TargetEndDate);         //Finally, add the control to the correct location in the table
                    endDate.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    tableLayoutPanel1.Controls.Add(endDate, x, 12);
                    endDate.AutoSize = true;

                    Label cBox = new Label();
                    cBox.Anchor = AnchorStyles.Left;
                    cBox.Text = string.Format(fullList[locations[(x - 1) / 2]].Comments);         //Finally, add the control to the correct location in the table
                    cBox.Font = new Font("Microsoft Sans Serif", 16.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    tableLayoutPanel1.Controls.Add(cBox, x, 13);
                    cBox.AutoSize = true;
                }
            }
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countOrders();
            if (whereAreWe.Equals("Pierce"))
            {
                button2.Text = "Switch to Pierce";
                label1.Text = "Memorial Orders";
                whereAreWe = "Memorial";
                GenerateTable();
            }
            else
            {
                button2.Text = "Switch to Memorial";
                label1.Text = "Pierce Orders";
                whereAreWe = "Pierce";
                GenerateTable();
            }
            
        }
        private void countOrders()
        {
            pierceOrders = 0;
            memorialOrders = 0;
            for(int i=0;i<fullList.Count;i++)
            {
                if (checkBox1.Checked==false && (fullList[i].Material.Equals("Zirlux") || fullList[i].Material.Equals("Powder") || fullList[i].Material.Equals("Zircad") || fullList[i].Material.Equals("ZenostarMO")))
                    memorialOrders++;
                else if (checkBox1.Checked==true && (fullList[i].Material.Equals("Emax Mandrel") || fullList[i].Material.Equals("Empress Mandrel") || fullList[i].Material.Equals("Zircad Mandrel")))
                    memorialOrders++;
                else if (fullList[i].Material.Equals("Emax Single") || fullList[i].Material.Equals("Emax Glassblock") || fullList[i].Material.Equals("Procad Single") || fullList[i].Material.Equals("Procad Multi"))
                    pierceOrders++;
            }
        }
        private void populateTests()
        {

            whichCheck.Clear();
            whichTests.Clear();
            //pageSizeShade.Clear();
            //pageBatch.Clear();
            //pageMaterials.Clear();
            //pageComments.Clear();
            //pageDate.Clear();
            locations.Clear();
            
            

            for (int i = 0; i < fullList.Count; i++) 
            {
                if (whereAreWe.Equals("Memorial") && checkBox1.Checked == false && (fullList[i].Material.Equals("Zirlux") || fullList[i].Material.Equals("Powder") || fullList[i].Material.Equals("Zircad") || fullList[i].Material.Equals("ZenostarMO")))
                {

                    List<string> whichCheckTemp = new List<string>();
                    List<string> whichTestsTemp= new List<string>();
                    //List<string> pageSizeShadeTemp = new List<string>();
                    //List<string> pageBatchTemp = new List<string>();
                    //List<string> pageMaterialsTemp = new List<string>();

                    if (fullList[i].StrengthStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Biaxial Strength"); }
                    else if (fullList[i].StrengthStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Biaxial Strength"); } 
                    else if (fullList[i].StrengthStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Biaxial Strength"); }
                    else if (fullList[i].StrengthStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Biaxial Strength"); }

                    if (fullList[i].PSHardnessStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Pre Sintered / Hardness"); }
                    else if (fullList[i].PSHardnessStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Pre Sintered / Hardness"); }
                    else if (fullList[i].PSHardnessStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Pre Sintered / Hardness"); }
                    else if (fullList[i].PSHardnessStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Pre Sintered / Hardness"); }

                    if (fullList[i].DimensionStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Dimension"); }
                    else if (fullList[i].DimensionStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Dimension"); }
                    else if (fullList[i].DimensionStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Dimension"); }
                    else if (fullList[i].DimensionStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Dimension"); }

                    if (fullList[i].DTStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Dental Technology"); }
                    else if (fullList[i].DTStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Dental Technology"); }
                    else if (fullList[i].DTStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Dental Technology"); }
                    else if (fullList[i].DTStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Dental Technology"); }

                    if (fullList[i].ArchimedesStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Archimedes"); }
                    else if (fullList[i].ArchimedesStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Archimedes"); }
                    else if (fullList[i].ArchimedesStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Archimedes"); }
                    else if (fullList[i].ArchimedesStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Archimedes"); }

                    if (fullList[i].ShadeStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Shade Check"); }
                    else if (fullList[i].ShadeStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Shade Check"); }
                    else if (fullList[i].ShadeStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Shade Check"); }
                    else if (fullList[i].ShadeStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Shade Check"); }

                    if (fullList[i].HomogeneityStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Homogeneity"); }
                    else if (fullList[i].HomogeneityStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Homogeneity"); }
                    else if (fullList[i].HomogeneityStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Homogeneity"); }
                    else if (fullList[i].HomogeneityStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Homogeneity"); }

                    if (fullList[i].PackagingStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Packaging"); ; }
                    else if (fullList[i].PackagingStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Packaging"); }

                    if (fullList[i].PowderStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Powder"); ; }
                    else if (fullList[i].PowderStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Powder"); }
                    else if (fullList[i].PowderStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Powder"); }
                    else if (fullList[i].PowderStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Powder"); }

                    if (fullList[i].DiscRingStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Disc w/Ring"); ; }
                    else if (fullList[i].DiscRingStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Disc w/Ring"); }
                    else if (fullList[i].DiscRingStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Disc w/Ring"); }
                    else if (fullList[i].DiscRingStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Disc w/Ring"); }

                    whichCheck.Add(whichCheckTemp);
                    whichTests.Add(whichTestsTemp);
                    locations.Add(i);

                }
                else if (whereAreWe.Equals("Memorial") && checkBox1.Checked==true && (fullList[i].Material.Equals("Emax Mandrel") || fullList[i].Material.Equals("Empress Mandrel") || fullList[i].Material.Equals("Zircad Mandrel")))
                {
                    List<string> whichCheckTemp = new List<string>();
                    List<string> whichTestsTemp = new List<string>();

                    if (fullList[i].ShearStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Shear Strength"); }
                    else if (fullList[i].ShearStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Shear Strength"); }
                    else if (fullList[i].ShearStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Shear Strength"); }
                    else if (fullList[i].ShearStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Shear Strength"); }

                    if (fullList[i].PackagingStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Packaging"); ; }
                    else if (fullList[i].PackagingStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Packaging"); }

                    whichCheck.Add(whichCheckTemp);
                    whichTests.Add(whichTestsTemp);
                    locations.Add(i);
                }

                else if (whereAreWe.Equals("Pierce") && (fullList[i].Material.Equals("Emax Single") || fullList[i].Material.Equals("Emax Glassblock") || fullList[i].Material.Equals("Procad Single") || fullList[i].Material.Equals("Procad Multi")))
                {
                    List<string> whichCheckTemp = new List<string>();
                    List<string> whichTestsTemp = new List<string>();

                    if (fullList[i].StrengthStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Biaxial Strength"); }
                    else if (fullList[i].StrengthStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Biaxial Strength"); }
                    else if (fullList[i].StrengthStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Biaxial Strength"); }
                    else if (fullList[i].StrengthStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Biaxial Strength"); }

                    if (fullList[i].PSHardnessStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Pre-Sintered/Hardness"); }
                    else if (fullList[i].PSHardnessStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Pre-Sintered/Hardness"); }
                    else if (fullList[i].PSHardnessStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Pre-Sintered/Hardness"); }
                    else if (fullList[i].PSHardnessStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Pre-Sintered/Hardness"); }

                    if (fullList[i].DimensionStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Dimension"); }
                    else if (fullList[i].DimensionStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Dimension"); }
                    else if (fullList[i].DimensionStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Dimension"); }
                    else if (fullList[i].DimensionStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Dimension"); }

                    if (fullList[i].DTStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Dental Technology"); }
                    else if (fullList[i].DTStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Dental Technology"); }
                    else if (fullList[i].DTStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Dental Technology"); }
                    else if (fullList[i].DTStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Dental Technology"); }

                    if (fullList[i].ArchimedesStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Archimedes"); }
                    else if (fullList[i].ArchimedesStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Archimedes"); }
                    else if (fullList[i].ArchimedesStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Archimedes"); }
                    else if (fullList[i].ArchimedesStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Archimedes"); }

                    if (fullList[i].ShadeStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Shade Check"); }
                    else if (fullList[i].ShadeStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Shade Check"); }
                    else if (fullList[i].ShadeStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Shade Check"); }
                    else if (fullList[i].ShadeStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Shade Check"); }

                    if (fullList[i].HomogeneityStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Homogeneity"); }
                    else if (fullList[i].HomogeneityStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Homogeneity"); }
                    else if (fullList[i].HomogeneityStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Homogeneity"); }
                    else if (fullList[i].HomogeneityStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Homogeneity"); }

                    if (fullList[i].XRFStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("XRF"); }
                    else if (fullList[i].XRFStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("XRF"); }
                    else if (fullList[i].XRFStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("XRF"); }
                    else if (fullList[i].XRFStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("XRF"); }

                    if (fullList[i].XRDStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("XRD"); }
                    else if (fullList[i].XRDStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("XRD"); }
                    else if (fullList[i].XRDStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("XRD"); }
                    else if (fullList[i].XRDStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("XRD"); }

                    if (fullList[i].MinoltaStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Minolta"); }
                    else if (fullList[i].MinoltaStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Minolta"); }
                    else if (fullList[i].MinoltaStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Minolta"); }
                    else if (fullList[i].MinoltaStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Minolta"); }

                    if (fullList[i].ShearStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Shear Strength"); }
                    else if (fullList[i].ShearStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Shear Strength"); }
                    else if (fullList[i].ShearStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Shear Strength"); }
                    else if (fullList[i].ShearStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Shear Strength"); }

                    if (fullList[i].PackagingStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Packaging"); }
                    else if (fullList[i].PackagingStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Packaging"); }

                    if (fullList[i].PowderStatus.Equals("In Process")) { whichCheckTemp.Add("Box"); whichTestsTemp.Add("Powder"); ; }
                    else if (fullList[i].PowderStatus.Equals("Warning")) { whichCheckTemp.Add("Yellow"); whichTestsTemp.Add("Powder"); }
                    else if (fullList[i].PowderStatus.Equals("Conform")) { whichCheckTemp.Add("Green"); whichTestsTemp.Add("Powder"); }
                    else if (fullList[i].PowderStatus.Equals("Non-Conform")) { whichCheckTemp.Add("Red"); whichTestsTemp.Add("Powder"); }

                    //pageMaterials.Add(fullList[i].Material);
                    //pageSizeShade.Add(fullList[i].SizeShade);
                    //pageBatch.Add(fullList[i].BatchNum);
                    whichCheck.Add(whichCheckTemp);
                    whichTests.Add(whichTestsTemp);
                    //pageComments.Add(fullList[i].Comments);
                    //pageDate.Add(fullList[i].TargetEndDate);
                    locations.Add(i);


                }
            }
            
        }
        List<SingleBatch> PullList()
        {
            File.Copy("G:\\QC\\QC Milling Ceramics\\QC Open Orders.csv", "G:\\QC\\QC Milling Ceramics\\QC Open Orders_temp.csv", true);
            var column1 = new List<string>();
            var column2 = new List<string>();
            var column3 = new List<string>();
            var column4 = new List<string>();
            var column5 = new List<string>();
            var column6 = new List<string>();
            var column7 = new List<string>();
            var column8 = new List<string>();
            var column9 = new List<string>();
            var column10 = new List<string>();
            var column11 = new List<string>();
            var column12 = new List<string>();
            var column13 = new List<string>();
            var column14 = new List<string>();
            var column15 = new List<string>();
            var column16 = new List<string>();
            var column17 = new List<string>();
            var column18 = new List<string>();
            var column19 = new List<string>();
            var column20 = new List<string>();
            var column21 = new List<string>();
            var column22 = new List<string>();
            var column23 = new List<string>();
            var column24 = new List<string>();
            var column25 = new List<string>();
            var column26 = new List<string>();
            var column27 = new List<string>();
            var column28 = new List<string>();
            var column29 = new List<string>();
            var column30 = new List<string>();
            var column31 = new List<string>();
            var column32 = new List<string>();
            var column33 = new List<string>();
            var column34 = new List<string>();
            var column35 = new List<string>();
            var column36 = new List<string>();
            var column37 = new List<string>();

            using (var rd = new StreamReader("G:\\QC\\QC Milling Ceramics\\QC Open Orders_temp.csv"))
            {
                while (!rd.EndOfStream)
                {
                    string theNextLine = rd.ReadLine();
                    if (theNextLine == "") break;
                    var splits = theNextLine.Split(',');
                    column1.Add(splits[0]);
                    column2.Add(splits[1]);
                    column3.Add(splits[2]);
                    column4.Add(splits[3]);
                    column5.Add(splits[4]);
                    column6.Add(splits[5]);
                    column7.Add(splits[6]);
                    column8.Add(splits[7]);
                    column9.Add(splits[8]);
                    column10.Add(splits[9]);
                    column11.Add(splits[10]);
                    column12.Add(splits[11]);
                    column13.Add(splits[12]);
                    column14.Add(splits[13]);
                    column15.Add(splits[14]);
                    column16.Add(splits[15]);
                    column17.Add(splits[16]);
                    column18.Add(splits[17]);
                    column19.Add(splits[18]);
                    column20.Add(splits[19]);
                    column21.Add(splits[20]);
                    column22.Add(splits[21]);
                    column23.Add(splits[22]);
                    column24.Add(splits[23]);
                    column25.Add(splits[24]);
                    column26.Add(splits[25]);
                    column27.Add(splits[26]);
                    column28.Add(splits[27]);
                    column29.Add(splits[28]);
                    column30.Add(splits[29]);
                    column31.Add(splits[30]);
                    column32.Add(splits[31]);
                    column33.Add(splits[32]);
                    column34.Add(splits[33]);
                    column35.Add(splits[34]);
                    column36.Add(splits[35]);
                    column37.Add(splits[36]);
                }
            }
            File.Delete("G:\\QC\\QC Milling Ceramics\\QC Open Orders_temp.csv");

            for (int i = 1; i < column31.Count; i++)
            {
                SingleBatch oneRow = new SingleBatch();
                oneRow.Material = column1[i];
                oneRow.BatchNum = column2[i];
                oneRow.ReceivedDate = column3[i];
                oneRow.TargetEndDate = column4[i];
                oneRow.StrengthStatus = column5[i];
                oneRow.StrengthDate = column6[i];
                oneRow.PSHardnessStatus = column7[i];
                oneRow.PSHardnessDate = column8[i];
                oneRow.DimensionStatus = column9[i];
                oneRow.DimensionDate = column10[i];
                oneRow.DTStatus = column11[i];
                oneRow.DTDate = column12[i];
                oneRow.ArchimedesStatus = column13[i];
                oneRow.ArchimedesDate = column14[i];
                oneRow.ShadeStatus = column15[i];
                oneRow.ShadeDate = column16[i];
                oneRow.HomogeneityStatus = column17[i];
                oneRow.HomogeneityDate = column18[i];
                oneRow.XRFStatus = column19[i];
                oneRow.XRFDate = column20[i];
                oneRow.XRDStatus = column21[i];
                oneRow.XRDDate = column22[i];
                oneRow.MinoltaStatus = column23[i];
                oneRow.MinoltaDate = column24[i];
                oneRow.ShearStatus = column25[i];
                oneRow.ShearDate = column26[i];
                oneRow.PackagingStatus = column27[i];
                oneRow.PackagingDate = column28[i];
                oneRow.FinalApprovalStatus = column29[i];
                oneRow.FinalApprovalDate = column30[i];
                oneRow.LeadTime = column31[i];
                oneRow.Comments = column32[i];
                oneRow.Quantity = column33[i];
                oneRow.SizeShade = column34[i];
                oneRow.PowderStatus = column35[i];
                oneRow.PowderDate = column36[i];
                fullList.Add(oneRow);
            }

            return fullList;
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            refreshTable();
        }
    }
}

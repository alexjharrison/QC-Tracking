using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace QCTracking
{
    

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FirstScreenForm(PullList()));
        }

        static List<SingleBatch> PullList()
        {
            List<SingleBatch> fullList = new List<SingleBatch>();
            File.Copy("G:\\QC\\QC Milling Ceramics\\Archive\\QC Open Orders.csv", "G:\\QC\\QC Milling Ceramics\\QC Open Orders_temp.csv", true);
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
            var column38 = new List<string>();
            var column39 = new List<string>();

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
                    column38.Add(splits[37]);
                    column39.Add(splits[38]);
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
                oneRow.DiscRingStatus = column37[i];
                oneRow.DiscRingDate = column38[i];
                fullList.Add(oneRow);
            }

            return fullList;
        }

        
    }

    public class SingleBatch
    {
        //private variables
        private string material = "";
        public string Material { get { return material; } set { material = value; } }
        private string batchNum = "";
        public string BatchNum { get { return batchNum; } set { batchNum = value; } }

        private string receivedDate = "";

        public string ReceivedDate
        {
            get { return receivedDate; }
            set { receivedDate = value; }
        }
        private string targetEndDate = "";

        public string TargetEndDate
        {
            get { return targetEndDate; }
            set { targetEndDate = value; }
        }
        private string strengthStatus = "";

        public string StrengthStatus
        {
            get { return strengthStatus; }
            set { strengthStatus = value; }
        }
        private string strengthDate = "";

        public string StrengthDate
        {
            get { return strengthDate; }
            set { strengthDate = value; }
        }
        private string pSHardnessStatus = "";

        public string PSHardnessStatus
        {
            get { return pSHardnessStatus; }
            set { pSHardnessStatus = value; }
        }
        private string pSHardnessDate = "";

        public string PSHardnessDate
        {
            get { return pSHardnessDate; }
            set { pSHardnessDate = value; }
        }
        private string dimensionStatus = "";

        public string DimensionStatus
        {
            get { return dimensionStatus; }
            set { dimensionStatus = value; }
        }
        private string dimensionDate = "";

        public string DimensionDate
        {
            get { return dimensionDate; }
            set { dimensionDate = value; }
        }
        private string dTStatus = "";

        public string DTStatus
        {
            get { return dTStatus; }
            set { dTStatus = value; }
        }
        private string dTDate = "";

        public string DTDate
        {
            get { return dTDate; }
            set { dTDate = value; }
        }
        private string archimedesStatus = "";

        public string ArchimedesStatus
        {
            get { return archimedesStatus; }
            set { archimedesStatus = value; }
        }
        private string archimedesDate = "";

        public string ArchimedesDate
        {
            get { return archimedesDate; }
            set { archimedesDate = value; }
        }
        private string shadeStatus = "";

        public string ShadeStatus
        {
            get { return shadeStatus; }
            set { shadeStatus = value; }
        }
        private string shadeDate = "";

        public string ShadeDate
        {
            get { return shadeDate; }
            set { shadeDate = value; }
        }
        private string homogeneityStatus = "";

        public string HomogeneityStatus
        {
            get { return homogeneityStatus; }
            set { homogeneityStatus = value; }
        }
        private string homogeneityDate = "";

        public string HomogeneityDate
        {
            get { return homogeneityDate; }
            set { homogeneityDate = value; }
        }
        private string xRFStatus = "";

        public string XRFStatus
        {
            get { return xRFStatus; }
            set { xRFStatus = value; }
        }
        private string xRFDate = "";

        public string XRFDate
        {
            get { return xRFDate; }
            set { xRFDate = value; }
        }
        private string xRDStatus = "";

        public string XRDStatus
        {
            get { return xRDStatus; }
            set { xRDStatus = value; }
        }
        private string xRDDate = "";

        public string XRDDate
        {
            get { return xRDDate; }
            set { xRDDate = value; }
        }
        private string minoltaStatus = "";

        public string MinoltaStatus
        {
            get { return minoltaStatus; }
            set { minoltaStatus = value; }
        }
        private string minoltaDate = "";

        public string MinoltaDate
        {
            get { return minoltaDate; }
            set { minoltaDate = value; }
        }
        private string shearStatus = "";

        public string ShearStatus
        {
            get { return shearStatus; }
            set { shearStatus = value; }
        }
        private string shearDate = "";

        public string ShearDate
        {
            get { return shearDate; }
            set { shearDate = value; }
        }
        private string packagingStatus = "";

        public string PackagingStatus
        {
            get { return packagingStatus; }
            set { packagingStatus = value; }
        }
        private string packagingDate = "";

        public string PackagingDate
        {
            get { return packagingDate; }
            set { packagingDate = value; }
        }
        private string finalApprovalStatus = "";

        public string FinalApprovalStatus
        {
            get { return finalApprovalStatus; }
            set { finalApprovalStatus = value; }
        }
        private string finalApprovalDate = "";

        public string FinalApprovalDate
        {
            get { return finalApprovalDate; }
            set { finalApprovalDate = value; }
        }
        private string leadTime = "";

        public string LeadTime
        {
            get { return leadTime; }
            set { leadTime = value; }
        }
        private string comments = "";

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private string quantity = "";

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        protected string ignore = "0";
        private string sizeShade = "";

        public string SizeShade
        {
            get { return sizeShade; }
            set { sizeShade = value; }
        }
        private string powderStatus = "";

        public string PowderStatus
        {
            get { return powderStatus; }
            set { powderStatus = value; }
        }

        
        private string powderDate = "";

        public string PowderDate
        {
            get { return powderDate; }
            set { powderDate = value; }
        }

        private string discRingStatus = "";

        public string DiscRingStatus
        {
            get { return discRingStatus; }
            set { discRingStatus = value; }
        }

        private string discRingDate = "";

        public string DiscRingDate
        {
            get { return discRingDate; }
            set { discRingDate = value; }
        }

    }
}

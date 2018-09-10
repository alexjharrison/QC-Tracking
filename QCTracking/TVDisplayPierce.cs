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
    public partial class TVDisplayPierce : Form
    {
        List<SingleBatch> fullList = new List<SingleBatch>();

        public TVDisplayPierce(List<SingleBatch> passedList)
        {
            InitializeComponent();
            this.Location = new Point(100, 100);

        }
    }
}

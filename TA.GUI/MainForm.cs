using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var loader = new TA.Core.Loader();
            loader.Load(@"source.txt").RemoveUselessChars().ToUpperCase();
            var w = loader.Words;

            var frequency = new TA.Basic.Frequency(w);
            frequency.Process();
        }
    }
}

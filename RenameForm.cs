using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace SuperCalc
{
    public partial class RenameForm : MaterialForm
    {
        public string newName;
        public RenameForm()
        {
            InitializeComponent();
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            newName = textBox.Text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleBufferedForms;

namespace SuperCalc
{
    public partial class TestForm : Form
    {

        public TestForm()
        {
            InitializeComponent();
            
            LayoutInit();
            GridsInit();
        }

        TableLayoutPanel tableLayoutPanel;
        DoubleBufferedDataGridView dataGridView = new DoubleBufferedDataGridView();
        DoubleBufferedDataGridView verticalGrid = new DoubleBufferedDataGridView();
        DoubleBufferedDataGridView horizontalGrid = new DoubleBufferedDataGridView();
        private void GridsInit()
        {
            dataGridView.Scroll += DataGridView1_Scroll;
            dataGridView.ColumnWidthChanged += DataGridView_ColumnWidthChanged;
            dataGridView.RowHeightChanged += DataGridView_RowHeightChanged;
            dataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;
            dataGridView.RowCount = 100;
            dataGridView.ColumnCount = 26;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;

            horizontalGrid.ColumnWidthChanged += HorizontalGrid_ColumnWidthChanged;
            horizontalGrid.CellClick += HorizontalGrid_CellClick;
            horizontalGrid.ColumnCount = 26;
            horizontalGrid.RowCount = 2;
            horizontalGrid.Dock = DockStyle.Fill;
            horizontalGrid.BorderStyle = BorderStyle.None;
            horizontalGrid.ColumnHeadersVisible = false;
            horizontalGrid.RowHeadersVisible = false;
            horizontalGrid.ScrollBars = ScrollBars.None;
            horizontalGrid.AllowUserToAddRows = false;
            horizontalGrid.AllowUserToResizeRows = false;
            horizontalGrid.ReadOnly = true;

            verticalGrid.RowHeightChanged += VerticalGrid_RowHeightChanged;
            verticalGrid.CellClick += VerticalGrid_CellClick;
            verticalGrid.RowCount = 100;
            verticalGrid.Dock = DockStyle.Fill;
            verticalGrid.BorderStyle = BorderStyle.None;
            verticalGrid.ColumnHeadersVisible = false;
            verticalGrid.RowHeadersVisible = false;
            verticalGrid.ScrollBars = ScrollBars.None;
            verticalGrid.AllowUserToAddRows = false;
            verticalGrid.ReadOnly = true;
        }

        private void VerticalGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.ClearSelection();
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView[i, e.RowIndex].Selected = true;
                horizontalGrid[i, 0].Selected = true;
            }
        }

        private void HorizontalGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.ClearSelection();
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView[e.ColumnIndex, i].Selected = true;
                verticalGrid[0, i].Selected = true;
            }
        }

        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            horizontalGrid.CurrentCell = horizontalGrid[dataGridView.CurrentCell.ColumnIndex, 0];
            verticalGrid.CurrentCell = verticalGrid[0, dataGridView.CurrentCell.RowIndex];
        }

        private void VerticalGrid_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView.Rows[e.Row.Index].Height = e.Row.Height;
        }

        private void HorizontalGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView.Columns[e.Column.Index].Width = e.Column.Width;
        }

        private void DataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            verticalGrid.Rows[e.Row.Index].Height = e.Row.Height;
        }

        private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            horizontalGrid.Columns[e.Column.Index].Width = e.Column.Width;
        }

        private void LayoutInit()
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95F));
            tableLayoutPanel.Controls.Add(dataGridView, 1, 1);
            tableLayoutPanel.Controls.Add(horizontalGrid, 1, 0);
            tableLayoutPanel.Controls.Add(verticalGrid, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ForeColor = SystemColors.ActiveCaptionText;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel.Size = new Size(800, 450);
            tableLayoutPanel.TabIndex = 0;
            Controls.Add(tableLayoutPanel);
        }

        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                horizontalGrid.HorizontalScrollingOffset = dataGridView.HorizontalScrollingOffset;
            }
            else 
            {
                verticalGrid.FirstDisplayedScrollingRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            }
        }
        
    }
}

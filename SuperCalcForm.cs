using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using DoubleBufferedForms;
using System.IO;

namespace SuperCalc
{
    public partial class SuperCalcForm : MaterialForm
    {
        List<DoubleBufferedDataGridView> dataGrids = new List<DoubleBufferedDataGridView>();
        List<DoubleBufferedDataGridView> horizontalGrids = new List<DoubleBufferedDataGridView>();
        List<DoubleBufferedDataGridView> verticalGrids = new List<DoubleBufferedDataGridView>();

        bool isSaved = true;
        string fileName;

        public SuperCalcForm()
        {
            InitializeComponent();
            AddPage();
        }

        private void addPageButton_Click(object sender, EventArgs e)
        {
            AddPage();
            isSaved = false;
        }

        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            AskForm askForm = new AskForm("Вы гей!");
            askForm.ShowDialog();
        }

        private void AddPage()
        {
            Data.AddNewDataTable();

            DoubleBufferedDataGridView dataGridView = new DoubleBufferedDataGridView();
            DoubleBufferedDataGridView verticalGrid = new DoubleBufferedDataGridView();
            DoubleBufferedDataGridView horizontalGrid = new DoubleBufferedDataGridView();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

            GridInit(ref dataGridView);

            dataGridView.DataSource = Data.dataSet.Tables[Data.dataSet.Tables.Count - 1];
            dataGrids.Add(dataGridView);

            RowColumnInit(Data.dataSet.Tables.Count - 1, ref horizontalGrid, ref verticalGrid);
            verticalGrids.Add(verticalGrid);
            horizontalGrids.Add(horizontalGrid);

            tabControl.TabPages.Add(Data.dataSet.Tables[Data.dataSet.Tables.Count - 1].TableName);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls.Add(tableLayoutPanel);
            tabControl.TabPages[tabControl.TabPages.Count - 1].ContextMenuStrip = contextMenuStrip;
            LayoutInit(ref tableLayoutPanel, ref dataGridView, ref horizontalGrid, ref verticalGrid);
        }

        private void GridInit(ref DoubleBufferedDataGridView dataGridView)
        {
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AllowUserToAddRows = true;
            dataGridView.GridColor = SystemColors.ControlLight;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            dataGridView.SelectionChanged += ColumnRowSelectedCellRedraw;
            dataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
            dataGridView.Scroll += DataGridView_Scroll;
            dataGridView.ColumnWidthChanged += DataGridView_ColumnWidthChanged;
            dataGridView.RowHeightChanged += DataGridView_RowHeightChanged;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(61, 81, 181);
        }

        private void DataGridView_CellValueChanged(object sender, EventArgs e)
        {
            isSaved = false;
        }

        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            int rowIndex = dataGridView.CurrentCellAddress.Y;
            int columnIndex = dataGridView.CurrentCellAddress.X;
            positionLabel.Text = Convert.ToChar('A' + columnIndex).ToString() + (rowIndex + 1).ToString();
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            string first = Convert.ToChar('A' + dataGridView.CurrentCellAddress.X).ToString() + (dataGridView.CurrentCellAddress.Y + 1).ToString();

            if (dataGridView.SelectedCells.Count <= 1)
                return;

            string last = Convert.ToChar('A' + dataGridView.SelectedCells[dataGridView.SelectedCells.Count - 1].ColumnIndex).ToString()
                    + (dataGridView.SelectedCells[dataGridView.SelectedCells.Count - 1].RowIndex + 1).ToString();

            if (dataGridView.CurrentCell.ColumnIndex < dataGridView.SelectedCells[dataGridView.SelectedCells.Count - 1].ColumnIndex
                || dataGridView.CurrentCell.RowIndex < dataGridView.SelectedCells[dataGridView.SelectedCells.Count - 1].RowIndex)
            {
                positionLabel.Text = first + ":" + last;
            }
            else 
            {
                positionLabel.Text = last + ":" + first;
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                if (MaterialMessageBox.Show("Изменения не были сохранены. Продолжить?", "Внимание", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return; 
                }
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    fileNameLabel.Text = openFileDialog.SafeFileName;
                }
                else
                    return;
            }

            Data.Import(fileName);
            LoadTables();
            isSaved = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                if (MaterialMessageBox.Show("Изменения не были сохранены. Продолжить?", "Внимание", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    fileNameLabel.Text = openFileDialog.SafeFileName;
                }
                else
                    return;
            }

            Data.Open(fileName);
            LoadTables();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    fileNameLabel.Text = Path.GetFileName(saveFileDialog.FileName);
                }
                else
                    return;

                Data.Save(fileName);
            }
            isSaved = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName.Contains(".xml") || fileName.Contains(".xml\r"))
            {
                Data.Save(fileName);
            }
            else
            {
                MaterialMessageBox.Show("Для сохранения импортированных\nданных необходимо выбрать пункт\n\"Сохранить как\" во вкладке \"Файл\"", "Внимание");
            }
            isSaved = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSaved = false;
            Data.dataSet.Tables.RemoveAt(tabControl.SelectedIndex);
            dataGrids.RemoveAt(tabControl.SelectedIndex);
            horizontalGrids.RemoveAt(tabControl.SelectedIndex);
            verticalGrids.RemoveAt(tabControl.SelectedIndex);
            tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
        }

        private void SuperCalcForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                if (MaterialMessageBox.Show("Изменения не были сохранены. Продолжить?",  "Внимание", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void LoadTables()
        {
            dataGrids.Clear();
            horizontalGrids.Clear();
            verticalGrids.Clear();
            tabControl.TabPages.Clear();

            DoubleBufferedDataGridView dataGridView;
            DoubleBufferedDataGridView horizontalGrid;
            DoubleBufferedDataGridView verticalGrid;
            TableLayoutPanel tableLayoutPanel;

            for (int i = 0; i < Data.dataSet.Tables.Count; i++)
            {
                dataGridView = new DoubleBufferedDataGridView();
                horizontalGrid = new DoubleBufferedDataGridView();
                verticalGrid = new DoubleBufferedDataGridView();
                tableLayoutPanel = new TableLayoutPanel();
                GridInit(ref dataGridView);
                RowColumnInit(i, ref horizontalGrid, ref verticalGrid);
                dataGridView.DataSource = Data.dataSet.Tables[i];
                dataGrids.Add(dataGridView);
                verticalGrids.Add(verticalGrid);
                horizontalGrids.Add(horizontalGrid);

                LayoutInit(ref tableLayoutPanel, ref dataGridView, ref horizontalGrid, ref verticalGrid);
                tabControl.TabPages.Add(Data.dataSet.Tables[i].TableName.Trim('\'', '$'));
                tabControl.TabPages[i].Controls.Add(tableLayoutPanel);
                tabControl.TabPages[i].ContextMenuStrip = contextMenuStrip;
            }
        }

        private void renamePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameForm renameForm = new RenameForm();
            string newName = renameForm.Show();
            if (newName == null)
                return;
            else
            {
                tabControl.SelectedTab.Text = newName;
                Data.dataSet.Tables[tabControl.SelectedIndex].TableName = newName;
            }

            isSaved = false;
        }

        private void RowColumnInit(int index, ref DoubleBufferedDataGridView horizontalGrid, ref DoubleBufferedDataGridView verticalGrid)
        {
            horizontalGrid.ColumnWidthChanged += HorizontalGrid_ColumnWidthChanged;
            horizontalGrid.CellClick += HorizontalGrid_CellClick;
            horizontalGrid.ColumnCount = Data.dataSet.Tables[index].Columns.Count;
            horizontalGrid.RowCount = 2;
            horizontalGrid.Dock = DockStyle.Fill;
            horizontalGrid.BorderStyle = BorderStyle.None;
            horizontalGrid.ColumnHeadersVisible = false;
            horizontalGrid.RowHeadersVisible = false;
            horizontalGrid.ScrollBars = ScrollBars.None;
            horizontalGrid.AllowUserToAddRows = false;
            horizontalGrid.AllowUserToResizeRows = false;
            horizontalGrid.ReadOnly = true;
            horizontalGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(61, 81, 181);

            for (int i = 0; i < Data.dataSet.Tables[index].Columns.Count; i++)
            {
                horizontalGrid[i, 0].Value = Convert.ToChar('A' + i).ToString();
            }

            verticalGrid.RowHeightChanged += VerticalGrid_RowHeightChanged;
            verticalGrid.CellClick += VerticalGrid_CellClick;
            verticalGrid.RowCount = Data.dataSet.Tables[index].Rows.Count + 1;
            verticalGrid.Dock = DockStyle.Fill;
            verticalGrid.BorderStyle = BorderStyle.None;
            verticalGrid.ColumnHeadersVisible = false;
            verticalGrid.RowHeadersVisible = false;
            verticalGrid.ScrollBars = ScrollBars.None;
            verticalGrid.AllowUserToAddRows = false;
            verticalGrid.ReadOnly = true;
            verticalGrid.Columns[0].Width = 40;
            verticalGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(61, 81, 181);

            for (int i = 0; i < Data.dataSet.Tables[index].Rows.Count; i++)
            {
                verticalGrid[0, i].Value = (i + 1).ToString();
            }
        }

        private void VerticalGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrids[tabControl.SelectedIndex].ClearSelection();
            for (int i = 0; i < dataGrids[tabControl.SelectedIndex].ColumnCount; i++)
            {
                dataGrids[tabControl.SelectedIndex][i, e.RowIndex].Selected = true;
                horizontalGrids[tabControl.SelectedIndex][i, 0].Selected = true;
            }
            verticalGrids[tabControl.SelectedIndex].ClearSelection();
            verticalGrids[tabControl.SelectedIndex][0, e.RowIndex].Selected = true;
        }

        private void HorizontalGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrids[tabControl.SelectedIndex].ClearSelection();
            for (int i = 0; i < dataGrids[tabControl.SelectedIndex].RowCount; i++)
            {
                dataGrids[tabControl.SelectedIndex][e.ColumnIndex, i].Selected = true;
                verticalGrids[tabControl.SelectedIndex][0, i].Selected = true;
            }
            horizontalGrids[tabControl.SelectedIndex].ClearSelection();
            horizontalGrids[tabControl.SelectedIndex][e.ColumnIndex, 0].Selected = true;
        }

        private void ColumnRowSelectedCellRedraw(object sender, EventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                int columnIndex = dataGridView.CurrentCell.ColumnIndex;

                horizontalGrids[tabControl.SelectedIndex].CurrentCell = horizontalGrids[tabControl.SelectedIndex][columnIndex, 0];
                verticalGrids[tabControl.SelectedIndex].CurrentCell = verticalGrids[tabControl.SelectedIndex][0, rowIndex];
            }
            catch
            { }
        }

        private void VerticalGrid_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            dataGrids[tabControl.SelectedIndex].Rows[e.Row.Index].Height = e.Row.Height;
        }

        private void HorizontalGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataGrids[tabControl.SelectedIndex].Columns[e.Column.Index].Width = e.Column.Width;
        }

        private void DataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            verticalGrids[tabControl.SelectedIndex].Rows[e.Row.Index].Height = e.Row.Height;
        }

        private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            horizontalGrids[tabControl.SelectedIndex].Columns[e.Column.Index].Width = e.Column.Width;
        }

        private void LayoutInit(ref TableLayoutPanel tableLayoutPanel, ref DoubleBufferedDataGridView dataGridView, ref DoubleBufferedDataGridView horizontalGrid, ref DoubleBufferedDataGridView verticalGrid)
        {
            Button selectAllButton = new Button();
            selectAllButton.MouseClick += SelectAllButton_MouseClick;
            selectAllButton.BackColor = Color.FromArgb(61, 81, 181);

            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(dataGridView, 1, 1);
            tableLayoutPanel.Controls.Add(horizontalGrid, 1, 0);
            tableLayoutPanel.Controls.Add(verticalGrid, 0, 1);
            tableLayoutPanel.Controls.Add(selectAllButton, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ForeColor = SystemColors.ActiveCaptionText;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 29));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Size = new Size(800, 450);
            tableLayoutPanel.TabIndex = 0;
        }

        private void SelectAllButton_MouseClick(object sender, EventArgs e)
        {
            dataGrids[tabControl.SelectedIndex].SelectAll();
            positionLabel.Text = "A1:Z1000";
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                horizontalGrids[tabControl.SelectedIndex].HorizontalScrollingOffset = dataGridView.HorizontalScrollingOffset;
            }
            else
            {
                verticalGrids[tabControl.SelectedIndex].FirstDisplayedScrollingRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            }
        }

        private void clearSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrids[tabControl.SelectedIndex].SelectedCells.Count; i++)
            {
                dataGrids[tabControl.SelectedIndex].SelectedCells[i].Value = DBNull.Value;
            }
        }

        private void clearActiveColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrids[tabControl.SelectedIndex].RowCount; i++)
                dataGrids[tabControl.SelectedIndex][dataGrids[tabControl.SelectedIndex].CurrentCell.ColumnIndex, i].Value = DBNull.Value;
            
        }

        private void clearActiveRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrids[tabControl.SelectedIndex].ColumnCount; i++)
                dataGrids[tabControl.SelectedIndex].CurrentRow.Cells[i].Value = DBNull.Value;
        }


        private void enterButton_Click(object sender, EventArgs e)
        {
            Evaluate();    
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Evaluate();
            }
        }

        public void Evaluate()
        {
            int rowIndex = dataGrids[tabControl.SelectedIndex].CurrentCell.RowIndex;
            int columnIndex = dataGrids[tabControl.SelectedIndex].CurrentCell.ColumnIndex;
            string result = Expression.Evaluate(textBox.Text, tabControl.SelectedIndex);

            if (result == null)
            {
                textBox.Text = "ошибка";

            }
            else
            {
                Data.dataSet.Tables[tabControl.SelectedIndex].Rows[rowIndex][columnIndex] = result;
            }
        }
    }
}
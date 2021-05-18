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
        string fileName;
        List<DoubleBufferedDataGridView> dataGrids = new List<DoubleBufferedDataGridView>();
        bool isSaved = true;

        public SuperCalcForm()
        {
            InitializeComponent();

        }

        private void addPageButton_Click(object sender, EventArgs e)
        {
            Data.AddNewDataTable();

            DoubleBufferedDataGridView dataGridView = new DoubleBufferedDataGridView();
            Initialize(ref dataGridView);
            dataGridView.DataSource = Data.dataSet.Tables[Data.dataSet.Tables.Count - 1];
            dataGrids.Add(dataGridView);

            tabControl.TabPages.Add(Data.dataSet.Tables[Data.dataSet.Tables.Count - 1].TableName);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls.Add(dataGridView);
            tabControl.TabPages[tabControl.TabPages.Count - 1].ContextMenuStrip = contextMenuStrip;

            isSaved = false;
        }
        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            MaterialMessageBox.Show("Вы гей.", "Внимание!");
        }
        private void Initialize(ref DoubleBufferedDataGridView dataGridView)
        {
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AllowUserToAddRows = true;
            dataGridView.GridColor = SystemColors.ControlLight;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            dataGridView.CurrentCellChanged += dataGridView_CurrentCellChanged;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;

            DataTable dataTable = new DataTable();
            for (int i = 0; i <= 25; i++)
                dataTable.Columns.Add(new DataColumn(Convert.ToChar('A' + i).ToString()));

            for (int i = 0; i < 1000; i++)
                dataTable.Rows.Add();

            dataGridView.RowHeadersVisible = false;
            dataGridView.ColumnHeadersVisible = false;

            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(61, 81, 181);
        }
        private void dataGridView_CellValueChanged(object sender, EventArgs e)
        {
            isSaved = false;
        }
        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            positionLabel.Text = Convert.ToChar('A' + dataGridView.CurrentCellAddress.X).ToString() + (dataGridView.CurrentCellAddress.Y + 1).ToString();
        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
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
            tabControl.TabPages.Clear();
            LoadTables();
            Redraw();
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
            Data.dataSet.Tables.RemoveAt(tabControl.SelectedIndex);
            dataGrids.RemoveAt(tabControl.SelectedIndex);
            tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);

            isSaved = false;
        }
        private void SuperCalcForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                if (MaterialMessageBox.Show("Изменения не были сохранены. Продолжить?", "Внимание", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        private void LoadTables()
        {
            dataGrids.Clear();
            for(int i = 0; i < Data.dataSet.Tables.Count; i++)
            {
                DoubleBufferedDataGridView dataGridView = new DoubleBufferedDataGridView();
                Initialize(ref dataGridView);
                dataGridView.DataSource = Data.dataSet.Tables[i];
                dataGrids.Add(dataGridView);
            }
            Redraw();
        }
        private void Redraw()
        {
            tabControl.TabPages.Clear();
            for (int i = 0; i < dataGrids.Count; i++)
            {
                tabControl.TabPages.Add(Data.dataSet.Tables[i].TableName.Trim('\'', '$'));
                tabControl.TabPages[i].Controls.Add(dataGrids[i]);
                tabControl.TabPages[i].ContextMenuStrip = contextMenuStrip;
            }
        }

        private void renamePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameForm renameForm = new RenameForm();
            renameForm.ShowDialog();
        }

        private void перейтиВТестовыйРежимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.Show();
        }
    }
}

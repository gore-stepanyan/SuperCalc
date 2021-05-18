namespace SuperCalc
{
    partial class SuperCalcForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.menuStripPanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСтраницуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPanel = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.positionLabel = new System.Windows.Forms.Label();
            this.addPageButton = new System.Windows.Forms.Button();
            this.dataGridPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.deletePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renamePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейтиВТестовыйРежимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.dataGridPanel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(3, 3);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(71, 16);
            this.headerLabel.TabIndex = 7;
            this.headerLabel.Text = "SuperCalc";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameLabel.ForeColor = System.Drawing.Color.White;
            this.fileNameLabel.Location = new System.Drawing.Point(1, 31);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(217, 25);
            this.fileNameLabel.TabIndex = 8;
            this.fileNameLabel.Text = "Новый документ.xml";
            // 
            // menuStripPanel
            // 
            this.menuStripPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStripPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStripPanel.Controls.Add(this.menuStrip);
            this.menuStripPanel.Location = new System.Drawing.Point(0, 64);
            this.menuStripPanel.Name = "menuStripPanel";
            this.menuStripPanel.Size = new System.Drawing.Size(750, 24);
            this.menuStripPanel.TabIndex = 9;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(750, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openXmlToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Импорт из Excel";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // openXmlToolStripMenuItem
            // 
            this.openXmlToolStripMenuItem.Name = "openXmlToolStripMenuItem";
            this.openXmlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openXmlToolStripMenuItem.Text = "Открыть";
            this.openXmlToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСтраницуToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // добавитьСтраницуToolStripMenuItem
            // 
            this.добавитьСтраницуToolStripMenuItem.Name = "добавитьСтраницуToolStripMenuItem";
            this.добавитьСтраницуToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.добавитьСтраницуToolStripMenuItem.Text = "Добавить страницу";
            this.добавитьСтраницуToolStripMenuItem.Click += new System.EventHandler(this.addPageButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteToolStripMenuItem.Text = "Удалить страницу";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перейтиВТестовыйРежимToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripPanel.Location = new System.Drawing.Point(0, 88);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(750, 48);
            this.toolStripPanel.TabIndex = 10;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(750, 48);
            this.toolStrip.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.panel1.Controls.Add(this.positionLabel);
            this.panel1.Controls.Add(this.addPageButton);
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 24);
            this.panel1.TabIndex = 11;
            // 
            // positionLabel
            // 
            this.positionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.positionLabel.ForeColor = System.Drawing.Color.White;
            this.positionLabel.Location = new System.Drawing.Point(669, 5);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(79, 16);
            this.positionLabel.TabIndex = 1;
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // addPageButton
            // 
            this.addPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPageButton.FlatAppearance.BorderSize = 0;
            this.addPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPageButton.ForeColor = System.Drawing.Color.White;
            this.addPageButton.Location = new System.Drawing.Point(0, 0);
            this.addPageButton.Name = "addPageButton";
            this.addPageButton.Size = new System.Drawing.Size(145, 24);
            this.addPageButton.TabIndex = 0;
            this.addPageButton.Text = "Добавить страницу";
            this.addPageButton.UseVisualStyleBackColor = true;
            this.addPageButton.Click += new System.EventHandler(this.addPageButton_Click);
            // 
            // dataGridPanel
            // 
            this.dataGridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPanel.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridPanel.Controls.Add(this.tabControl);
            this.dataGridPanel.Location = new System.Drawing.Point(0, 137);
            this.dataGridPanel.Name = "dataGridPanel";
            this.dataGridPanel.Size = new System.Drawing.Size(750, 339);
            this.dataGridPanel.TabIndex = 12;
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(80, 24);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(4, 4);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(750, 339);
            this.tabControl.TabIndex = 9;
            this.tabControl.DoubleClick += new System.EventHandler(this.tabControl_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.contextMenuStrip.Depth = 0;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletePageToolStripMenuItem,
            this.renamePageToolStripMenuItem});
            this.contextMenuStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(216, 48);
            // 
            // deletePageToolStripMenuItem
            // 
            this.deletePageToolStripMenuItem.Name = "deletePageToolStripMenuItem";
            this.deletePageToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.deletePageToolStripMenuItem.Text = "Удалить страницу";
            this.deletePageToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renamePageToolStripMenuItem
            // 
            this.renamePageToolStripMenuItem.Name = "renamePageToolStripMenuItem";
            this.renamePageToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.renamePageToolStripMenuItem.Text = "Переименовать страницу";
            this.renamePageToolStripMenuItem.Click += new System.EventHandler(this.renamePageToolStripMenuItem_Click);
            // 
            // перейтиВТестовыйРежимToolStripMenuItem
            // 
            this.перейтиВТестовыйРежимToolStripMenuItem.Name = "перейтиВТестовыйРежимToolStripMenuItem";
            this.перейтиВТестовыйРежимToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.перейтиВТестовыйРежимToolStripMenuItem.Text = "Перейти в тестовый режим";
            this.перейтиВТестовыйРежимToolStripMenuItem.Click += new System.EventHandler(this.перейтиВТестовыйРежимToolStripMenuItem_Click);
            // 
            // SuperCalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.dataGridPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripPanel);
            this.Controls.Add(this.menuStripPanel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.headerLabel);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SuperCalcForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuperCalcForm_FormClosing);
            this.menuStripPanel.ResumeLayout(false);
            this.menuStripPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.dataGridPanel.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Panel menuStripPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.Panel toolStripPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel dataGridPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button addPageButton;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label positionLabel;
        private MaterialSkin.Controls.MaterialContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deletePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renamePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтраницуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейтиВТестовыйРежимToolStripMenuItem;
    }
}



namespace SuperCalc
{
    partial class RenameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new MaterialSkin.Controls.MaterialButton();
            this.renameButton = new MaterialSkin.Controls.MaterialButton();
            this.textBox = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Depth = 0;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.DrawShadows = true;
            this.cancelButton.HighEmphasis = true;
            this.cancelButton.Icon = null;
            this.cancelButton.Location = new System.Drawing.Point(211, 108);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(82, 36);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelButton.UseAccentColor = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // renameButton
            // 
            this.renameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.renameButton.Depth = 0;
            this.renameButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.renameButton.DrawShadows = true;
            this.renameButton.HighEmphasis = true;
            this.renameButton.Icon = null;
            this.renameButton.Location = new System.Drawing.Point(55, 108);
            this.renameButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.renameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(148, 36);
            this.renameButton.TabIndex = 1;
            this.renameButton.Text = "Переименовать";
            this.renameButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.renameButton.UseAccentColor = false;
            this.renameButton.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBox.Location = new System.Drawing.Point(113, 74);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(182, 22);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 74);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(101, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Введите имя:";
            // 
            // RenameForm
            // 
            this.AcceptButton = this.renameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "RenameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Переименовать";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton cancelButton;
        private MaterialSkin.Controls.MaterialButton renameButton;
        private System.Windows.Forms.TextBox textBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
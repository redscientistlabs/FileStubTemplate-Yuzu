
namespace FileStub.Templates
{
    partial class FileStubTemplateYuzu
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
            this.lbTemplateDescription = new System.Windows.Forms.Label();
            this.pnTarget = new System.Windows.Forms.Panel();
            this.cbSelectedGame = new System.Windows.Forms.ComboBox();
            this.lbGameName = new System.Windows.Forms.Label();
            this.btnPrepareMod = new System.Windows.Forms.Button();
            this.lbNSOTarget = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrepareNROMod = new System.Windows.Forms.Button();
            this.pnTarget.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTemplateDescription
            // 
            this.lbTemplateDescription.AllowDrop = true;
            this.lbTemplateDescription.BackColor = System.Drawing.Color.Transparent;
            this.lbTemplateDescription.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbTemplateDescription.ForeColor = System.Drawing.Color.White;
            this.lbTemplateDescription.Location = new System.Drawing.Point(-2, 0);
            this.lbTemplateDescription.Name = "lbTemplateDescription";
            this.lbTemplateDescription.Padding = new System.Windows.Forms.Padding(16);
            this.lbTemplateDescription.Size = new System.Drawing.Size(276, 103);
            this.lbTemplateDescription.TabIndex = 38;
            this.lbTemplateDescription.Tag = "";
            this.lbTemplateDescription.Text = "_";
            this.lbTemplateDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnTarget
            // 
            this.pnTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.pnTarget.Controls.Add(this.cbSelectedGame);
            this.pnTarget.Controls.Add(this.lbGameName);
            this.pnTarget.Controls.Add(this.btnPrepareNROMod);
            this.pnTarget.Controls.Add(this.btnPrepareMod);
            this.pnTarget.Controls.Add(this.lbNSOTarget);
            this.pnTarget.Location = new System.Drawing.Point(14, 126);
            this.pnTarget.Name = "pnTarget";
            this.pnTarget.Size = new System.Drawing.Size(274, 140);
            this.pnTarget.TabIndex = 39;
            this.pnTarget.Tag = "color:normal";
            // 
            // cbSelectedGame
            // 
            this.cbSelectedGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.cbSelectedGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectedGame.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbSelectedGame.ForeColor = System.Drawing.Color.White;
            this.cbSelectedGame.FormattingEnabled = true;
            this.cbSelectedGame.Items.AddRange(new object[] {
            "None"});
            this.cbSelectedGame.Location = new System.Drawing.Point(6, 116);
            this.cbSelectedGame.Name = "cbSelectedGame";
            this.cbSelectedGame.Size = new System.Drawing.Size(265, 21);
            this.cbSelectedGame.TabIndex = 140;
            this.cbSelectedGame.Tag = "color:normal";
            this.cbSelectedGame.SelectedIndexChanged += new System.EventHandler(this.cbSelectedGame_SelectedIndexChanged);
            // 
            // lbGameName
            // 
            this.lbGameName.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lbGameName.ForeColor = System.Drawing.Color.White;
            this.lbGameName.Location = new System.Drawing.Point(4, 93);
            this.lbGameName.Name = "lbGameName";
            this.lbGameName.Size = new System.Drawing.Size(267, 20);
            this.lbGameName.TabIndex = 194;
            this.lbGameName.Text = "No game selected.";
            // 
            // btnPrepareMod
            // 
            this.btnPrepareMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrepareMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrepareMod.FlatAppearance.BorderSize = 0;
            this.btnPrepareMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepareMod.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPrepareMod.ForeColor = System.Drawing.Color.White;
            this.btnPrepareMod.Location = new System.Drawing.Point(186, 3);
            this.btnPrepareMod.Name = "btnPrepareMod";
            this.btnPrepareMod.Size = new System.Drawing.Size(85, 40);
            this.btnPrepareMod.TabIndex = 192;
            this.btnPrepareMod.TabStop = false;
            this.btnPrepareMod.Tag = "color:dark1";
            this.btnPrepareMod.Text = "Prepare Exefs Mod";
            this.btnPrepareMod.UseVisualStyleBackColor = false;
            this.btnPrepareMod.Click += new System.EventHandler(this.btnPrepareMod_click);
            // 
            // lbNSOTarget
            // 
            this.lbNSOTarget.AllowDrop = true;
            this.lbNSOTarget.BackColor = System.Drawing.Color.Transparent;
            this.lbNSOTarget.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbNSOTarget.ForeColor = System.Drawing.Color.White;
            this.lbNSOTarget.Location = new System.Drawing.Point(3, 3);
            this.lbNSOTarget.Name = "lbNSOTarget";
            this.lbNSOTarget.Padding = new System.Windows.Forms.Padding(8);
            this.lbNSOTarget.Size = new System.Drawing.Size(130, 32);
            this.lbNSOTarget.TabIndex = 39;
            this.lbNSOTarget.Tag = "";
            this.lbNSOTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel1.Controls.Add(this.lbTemplateDescription);
            this.panel1.Location = new System.Drawing.Point(14, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 103);
            this.panel1.TabIndex = 40;
            this.panel1.Tag = "color:normal";
            // 
            // btnPrepareNROMod
            // 
            this.btnPrepareNROMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrepareNROMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrepareNROMod.FlatAppearance.BorderSize = 0;
            this.btnPrepareNROMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepareNROMod.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPrepareNROMod.ForeColor = System.Drawing.Color.White;
            this.btnPrepareNROMod.Location = new System.Drawing.Point(186, 49);
            this.btnPrepareNROMod.Name = "btnPrepareNROMod";
            this.btnPrepareNROMod.Size = new System.Drawing.Size(85, 40);
            this.btnPrepareNROMod.TabIndex = 192;
            this.btnPrepareNROMod.TabStop = false;
            this.btnPrepareNROMod.Tag = "color:dark1";
            this.btnPrepareNROMod.Text = "Prepare NRO Mod";
            this.btnPrepareNROMod.UseVisualStyleBackColor = false;
            this.btnPrepareNROMod.Click += new System.EventHandler(this.btnPrepareNROMod_Click);
            // 
            // FileStubTemplateYuzu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(300, 280);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnTarget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileStubTemplateYuzu";
            this.Tag = "color:dark1";
            this.Text = "Yuzu";
            this.Load += new System.EventHandler(this.FileStubTemplateYuzu_Load);
            this.pnTarget.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbTemplateDescription;
        private System.Windows.Forms.Panel pnTarget;
        public System.Windows.Forms.Label lbNSOTarget;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cbSelectedGame;
        public System.Windows.Forms.Label lbGameName;
        private System.Windows.Forms.Button btnPrepareMod;
        private System.Windows.Forms.Button btnPrepareNROMod;
    }
}

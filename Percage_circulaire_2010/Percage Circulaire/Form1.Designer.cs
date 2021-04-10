namespace Percage_Circulaire
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NUDPrecision = new System.Windows.Forms.NumericUpDown();
            this.lPrecision = new System.Windows.Forms.Label();
            this.NUDOffset = new System.Windows.Forms.NumericUpDown();
            this.NUDNbTools = new System.Windows.Forms.NumericUpDown();
            this.lDiameter = new System.Windows.Forms.Label();
            this.lNbTools = new System.Windows.Forms.Label();
            this.lOffcet = new System.Windows.Forms.Label();
            this.NUDDiameter = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lResult = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnApercu = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbDispAngle = new System.Windows.Forms.CheckBox();
            this.cbDispNumPoint = new System.Windows.Forms.CheckBox();
            this.cbDispAxes = new System.Windows.Forms.CheckBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDNbTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDiameter)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 321);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 321);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(636, 366);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 18;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackgroundImage = global::Percage_Circulaire.Properties.Resources.FondGauche;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(225, 366);
            this.splitContainer2.SplitterDistance = 121;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Percage_Circulaire.Properties.Resources.pignon1;
            this.groupBox1.Controls.Add(this.NUDPrecision);
            this.groupBox1.Controls.Add(this.lPrecision);
            this.groupBox1.Controls.Add(this.NUDOffset);
            this.groupBox1.Controls.Add(this.NUDNbTools);
            this.groupBox1.Controls.Add(this.lDiameter);
            this.groupBox1.Controls.Add(this.lNbTools);
            this.groupBox1.Controls.Add(this.lOffcet);
            this.groupBox1.Controls.Add(this.NUDDiameter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Brown;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres";
            // 
            // NUDPrecision
            // 
            this.NUDPrecision.BackColor = System.Drawing.Color.LightYellow;
            this.NUDPrecision.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NUDPrecision.Location = new System.Drawing.Point(127, 94);
            this.NUDPrecision.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NUDPrecision.Name = "NUDPrecision";
            this.NUDPrecision.Size = new System.Drawing.Size(87, 20);
            this.NUDPrecision.TabIndex = 4;
            this.NUDPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUDPrecision.ValueChanged += new System.EventHandler(this.Calcul);
            // 
            // lPrecision
            // 
            this.lPrecision.AutoSize = true;
            this.lPrecision.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lPrecision.Location = new System.Drawing.Point(7, 96);
            this.lPrecision.Name = "lPrecision";
            this.lPrecision.Size = new System.Drawing.Size(96, 13);
            this.lPrecision.TabIndex = 0;
            this.lPrecision.Text = "Précision de calcul";
            // 
            // NUDOffset
            // 
            this.NUDOffset.BackColor = System.Drawing.Color.LightYellow;
            this.NUDOffset.DecimalPlaces = 2;
            this.NUDOffset.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NUDOffset.Location = new System.Drawing.Point(127, 69);
            this.NUDOffset.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.NUDOffset.Name = "NUDOffset";
            this.NUDOffset.Size = new System.Drawing.Size(87, 20);
            this.NUDOffset.TabIndex = 3;
            this.NUDOffset.ValueChanged += new System.EventHandler(this.Calcul);
            // 
            // NUDNbTools
            // 
            this.NUDNbTools.BackColor = System.Drawing.Color.LightYellow;
            this.NUDNbTools.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NUDNbTools.Location = new System.Drawing.Point(127, 19);
            this.NUDNbTools.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUDNbTools.Name = "NUDNbTools";
            this.NUDNbTools.Size = new System.Drawing.Size(87, 20);
            this.NUDNbTools.TabIndex = 1;
            this.NUDNbTools.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUDNbTools.ValueChanged += new System.EventHandler(this.Calcul);
            // 
            // lDiameter
            // 
            this.lDiameter.AutoSize = true;
            this.lDiameter.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lDiameter.Location = new System.Drawing.Point(7, 40);
            this.lDiameter.Name = "lDiameter";
            this.lDiameter.Size = new System.Drawing.Size(82, 26);
            this.lDiameter.TabIndex = 0;
            this.lDiameter.Text = "Diamètre de \r\nla courone (mm)";
            // 
            // lNbTools
            // 
            this.lNbTools.AutoSize = true;
            this.lNbTools.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lNbTools.Location = new System.Drawing.Point(7, 21);
            this.lNbTools.Name = "lNbTools";
            this.lNbTools.Size = new System.Drawing.Size(85, 13);
            this.lNbTools.TabIndex = 0;
            this.lNbTools.Text = "Nombre de trous";
            // 
            // lOffcet
            // 
            this.lOffcet.AutoSize = true;
            this.lOffcet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lOffcet.Location = new System.Drawing.Point(7, 71);
            this.lOffcet.Name = "lOffcet";
            this.lOffcet.Size = new System.Drawing.Size(113, 13);
            this.lOffcet.TabIndex = 0;
            this.lOffcet.Text = "Décalage à l\'origine (°)";
            // 
            // NUDDiameter
            // 
            this.NUDDiameter.BackColor = System.Drawing.Color.LightYellow;
            this.NUDDiameter.DecimalPlaces = 3;
            this.NUDDiameter.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NUDDiameter.Location = new System.Drawing.Point(127, 44);
            this.NUDDiameter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDDiameter.Name = "NUDDiameter";
            this.NUDDiameter.Size = new System.Drawing.Size(87, 20);
            this.NUDDiameter.TabIndex = 2;
            this.NUDDiameter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDDiameter.ValueChanged += new System.EventHandler(this.Calcul);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Brown;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 241);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Résultat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pour Papa. (par Vincent le 30 avril 2010)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lResult
            // 
            this.lResult.AutoEllipsis = true;
            this.lResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lResult.ForeColor = System.Drawing.Color.Black;
            this.lResult.Location = new System.Drawing.Point(3, 16);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(219, 222);
            this.lResult.TabIndex = 0;
            this.lResult.Text = "text";
            this.lResult.Click += new System.EventHandler(this.lResult_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.LightYellow;
            this.splitContainer3.Panel1.BackgroundImage = global::Percage_Circulaire.Properties.Resources.FondHaut;
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Size = new System.Drawing.Size(407, 366);
            this.splitContainer3.SplitterDistance = 41;
            this.splitContainer3.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.BackgroundImage = global::Percage_Circulaire.Properties.Resources.pignonbas;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox4.Controls.Add(this.btnApercu);
            this.groupBox4.Controls.Add(this.btnImprimer);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.ForeColor = System.Drawing.Color.Brown;
            this.groupBox4.Location = new System.Drawing.Point(237, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(170, 41);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Impression";
            // 
            // btnApercu
            // 
            this.btnApercu.BackColor = System.Drawing.Color.LightYellow;
            this.btnApercu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApercu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnApercu.Location = new System.Drawing.Point(6, 14);
            this.btnApercu.Name = "btnApercu";
            this.btnApercu.Size = new System.Drawing.Size(75, 23);
            this.btnApercu.TabIndex = 8;
            this.btnApercu.Text = "Aperçu";
            this.btnApercu.UseVisualStyleBackColor = false;
            this.btnApercu.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnImprimer
            // 
            this.btnImprimer.BackColor = System.Drawing.Color.LightYellow;
            this.btnImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimer.Location = new System.Drawing.Point(87, 14);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(75, 23);
            this.btnImprimer.TabIndex = 9;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.BackgroundImage = global::Percage_Circulaire.Properties.Resources.pignonbas;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox3.Controls.Add(this.cbDispAngle);
            this.groupBox3.Controls.Add(this.cbDispNumPoint);
            this.groupBox3.Controls.Add(this.cbDispAxes);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.ForeColor = System.Drawing.Color.Brown;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 41);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Affichage";
            // 
            // cbDispAngle
            // 
            this.cbDispAngle.AutoSize = true;
            this.cbDispAngle.Checked = true;
            this.cbDispAngle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDispAngle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbDispAngle.Location = new System.Drawing.Point(178, 19);
            this.cbDispAngle.Name = "cbDispAngle";
            this.cbDispAngle.Size = new System.Drawing.Size(53, 17);
            this.cbDispAngle.TabIndex = 7;
            this.cbDispAngle.Text = "Angle";
            this.cbDispAngle.UseVisualStyleBackColor = true;
            this.cbDispAngle.CheckedChanged += new System.EventHandler(this.Calcul);
            // 
            // cbDispNumPoint
            // 
            this.cbDispNumPoint.AutoSize = true;
            this.cbDispNumPoint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbDispNumPoint.Location = new System.Drawing.Point(61, 19);
            this.cbDispNumPoint.Name = "cbDispNumPoint";
            this.cbDispNumPoint.Size = new System.Drawing.Size(120, 17);
            this.cbDispNumPoint.TabIndex = 6;
            this.cbDispNumPoint.Text = "Numéro de percage";
            this.cbDispNumPoint.UseVisualStyleBackColor = true;
            this.cbDispNumPoint.CheckedChanged += new System.EventHandler(this.Calcul);
            // 
            // cbDispAxes
            // 
            this.cbDispAxes.AutoSize = true;
            this.cbDispAxes.Checked = true;
            this.cbDispAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDispAxes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbDispAxes.Location = new System.Drawing.Point(6, 19);
            this.cbDispAxes.Name = "cbDispAxes";
            this.cbDispAxes.Size = new System.Drawing.Size(49, 17);
            this.cbDispAxes.TabIndex = 5;
            this.cbDispAxes.Text = "Axes";
            this.cbDispAxes.UseVisualStyleBackColor = true;
            this.cbDispAxes.CheckedChanged += new System.EventHandler(this.Calcul);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(636, 366);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(644, 400);
            this.Name = "Form1";
            this.Text = "Percage circulaire";
            this.Load += new System.EventHandler(this.Calcul);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.Calcul);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDNbTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDiameter)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lResult;
        private System.Windows.Forms.Label lPrecision;
        private System.Windows.Forms.NumericUpDown NUDNbTools;
        private System.Windows.Forms.Label lNbTools;
        private System.Windows.Forms.NumericUpDown NUDDiameter;
        private System.Windows.Forms.Label lOffcet;
        private System.Windows.Forms.Label lDiameter;
        private System.Windows.Forms.NumericUpDown NUDPrecision;
        private System.Windows.Forms.NumericUpDown NUDOffset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbDispNumPoint;
        private System.Windows.Forms.CheckBox cbDispAxes;
        private System.Windows.Forms.CheckBox cbDispAngle;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnApercu;
        private System.Windows.Forms.Label label1;

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Percage_Circulaire
{
    public partial class Form1 : Form
    {
        private Bitmap DrawArea;  // make a persistent drawing area

        private class Tool
        {
            public double X, Y, Angle; //Valeurs approximees pour affichage
            public double X_, Y_, Angle_; //Valeurs reelles pour calcul
            public int Num; //numero du trou
        }


        public Form1()
        {
            InitializeComponent();

            /*//Anniversaire papa
            DateTime AnnifPapa = new DateTime(2010, 4, 30);
            if (DateTime.Today.CompareTo(AnnifPapa) < 0)
            {
                MessageBox.Show("Trop tot ! \nAttendre le 30/04.", "Version non activé", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }*/

            //Impression
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);

            //Chargement des données
            NUDDiameter.Value = Properties.Settings.Default.Diameter;
            NUDNbTools.Value = Properties.Settings.Default.NbTools;
            NUDOffset.Value = Properties.Settings.Default.Offcet;
            NUDPrecision.Value = Properties.Settings.Default.Precision;
            Width = Properties.Settings.Default.Width;
            Height = Properties.Settings.Default.Height;
            cbDispAxes.Checked = Properties.Settings.Default.ShowAxis;
            cbDispNumPoint.Checked = Properties.Settings.Default.ShowPointNum;
            cbDispAngle.Checked = Properties.Settings.Default.ShowAngle;

            //Anniversaire papa
            if (DateTime.Today.Day == 30 && DateTime.Today.Month == 4)
            {
                label1.Text = "Bon anniversaire papa !";
                MessageBox.Show("Bon anniversaire papa !", "Message personnel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// ApplyChanges
        /// </summary>
        private void Calcul(object sender, EventArgs e)
        {
            //Modification du champs de l'offset et de la precision
            NUDOffset.Maximum = (int)(360 / NUDNbTools.Value) - 1;
            NUDOffset.DecimalPlaces = (int)NUDPrecision.Value;
            NUDDiameter.DecimalPlaces = (int)NUDPrecision.Value;

            List<Tool> Tools = CalculTools();

            UpdateResult(Tools);
            Draw(Tools);
        }

        /// <summary>
        /// Calculate all coords
        /// </summary>
        private List<Tool> CalculTools(){
			List<Tool> Tools=new List<Tool>();
			Tool tool;
			double Angle= 90 - (double)NUDOffset.Value;
			int Num=1;
			
			while(Tools.Count<(int)NUDNbTools.Value){
				tool=new Tool();
				tool.X_ = (double)NUDDiameter.Value / 2 * Math.Cos(Angle * Math.PI / 180);
				tool.Y_ = (double)NUDDiameter.Value / 2 * Math.Sin(Angle * Math.PI / 180);
				
				tool.Num=Num;
				tool.Angle_=Angle;
                tool.Angle = Math.Round(90 - Angle, (int)NUDPrecision.Value); 
                if (tool.Angle < 0) tool.Angle += 360;
				tool.X = Math.Round(tool.X_ , (int)NUDPrecision.Value);
				tool.Y = Math.Round(tool.Y_ , (int)NUDPrecision.Value);
                tool.Y_ *= -1; //Pour l'affichage

                Tools.Add(tool);
				Angle -= 360 / (double)NUDNbTools.Value;
                if (Angle < 0) Angle += 360;
				Num++;
			}
			
			return Tools;
		}

        private void UpdateResult(List<Tool> Tools)
        {
            lResult.Text = "Trou n°N : {Angle en degrès} \n=> X en mm ; Y en mm \n\n";
            foreach (Tool Tool in Tools)
                lResult.Text = lResult.Text + "Trou n°" + Tool.Num + ": {" + Tool.Angle + "°} ->  X=" + Tool.X + " ; Y=" + Tool.Y + "\n";
        }



        /// <summary>
        /// Draw for display on form. Get client size, and set appropriate background
        /// </summary>
        private void Draw(List<Tool> Tools)
        {
            Draw(Tools, pictureBox1.Width, pictureBox1.Height, (int)Math.Min(pictureBox1.Width / 8, pictureBox1.Height / 8), BackColor);
            pictureBox1.Image = DrawArea;
            Invalidate(true);
        }

        /// <summary>
        /// Draw points on circle, displaying graphical coords
        /// </summary>
        private void Draw(List<Tool> Tools, int WidthTot, int HeightTot, int Margin, Color BgColor)
        {
            DrawArea = new Bitmap(WidthTot, HeightTot);
            Graphics xGraph = Graphics.FromImage(DrawArea);
            Pen Pen;
            int DiameterCircle = Math.Min(WidthTot - 2 * Margin, HeightTot - 2 * Margin);
            int CenterCircle = Math.Min(WidthTot / 2, HeightTot / 2);
            double RatioDisplay = DiameterCircle / (double)NUDDiameter.Value;
            String s;
            Font F;

            // clear the drawing area to background color
            xGraph.Clear(BgColor);

            // Draw primary circle
            Pen = new Pen(Color.Crimson);
            xGraph.DrawArc(Pen, CenterCircle - DiameterCircle / 2, CenterCircle - DiameterCircle / 2, DiameterCircle, DiameterCircle, 0, 360);

            // Draw axis
            if (cbDispAxes.Checked)
            {
                //Les axes
                Pen = new Pen(Color.DarkKhaki);
                xGraph.DrawLine(Pen, CenterCircle - DiameterCircle / 2 - Margin / 2, CenterCircle, CenterCircle + DiameterCircle / 2 + Margin / 2, CenterCircle);
                xGraph.DrawLine(Pen, CenterCircle, CenterCircle - DiameterCircle / 2 - Margin / 2, CenterCircle, CenterCircle + DiameterCircle / 2 + Margin / 2);

                //X et Y
                F = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                s = "X";
                float sX = CenterCircle + DiameterCircle / 2 + Margin * 2 / 3 - xGraph.MeasureString(s, F).Width / 2;
                float sY = CenterCircle - xGraph.MeasureString(s, F).Height / 2;
                xGraph.DrawString(s, F, Brushes.Orange, sX, sY);
                s = "Y";
                sX = CenterCircle - xGraph.MeasureString(s, F).Width / 2;
                sY = CenterCircle - DiameterCircle / 2 - Margin * 2 / 3 - xGraph.MeasureString(s, F).Height / 2;
                xGraph.DrawString(s, F, Brushes.Orange, sX, sY);

                //Le diametre
                F = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
                Pen = new Pen(Color.Maroon);
                xGraph.DrawLine(Pen, CenterCircle - DiameterCircle / 2, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3, CenterCircle + DiameterCircle / 2, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3);
                int ArrowSize = 10;
                xGraph.DrawLine(Pen, CenterCircle - DiameterCircle / 2, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3, CenterCircle - DiameterCircle / 2 + ArrowSize, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3 - ArrowSize);
                xGraph.DrawLine(Pen, CenterCircle - DiameterCircle / 2, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3, CenterCircle - DiameterCircle / 2 + ArrowSize, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3 + ArrowSize);
                xGraph.DrawLine(Pen, CenterCircle + DiameterCircle / 2, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3, CenterCircle + DiameterCircle / 2 - ArrowSize, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3 - ArrowSize);
                xGraph.DrawLine(Pen, CenterCircle + DiameterCircle / 2, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3, CenterCircle + DiameterCircle / 2 - ArrowSize, CenterCircle + DiameterCircle / 2 + Margin * 2 / 3 + ArrowSize);
                s = "d = " + NUDDiameter.Value + " mm";
                sX = CenterCircle - xGraph.MeasureString(s, F).Width / 2;
                sY = CenterCircle + DiameterCircle / 2 + Margin * 2 / 3 - xGraph.MeasureString(s, F).Height / 2 + ArrowSize;
                xGraph.DrawString(s, F, Brushes.Maroon, sX, sY);

                //Angle de decalage
                xGraph.DrawArc(Pen, CenterCircle - DiameterCircle / 2 - 1, CenterCircle - DiameterCircle / 2 - 1, DiameterCircle + 2, DiameterCircle + 2, -90,  (float)NUDOffset.Value);
                xGraph.DrawArc(Pen, CenterCircle - DiameterCircle / 2 - 2, CenterCircle - DiameterCircle / 2 - 2, DiameterCircle + 4, DiameterCircle + 4, -90, (float)NUDOffset.Value);
                s = "décalage = " + NUDOffset.Value + "°";
                sX = DiameterCircle + 2 * Margin - xGraph.MeasureString(s, F).Width;
                sY = CenterCircle - xGraph.MeasureString(s, F).Height / 2 - DiameterCircle / 2;
                xGraph.DrawString(s, F, Brushes.Maroon, sX, sY);

            }

            //Draw points
            int DiameterPoint = (int)DiameterCircle / 15;
            int DiameterPointMini = 1;
            int SizesX, SizesY;
            Font Font;
            foreach (Tool Tool in Tools)
            {
                float DispX, DispY;
                Pen = new Pen(Color.Blue);
                DispX = (float)(RatioDisplay * Tool.X_ - DiameterPoint / 2 + CenterCircle);
                DispY = (float)(RatioDisplay * Tool.Y_ - DiameterPoint / 2 + CenterCircle);
                xGraph.DrawArc(Pen, DispX, DispY, DiameterPoint, DiameterPoint, 0, 360);

                DispX = (float)(RatioDisplay * Tool.X_ - DiameterPointMini / 2 + CenterCircle);
                DispY = (float)(RatioDisplay * Tool.Y_ - DiameterPointMini / 2 + CenterCircle);
                xGraph.DrawArc(Pen, DispX, DispY, DiameterPointMini, DiameterPointMini, 0, 360);



                if (cbDispNumPoint.Checked) s = "[" + Tool.Num + "] ";
                else s = "";
                s += "X=" + Tool.X + " ; Y=" + Tool.Y;
                Font = new Font(FontFamily.GenericSansSerif, 8);
                SizesX = (int)xGraph.MeasureString(s, Font).Width;
                SizesY = (int)xGraph.MeasureString(s, Font).Height;
                double RatioDisplayCoord = (DiameterCircle - 4 / 3 * DiameterPoint - SizesX) / (double)NUDDiameter.Value;
                DispX = (float)(RatioDisplayCoord * Tool.X_ - SizesX / 2 + CenterCircle);
                DispY = (float)(RatioDisplayCoord * Tool.Y_ - SizesY / 2 + CenterCircle);
                xGraph.DrawString(s, Font, Brushes.Crimson, DispX, DispY);


                if (cbDispAngle.Checked)
                {
                    s = "{" + Tool.Angle + "°}";
                    Font = new Font(FontFamily.GenericSansSerif, 10);
                    SizesX = (int)xGraph.MeasureString(s, Font).Width;
                    SizesY = (int)xGraph.MeasureString(s, Font).Height;
                    double RatioDisplayAngle = (DiameterCircle / (double)NUDDiameter.Value) / 3;
                    DispX = (float)(RatioDisplayAngle * Tool.X_ - SizesX / 2 + CenterCircle);
                    DispY = (float)(RatioDisplayAngle * Tool.Y_ - SizesY / 2 + CenterCircle);
                    xGraph.DrawString(s, Font, Brushes.DodgerBlue, DispX, DispY);
                }
            }

            xGraph.Dispose();


        }



        /// <summary>
        /// save drawing in bitmap DrawArea as a jpeg file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Jpeg;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG Files(*.jpg)|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // now save the image in the DrawArea
                DrawArea.Save(sfd.FileName, format);
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Enregistrement des changements
            Properties.Settings.Default.Diameter = NUDDiameter.Value;
            Properties.Settings.Default.NbTools = NUDNbTools.Value;
            Properties.Settings.Default.Offcet = NUDOffset.Value;
            Properties.Settings.Default.Precision = NUDPrecision.Value;
            Properties.Settings.Default.ShowAxis = cbDispAxes.Checked;
            Properties.Settings.Default.ShowPointNum = cbDispNumPoint.Checked;
            Properties.Settings.Default.ShowAngle = cbDispAngle.Checked;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Height = Height;
            Properties.Settings.Default.Save();

            //Liberation ressource dessin
            DrawArea.Dispose();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ListBox ListBox1 = new ListBox();

            // Initialize the dialog's PrinterSettings property to hold user
            // defined printer settings.
            pageSetupDialog1.PageSettings =
                new System.Drawing.Printing.PageSettings();

            // Initialize dialog's PrinterSettings property to hold user
            // set printer settings.
            pageSetupDialog1.PrinterSettings =
                new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog1.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();

            // If the result is OK, display selected settings in
            // ListBox1. These values can be used when printing the
            // document.
            if (result == DialogResult.OK)
            {
                object[] results = new object[]{ 
                pageSetupDialog1.PageSettings.Margins, 
                pageSetupDialog1.PageSettings.PaperSize, 
                pageSetupDialog1.PageSettings.Landscape, 
                pageSetupDialog1.PrinterSettings.PrinterName, 
                pageSetupDialog1.PrinterSettings.PrintRange};
                ListBox1.Items.AddRange(results);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.AllowSomePages = false;
            printDialog1.ShowHelp = false;
            printDialog1.AllowPrintToFile = false;
            printDialog1.Document = printDocument1;


            DialogResult result = printDialog1.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.UseAntiAlias = true;
            printPreviewDialog1.Width = 700;
            printPreviewDialog1.Height = 800;
            printPreviewDialog1.ShowDialog();

        }


        // The PrintDialog will print the document
        // by handling the document's PrintPage event.
        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.Clear(Color.White);

            //L'image
            Draw(CalculTools(),600, 600, 50, Color.White);
            e.Graphics.DrawImage(DrawArea, 70, 50);

            //Le titre
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString("Perçage circulaire", printFont, System.Drawing.Brushes.Navy, 0, 0);
            printFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString("Pour une répétition circulaire de perçages avec des coordonnées cartésiennes", printFont, System.Drawing.Brushes.Navy, 15, 40);

            //La date et signature
            printFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Italic);
            e.Graphics.DrawString("par Vincent pour son papa (le 30 avril 2010)", printFont, System.Drawing.Brushes.Black, 470, 15);
            printFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            e.Graphics.DrawString(DateTime.Now.ToString("<dd/MM/yyyy>"), printFont, System.Drawing.Brushes.Black, 695, 40);

            //Affichage des resultats
            int ResultX = 0, ResultY = 700, ResultMargin = 25;
            printFont = new System.Drawing.Font("Times new roman", 12, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(lResult.Text, printFont, System.Drawing.Brushes.Black, ResultX + ResultMargin, ResultY + ResultMargin);

            float ResultWidth = e.Graphics.MeasureString(lResult.Text, printFont).Width;
            float ResultHeight = e.Graphics.MeasureString(lResult.Text, printFont).Height;
            e.Graphics.DrawRectangle(new Pen(Color.Turquoise), ResultX, ResultY, ResultX + ResultMargin * 2 + ResultWidth, ResultY + ResultHeight + ResultMargin * 2);


            //Affichage des parametres
            int ParameterX = 500, ParameterY = 700, ParameterSpace = 25, ParameterMargin = 25;
            e.Graphics.DrawString(lNbTools.Text + " = " + NUDNbTools.Value, printFont, System.Drawing.Brushes.Black, ParameterX + ParameterMargin, ParameterY + ParameterMargin);
            e.Graphics.DrawString(lDiameter.Text + " = " + NUDDiameter.Value, printFont, System.Drawing.Brushes.Black, ParameterX + ParameterMargin, ParameterY + ParameterMargin + ParameterSpace);
            e.Graphics.DrawString(lOffcet.Text + " = " + NUDOffset.Value, printFont, System.Drawing.Brushes.Black, ParameterX + ParameterMargin, ParameterY + ParameterMargin + ParameterSpace * 2);

            float ParameterWidth = Math.Max(
                e.Graphics.MeasureString(lNbTools.Text + " = " + NUDNbTools.Value, printFont).Width,
                e.Graphics.MeasureString(lDiameter.Text + " = " + NUDDiameter.Value, printFont).Width
                );
            ParameterWidth = Math.Max(
                ParameterWidth,
                e.Graphics.MeasureString(lOffcet.Text + " = " + NUDOffset.Value, printFont).Width
                );
            e.Graphics.DrawRectangle(new Pen(Color.Turquoise), ParameterX, ParameterY, ParameterX + ParameterMargin * 2 + ParameterWidth, ParameterY + ParameterMargin * 2 + ParameterSpace * 3);



        }

        private void lResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lResult.Text);
            MessageBox.Show("Le texte a été copié dans le presse papier", "Copie des résultats", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(DrawArea);
            MessageBox.Show("L'image a été copié dans le presse papier\nPour une meilleure résolution, copier avec une fénêtre plus grande.", "Copie de l'image", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



    }
}
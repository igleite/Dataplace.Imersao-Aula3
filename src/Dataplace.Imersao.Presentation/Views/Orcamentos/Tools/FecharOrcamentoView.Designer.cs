﻿namespace Dataplace.Imersao.Presentation.Views
{
    partial class CancelarOrcamentoView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelarOrcamentoView));
            this.gridOrcamento = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.tsiMarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDesmarca = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAberto = new System.Windows.Forms.CheckBox();
            this.chkCancelado = new System.Windows.Forms.CheckBox();
            this.chkFechado = new System.Windows.Forms.CheckBox();
            this.rangeDate = new dpLibrary05.ucSymGen_ReferenceDtp();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrcamento)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridOrcamento
            // 
            this.gridOrcamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrcamento.GroupByCaption = "Drag a column header here to group by that column";
            this.gridOrcamento.Images.Add(((System.Drawing.Image)(resources.GetObject("gridOrcamento.Images"))));
            this.gridOrcamento.Location = new System.Drawing.Point(2, 92);
            this.gridOrcamento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridOrcamento.Name = "gridOrcamento";
            this.gridOrcamento.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.gridOrcamento.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.gridOrcamento.PreviewInfo.ZoomFactor = 75D;
            this.gridOrcamento.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen;
            this.gridOrcamento.PrintInfo.MeasurementPrinterName = null;
            this.gridOrcamento.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("gridOrcamento.PrintInfo.PageSettings")));
            this.gridOrcamento.Size = new System.Drawing.Size(1006, 451);
            this.gridOrcamento.TabIndex = 3;
            this.gridOrcamento.UseCompatibleTextRendering = false;
            this.gridOrcamento.PropBag = resources.GetString("gridOrcamento.PropBag");
            // 
            // btnCarregar
            // 
            this.btnCarregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarregar.Location = new System.Drawing.Point(926, 2);
            this.btnCarregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(82, 24);
            this.btnCarregar.TabIndex = 2;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 552);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(100, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiMarcar,
            this.tsiDesmarca,
            this.tsiExcel});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(88, 22);
            this.toolStripSplitButton1.Text = "Ferramentas";
            // 
            // tsiMarcar
            // 
            this.tsiMarcar.Name = "tsiMarcar";
            this.tsiMarcar.Size = new System.Drawing.Size(174, 22);
            this.tsiMarcar.Text = "Marcar Todos";
            // 
            // tsiDesmarca
            // 
            this.tsiDesmarca.Name = "tsiDesmarca";
            this.tsiDesmarca.Size = new System.Drawing.Size(174, 22);
            this.tsiDesmarca.Text = "Desmarcar Todos";
            // 
            // tsiExcel
            // 
            this.tsiExcel.Name = "tsiExcel";
            this.tsiExcel.Size = new System.Drawing.Size(174, 22);
            this.tsiExcel.Text = "Exportar para excel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAberto);
            this.groupBox1.Controls.Add(this.chkCancelado);
            this.groupBox1.Controls.Add(this.chkFechado);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(163, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situação";
            // 
            // chkAberto
            // 
            this.chkAberto.AutoSize = true;
            this.chkAberto.Checked = true;
            this.chkAberto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAberto.Location = new System.Drawing.Point(11, 17);
            this.chkAberto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAberto.Name = "chkAberto";
            this.chkAberto.Size = new System.Drawing.Size(57, 17);
            this.chkAberto.TabIndex = 0;
            this.chkAberto.Text = "Aberto";
            this.chkAberto.UseVisualStyleBackColor = true;
            // 
            // chkCancelado
            // 
            this.chkCancelado.AutoSize = true;
            this.chkCancelado.Location = new System.Drawing.Point(11, 59);
            this.chkCancelado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkCancelado.Name = "chkCancelado";
            this.chkCancelado.Size = new System.Drawing.Size(77, 17);
            this.chkCancelado.TabIndex = 2;
            this.chkCancelado.Text = "Cancelado";
            this.chkCancelado.UseVisualStyleBackColor = true;
            // 
            // chkFechado
            // 
            this.chkFechado.AutoSize = true;
            this.chkFechado.Location = new System.Drawing.Point(11, 38);
            this.chkFechado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFechado.Name = "chkFechado";
            this.chkFechado.Size = new System.Drawing.Size(68, 17);
            this.chkFechado.TabIndex = 1;
            this.chkFechado.Text = "Fechado";
            this.chkFechado.UseVisualStyleBackColor = true;
            // 
            // rangeDate
            // 
            this.rangeDate.Date1CustomFormat = dpLibrary05.ucSymGen_ReferenceDtp.CustomFormatEnum.FShort;
            this.rangeDate.Date2CustomFormat = dpLibrary05.ucSymGen_ReferenceDtp.CustomFormatEnum.FShort;
            this.rangeDate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.rangeDate.DotNetContainer = false;
            this.rangeDate.KeyPreview = false;
            this.rangeDate.Label1Text = dpLibrary05.ucSymGen_ReferenceDtp.LabelTextEnum.TFrom;
            this.rangeDate.Label2Text = dpLibrary05.ucSymGen_ReferenceDtp.LabelTextEnum.TTo;
            this.rangeDate.Location = new System.Drawing.Point(172, 17);
            this.rangeDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rangeDate.Name = "rangeDate";
            this.rangeDate.OpenModal = false;
            this.rangeDate.Parameters = ((System.Collections.Generic.IDictionary<string, object>)(resources.GetObject("rangeDate.Parameters")));
            this.rangeDate.Size = new System.Drawing.Size(272, 22);
            this.rangeDate.TabIndex = 1;
            this.rangeDate.TabOrderScheme = dpLibrary05.TabOrderManager.TabScheme.None;
            // 
            // CancelamentoOrcamentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rangeDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.gridOrcamento);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CancelamentoOrcamentoView";
            this.Size = new System.Drawing.Size(1010, 609);
            this.Controls.SetChildIndex(this.gridOrcamento, 0);
            this.Controls.SetChildIndex(this.btnCarregar, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.rangeDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrcamento)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid gridOrcamento;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem tsiMarcar;
        private System.Windows.Forms.ToolStripMenuItem tsiDesmarca;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAberto;
        private System.Windows.Forms.CheckBox chkCancelado;
        private System.Windows.Forms.CheckBox chkFechado;
        private System.Windows.Forms.ToolStripMenuItem tsiExcel;
        internal dpLibrary05.ucSymGen_ReferenceDtp rangeDate;
    }
}

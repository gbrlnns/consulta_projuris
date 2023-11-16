namespace API_Tarefas
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            statusBar = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            progressBar = new ToolStripProgressBar();
            fileNameBox = new TextBox();
            fileSelect = new Button();
            openFile = new OpenFileDialog();
            label1 = new Label();
            process = new Button();
            saveFile = new SaveFileDialog();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { statusLabel, progressBar });
            statusBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusBar.Location = new Point(0, 235);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(755, 28);
            statusBar.TabIndex = 0;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(56, 22);
            statusLabel.Text = "Pronto.";
            // 
            // progressBar
            // 
            progressBar.Alignment = ToolStripItemAlignment.Right;
            progressBar.CausesValidation = false;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(150, 20);
            progressBar.Style = ProgressBarStyle.Continuous;
            // 
            // fileNameBox
            // 
            fileNameBox.Location = new Point(52, 66);
            fileNameBox.Name = "fileNameBox";
            fileNameBox.ReadOnly = true;
            fileNameBox.Size = new Size(527, 27);
            fileNameBox.TabIndex = 1;
            // 
            // fileSelect
            // 
            fileSelect.Location = new Point(595, 66);
            fileSelect.Name = "fileSelect";
            fileSelect.Size = new Size(94, 29);
            fileSelect.TabIndex = 2;
            fileSelect.Text = "...";
            fileSelect.UseVisualStyleBackColor = true;
            fileSelect.Click += fileSelect_Click;
            // 
            // openFile
            // 
            openFile.AddExtension = false;
            openFile.AddToRecent = false;
            openFile.DefaultExt = "xlsx";
            openFile.Filter = "Pastas de Trabalho do Excel (.xlsx)|*.xlsx";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 43);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 3;
            label1.Text = "Planilha de processos:";
            // 
            // process
            // 
            process.Enabled = false;
            process.Location = new Point(167, 155);
            process.Name = "process";
            process.Size = new Size(359, 29);
            process.TabIndex = 4;
            process.Text = "Obter listas de tarefas";
            process.UseVisualStyleBackColor = true;
            process.Click += process_Click;
            // 
            // saveFile
            // 
            saveFile.DefaultExt = "xlsx";
            saveFile.Filter = "Pastas de Trabalho do Excel (.xlsx)|*.xlsx";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 263);
            Controls.Add(process);
            Controls.Add(label1);
            Controls.Add(fileSelect);
            Controls.Add(fileNameBox);
            Controls.Add(statusBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "Captura de tarefas do Projuris";
            Load += Main_Load;
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusBar;
        private ToolStripStatusLabel statusLabel;
        private TextBox fileNameBox;
        private Button fileSelect;
        private OpenFileDialog openFile;
        private ToolStripProgressBar progressBar;
        private Label label1;
        private Button process;
        private SaveFileDialog saveFile;
    }
}

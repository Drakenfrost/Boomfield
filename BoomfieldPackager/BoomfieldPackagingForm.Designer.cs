using System.Windows.Forms;
using System.Drawing;

namespace BoomfieldPackager
{
    partial class BoomfieldPackagingForm
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
            packageProgressBar = new ProgressBar();
            packageCancelButton = new Button();
            packageLabel = new Label();
            SuspendLayout();
            // 
            // packageProgressBar
            // 
            packageProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            packageProgressBar.Location = new Point(12, 12);
            packageProgressBar.Name = "packageProgressBar";
            packageProgressBar.Size = new Size(410, 23);
            packageProgressBar.TabIndex = 0;
            // 
            // packageCancelButton
            // 
            packageCancelButton.Location = new Point(330, 46);
            packageCancelButton.Name = "packageCancelButton";
            packageCancelButton.Size = new Size(92, 23);
            packageCancelButton.TabIndex = 1;
            packageCancelButton.Text = "Cancel";
            packageCancelButton.UseVisualStyleBackColor = true;
            packageCancelButton.Click += packageCancelButton_Click;
            // 
            // packageLabel
            // 
            packageLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            packageLabel.AutoEllipsis = true;
            packageLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            packageLabel.Location = new Point(12, 38);
            packageLabel.Name = "packageLabel";
            packageLabel.Size = new Size(312, 34);
            packageLabel.TabIndex = 2;
            packageLabel.Text = "Packaging XYZ";
            // 
            // BoomfieldPackagingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 81);
            Controls.Add(packageLabel);
            Controls.Add(packageCancelButton);
            Controls.Add(packageProgressBar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(450, 120);
            MinimumSize = new Size(450, 120);
            Name = "BoomfieldPackagingForm";
            Text = "Packaging Boomfield";
            FormClosing += BoomfieldPackagingForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar packageProgressBar;
        private Button packageCancelButton;
        private Label packageLabel;
    }
}
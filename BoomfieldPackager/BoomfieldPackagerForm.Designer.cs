using System.Drawing;
using System.Windows.Forms;

namespace BoomfieldPackager;

partial class BoomfieldPackagerForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoomfieldPackagerForm));
        packageButton = new Button();
        zipCheckBox = new CheckBox();
        outputFolderTextBox = new TextBox();
        outputFolderLabel = new Label();
        infoLabel = new Label();
        packageOutputBrowseButton = new Button();
        packageOutputFolderBrowserDialog = new FolderBrowserDialog();
        SuspendLayout();
        // 
        // packageButton
        // 
        packageButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        packageButton.Location = new Point(12, 117);
        packageButton.Name = "packageButton";
        packageButton.Size = new Size(460, 32);
        packageButton.TabIndex = 0;
        packageButton.Text = "Package Boomfield";
        packageButton.UseVisualStyleBackColor = true;
        packageButton.Click += packageButton_Click;
        // 
        // zipCheckBox
        // 
        zipCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        zipCheckBox.AutoSize = true;
        zipCheckBox.Location = new Point(12, 92);
        zipCheckBox.Name = "zipCheckBox";
        zipCheckBox.Size = new Size(132, 19);
        zipCheckBox.TabIndex = 1;
        zipCheckBox.Text = "Compress to ZIP file";
        zipCheckBox.UseVisualStyleBackColor = true;
        // 
        // outputFolderTextBox
        // 
        outputFolderTextBox.AllowDrop = true;
        outputFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        outputFolderTextBox.Location = new Point(99, 12);
        outputFolderTextBox.Name = "outputFolderTextBox";
        outputFolderTextBox.Size = new Size(373, 23);
        outputFolderTextBox.TabIndex = 2;
        outputFolderTextBox.TextChanged += outputFolderTextBox_TextChanged;
        // 
        // outputFolderLabel
        // 
        outputFolderLabel.AutoSize = true;
        outputFolderLabel.Location = new Point(12, 15);
        outputFolderLabel.Name = "outputFolderLabel";
        outputFolderLabel.Size = new Size(81, 15);
        outputFolderLabel.TabIndex = 3;
        outputFolderLabel.Text = "Output Folder";
        // 
        // infoLabel
        // 
        infoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        infoLabel.AutoEllipsis = true;
        infoLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
        infoLabel.Location = new Point(99, 38);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new Size(373, 51);
        infoLabel.TabIndex = 4;
        infoLabel.Text = "Please provide a valid output folder path!";
        // 
        // packageOutputBrowseButton
        // 
        packageOutputBrowseButton.Location = new Point(12, 38);
        packageOutputBrowseButton.Name = "packageOutputBrowseButton";
        packageOutputBrowseButton.Size = new Size(81, 23);
        packageOutputBrowseButton.TabIndex = 5;
        packageOutputBrowseButton.Text = "Browse";
        packageOutputBrowseButton.UseVisualStyleBackColor = true;
        packageOutputBrowseButton.Click += packageOutputBrowseButton_Click;
        // 
        // BoomfieldPackagerForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(484, 161);
        Controls.Add(packageOutputBrowseButton);
        Controls.Add(infoLabel);
        Controls.Add(outputFolderLabel);
        Controls.Add(outputFolderTextBox);
        Controls.Add(zipCheckBox);
        Controls.Add(packageButton);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximumSize = new Size(500, 200);
        MinimumSize = new Size(350, 200);
        Name = "BoomfieldPackagerForm";
        Text = "Boomfield Packager";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button packageButton;
    private CheckBox zipCheckBox;
    private TextBox outputFolderTextBox;
    private Label outputFolderLabel;
    private Label infoLabel;
    private Button packageOutputBrowseButton;
    private FolderBrowserDialog packageOutputFolderBrowserDialog;
}
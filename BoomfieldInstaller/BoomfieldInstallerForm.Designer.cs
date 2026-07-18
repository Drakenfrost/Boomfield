using System.ComponentModel;

namespace BoomfieldInstaller;

partial class BoomfieldInstallerForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private IContainer components = null;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoomfieldInstallerForm));
        bf2ExePathLabel = new System.Windows.Forms.Label();
        bf2ExeSelectButton = new System.Windows.Forms.Button();
        bf2ExePathTextBox = new System.Windows.Forms.TextBox();
        installButton = new System.Windows.Forms.Button();
        createShortcutCheckBox = new System.Windows.Forms.CheckBox();
        bf2ExeOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
        cleanInstallCheckBox = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // bf2ExePathLabel
        // 
        bf2ExePathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        bf2ExePathLabel.Location = new System.Drawing.Point(12, 9);
        bf2ExePathLabel.Name = "bf2ExePathLabel";
        bf2ExePathLabel.Size = new System.Drawing.Size(460, 20);
        bf2ExePathLabel.TabIndex = 1;
        bf2ExePathLabel.Text = "Where is your BF2.exe located?";
        bf2ExePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // bf2ExeSelectButton
        // 
        bf2ExeSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)224)), ((int)((byte)192)));
        bf2ExeSelectButton.Location = new System.Drawing.Point(12, 59);
        bf2ExeSelectButton.Name = "bf2ExeSelectButton";
        bf2ExeSelectButton.Size = new System.Drawing.Size(150, 25);
        bf2ExeSelectButton.TabIndex = 2;
        bf2ExeSelectButton.Text = "Select BF2 Executable";
        bf2ExeSelectButton.UseVisualStyleBackColor = false;
        bf2ExeSelectButton.Click += bf2ExeSelectButton_Click;
        // 
        // bf2ExePathTextBox
        // 
        bf2ExePathTextBox.Location = new System.Drawing.Point(12, 32);
        bf2ExePathTextBox.Name = "bf2ExePathTextBox";
        bf2ExePathTextBox.Size = new System.Drawing.Size(460, 23);
        bf2ExePathTextBox.TabIndex = 3;
        // 
        // installButton
        // 
        installButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        installButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)192)), ((int)((byte)255)), ((int)((byte)192)));
        installButton.Location = new System.Drawing.Point(397, 59);
        installButton.Name = "installButton";
        installButton.Size = new System.Drawing.Size(75, 25);
        installButton.TabIndex = 4;
        installButton.Text = "Install";
        installButton.UseVisualStyleBackColor = false;
        installButton.Click += installButton_Click;
        // 
        // createShortcutCheckBox
        // 
        createShortcutCheckBox.BackColor = System.Drawing.Color.Transparent;
        createShortcutCheckBox.Location = new System.Drawing.Point(282, 60);
        createShortcutCheckBox.Name = "createShortcutCheckBox";
        createShortcutCheckBox.Size = new System.Drawing.Size(109, 24);
        createShortcutCheckBox.TabIndex = 5;
        createShortcutCheckBox.Text = "Create Shortcut";
        createShortcutCheckBox.UseVisualStyleBackColor = false;
        // 
        // cleanInstallCheckBox
        // 
        cleanInstallCheckBox.BackColor = System.Drawing.Color.Transparent;
        cleanInstallCheckBox.Location = new System.Drawing.Point(184, 60);
        cleanInstallCheckBox.Name = "cleanInstallCheckBox";
        cleanInstallCheckBox.Size = new System.Drawing.Size(92, 24);
        cleanInstallCheckBox.TabIndex = 6;
        cleanInstallCheckBox.Text = "Clean Install";
        cleanInstallCheckBox.UseVisualStyleBackColor = false;
        // 
        // BoomfieldInstallerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        ClientSize = new System.Drawing.Size(484, 211);
        Controls.Add(installButton);
        Controls.Add(createShortcutCheckBox);
        Controls.Add(cleanInstallCheckBox);
        Controls.Add(bf2ExeSelectButton);
        Controls.Add(bf2ExePathTextBox);
        Controls.Add(bf2ExePathLabel);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Location = new System.Drawing.Point(15, 15);
        MaximumSize = new System.Drawing.Size(500, 250);
        MinimumSize = new System.Drawing.Size(500, 250);
        Text = "Boomfield Installer";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label bf2ExePathLabel;
    private System.Windows.Forms.TextBox bf2ExePathTextBox;
    private System.Windows.Forms.OpenFileDialog bf2ExeOpenFileDialog;
    private System.Windows.Forms.CheckBox cleanInstallCheckBox;
    private System.Windows.Forms.CheckBox createShortcutCheckBox;
    private System.Windows.Forms.Button bf2ExeSelectButton;
    private System.Windows.Forms.Button installButton;

    #endregion
}
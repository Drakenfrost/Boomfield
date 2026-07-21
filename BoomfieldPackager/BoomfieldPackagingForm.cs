using System;
using System.Windows.Forms;

namespace BoomfieldPackager
{
    public partial class BoomfieldPackagingForm : Form
    {
        private readonly BoomfieldPackagerForm _packager;

        public BoomfieldPackagingForm(BoomfieldPackagerForm packager)
        {
            InitializeComponent();

            packageProgressBar.Minimum = 0;
            packageProgressBar.Maximum = BoomfieldPackagerForm.EntryCount;

            _packager = packager;
            _packager.PackageProgressChanged += OnProgressChanged;
        }

        private void packageCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnProgressChanged(int progress)
        {
            packageProgressBar.Value = progress;
            packageLabel.Text = _packager.PackageProgressInfo;
        }

        private void BoomfieldPackagingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _packager.CancellationTokenSource?.Cancel();
        }
    }
}

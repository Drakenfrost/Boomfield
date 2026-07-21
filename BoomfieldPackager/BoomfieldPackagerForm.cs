using BoomfieldInstaller;
using System.Windows.Forms;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace BoomfieldPackager;

public partial class BoomfieldPackagerForm : Form
{
    public string PackageProgressInfo { get; private set; } = "";

    public event Action<int>? PackageProgressChanged;

    public CancellationTokenSource? CancellationTokenSource;

    // The total number of folders and files that will be copied when packaging.
    public static int EntryCount => BoomfieldModFolderNames.Length + BoomfieldModFileNames.Length;

    private const string BoomfieldFolderName = "boomfield";

    private const string BoomfieldIconName = "mod_icon.ico";

    private const string BoomfieldPackagedFolderName = "BoomfieldBF2Mod";
    private string OutputFolderPath => outputFolderTextBox.Text.Trim();

    private const string BoomfieldInstallerFolderPath = "BoomfieldInstaller\\bin\\Installer";

    private const string BoomfieldInstallerExeName = "BoomfieldInstaller.exe";

    private static readonly string[] BoomfieldModFolderNames =
    [
        "AI",
        "Common",
        "Fonts",
        "Levels",
        "Localization",
        "Menu",
        "Movies",
        "Objects",
        "Python",
        "Settings",
        "Shaders"
    ];

    private static readonly string[] BoomfieldModFileNames =
    [
        "Common_server.zip",
        "Common_client.zip",
        "Objects_Server.zip",
        "Objects_client.zip",
        "Menu_Server.zip",
        "Menu_client.zip",
        "Fonts_client.zip",
        "Shaders_client.zip",
        "ServerArchives.con",
        "ClientArchives.con",
        "GameLogicInit.con",
        "Init.con",
        "boomfield.mew",
        "Mod.desc",
        "mod_icon.ico",
        "mod_icon.jpg",
        "mod_icon.png",
        "Ingame.mep"
    ];

    private static bool packaging;

    private BoomfieldPackagingForm? packagingForm;

    public BoomfieldPackagerForm()
    {
        InitializeComponent();

        outputFolderTextBox.Text = GetBoomfieldRootFolderPath();
    }

    private void outputFolderTextBox_TextChanged(object sender, EventArgs e)
    {
        UpdateInfo();
    }
    private void packageOutputBrowseButton_Click(object sender, EventArgs e)
    {
        if (packageOutputFolderBrowserDialog.ShowDialog() == DialogResult.OK &&
            Directory.Exists(packageOutputFolderBrowserDialog.SelectedPath))
        {
            outputFolderTextBox.Text = packageOutputFolderBrowserDialog.SelectedPath;
        }
    }

    private async void packageButton_Click(object sender, EventArgs e)
    {
        try
        {
            await PackageBoomfield();
        }
        catch (Exception ex)
        {
            ShowErrorMessage(
                "Failed to package Boomfield:\n" +
                $"{ex.Message}");

            packagingForm?.Close();
        }
    }

    private void UpdateInfo()
    {
        if (Directory.Exists(OutputFolderPath))
        {
            infoLabel.Text = $"Package will be created at '{GetPackageOutputFolderPath()}'";
        }
        else
        {
            infoLabel.Text = "Please provide a valid output folder path!";
        }
    }

    private async Task PackageBoomfield()
    {
        if (packaging)
            return;

        var boomfieldRootFolder = GetBoomfieldRootFolderPath();

        if (!Directory.Exists(boomfieldRootFolder))
        {
            ShowErrorMessage($"Please ensure this packager is being run inside the {BoomfieldFolderName} folder.");
            return;
        }

        if (!Directory.Exists(OutputFolderPath))
        {
            ShowErrorMessage(
                "Package output path is not valid.\n" +
                $"Provided path: {OutputFolderPath}");
            return;
        }

        packaging = true;
        PackageProgressChanged?.Invoke(0);
        CancellationTokenSource = new();
        packagingForm = new BoomfieldPackagingForm(this);
        packagingForm.Show(this);

        var packageOutputFolderPath = GetPackageOutputFolderPath();
        var boomfieldOutputFolderPath = Path.Combine(packageOutputFolderPath, BoomfieldFolderName);

        var count = 0;

        // Copy mod folders.
        foreach (var folderName in BoomfieldModFolderNames)
        {
            if (CancellationTokenSource.IsCancellationRequested)
                return;

            var source = Path.Combine(boomfieldRootFolder, folderName);
            var dest = Path.Combine(boomfieldOutputFolderPath, folderName);
            PackageProgressInfo = dest;

            if (source == dest)
                break;

            try
            {
                await Task.Run(() => Utilities.CopyDirectory(source, dest, true), CancellationTokenSource.Token);
            }
            catch (Exception e)
            {
                //ShowErrorMessage(e.Message);
            }

            count++;
            PackageProgressChanged?.Invoke(count);
        }

        // Copy mod files.
        foreach (var fileName in BoomfieldModFileNames)
        {
            if (CancellationTokenSource.IsCancellationRequested)
                return;

            var source = Path.Combine(boomfieldRootFolder, fileName);
            var dest = Path.Combine(boomfieldOutputFolderPath, fileName);
            PackageProgressInfo = dest;

            if (source == dest)
                break;

            try
            {
                await Task.Run(() => File.Copy(source, dest), CancellationTokenSource.Token);
            }
            catch (Exception e)
            {
                //ShowErrorMessage(e.Message);
            }

            count++;
            PackageProgressChanged?.Invoke(count);
        }

        // Copy installer.
        try
        {
            var installerDir = new DirectoryInfo(Path.Combine(GetBoomfieldRootFolderPath(), BoomfieldInstallerFolderPath));
            var installerFiles = installerDir.GetFiles();

            foreach (var file in installerFiles)
            {
                await Task.Run(() => File.Copy(file.FullName, Path.Combine(packageOutputFolderPath, file.Name)), CancellationTokenSource.Token);
            }
        }
        catch (Exception e)
        {
            ShowErrorMessage(e.Message);
        }

        // Compress to ZIP file if applicable.
        if (zipCheckBox.Checked)
        {
            PackageProgressInfo = "Compressing to ZIP file...";
            PackageProgressChanged?.Invoke(count);

            try
            {
                await Task.Run(() =>
                    ZipFile.CreateFromDirectory(packageOutputFolderPath, packageOutputFolderPath + ".zip"));
            }
            catch (Exception e)
            {
                ShowErrorMessage("Failed to zip package.\n\n" +
                                 $"{e.Message}");
            }
        }

        // Success!
        packagingForm.Close();
        ShowInfoMessage("Boomfield Battlefield 2 mod has been packaged!", "Success");
        packaging = false;
    }

    private string GetBoomfieldRootFolderPath()
    {
        var currentDirPath = AppDomain.CurrentDomain.BaseDirectory;

        var boomfieldDirPath = Path.Combine(
            currentDirPath[..currentDirPath.IndexOf(BoomfieldFolderName, StringComparison.Ordinal)],
            BoomfieldFolderName);

        return boomfieldDirPath;
    }

    private string GetPackageOutputFolderPath()
    {
        var packagePath = Path.Combine(OutputFolderPath, BoomfieldPackagedFolderName);

        return packagePath;
    }

    private static void ShowInfoMessage(string message, string caption = "Info")
    {
        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static void ShowWarningMessage(string message, string caption = "Warning")
    {
        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private static void ShowErrorMessage(string message, string caption = "Error")
    {
        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
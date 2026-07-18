// Debug mode does a fake install, stepping through the files and folders that would be copied
// without actually copying them.
//#define DEBUG_MODE

using System;
using System.IO;
using System.Windows.Forms;

namespace BoomfieldInstaller;

// TODO: Try to find the BF2 exe and autopopulate the path field.
public partial class BoomfieldInstallerForm : Form
{
    private const string BoomfieldFolderName = "boomfield";

    private const string Bf2ExeFileName = "BF2.exe";

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

    public BoomfieldInstallerForm()
    {
        InitializeComponent();

        bf2ExeOpenFileDialog.Multiselect = false;
        bf2ExeOpenFileDialog.CheckFileExists = true;
        bf2ExeOpenFileDialog.ReadOnlyChecked = true;
        bf2ExeOpenFileDialog.Filter = "BF2 Executable | BF2.exe";

        createShortcutCheckBox.Checked = true;
    }

    private void bf2ExeSelectButton_Click(object sender, EventArgs e)
    {
        if (bf2ExeOpenFileDialog.ShowDialog() == DialogResult.OK)
        {
            bf2ExePathTextBox.Text = bf2ExeOpenFileDialog.FileName;
        }
    }

    private void installButton_Click(object sender, EventArgs e)
    {
        InstallBoomfield();
    }

    private void InstallBoomfield()
    {
        var bf2ExePath = bf2ExePathTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(bf2ExePath))
        {
            ShowErrorMessage($"Please provide the location of {Bf2ExeFileName}.");
            return;
        }

        var bf2Exe = new FileInfo(bf2ExePath);

        if (!bf2Exe.Exists)
        {
            ShowErrorMessage($"{Bf2ExeFileName} was not found at '{bf2ExePath}'.");
            return;
        }

        var bf2RootDir = Path.GetDirectoryName(bf2Exe.FullName);

        if (bf2RootDir == null)
        {
            ShowErrorMessage($"{Bf2ExeFileName} is not in a valid location.");
            return;
        }

        var bf2ModsDir = new DirectoryInfo(Path.Combine(bf2RootDir, "mods"));

        if (!bf2ModsDir.Exists)
        {
            ShowErrorMessage($"No mods folder exists at '{bf2RootDir}'.");
            return;
        }

        // Find the root Boomfield folder.
        var currentDirPath = AppDomain.CurrentDomain.BaseDirectory;

        var boomfieldDirPath = Path.Combine(
            currentDirPath[..currentDirPath.IndexOf(BoomfieldFolderName, StringComparison.Ordinal)],
            BoomfieldFolderName);

        var boomfieldDir = new DirectoryInfo(boomfieldDirPath);

        if (!boomfieldDir.Exists)
        {
            ShowErrorMessage("This copy of boomfield has been altered or corrupted.");
            return;
        }

        var installPath = Path.Combine(bf2ModsDir.FullName, BoomfieldFolderName);

        // Let the user know that the installation is about to begin.
        var installDialogResult = MessageBox.Show(
            $"You are about to install Boomfield, a mod for Battlefield 2!\n\n" + 
            $"Source: {boomfieldDir}\n" +
            $"Destination: {installPath}\n\n" +
            $"Would you like to continue with the installation?",
            "Install Boomfield",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (installDialogResult != DialogResult.Yes)
        {
            ShowErrorMessage("You aborted the installation.", "Aborted");
            return;
        }
        
        // Delete mod folders and files if doing a clean install.
        if (cleanInstallCheckBox.Checked)
        {
            foreach (var folderName in BoomfieldModFolderNames)
            {
                var folderPath = Path.Combine(installPath, folderName);
                    

#if DEBUG_MODE
                ShowWarningMessage(
                    $"The following would be deleted in a real installation:\n\n" +
                    $"Folder: {folderPath}\n" +
                    "Debug");
                continue;
#endif

                try
                {
                    Directory.Delete(folderPath, true);
                }
                catch (IOException e)
                {
                    ShowErrorMessage("Failed to clean mod files.\n\n" +
                                     $"{e.Message}");
                }
            }
            
            foreach (var fileName in BoomfieldModFileNames)
            {
                var filePath = Path.Combine(installPath, fileName);

#if DEBUG_MODE
                ShowWarningMessage(
                    $"The following would be deleted in a real installation:\n\n" +
                    $"File: {filePath}\n" +
                    "Debug");
                continue;
#endif

                try
                {
                    File.Delete(filePath);
                }
                catch (IOException e)
                {
                    ShowErrorMessage("Failed to clean mod files.\n\n" +
                                     $"{e.Message}");
                }
            }
        }

        // Copy mod folders.
        foreach (var folderName in BoomfieldModFolderNames)
        {
            var source = Path.Combine(boomfieldDir.FullName, folderName);
            var dest = Path.Combine(installPath, folderName);
            var sourceIsDest = source == dest;

#if DEBUG_MODE
            ShowWarningMessage(
                $"The following would be copied in a real installation:\n\n" +
                $"Source: {source}\n" +
                $"Destintaion: {dest}\n" +
                $"Source is destination? {sourceIsDest}",
                "Debug");
            continue;
#endif

            if (source == dest)
                continue;

            try
            {
                Utilities.CopyDirectory(source, dest, true);
            }
            catch (IOException e)
            {
                ShowErrorMessage("Failed to copy mod folders.\n\n" +
                                 $"{e.Message}");
            }
        }

        // Copy mod files.
        foreach (var fileName in BoomfieldModFileNames)
        {
            var source = Path.Combine(boomfieldDir.FullName, fileName);
            var dest = Path.Combine(installPath, fileName);
            var sourceIsDest = source == dest;

#if DEBUG_MODE
            ShowWarningMessage(
                $"The following would be copied in a real installation:\n\n" +
                $"Source: {source}\n" +
                $"Destintaion: {dest}\n" +
                $"Source is destination? {sourceIsDest}",
                "Debug");
            continue;
#endif

            if (source == dest)
                continue;

            try
            {
                File.Copy(fileName, Path.Combine(source, dest));
            }
            catch (IOException e)
            {
                ShowErrorMessage("Failed to copy mod files.\n\n" +
                                 $"{e.Message}");
            }
        }

        // Success!
        ShowInfoMessage("Boomfield Battlefield 2 mod installed!", "Success");

        return;

        void ShowInfoMessage(string message, string caption = "Info")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void ShowWarningMessage(string message, string caption = "Warning")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void ShowErrorMessage(string message, string caption = "Error")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
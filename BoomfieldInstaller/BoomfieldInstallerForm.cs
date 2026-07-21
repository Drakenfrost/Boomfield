// Debug mode does a fake install, stepping through the files and folders that would be copied
// without actually copying them.
//#define DEBUG_MODE

using System;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace BoomfieldInstaller;

public partial class BoomfieldInstallerForm : Form
{
    private const string BoomfieldFolderName = "boomfield";

    private const string BoomfieldIconName = "mod_icon.ico";

    private const string Bf2ExeFileName = "BF2.exe";

    private const string Bf2DefaultInstallPath = "C:\\Program Files (x86)\\EA Games\\Battlefield 2";

    /// <summary>
    /// Assigned from <see cref="bf2ExePathTextBox"/>.
    /// </summary>
    private string Bf2ExeFilePath => bf2ExePathTextBox.Text.Trim();

    private string Bf2RootFolderPath => Path.GetDirectoryName(Bf2ExeFilePath) ?? "";

    private string Bf2ModsFolderPath => Path.Combine(Bf2RootFolderPath, "mods");

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

        var defaultBf2ExeLocation = Path.Combine(Bf2DefaultInstallPath, Bf2ExeFileName);

        // TODO: Try to find the BF2 exe and autopopulate the path field.
        // For now, only check if the BF2.exe is at the default install location,
        // otherwise the input field is left blank for the user to fill in.
        if (File.Exists(defaultBf2ExeLocation))
        {
            bf2ExePathTextBox.Text = defaultBf2ExeLocation;
        }
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
        if (string.IsNullOrWhiteSpace(Bf2ExeFilePath))
        {
            ShowErrorMessage($"Please provide the location of {Bf2ExeFileName}.");
            return;
        }

        if (!File.Exists(Bf2ExeFilePath))
        {
            ShowErrorMessage($"{Bf2ExeFileName} was not found at '{Bf2ExeFilePath}'.");
            return;
        }

        if (!Directory.Exists(Bf2ModsFolderPath))
        {
            ShowErrorMessage($"No mods folder exists at '{Bf2RootFolderPath}'.");
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

        var installPath = Path.Combine(Bf2ModsFolderPath, BoomfieldFolderName);

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
            if (sourceIsDest)
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
            if (sourceIsDest)
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

        // Create shortcut if the user chose to.
        if (createShortcutCheckBox.Checked)
        {
            CreateShortcut();
        }

        // Success!
        ShowInfoMessage("Boomfield Battlefield 2 mod installed!", "Success");

        return;
    }

    private void CreateShortcut()
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var shortcutPath = Path.Combine(desktopPath, "Boomfield.lnk");
        var targetPath = $"\"{Bf2ExeFilePath}\"";
        var arguments = $"+restart 1 +modPath \"mods/{BoomfieldFolderName}\"";
        var iconPath = Path.Combine(Bf2ModsFolderPath, BoomfieldFolderName, BoomfieldIconName);

        var createShortcutResult = MessageBox.Show(
            $"Do you want to create a shortcut at '{shortcutPath}'?",
            "Create Boomfield Shortcut",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

        if (createShortcutResult != DialogResult.Yes)
            return;

        try
        {
            var shell = new WshShell();
            var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            shortcut.Description = "Runs Battlefield 2 with the Boomfield mod";
            shortcut.TargetPath = targetPath;
            shortcut.IconLocation = iconPath;
            shortcut.Arguments = arguments;
            shortcut.WorkingDirectory = Bf2RootFolderPath;
            shortcut.WindowStyle = 1;
            shortcut.Save();

        }
        catch (IOException e)
        {
            ShowErrorMessage("Failed to create shortcut.\n\n" +
                             $"{e.Message}");
        }
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

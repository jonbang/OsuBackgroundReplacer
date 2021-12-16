using System.Reflection;

namespace Osu_BG_Replace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public static void Persistent(string one, bool p)
        {
            if (p)
            {
                MessageBox.Show(one, "Osu! Background Replacer", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show(one, "Osu! Background Replacer");
            }
        }

        public static void MoveDirectory(string source, string target, bool del)
        {
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Copy(file, targetFile);
                }
            }
            if (del)
            {
                Directory.Delete(source, true);
            }
        }

        public void WriteResourceToFile(string resourceName, string fileName)
        {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }

        public static void CopyDirectory(string source, string target)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    if (!File.Exists(Path.Combine(folders.Target, Path.GetFileName(file))))
                    {
                        File.Copy(file, Path.Combine(folders.Target, Path.GetFileName(file)));
                    }
                }
                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    if (!Directory.Exists(Path.Combine(folders.Target, Path.GetFileName(folder))))
                    {
                        stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                    }
                }
            }
        }

        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void groupBox1_Enter(object sender, EventArgs e)
        { }

        private void label2_Click(object sender, EventArgs e)
        { }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            bool p = Persistence.Checked; //if p is true show window above all windows
            String Opath = tbOsuFolder.Text;
            String Wpath = Path.Combine(Opath, "Songs");
            String Ipath = "Black.png";
            String f;
            String Cpath = "Osu!SongReplacement.cache";
            if (string.IsNullOrEmpty(Opath) || Directory.GetFiles(Opath, "osu!.exe").Length == 0)
            {
                Persistent("Please provide the directory to osu.exe", p);
                return;
            }
            else
            {
                if (CustomBG.Checked) //if user wants a custom background
                {
                    Ipath = tbimgPath.Text;
                    if (!Ipath.EndsWith(".png") && !Ipath.EndsWith(".jpg"))
                    {
                        Persistent("Please provide a valid .png or .jpg file.", p);
                        return;
                    }
                } else if (!CustomBG.Checked) {
                    Ipath = "Black.png";
                }
                if (Backup.Checked) //if backup wanted
                {
                    String Bpath = tbBackup.Text;
                    if (string.IsNullOrEmpty(Bpath))
                    {
                        if (p) 
                        { 
                            var selectedOption = MessageBox.Show($"Do you want to use the default backup path? ({Path.Combine(Opath, "Songs-Backup")})", "Osu! Background Replacer", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                            if (selectedOption == DialogResult.Yes) //The user has selected "Yes"
                            {
                                Directory.CreateDirectory(Path.Combine(Opath, "Songs-Backup"));
                                Bpath = Path.Combine(Opath, "Songs-Backup");
                            }
                            else
                            { //The user has selected "No"
                                return;
                            }
                        }
                        else 
                        { 
                            var selectedOption = MessageBox.Show($"Do you want to use the default backup path? ({Path.Combine(Opath, "Songs-Backup")})", "Osu! Background Replacer");
                            if (selectedOption == DialogResult.Yes) //The user has selected "Yes"
                            {
                                Directory.CreateDirectory(Path.Combine(Opath, "Songs-Backup"));
                                Bpath = Path.Combine(Opath, "Songs-Backup");
                            }
                            else
                            { //The user has selected "No"
                                return;
                            }
                        }
                    }
                    if (!Directory.Exists(Bpath))
                    {
                        Directory.CreateDirectory(Bpath);
                    }
                    CopyDirectory(Wpath, Bpath);
                }
                if (!File.Exists(Cpath))
                {
                    File.Create(Cpath).Dispose();
                }
                foreach (var folder in Directory.GetDirectories(Wpath, "*.*"))
                {
                    string lastFolderName = Path.GetFileName(folder); //Get foldername
                    string lastCFolderName = Path.GetFileName(Ipath); //Get foldername
                    if (!File.ReadAllText(Cpath).Contains($"{lastFolderName}: {lastCFolderName}")) //if folder has not been previously altered with this image
                    {
                        if (File.ReadAllText(Cpath).Contains($"{lastFolderName}:"))
                        {
                            using (StreamWriter writer = new StreamWriter(Cpath))
                            {
                                writer.WriteLine(String.Empty);
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(Cpath, true))
                        {
                            writer.WriteLine($"{lastFolderName}: {lastCFolderName}");
                        }
                        foreach (var file in Directory.GetFiles(folder))
                        {
                            if (file.EndsWith(".png") || file.EndsWith(".jpg"))
                            {
                                f = file;
                                File.Delete(file);
                                if (!Ipath.Contains("Black.png"))
                                {
                                    File.Copy(Ipath, f);
                                } else
                                {
                                    WriteResourceToFile("Osu_BG_Replace.Resources.Black.png", f);
                                }
                            }
                        }
                    }
                }
                Persistent("Your Osu! backgrounds have been replaced!", p);
            }
        }

        private void tbOsuFolder_TextChanged(object sender, EventArgs e)
        { }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void Backup_CheckedChanged(object sender, EventArgs e)
        {}

        private void CustomBG_CheckedChanged(object sender, EventArgs e)
        {}

        private void tbBackup_TextChanged(object sender, EventArgs e)
        {}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {}

        private void CacheClear_Click(object sender, EventArgs e)
        {
            bool p = Persistence.Checked; //if p is true show window above all windows
            if (File.Exists("Osu!SongReplacement.cache"))
            {
                File.WriteAllText("Osu!SongReplacement.cache", string.Empty);
                Persistent("Cache cleared.", p);
            } else
            {
                Persistent("Unable to locate cache file.", p);
                return;
            }
        }

        private void BR_Click(object sender, EventArgs e)
        {
            String Opath = tbOsuFolder.Text;
            bool w = false;
            bool p = Persistence.Checked; //if p is true show window above all windows
            if (string.IsNullOrEmpty(Opath) || Directory.GetFiles(Opath, "osu!.exe").Length == 0)
            {
                Persistent("Please provide the directory to osu.exe", p);
                return;
            }
            else if (!Directory.Exists(tbBackup.Text) && !Directory.Exists(Path.Combine(Opath, "Songs-Backup")))
            {
                Persistent("Directory is invalid.", p);
                return;
            }
            try
            {if (Directory.GetFiles(Directory.GetDirectories(Path.Combine(Opath, "Songs-Backup"))[0], "*.osu").Length > 0 || Directory.GetFiles(Directory.GetDirectories(tbBackup.Text)[0], "*.osu").Length > 0) //check if first folder in directory (irrespective of sorting method) contains a .osu file
                {
                    if (p)
                    {
                        var selectedOption = MessageBox.Show("Do you want to remove the backup?", "Osu! Background Replacer", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                        if (selectedOption == DialogResult.Yes) //The user has selected "Yes"
                        {
                            w = true;
                        }
                    }
                    else
                    {
                        var selectedOption = MessageBox.Show("Do you want to remove the backup?", "Osu! Background Replacer", MessageBoxButtons.YesNo);
                        if (selectedOption == DialogResult.Yes) //The user has selected "Yes"
                        {
                            w = true;
                        }
                    }
                    if (Backup.Checked) //if custom backup location was used
                    {
                        String Bpath = tbBackup.Text;
                        if (string.IsNullOrEmpty(Bpath))
                        {
                            if (Directory.Exists(Path.Combine(Opath, "Songs-Backup")))
                            {
                                if (w)
                                {
                                    MoveDirectory(Path.Combine(Opath, "Songs-Backup"), Path.Combine(Opath, "Songs"), true);
                                }
                                else
                                {
                                    MoveDirectory(Path.Combine(Opath, "Songs-Backup"), Path.Combine(Opath, "Songs"), false);
                                }
                            }
                        }
                        else if (Directory.Exists(Bpath))
                        {
                            if (w)
                            {
                                MoveDirectory(Bpath, Path.Combine(Opath, "Songs"), true);
                            }
                            else
                            {
                                MoveDirectory(Bpath, Path.Combine(Opath, "Songs"), false);
                            }
                        }
                        else if (!Directory.Exists(Bpath) && !Directory.Exists(Path.Combine(Opath, "Songs-Backup")))
                        {
                            Persistent("Directory is invalid.", p);
                            return;
                        }
                        if (File.Exists("Osu!SongReplacement.cache"))
                        {
                            File.WriteAllText("Osu!SongReplacement.cache", string.Empty);
                        }
                        Persistent("Your backup has been restored", p);
                    }
                    else
                    {
                        if (w)
                        {
                            MoveDirectory(Path.Combine(Opath, "Songs-Backup"), Path.Combine(Opath, "Songs"), true);
                        }
                        else
                        {
                            MoveDirectory(Path.Combine(Opath, "Songs-Backup"), Path.Combine(Opath, "Songs"), false);
                        }
                        if (File.Exists("Osu!SongReplacement.cache"))
                        {
                            File.WriteAllText("Osu!SongReplacement.cache", string.Empty);
                        }
                        Persistent("Your backup has been restored", p);
                    }
                }
            } catch
            {
                Persistent("Directory is invalid.", p);
                return;
            }
        }

        private void Persistence_CheckedChanged(object sender, EventArgs e)
        {}
    }
}
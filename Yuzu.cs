namespace FileStub.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml;
    using Newtonsoft.Json;
    using RTCV.Common;
    using RTCV.CorruptCore;
    using RTCV.UI;

    public partial class FileStubTemplateYuzu : Form, IFileStubTemplate
    {

        const string YUZUSTUB_MAIN = "Yuzu : NS Executable - main";
        const string YUZUSTUB_ALL = "Yuzu : NS Executables - main, sdk, and subsdk";
        public static string YuzuDir = Path.Combine(FileStub.FileWatch.currentDir, "YUZU");
        public string YuzuExePath = Path.Combine(FileStub.FileWatch.currentDir, "EMUS", "YUZU", "yuzu.exe");
        public string GameExefsModFolder;
        public string GameNSODumpFolder;
        public string GameID;
        YuzuTemplateSession currentYuzuSession;
        public Dictionary<string, YuzuTemplateSession> knownGamesDico = new Dictionary<string, YuzuTemplateSession>();
        string currentSelectedTemplate = null;
        Process YuzuProcess = null;
        string gamepath = null;
        public string[] TemplateNames
        {
            get => new string[] {
            YUZUSTUB_MAIN,
            YUZUSTUB_ALL,
        };
        }

        public bool DisplayDragAndDrop => true;
        public bool DisplayBrowseTarget => true;


        public FileStubTemplateYuzu()
        {
            InitializeComponent();
            if (!Directory.Exists(YuzuDir))
                Directory.CreateDirectory(YuzuDir);

            string YuzuParamsDir = Path.Combine(YuzuDir, "PARAMS");

            if (!Directory.Exists(YuzuParamsDir))
                Directory.CreateDirectory(YuzuParamsDir);
            lbNSOTarget.Visible = false;
            currentYuzuSession = new YuzuTemplateSession();
        }
        public FileTarget[] GetTargets()
        {
            lbGameName.Visible = false;
            if (GameExefsModFolder == "")
            {
                MessageBox.Show("No target loaded");
                return null;
            }

            List<FileTarget> targets = new List<FileTarget>();

            DirectoryInfo baseFolder = new DirectoryInfo(GameExefsModFolder);

            List<FileInfo> allFiles = SelectMultipleForm.DirSearch(baseFolder);

            string baseless(string path) => path.Replace(GameExefsModFolder, "");

            //var allDlls = allFiles.Where(it => it.Extension == ".dll");

            var mainExe = allFiles.Where(it => it.Name.ToUpper().Contains("MAIN")).ToArray();

            var allExecutables = allFiles.Where(it =>
                    it.Name.ToUpper().Contains("MAIN") && !it.Name.ToUpper().Contains("NPDM") && !it.Name.ToUpper().Contains("BAK") ||
                    it.Name.ToUpper().Contains("SDK") && !it.Name.ToUpper().Contains("BAK")
                    ).ToArray();

            var allMain = allExecutables.Where(it =>
                    it.Name.ToUpper().Contains("MAIN")
                    ).ToArray();


            switch (currentSelectedTemplate)
            {
                case YUZUSTUB_MAIN:
                    {
                        targets.AddRange(mainExe.Select(it => Vault.RequestFileTarget(baseless(it.FullName), baseFolder.FullName)));
                    }
                    break;
                case YUZUSTUB_ALL:
                    {
                        targets.AddRange(allExecutables.Select(it => Vault.RequestFileTarget(baseless(it.FullName), baseFolder.FullName)));
                    }
                    break;
            }
            gamepath = lbNSOTarget.Text;
            currentYuzuSession.gameName = lbNSOTarget.Text;
            currentYuzuSession.YuzuExePath = this.YuzuExePath;
            lbGameName.Visible = false;
            knownGamesDico[currentYuzuSession.gameName] = currentYuzuSession;
            cbSelectedGame.Items.Add(currentYuzuSession.gameName);
            //cbSelectedGame.SelectedIndex = cbSelectedGame.Items.Count - 1;
            currentYuzuSession.gameFilePath = currentYuzuSession.gameName;
            foreach (YuzuTemplateSession cgi in knownGamesDico.Values)
            {
                cgi.YuzuExePath = currentYuzuSession.YuzuExePath;
                cgi.gameFilePath = currentYuzuSession.gameFilePath;
            }
            //SaveKnownGames();

            //Prepare filestub for execution
            var sf = S.GET<StubForm>();
            FileWatch.currentSession.selectedExecution = ExecutionType.EXECUTE_OTHER_PROGRAM;
            Executor.otherProgram = currentYuzuSession.YuzuExePath;
            sf.tbArgs.Text = $"\"{currentYuzuSession.gameFilePath}\"";
            FileWatch.currentSession.bigEndian = false;
            return targets.ToArray();
        }

        public Form GetTemplateForm(string name)
        {
            this.SummonTemplate(name);
            return this;
        }

        public bool LoadKnownGames()
        {
            JsonSerializer serializer = new JsonSerializer();
            string path = Path.Combine(YuzuDir, "PARAMS", "knowngames.json");
            if (!File.Exists(path))
            {
                knownGamesDico = new Dictionary<string, YuzuTemplateSession>();
                return true;
            }
            try
            {

                using (StreamReader sw = new StreamReader(path))
                using (JsonTextReader reader = new JsonTextReader(sw))
                {
                    knownGamesDico = serializer.Deserialize<Dictionary<string, YuzuTemplateSession>>(reader);
                }

                foreach (var key in knownGamesDico.Keys)
                    cbSelectedGame.Items.Add(key);
            }
            catch (IOException e)
            {
                MessageBox.Show("Unable to access the filemap! Figure out what's locking it and then restart the WGH.\n" + e.ToString());
                return false;
            }
            return true;
        }
        public bool SaveKnownGames()
        {
            JsonSerializer serializer = new JsonSerializer();
            var path = Path.Combine(YuzuDir, "PARAMS", "knowngames.json");
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, knownGamesDico);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Unable to access the known games!\n" + e.ToString());
                return false;
            }
            return true;
        }
        private void SummonTemplate(string name)
        {
            currentSelectedTemplate = name;

            lbTemplateDescription.Text =
$@"== Corrupt Switch Games ==
   TODO: description
   ";
        }

        public void GetGameTitleID(string game_name)
        {
            Regex rx = new Regex(@"([ABCDEF0123456789]{16})", RegexOptions.Compiled);
            Match match = rx.Match(game_name);
            GameID = match.Groups[1].Value;
            GameNSODumpFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "yuzu", "dump", GameID, "nso_dump");
        }

        bool IFileStubTemplate.DragDrop(string[] fd)
        {
            if (fd.Length > 1 || fd[0].EndsWith("\\") || !(fd[0].ToUpper().Contains(".NSP") || fd[0].ToUpper().Contains(".XCI")))
            {
                MessageBox.Show("Please only drop an NSP or XCI dump of your game.");
                lbNSOTarget.Text = "";
                return false;
            }

            lbNSOTarget.Text = fd[0];
            GetGameTitleID(new FileInfo(fd[0]).Name);
            return true;
        }

        public void BrowseFiles()
        {
            string filename;

            OpenFileDialog OpenFileDialog1;
            OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.Title = "Open Switch Game";
            OpenFileDialog1.Filter = "Switch Game|*.xci;*.nsp";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog1.FileName.ToString().Contains('^'))
                {
                    MessageBox.Show("You can't use a file that contains the character ^ ");
                    lbNSOTarget.Text = "";
                    return;
                }

                filename = OpenFileDialog1.FileName;
            }
            else
            {
                lbNSOTarget.Text = "";
                return;
            }
            lbNSOTarget.Text = filename;
            GetGameTitleID(new FileInfo(filename).Name);
        }

        private void FileStubTemplateYuzu_Load(object sender, EventArgs e)
        {
            cbSelectedGame.SelectedIndex = 0;
            //LoadKnownGames();
        }

        private void btnPrepareMod_click(object sender, EventArgs e)
        {
            if (GameID == "")
            {
                MessageBox.Show("Game not defined!");
                return;
            }
            GameExefsModFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "yuzu", "load", GameID, "corruptions", "exefs");
            if (!Directory.Exists(GameExefsModFolder))
            {
                Directory.CreateDirectory(GameExefsModFolder);
            }
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = YuzuExePath;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(YuzuExePath);
            processStartInfo.Arguments = $"-d -g \"{lbNSOTarget.Text}\"";
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            var di = new DirectoryInfo(GameNSODumpFolder);
            process.WaitForExit();
            foreach(var file in di.GetFiles())
            {
                var newname = Regex.Replace(file.Name, @"(-[ABCDEF0123456789]{40})", "");
                if (newname == file.Name)
                {
                    newname = Regex.Replace(file.Name, @"(-[ABCDEF0123456789]{32})", "");
                }
                if (File.Exists(Path.Combine(GameExefsModFolder, newname)))
                {
                    continue;
                }
                file.CopyTo(Path.Combine(GameExefsModFolder, newname));
            }
        }

        internal bool SelectGame(string selected = null)
        {
            if (selected != null && selected != "None")
                currentYuzuSession = knownGamesDico[selected];

            

            //string gameFullPath = currentYuzuSession.gameFilePath;
            //if (!File.Exists(gameFullPath))
            //{
            //    string message = "File Stub couldn't find the file for this game. Would you like to remove this entry?";
            //    var result = MessageBox.Show(message, "Error finding game", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            //    if (result == DialogResult.Yes)
            //        UnmodGame();

            //    cbSelectedGame.SelectedIndex = 0;
            //    return false;
            //}

            //if (!LoadRpxFileInterface())
            //    return false;



            //load target here




            //S.GET<StubForm>().lbCemuStatus.Text = "Ready for corrupting";
            //S.GET<StubForm>().lbTargetedGameRpx.Text = currentSession.gameRpxFileInfo.FullName;
            //S.GET<StubForm>().lbTargetedGameId.Text = "Game ID: " + currentSession.FirstID + "-" + currentSession.SecondID;
            //EnableInterface();

            return true;
        }

        private void UnmodGame()
        {
            var lastRef = currentYuzuSession;

            FileInterface.CompositeFilenameDico.Remove(lastRef.gameName);
            knownGamesDico.Remove(lastRef.gameName);
            SaveKnownGames();
            cbSelectedGame.SelectedIndex = 0;
            cbSelectedGame.Items.Remove(lastRef.gameName);
        }

        private void cbSelectedGame_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selected = cbSelectedGame.SelectedItem.ToString();

            if (selected == "None")
                return;

            if (!SelectGame(selected))
            {
                cbSelectedGame.SelectedIndex = 0;
                return;
            }

            S.GET<StubForm>().btnLoadTargets_Click(null, null);

        }

        public void GetSegments(FileInterface exeInterface)
        {
            
        }
    }
    public class YuzuTemplateSession
    {
        public FileInfo gameMainExeFileInfo = null;
        public FileInfo YuzuExeFile = null;
        public string YuzuExePath = null;
        public DirectoryInfo gameSaveFolder = null;
        public string gameID;
        public string gameFile = null;
        public string gameFilePath = null;
        public string gameExefsModPath = null;
        public string FirstID = null;
        public string SecondID = null;
        public string fileInterfaceTargetId = null;
        public string gameName = "Autodetect";
        public string mainUncompressedToken = null;
        internal FileMemoryInterface fileInterface;

        public override string ToString()
        {
            return gameName;
        }
    }
}

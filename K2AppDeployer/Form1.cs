using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;




namespace K2AppDeployer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Directory.Exists(@"K:\scripts"))
            {
                log("K: drive appears to be mapped to the K2000 already.");
                getTaskFiles();
            }
            if (File.Exists(@"settings.xml"))
            {
                log("Loading settings from settings.xml");
                string XMLFile = "settings.xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XMLFile);
                XmlNode K2HostNameNode = xmlDoc.SelectSingleNode("//Settings/K2HostName");
                K2HostName.Text = K2HostNameNode.InnerText;

            }
            if(File.Exists(@"tasks.xml"))
            {
                Directory.CreateDirectory(@"c:\KACE\engine");
                File.Copy(@"tasks.xml", @"c:\KACE\engine\tasks.xml");
            }
            String[] arguments = Environment.GetCommandLineArgs();
            if(arguments.Length > 1)
            {
                K2SAMBAPass.Text = arguments[1];
                if(K2HostName.Text != "") {
                    mapDrive();
                }
            }

        }

        public void log(string message)
        {
            outputBox.Text = outputBox.Text + message + "\r\n";
        }

        public void mapDrive()
        {
            log("Mapping k drive to K2 peinst share");
            Cursor.Current = Cursors.WaitCursor;
            string userName = "admin";
            string K2path = "\\\\" + K2HostName.Text + "\\peinst";
            if (DriveSettings.MapNetworkDrive("K", K2path, userName, K2SAMBAPass.Text))
            {

                log("Mapped K: to " + K2path);
                //System.Diagnostics.Process.Start("explorer.exe", @"K:\");
                getTaskFiles();

            }
            else
            {
                //there was a problem, I guess.
                MessageBox.Show("Error mapping K: to " + K2path);

            }
            Cursor.Current = Cursors.Default;

        }

        private void mapKDrive_Click(object sender, EventArgs e)
        {
            mapDrive();
        }

        public void getTaskFiles()
        {
            tasksList.Visible = true;
            tasksListLabel.Visible = true;
            log("Getting list of task files");
            var taskFiles = Directory.GetFiles(@"K:\scripts", "*Tasks*.xml").OrderBy(f => f);
            foreach (string file in taskFiles)
                {
                    tasksList.Items.Add(file);
                }

}

        private void tasksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            POTasks.Items.Clear();
            var unCheckedTasks = new List<string>();
            unCheckedTasks.Add("Set KACE Path");
            unCheckedTasks.Add("Fix BCD");
            unCheckedTasks.Add("Copy Drivers");
            unCheckedTasks.Add("Copy Post Install Files");
            unCheckedTasks.Add("Setup Post Install Tasks");
            unCheckedTasks.Add("Update Configuration For OS Tasks");
            unCheckedTasks.Add("Capture and Disable UAC");
            unCheckedTasks.Add("Run DPInst");
            unCheckedTasks.Add("Restore UAC");
            
            log("Selected " + tasksList.SelectedItem);
            string XMLFile = tasksList.SelectedItem.ToString();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLFile);
            XmlNodeList itemNodes = xmlDoc.SelectNodes("//Tasks/Task");
            foreach (XmlNode itemNode in itemNodes)
            {
                string id = itemNode.Attributes["ID"].Value;
                XmlNode name = itemNode.SelectSingleNode("Name");
                XmlNode WorkingDirectory = itemNode.SelectSingleNode("WorkingDirectory");
                XmlNode CommandLine = itemNode.SelectSingleNode("CommandLine");
                XmlNode Parameters = itemNode.SelectSingleNode("Parameters");
                XmlNode PostTaskAction = itemNode.SelectSingleNode("PostTaskAction");
                XmlNode KACETaskType = itemNode.SelectSingleNode("KACETaskType");
                XmlNode FileType = itemNode.SelectSingleNode("FileType");
                XmlNode Type = itemNode.SelectSingleNode("Type");
                XmlNode Guid = itemNode.SelectSingleNode("Guid");

                if (Type.InnerText == "PO")
                {
                    ListViewItem itm;
                    string[] task = new string[10];
                    task[0] = id;
                    task[1] = name.InnerText;
                    task[2] = WorkingDirectory.InnerText;
                    task[3] = CommandLine.InnerXml;
                    task[4] = Parameters.InnerText;
                    task[5] = PostTaskAction.InnerText;
                    task[6] = KACETaskType.InnerText;
                    task[7] = FileType.InnerText;
                    task[8] = Type.InnerText;
                    task[9] = Guid.InnerText;
                    itm = new ListViewItem(task);
                    if (unCheckedTasks.Contains(name.InnerText))
                    {
                        POTasks.Items.Add(itm);
                    } else
                    {
                        itm.Checked = true;
                        POTasks.Items.Add(itm);
                    }
                    
                }
            }
            generateTasksXML.Visible = true;

        }

        private void generateTasksXML_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\KACE\engine");
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Tasks");
            xmlDoc.AppendChild(rootNode);
            foreach (ListViewItem task in POTasks.Items)
            {
                if(task.Checked)
                {
                    XmlNode taskNode = xmlDoc.CreateElement("Task");
                    XmlAttribute attribute = xmlDoc.CreateAttribute("ID");
                    attribute.Value = task.SubItems[0].Text;
                    XmlNode name = xmlDoc.CreateElement("Name");
                    name.InnerText = task.SubItems[1].Text;
                    taskNode.AppendChild(name);
                    XmlNode WorkingDirectory = xmlDoc.CreateElement("WorkingDirectory");
                    if(Directory.Exists("K:\\applications\\" + task.SubItems[0].Text + "\\contents"))
                    {
                        WorkingDirectory.InnerText = task.SubItems[2].Text + "\\contents";
                    } else
                    {
                        WorkingDirectory.InnerText = task.SubItems[2].Text;
                    }
                    taskNode.AppendChild(WorkingDirectory);
                    XmlNode CommandLine = xmlDoc.CreateElement("CommandLine");
                    CommandLine.InnerXml = task.SubItems[3].Text;
                    taskNode.AppendChild(CommandLine);
                    XmlNode Parameters = xmlDoc.CreateElement("Parameters");
                    Parameters.InnerText = task.SubItems[4].Text;
                    taskNode.AppendChild(Parameters);
                    XmlNode PostTaskAction = xmlDoc.CreateElement("PostTaskAction");
                    PostTaskAction.InnerText = task.SubItems[5].Text;
                    taskNode.AppendChild(PostTaskAction);
                    XmlNode KACETaskType = xmlDoc.CreateElement("KACETaskType");
                    KACETaskType.InnerText = task.SubItems[6].Text;
                    taskNode.AppendChild(KACETaskType);
                    XmlNode FileType = xmlDoc.CreateElement("FileType");
                    FileType.InnerText = task.SubItems[7].Text;
                    taskNode.AppendChild(FileType);
                    XmlNode Type = xmlDoc.CreateElement("Type");
                    Type.InnerText = task.SubItems[8].Text;
                    taskNode.AppendChild(Type);
                    XmlNode Guid = xmlDoc.CreateElement("Guid");
                    Guid.InnerText = task.SubItems[9].Text;
                    taskNode.AppendChild(Guid);
                    rootNode.AppendChild(taskNode);
                }
            }
            xmlDoc.Save(@"c:\KACE\engine\tasks.xml");
            log("Saved tasks.xml file");

            //System.Diagnostics.Process.Start("notepad.exe", @"c:\temp\tasks.xml");
        }

        private void generateSettingsXML_Click(object sender, EventArgs e)
        {
            XmlDocument settings = new XmlDocument();
            XmlNode rootNode = settings.CreateElement("Settings");
            settings.AppendChild(rootNode);
            XmlNode K2HostNameNode = settings.CreateElement("K2HostName");
            K2HostNameNode.InnerText = K2HostName.Text;
            rootNode.AppendChild(K2HostNameNode);
            settings.Save("settings.xml");
        }

        private void launchKE_Click(object sender, EventArgs e)
        {
            bool is64 = Environment.Is64BitOperatingSystem;
            log(@"Copying KACE Engine files to c:\KACE");
            Directory.CreateDirectory(@"c:\KACE\engine");
            if(!File.Exists(@"c:\KACE\engine\tasks.xml"))
            {
                MessageBox.Show("No tasks.xml file was found, please select a list of tasks and generate one.");
                
            }
            if (!Directory.Exists(@"k:\scripts\"))
            {
                mapDrive();
            }
            string[] configXML = { config.Text.ToString() };
            File.WriteAllLines(@"C:\KACE\engine\config.xml", configXML);
            if(is64)
            {
                File.Copy(@"K:\hta\amd64\KACEEngine.exe", @"C:\KACE\engine\KACEEngine.exe", true);

            } else
            {
                File.Copy(@"K:\hta\x86\KACEEngine.exe", @"C:\KACE\engine\KACEEngine.exe", true);
            }
            DirectoryCopyClass.DirectoryCopy(@"K:\hta\kaceengineui", @"c:\KACE\engine\kaceengineui", true);
            System.Diagnostics.Process.Start(@"c:\KACE\engine\KACEEngine.exe");
        }

        private void config_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

public class DriveSettings
{

    private enum ResourceScope
    {
        RESOURCE_CONNECTED = 1,
        RESOURCE_GLOBALNET,
        RESOURCE_REMEMBERED,
        RESOURCE_RECENT,
        RESOURCE_CONTEXT
    }
    private enum ResourceType
    {
        RESOURCETYPE_ANY,
        RESOURCETYPE_DISK,
        RESOURCETYPE_PRINT,
        RESOURCETYPE_RESERVED
    }
    private enum ResourceUsage
    {
        RESOURCEUSAGE_CONNECTABLE = 0x00000001,
        RESOURCEUSAGE_CONTAINER = 0x00000002,
        RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
        RESOURCEUSAGE_SIBLING = 0x00000008,
        RESOURCEUSAGE_ATTACHED = 0x00000010
    }
    private enum ResourceDisplayType
    {
        RESOURCEDISPLAYTYPE_GENERIC,
        RESOURCEDISPLAYTYPE_DOMAIN,
        RESOURCEDISPLAYTYPE_SERVER,
        RESOURCEDISPLAYTYPE_SHARE,
        RESOURCEDISPLAYTYPE_FILE,
        RESOURCEDISPLAYTYPE_GROUP,
        RESOURCEDISPLAYTYPE_NETWORK,
        RESOURCEDISPLAYTYPE_ROOT,
        RESOURCEDISPLAYTYPE_SHAREADMIN,
        RESOURCEDISPLAYTYPE_DIRECTORY,
        RESOURCEDISPLAYTYPE_TREE,
        RESOURCEDISPLAYTYPE_NDSCONTAINER
    }
    [StructLayout(LayoutKind.Sequential)]
    private struct NETRESOURCE
    {
        public ResourceScope oResourceScope;
        public ResourceType oResourceType;
        public ResourceDisplayType oDisplayType;
        public ResourceUsage oResourceUsage;
        public string sLocalName;
        public string sRemoteName;
        public string sComments;
        public string sProvider;
    }
    [DllImport("mpr.dll")]
    private static extern int WNetAddConnection2
        (ref NETRESOURCE oNetworkResource, string sPassword,
        string sUserName, int iFlags);

    [DllImport("mpr.dll")]
    private static extern int WNetCancelConnection2
        (string sLocalName, uint iFlags, int iForce);

    public static bool MapNetworkDrive(string sDriveLetter, string sNetworkPath, string userName, string password)
    {
        int retVal;
        //MessageBox.Show(sNetworkPath + userName + password);
        //Checks if the last character is \ as this causes error on mapping a drive.
        if (sNetworkPath.Substring(sNetworkPath.Length - 1, 1) == @"\")
        {
            sNetworkPath = sNetworkPath.Substring(0, sNetworkPath.Length - 1);
        }

        NETRESOURCE oNetworkResource = new NETRESOURCE();
        oNetworkResource.oResourceType = ResourceType.RESOURCETYPE_DISK;
        oNetworkResource.sLocalName = sDriveLetter + ":";
        oNetworkResource.sRemoteName = sNetworkPath;
        
        //If Drive is already mapped disconnect the current 
        //mapping before adding the new mapping
        if (IsDriveMapped(sDriveLetter))
        {
            DisconnectNetworkDrive(sDriveLetter, true);
        }

        retVal = WNetAddConnection2(ref oNetworkResource, password, userName, 0);
        if (retVal == 0)
        {
            return true;
        }
        else
        {
            //MessageBox.Show(sNetworkPath);
            
            return false;
        }
    }

    public static int DisconnectNetworkDrive(string sDriveLetter, bool bForceDisconnect)
    {
        if (bForceDisconnect)
        {
            return WNetCancelConnection2(sDriveLetter + ":", 0, 1);
        }
        else
        {
            return WNetCancelConnection2(sDriveLetter + ":", 0, 0);
        }
    }

    public static bool IsDriveMapped(string sDriveLetter)
    {
        string[] DriveList = Environment.GetLogicalDrives();
        for (int i = 0; i < DriveList.Length; i++)
        {
            if (sDriveLetter + ":\\" == DriveList[i].ToString())
            {
                return true;
            }
        }
        return false;
    }
}

public class DirectoryCopyClass
{
    static void DCMain()
    {
        // Copy from the current directory, include subdirectories.
        DirectoryCopy(".", @".\temp", true);
    }

    public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}

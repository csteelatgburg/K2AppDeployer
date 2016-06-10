namespace K2AppDeployer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.K2HostName = new System.Windows.Forms.TextBox();
            this.K2SAMBAPass = new System.Windows.Forms.TextBox();
            this.mapKDrive = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.tasksList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tasksListLabel = new System.Windows.Forms.Label();
            this.POTasksLabel = new System.Windows.Forms.Label();
            this.POTasks = new System.Windows.Forms.ListView();
            this.TaskID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WorkingDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommandLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Parameters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PostTaskAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KACETaskType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Guid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.generateTasksXML = new System.Windows.Forms.Button();
            this.launchKE = new System.Windows.Forms.Button();
            this.config = new System.Windows.Forms.RichTextBox();
            this.Step1 = new System.Windows.Forms.Label();
            this.Step2 = new System.Windows.Forms.Label();
            this.Step3 = new System.Windows.Forms.Label();
            this.Step4 = new System.Windows.Forms.Label();
            this.Step5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "K2 Hostname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "SAMBA Password";
            // 
            // K2HostName
            // 
            this.K2HostName.Location = new System.Drawing.Point(268, 46);
            this.K2HostName.Name = "K2HostName";
            this.K2HostName.Size = new System.Drawing.Size(279, 31);
            this.K2HostName.TabIndex = 2;
            this.K2HostName.TextChanged += new System.EventHandler(this.K2HostName_TextChanged);
            // 
            // K2SAMBAPass
            // 
            this.K2SAMBAPass.Location = new System.Drawing.Point(268, 88);
            this.K2SAMBAPass.Name = "K2SAMBAPass";
            this.K2SAMBAPass.PasswordChar = '*';
            this.K2SAMBAPass.Size = new System.Drawing.Size(279, 31);
            this.K2SAMBAPass.TabIndex = 3;
            // 
            // mapKDrive
            // 
            this.mapKDrive.Enabled = false;
            this.mapKDrive.Location = new System.Drawing.Point(315, 134);
            this.mapKDrive.Name = "mapKDrive";
            this.mapKDrive.Size = new System.Drawing.Size(232, 62);
            this.mapKDrive.TabIndex = 4;
            this.mapKDrive.Text = "Map K: to K2000";
            this.mapKDrive.UseVisualStyleBackColor = true;
            this.mapKDrive.Click += new System.EventHandler(this.mapKDrive_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(817, 378);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(650, 319);
            this.outputBox.TabIndex = 6;
            this.outputBox.Text = "";
            // 
            // tasksList
            // 
            this.tasksList.FormattingEnabled = true;
            this.tasksList.ItemHeight = 25;
            this.tasksList.Location = new System.Drawing.Point(29, 275);
            this.tasksList.Name = "tasksList";
            this.tasksList.Size = new System.Drawing.Size(687, 279);
            this.tasksList.TabIndex = 7;
            this.tasksList.Visible = false;
            this.tasksList.SelectedIndexChanged += new System.EventHandler(this.tasksList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(812, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Log";
            // 
            // tasksListLabel
            // 
            this.tasksListLabel.AutoSize = true;
            this.tasksListLabel.Location = new System.Drawing.Point(24, 247);
            this.tasksListLabel.Name = "tasksListLabel";
            this.tasksListLabel.Size = new System.Drawing.Size(290, 25);
            this.tasksListLabel.TabIndex = 9;
            this.tasksListLabel.Text = "Select a tasks list from below";
            this.tasksListLabel.Visible = false;
            // 
            // POTasksLabel
            // 
            this.POTasksLabel.AutoSize = true;
            this.POTasksLabel.Location = new System.Drawing.Point(37, 610);
            this.POTasksLabel.Name = "POTasksLabel";
            this.POTasksLabel.Size = new System.Drawing.Size(182, 25);
            this.POTasksLabel.TabIndex = 11;
            this.POTasksLabel.Text = "Post-Install Tasks";
            // 
            // POTasks
            // 
            this.POTasks.CheckBoxes = true;
            this.POTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TaskID,
            this.TaskName,
            this.WorkingDirectory,
            this.CommandLine,
            this.Parameters,
            this.PostTaskAction,
            this.KACETaskType,
            this.FileType,
            this.Type,
            this.Guid});
            this.POTasks.Location = new System.Drawing.Point(42, 638);
            this.POTasks.Name = "POTasks";
            this.POTasks.Size = new System.Drawing.Size(674, 727);
            this.POTasks.TabIndex = 12;
            this.POTasks.UseCompatibleStateImageBehavior = false;
            this.POTasks.View = System.Windows.Forms.View.Details;
            // 
            // TaskID
            // 
            this.TaskID.Text = "ID";
            this.TaskID.Width = 75;
            // 
            // TaskName
            // 
            this.TaskName.Text = "Task Name";
            this.TaskName.Width = 250;
            // 
            // WorkingDirectory
            // 
            this.WorkingDirectory.Text = "WorkingDirectory";
            this.WorkingDirectory.Width = 10;
            // 
            // CommandLine
            // 
            this.CommandLine.Text = "CommandLine";
            // 
            // Parameters
            // 
            this.Parameters.Text = "Parameters";
            // 
            // PostTaskAction
            // 
            this.PostTaskAction.Text = "PostTaskAction";
            // 
            // KACETaskType
            // 
            this.KACETaskType.Text = "KACETaskType";
            // 
            // FileType
            // 
            this.FileType.Text = "FileType";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // Guid
            // 
            this.Guid.Text = "Guid";
            // 
            // generateTasksXML
            // 
            this.generateTasksXML.Location = new System.Drawing.Point(876, 46);
            this.generateTasksXML.Name = "generateTasksXML";
            this.generateTasksXML.Size = new System.Drawing.Size(232, 62);
            this.generateTasksXML.TabIndex = 13;
            this.generateTasksXML.Text = "Generate tasks.xml";
            this.generateTasksXML.UseVisualStyleBackColor = true;
            this.generateTasksXML.Click += new System.EventHandler(this.generateTasksXML_Click);
            // 
            // launchKE
            // 
            this.launchKE.Enabled = false;
            this.launchKE.Location = new System.Drawing.Point(876, 203);
            this.launchKE.Name = "launchKE";
            this.launchKE.Size = new System.Drawing.Size(229, 69);
            this.launchKE.TabIndex = 15;
            this.launchKE.Text = "Launch KACE Engine";
            this.launchKE.UseVisualStyleBackColor = true;
            this.launchKE.Click += new System.EventHandler(this.launchKE_Click);
            // 
            // config
            // 
            this.config.Location = new System.Drawing.Point(793, 1081);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(674, 273);
            this.config.TabIndex = 16;
            this.config.Text = resources.GetString("config.Text");
            this.config.Visible = false;
            // 
            // Step1
            // 
            this.Step1.AutoSize = true;
            this.Step1.Location = new System.Drawing.Point(12, 13);
            this.Step1.Name = "Step1";
            this.Step1.Size = new System.Drawing.Size(276, 25);
            this.Step1.TabIndex = 17;
            this.Step1.Text = "Step 1. Map Drive to K2000";
            // 
            // Step2
            // 
            this.Step2.AutoSize = true;
            this.Step2.Location = new System.Drawing.Point(12, 207);
            this.Step2.Name = "Step2";
            this.Step2.Size = new System.Drawing.Size(254, 25);
            this.Step2.TabIndex = 18;
            this.Step2.Text = "Step 2. Select a tasks list";
            // 
            // Step3
            // 
            this.Step3.AutoSize = true;
            this.Step3.Location = new System.Drawing.Point(12, 577);
            this.Step3.Name = "Step3";
            this.Step3.Size = new System.Drawing.Size(542, 25);
            this.Step3.TabIndex = 19;
            this.Step3.Text = "Step 3. Select appropriate tasks from Post-Install Tasks";
            // 
            // Step4
            // 
            this.Step4.AutoSize = true;
            this.Step4.Location = new System.Drawing.Point(812, 13);
            this.Step4.Name = "Step4";
            this.Step4.Size = new System.Drawing.Size(271, 25);
            this.Step4.TabIndex = 20;
            this.Step4.Text = "Step 4. Generate tasks.xml";
            // 
            // Step5
            // 
            this.Step5.AutoSize = true;
            this.Step5.Location = new System.Drawing.Point(812, 153);
            this.Step5.Name = "Step5";
            this.Step5.Size = new System.Drawing.Size(293, 25);
            this.Step5.TabIndex = 21;
            this.Step5.Text = "Step 5. Launch KACE Engine";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 1377);
            this.Controls.Add(this.Step5);
            this.Controls.Add(this.Step4);
            this.Controls.Add(this.Step3);
            this.Controls.Add(this.Step2);
            this.Controls.Add(this.Step1);
            this.Controls.Add(this.config);
            this.Controls.Add(this.launchKE);
            this.Controls.Add(this.generateTasksXML);
            this.Controls.Add(this.POTasks);
            this.Controls.Add(this.POTasksLabel);
            this.Controls.Add(this.tasksListLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tasksList);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.mapKDrive);
            this.Controls.Add(this.K2SAMBAPass);
            this.Controls.Add(this.K2HostName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1544, 1448);
            this.Name = "Form1";
            this.Text = "K2 App Deployer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox K2HostName;
        private System.Windows.Forms.TextBox K2SAMBAPass;
        private System.Windows.Forms.Button mapKDrive;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.ListBox tasksList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tasksListLabel;
        private System.Windows.Forms.Label POTasksLabel;
        private System.Windows.Forms.ListView POTasks;
        private System.Windows.Forms.ColumnHeader TaskID;
        private System.Windows.Forms.ColumnHeader TaskName;
        private System.Windows.Forms.ColumnHeader WorkingDirectory;
        private System.Windows.Forms.Button generateTasksXML;
        private System.Windows.Forms.ColumnHeader CommandLine;
        private System.Windows.Forms.ColumnHeader Parameters;
        private System.Windows.Forms.ColumnHeader PostTaskAction;
        private System.Windows.Forms.ColumnHeader KACETaskType;
        private System.Windows.Forms.ColumnHeader FileType;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Guid;
        private System.Windows.Forms.Button launchKE;
        private System.Windows.Forms.RichTextBox config;
        private System.Windows.Forms.Label Step1;
        private System.Windows.Forms.Label Step2;
        private System.Windows.Forms.Label Step3;
        private System.Windows.Forms.Label Step4;
        private System.Windows.Forms.Label Step5;
    }
}


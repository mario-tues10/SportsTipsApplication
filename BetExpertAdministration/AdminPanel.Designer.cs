namespace BetExpertAdministration
{
    partial class AdminPanel
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
            this.loggedUser = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.deleteTipster = new System.Windows.Forms.Button();
            this.resumeTipster = new System.Windows.Forms.Button();
            this.suspendTipster = new System.Windows.Forms.Button();
            this.allTipsters = new System.Windows.Forms.Button();
            this.Tipsters = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deleteMatch = new System.Windows.Forms.Button();
            this.Matches = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.allMatches = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.assignCompetition = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.secondCompetitor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.createMatch = new System.Windows.Forms.Button();
            this.firstCompetitor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deleteCompetition = new System.Windows.Forms.Button();
            this.allCompetitions = new System.Windows.Forms.Button();
            this.competition = new System.Windows.Forms.GroupBox();
            this.createCompetition = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.sport = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Competitions = new System.Windows.Forms.ListView();
            this.columnID = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnSport = new System.Windows.Forms.ColumnHeader();
            this.columnStart = new System.Windows.Forms.ColumnHeader();
            this.columnEnd = new System.Windows.Forms.ColumnHeader();
            this.Administration = new System.Windows.Forms.TabControl();
            this.Profile = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.competition.SuspendLayout();
            this.Administration.SuspendLayout();
            this.SuspendLayout();
            // 
            // loggedUser
            // 
            this.loggedUser.AutoSize = true;
            this.loggedUser.Location = new System.Drawing.Point(16, 20);
            this.loggedUser.Name = "loggedUser";
            this.loggedUser.Size = new System.Drawing.Size(0, 20);
            this.loggedUser.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.deleteTipster);
            this.tabPage3.Controls.Add(this.resumeTipster);
            this.tabPage3.Controls.Add(this.suspendTipster);
            this.tabPage3.Controls.Add(this.allTipsters);
            this.tabPage3.Controls.Add(this.Tipsters);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(940, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tipster";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // deleteTipster
            // 
            this.deleteTipster.Location = new System.Drawing.Point(576, 318);
            this.deleteTipster.Name = "deleteTipster";
            this.deleteTipster.Size = new System.Drawing.Size(307, 71);
            this.deleteTipster.TabIndex = 5;
            this.deleteTipster.Text = "Delete tipster account";
            this.deleteTipster.UseVisualStyleBackColor = true;
            this.deleteTipster.Click += new System.EventHandler(this.deleteTipster_Click);
            // 
            // resumeTipster
            // 
            this.resumeTipster.Location = new System.Drawing.Point(576, 216);
            this.resumeTipster.Name = "resumeTipster";
            this.resumeTipster.Size = new System.Drawing.Size(307, 72);
            this.resumeTipster.TabIndex = 4;
            this.resumeTipster.Text = "Resume tipster";
            this.resumeTipster.UseVisualStyleBackColor = true;
            this.resumeTipster.Click += new System.EventHandler(this.resumeTipster_Click);
            // 
            // suspendTipster
            // 
            this.suspendTipster.Location = new System.Drawing.Point(576, 127);
            this.suspendTipster.Name = "suspendTipster";
            this.suspendTipster.Size = new System.Drawing.Size(307, 66);
            this.suspendTipster.TabIndex = 3;
            this.suspendTipster.Text = "Suspend tipster";
            this.suspendTipster.UseVisualStyleBackColor = true;
            this.suspendTipster.Click += new System.EventHandler(this.suspendTipster_Click);
            // 
            // allTipsters
            // 
            this.allTipsters.Location = new System.Drawing.Point(576, 23);
            this.allTipsters.Name = "allTipsters";
            this.allTipsters.Size = new System.Drawing.Size(307, 74);
            this.allTipsters.TabIndex = 2;
            this.allTipsters.Text = "All tipsters";
            this.allTipsters.UseVisualStyleBackColor = true;
            this.allTipsters.Click += new System.EventHandler(this.allTipsters_Click);
            // 
            // Tipsters
            // 
            this.Tipsters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.Tipsters.FullRowSelect = true;
            this.Tipsters.Location = new System.Drawing.Point(20, 23);
            this.Tipsters.Name = "Tipsters";
            this.Tipsters.Size = new System.Drawing.Size(512, 366);
            this.Tipsters.TabIndex = 1;
            this.Tipsters.UseCompatibleStateImageBehavior = false;
            this.Tipsters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 43;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Success rate";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 130;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Last prediction days";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 160;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Suspended";
            this.columnHeader10.Width = 100;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deleteMatch);
            this.tabPage2.Controls.Add(this.Matches);
            this.tabPage2.Controls.Add(this.allMatches);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(940, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Match";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // deleteMatch
            // 
            this.deleteMatch.Location = new System.Drawing.Point(535, 342);
            this.deleteMatch.Name = "deleteMatch";
            this.deleteMatch.Size = new System.Drawing.Size(390, 41);
            this.deleteMatch.TabIndex = 7;
            this.deleteMatch.Text = "Delete match";
            this.deleteMatch.UseVisualStyleBackColor = true;
            this.deleteMatch.Click += new System.EventHandler(this.deleteMatch_Click);
            // 
            // Matches
            // 
            this.Matches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.Matches.FullRowSelect = true;
            this.Matches.Location = new System.Drawing.Point(17, 17);
            this.Matches.Name = "Matches";
            this.Matches.Size = new System.Drawing.Size(512, 366);
            this.Matches.TabIndex = 4;
            this.Matches.UseCompatibleStateImageBehavior = false;
            this.Matches.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First competitor";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Second Competitor";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 135;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Start time";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Competition id";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 115;
            // 
            // allMatches
            // 
            this.allMatches.Location = new System.Drawing.Point(535, 300);
            this.allMatches.Name = "allMatches";
            this.allMatches.Size = new System.Drawing.Size(390, 36);
            this.allMatches.TabIndex = 6;
            this.allMatches.Text = "All matches";
            this.allMatches.UseVisualStyleBackColor = true;
            this.allMatches.Click += new System.EventHandler(this.allMatches_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.assignCompetition);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.secondCompetitor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.createMatch);
            this.groupBox1.Controls.Add(this.firstCompetitor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(535, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 277);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create match";
            // 
            // startTime
            // 
            this.startTime.Location = new System.Drawing.Point(128, 113);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(250, 27);
            this.startTime.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Start time: ";
            // 
            // assignCompetition
            // 
            this.assignCompetition.FormattingEnabled = true;
            this.assignCompetition.Location = new System.Drawing.Point(161, 154);
            this.assignCompetition.Name = "assignCompetition";
            this.assignCompetition.Size = new System.Drawing.Size(217, 28);
            this.assignCompetition.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Competition: ";
            // 
            // secondCompetitor
            // 
            this.secondCompetitor.Location = new System.Drawing.Point(161, 70);
            this.secondCompetitor.Name = "secondCompetitor";
            this.secondCompetitor.Size = new System.Drawing.Size(217, 27);
            this.secondCompetitor.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Second competitor: ";
            // 
            // createMatch
            // 
            this.createMatch.Location = new System.Drawing.Point(15, 209);
            this.createMatch.Name = "createMatch";
            this.createMatch.Size = new System.Drawing.Size(363, 45);
            this.createMatch.TabIndex = 10;
            this.createMatch.Text = "Create match";
            this.createMatch.UseVisualStyleBackColor = true;
            this.createMatch.Click += new System.EventHandler(this.createMatch_Click);
            // 
            // firstCompetitor
            // 
            this.firstCompetitor.Location = new System.Drawing.Point(161, 31);
            this.firstCompetitor.Name = "firstCompetitor";
            this.firstCompetitor.Size = new System.Drawing.Size(217, 27);
            this.firstCompetitor.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "First competitor: ";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deleteCompetition);
            this.tabPage1.Controls.Add(this.allCompetitions);
            this.tabPage1.Controls.Add(this.competition);
            this.tabPage1.Controls.Add(this.Competitions);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(940, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Competition";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deleteCompetition
            // 
            this.deleteCompetition.Location = new System.Drawing.Point(535, 333);
            this.deleteCompetition.Name = "deleteCompetition";
            this.deleteCompetition.Size = new System.Drawing.Size(384, 40);
            this.deleteCompetition.TabIndex = 3;
            this.deleteCompetition.Text = "Delete competition";
            this.deleteCompetition.UseVisualStyleBackColor = true;
            this.deleteCompetition.Click += new System.EventHandler(this.deleteCompetition_Click);
            // 
            // allCompetitions
            // 
            this.allCompetitions.Location = new System.Drawing.Point(535, 290);
            this.allCompetitions.Name = "allCompetitions";
            this.allCompetitions.Size = new System.Drawing.Size(384, 37);
            this.allCompetitions.TabIndex = 2;
            this.allCompetitions.Text = "All competitions";
            this.allCompetitions.UseVisualStyleBackColor = true;
            this.allCompetitions.Click += new System.EventHandler(this.allCompetitions_Click);
            // 
            // competition
            // 
            this.competition.Controls.Add(this.createCompetition);
            this.competition.Controls.Add(this.endDate);
            this.competition.Controls.Add(this.label4);
            this.competition.Controls.Add(this.startDate);
            this.competition.Controls.Add(this.sport);
            this.competition.Controls.Add(this.name);
            this.competition.Controls.Add(this.label3);
            this.competition.Controls.Add(this.label2);
            this.competition.Controls.Add(this.label1);
            this.competition.Location = new System.Drawing.Point(535, 16);
            this.competition.Name = "competition";
            this.competition.Size = new System.Drawing.Size(384, 268);
            this.competition.TabIndex = 1;
            this.competition.TabStop = false;
            this.competition.Text = "Create competition";
            // 
            // createCompetition
            // 
            this.createCompetition.Location = new System.Drawing.Point(15, 207);
            this.createCompetition.Name = "createCompetition";
            this.createCompetition.Size = new System.Drawing.Size(350, 49);
            this.createCompetition.TabIndex = 10;
            this.createCompetition.Text = "Create competition";
            this.createCompetition.UseVisualStyleBackColor = true;
            this.createCompetition.Click += new System.EventHandler(this.createCompetition_Click);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(103, 164);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(262, 27);
            this.endDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "End date: ";
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(103, 127);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(262, 27);
            this.startDate.TabIndex = 7;
            // 
            // sport
            // 
            this.sport.FormattingEnabled = true;
            this.sport.Items.AddRange(new object[] {
            "Football",
            "Basketball",
            "Tennis"});
            this.sport.Location = new System.Drawing.Point(103, 86);
            this.sport.Name = "sport";
            this.sport.Size = new System.Drawing.Size(262, 28);
            this.sport.TabIndex = 6;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(103, 46);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(262, 27);
            this.name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start date: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sport: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // Competitions
            // 
            this.Competitions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnName,
            this.columnSport,
            this.columnStart,
            this.columnEnd});
            this.Competitions.FullRowSelect = true;
            this.Competitions.Location = new System.Drawing.Point(17, 16);
            this.Competitions.Name = "Competitions";
            this.Competitions.Size = new System.Drawing.Size(512, 366);
            this.Competitions.TabIndex = 0;
            this.Competitions.UseCompatibleStateImageBehavior = false;
            this.Competitions.View = System.Windows.Forms.View.Details;
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.Width = 130;
            // 
            // columnSport
            // 
            this.columnSport.Text = "Sport";
            this.columnSport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSport.Width = 93;
            // 
            // columnStart
            // 
            this.columnStart.Text = "Start date";
            this.columnStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStart.Width = 113;
            // 
            // columnEnd
            // 
            this.columnEnd.Text = "End date";
            this.columnEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnEnd.Width = 113;
            // 
            // Administration
            // 
            this.Administration.Controls.Add(this.tabPage1);
            this.Administration.Controls.Add(this.tabPage2);
            this.Administration.Controls.Add(this.tabPage3);
            this.Administration.Location = new System.Drawing.Point(12, 58);
            this.Administration.Name = "Administration";
            this.Administration.SelectedIndex = 0;
            this.Administration.Size = new System.Drawing.Size(948, 454);
            this.Administration.TabIndex = 0;
            // 
            // Profile
            // 
            this.Profile.Location = new System.Drawing.Point(620, 12);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(154, 57);
            this.Profile.TabIndex = 2;
            this.Profile.Text = "Profile";
            this.Profile.UseVisualStyleBackColor = true;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(802, 12);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(154, 57);
            this.logOut.TabIndex = 3;
            this.logOut.Text = "Log out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 524);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.loggedUser);
            this.Controls.Add(this.Administration);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.competition.ResumeLayout(false);
            this.competition.PerformLayout();
            this.Administration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label loggedUser;
        private TabPage tabPage3;
        private Button deleteTipster;
        private Button resumeTipster;
        private Button suspendTipster;
        private Button allTipsters;
        private ListView Tipsters;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private TabPage tabPage2;
        private Button deleteMatch;
        private ListView Matches;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button allMatches;
        private GroupBox groupBox1;
        private DateTimePicker startTime;
        private Label label5;
        private ComboBox assignCompetition;
        private Label label9;
        private TextBox secondCompetitor;
        private Label label6;
        private Button createMatch;
        private TextBox firstCompetitor;
        private Label label8;
        private TabPage tabPage1;
        private Button deleteCompetition;
        private Button allCompetitions;
        private GroupBox competition;
        private Button createCompetition;
        private DateTimePicker endDate;
        private Label label4;
        private DateTimePicker startDate;
        private ComboBox sport;
        private TextBox name;
        private Label label3;
        private Label label2;
        private Label label1;
        private ListView Competitions;
        private ColumnHeader columnID;
        private ColumnHeader columnName;
        private ColumnHeader columnSport;
        private ColumnHeader columnStart;
        private ColumnHeader columnEnd;
        private TabControl Administration;
        private Button Profile;
        private Button logOut;
    }
}
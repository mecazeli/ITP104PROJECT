namespace ITP104PROJECT
{
    partial class Dashboard
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
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnProjects = new System.Windows.Forms.Button();
            this.lblDepartments = new System.Windows.Forms.Label();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblProjects = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnSideDep = new System.Windows.Forms.Button();
            this.btnSideEmp = new System.Windows.Forms.Button();
            this.btnSideProj = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSideBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.panelSideBar.Controls.Add(this.btnLogout);
            this.panelSideBar.Controls.Add(this.btnSettings);
            this.panelSideBar.Controls.Add(this.btnSideProj);
            this.panelSideBar.Controls.Add(this.btnSideEmp);
            this.panelSideBar.Controls.Add(this.btnSideDep);
            this.panelSideBar.Controls.Add(this.btnDashboard);
            this.panelSideBar.Controls.Add(this.lblAdmin);
            this.panelSideBar.Controls.Add(this.pictureBox1);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(267, 726);
            this.panelSideBar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(223)))));
            this.panel1.Controls.Add(this.lblProjects);
            this.panel1.Controls.Add(this.lblEmployees);
            this.panel1.Controls.Add(this.lblDepartments);
            this.panel1.Controls.Add(this.btnProjects);
            this.panel1.Controls.Add(this.btnEmployees);
            this.panel1.Controls.Add(this.btnDepartments);
            this.panel1.Controls.Add(this.lblDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(267, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 726);
            this.panel1.TabIndex = 1;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(83, 39);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(262, 44);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "DASHBOARD";
            // 
            // btnDepartments
            // 
            this.btnDepartments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnDepartments.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDepartments.FlatAppearance.BorderSize = 5;
            this.btnDepartments.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartments.Location = new System.Drawing.Point(91, 163);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(210, 190);
            this.btnDepartments.TabIndex = 1;
            this.btnDepartments.UseVisualStyleBackColor = false;
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnEmployees.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEmployees.FlatAppearance.BorderSize = 5;
            this.btnEmployees.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Location = new System.Drawing.Point(350, 163);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(210, 190);
            this.btnEmployees.TabIndex = 2;
            this.btnEmployees.UseVisualStyleBackColor = false;
            // 
            // btnProjects
            // 
            this.btnProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnProjects.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProjects.FlatAppearance.BorderSize = 5;
            this.btnProjects.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjects.Location = new System.Drawing.Point(607, 163);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(210, 190);
            this.btnProjects.TabIndex = 3;
            this.btnProjects.UseVisualStyleBackColor = false;
            // 
            // lblDepartments
            // 
            this.lblDepartments.AutoSize = true;
            this.lblDepartments.Font = new System.Drawing.Font("Arial Narrow", 15.8F, System.Drawing.FontStyle.Bold);
            this.lblDepartments.Location = new System.Drawing.Point(123, 375);
            this.lblDepartments.Name = "lblDepartments";
            this.lblDepartments.Size = new System.Drawing.Size(149, 31);
            this.lblDepartments.TabIndex = 4;
            this.lblDepartments.Text = "Departments";
            // 
            // lblEmployees
            // 
            this.lblEmployees.AutoSize = true;
            this.lblEmployees.Font = new System.Drawing.Font("Arial Narrow", 15.8F, System.Drawing.FontStyle.Bold);
            this.lblEmployees.Location = new System.Drawing.Point(392, 375);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(131, 31);
            this.lblEmployees.TabIndex = 5;
            this.lblEmployees.Text = "Employees";
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.Font = new System.Drawing.Font("Arial Narrow", 15.8F, System.Drawing.FontStyle.Bold);
            this.lblProjects.Location = new System.Drawing.Point(663, 375);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(101, 31);
            this.lblProjects.TabIndex = 6;
            this.lblProjects.Text = "Projects";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(62, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 127);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.ForeColor = System.Drawing.Color.White;
            this.lblAdmin.Location = new System.Drawing.Point(42, 192);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(180, 23);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = "Admin Jessa Cariñaga";
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 278);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(267, 52);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // btnSideDep
            // 
            this.btnSideDep.FlatAppearance.BorderSize = 0;
            this.btnSideDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideDep.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSideDep.ForeColor = System.Drawing.Color.White;
            this.btnSideDep.Location = new System.Drawing.Point(3, 336);
            this.btnSideDep.Name = "btnSideDep";
            this.btnSideDep.Size = new System.Drawing.Size(267, 52);
            this.btnSideDep.TabIndex = 3;
            this.btnSideDep.Text = "Departments";
            this.btnSideDep.UseVisualStyleBackColor = true;
            // 
            // btnSideEmp
            // 
            this.btnSideEmp.FlatAppearance.BorderSize = 0;
            this.btnSideEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideEmp.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSideEmp.ForeColor = System.Drawing.Color.White;
            this.btnSideEmp.Location = new System.Drawing.Point(0, 394);
            this.btnSideEmp.Name = "btnSideEmp";
            this.btnSideEmp.Size = new System.Drawing.Size(267, 52);
            this.btnSideEmp.TabIndex = 4;
            this.btnSideEmp.Text = "Employees";
            this.btnSideEmp.UseVisualStyleBackColor = true;
            // 
            // btnSideProj
            // 
            this.btnSideProj.FlatAppearance.BorderSize = 0;
            this.btnSideProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideProj.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSideProj.ForeColor = System.Drawing.Color.White;
            this.btnSideProj.Location = new System.Drawing.Point(0, 452);
            this.btnSideProj.Name = "btnSideProj";
            this.btnSideProj.Size = new System.Drawing.Size(267, 52);
            this.btnSideProj.TabIndex = 5;
            this.btnSideProj.Text = "Projects";
            this.btnSideProj.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 510);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(267, 52);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 568);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(267, 52);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 726);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSideBar);
            this.Name = "Dashboard";
            this.Text = "Connect";
            this.panelSideBar.ResumeLayout(false);
            this.panelSideBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnProjects;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Label lblProjects;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Label lblDepartments;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSideProj;
        private System.Windows.Forms.Button btnSideEmp;
        private System.Windows.Forms.Button btnSideDep;
    }
}
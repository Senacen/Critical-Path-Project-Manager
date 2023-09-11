﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    public partial class LoadProjectForm : Form
    {
        private string username;
        public LoadProjectForm(string username)
        {
            InitializeComponent();
            this.username = username;
            foreach (string projectName in DatabaseFunctions.projectNamesList(username))
            {
                ProjectListBox.Items.Add(projectName);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string projectName = ProjectListBox.Text;
            if (projectName == "") return;
            EditProjectForm editProjectForm = new EditProjectForm(projectName, username);
            editProjectForm.Show();
            this.Close();
        }

        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

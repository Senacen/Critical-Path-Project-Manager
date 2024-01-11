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
    public partial class ProjectTrackerForm : Form
    {
        private string projectName, username;

      
        public ProjectTrackerForm(string projectName, string username)
        {
            InitializeComponent();

            // Display the username and project name at the top of the window
            this.projectName = projectName;
            this.username = username;
            this.Text += " - " + projectName + " - " + username;

            CompletedDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IncompleteDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AvailableDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CompletedDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            IncompleteDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AvailableDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            updateAllDataGrids();
        }

        private void updateAllDataGrids()
        {
            updateCompletedDataGrid();
            updateAvailableDataGrid();
            updateIncompleteDataGrid();
            
        }

        private void updateCompletedDataGrid()
        {
            CompletedDataGrid.DataSource = DatabaseFunctions.completedTasks(projectName);
        }

        private void updateIncompleteDataGrid()
        {
            IncompleteDataGrid.DataSource = DatabaseFunctions.incompleteTasks(projectName);
        }

        private void updateAvailableDataGrid()
        {
            AvailableDataGrid.DataSource = DatabaseFunctions.availableTasks(projectName);
        }
        private void BackToCPAFormButton_Click(object sender, EventArgs e)
        {
            CPAForm cpaForm = new CPAForm(projectName, username);
            cpaForm.Show();
            this.Close();
        }

        private void MarkCompletedButton_Click(object sender, EventArgs e)
        {
            if (AvailableDataGrid.SelectedRows.Count != 1) return;
            DataGridViewRow selectedTask = AvailableDataGrid.SelectedRows[0];
            string taskName = selectedTask.Cells["Name"].Value.ToString();
            DatabaseFunctions.markTaskCompleted(projectName, taskName);
            updateAllDataGrids();
        }

        private void MarkIncompleteButton_Click(object sender, EventArgs e)
        {
            if (CompletedDataGrid.SelectedRows.Count != 1) return;
            DataGridViewRow selectedTask = CompletedDataGrid.SelectedRows[0];
            string taskName = selectedTask.Cells["Name"].Value.ToString();
            DatabaseFunctions.markTaskIncomplete(projectName, taskName);
            updateAllDataGrids();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

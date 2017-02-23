using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace LargeHistNoteActivFixer
{
    public partial class MainWindow : Window
    {
        private DataTable databaseTable = new DataTable();
        private DataTable activitiesTable = new DataTable();
        private DataTable notesTable = new DataTable();
        private DataTable historiesTable = new DataTable();
        private TimeZone localTime = TimeZone.CurrentTimeZone;
        private DateTime currentTime = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();
            loadDatabases();
            About aboutWindow = new About();
            aboutWindow.ShowDialog();

            // Check if the current time zone is daylight saving or not, then display the current time zone
            if (localTime.IsDaylightSavingTime(currentTime))
            {
                timeZoneLabel.Content = "Showing results in " + localTime.DaylightName;
            }
            else
            {
                timeZoneLabel.Content = "Showing results in " + localTime.StandardName;
            }
        }

        private void loadDatabases()
        {            
            try
            {
                // Clear the Databases DataTable
                databaseTable.Clear();

                // Connect to ACT7 instance
                string connectionString = @"Data Source=(local); Initial Catalog=master; Server=(local)\ACT7; Integrated Security=True;";
                SqlConnection dataConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("select name from sys.databases where name != 'master' and name != 'model' and name != 'msdb' and name != 'tempdb' and name != 'ActEmailMessageStore'", dataConnection);
                dataConnection.Open();
    
                // Create data adaptor and populate database list
                SqlDataAdapter dataAdaptor = new SqlDataAdapter(command);
                dataAdaptor.Fill(databaseTable);
    
                // Close the connection and get rid of the data adaptor
                dataConnection.Close();
                dataAdaptor.Dispose();

                List<string> databases = new List<string>();

                foreach (DataRow dr in databaseTable.Rows)
                {
                    databases.Add(dr["name"].ToString());
                }

                databases.Sort();
                databaseNameList.ItemsSource = databases;

                // Update status to Ready
                label_Status.Content = "Status: Ready";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            loadDatabases();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            label_Status.Content = "Status: Working...";

            if (loadActivities() & loadNotes() & loadHistories())
            {
                label_Status.Content = "Status: Completed successfully";
            }
            else label_Status.Content = "Status: Completed with errors";

            label_ActivitiesCount.Content = activitiesTable.Rows.Count.ToString();
            label_NotesCount.Content = notesTable.Rows.Count.ToString();
            label_HistoriesCount.Content = historiesTable.Rows.Count.ToString();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }

        private bool loadActivities()
        {
            if (databaseNameList.SelectedIndex != -1)
            {
                try
                {
                    // Clear the DataTable
                    activitiesTable.Clear();

                    // Connect to ACT7 instance
                    string connectionString = @"Data Source=(local); Initial Catalog=" + databaseNameList.SelectedItem.ToString() + @"; Server=(local)\ACT7; Integrated Security=True;";
                    SqlConnection dataConnection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("select tbl_contact.fullname as 'Contact Name', tbl_contact.COMPANYNAME as 'Company', tbl_activity.starttime as 'Start Time', tbl_activity.createdate as 'Create Date', tbl_activity.regarding as 'Regarding', tbl_activity.ACTIVITYID as 'Activity GUID' from tbl_activity left join tbl_contact_activity on tbl_contact_activity.ACTIVITYID = TBL_ACTIVITY.ACTIVITYID left join TBL_CONTACT on TBL_CONTACT.CONTACTID = TBL_CONTACT_ACTIVITY.CONTACTID where DATALENGTH(tbl_activity.regarding) + DATALENGTH(tbl_activity.details) >= 2000000 order by STARTTIME", dataConnection);
                    dataConnection.Open();

                    // Create data adaptor and populate database list
                    SqlDataAdapter dataAdaptor = new SqlDataAdapter(command);
                    dataAdaptor.Fill(activitiesTable);

                    // Close the connection and get rid of the data adaptor
                    dataConnection.Close();
                    dataAdaptor.Dispose();

                    //Convert all DateTimes in the grid from UTC to the local time zone
                    for (int i = 0; i < activitiesTable.Rows.Count; i++)
                    {
                        string startTimeString = activitiesTable.Rows[i]["Start Time"].ToString();
                        string createDateString = activitiesTable.Rows[i]["Create Date"].ToString();
                        DateTime startTime = Convert.ToDateTime(startTimeString);
                        DateTime createDate = Convert.ToDateTime(createDateString);
                        activitiesTable.Rows[i]["Start Time"] = localTime.ToLocalTime(startTime);
                        activitiesTable.Rows[i]["Create Date"] = localTime.ToLocalTime(createDate);
                    }

                    // Throw the DataTable at the UI to be displayed
                    activitiesDataGrid.ItemsSource = activitiesTable.DefaultView;

                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);

                    return false;
                }
            }
            else
            {
                MessageBox.Show("No database selected.");

                return false;
            }
        }

        private bool loadNotes()
        {
            if (databaseNameList.SelectedIndex != -1)
            {
                try
                {
                    // Clear the DataTable
                    notesTable.Clear();

                    // Connect to ACT7 instance
                    string connectionString = @"Data Source=(local); Initial Catalog=" + databaseNameList.SelectedItem.ToString() + @"; Server=(local)\ACT7; Integrated Security=True;";
                    SqlConnection dataConnection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("select tbl_contact.fullname as 'Contact Name', tbl_contact.COMPANYNAME as 'Company', tbl_note.createdate as 'Create Date', tbl_note.NOTEID as 'Note GUID' from tbl_note left join tbl_contact_note on tbl_contact_note.NOTEID = TBL_NOTE.NOTEID left join TBL_CONTACT on TBL_CONTACT.CONTACTID = TBL_CONTACT_NOTE.CONTACTID where DATALENGTH(tbl_note.notetext) >= 2000000 order by fullname", dataConnection);
                    dataConnection.Open();

                    // Create data adaptor and populate database list
                    SqlDataAdapter dataAdaptor = new SqlDataAdapter(command);
                    dataAdaptor.Fill(notesTable);

                    // Close the connection and get rid of the data adaptor
                    dataConnection.Close();
                    dataAdaptor.Dispose();

                    //Convert all DateTimes in the grid from UTC to the local time zone
                    for (int i = 0; i < notesTable.Rows.Count; i++)
                    {
                        string dateTimeString = notesTable.Rows[i]["Create Date"].ToString();
                        DateTime dateTime = Convert.ToDateTime(dateTimeString);
                        notesTable.Rows[i]["Create Date"] = localTime.ToLocalTime(dateTime);
                    }

                    // Throw the DataTable at the UI to be displayed
                    notesDataGrid.ItemsSource = notesTable.DefaultView;

                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);

                    return false;
                }
            }
            else
            {
                MessageBox.Show("No database selected.");

                return false;
            }
        }

        private bool loadHistories()
        {
            if (databaseNameList.SelectedIndex != -1)
            {
                try
                {
                    // Clear the DataTable
                    historiesTable.Clear();

                    // Connect to ACT7 instance
                    string connectionString = @"Data Source=(local); Initial Catalog=" + databaseNameList.SelectedItem.ToString() + @"; Server=(local)\ACT7; Integrated Security=True;";
                    SqlConnection dataConnection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("select tbl_contact.fullname as 'Contact Name', tbl_contact.COMPANYNAME as 'Company', tbl_history.starttime as 'Start Time', tbl_history.createdate as 'Create Date', tbl_history.regarding as 'Regarding', tbl_history.HISTORYID as 'History GUID' from tbl_history left join tbl_contact_history on tbl_contact_history.HISTORYID = TBL_HISTORY.HISTORYID left join TBL_CONTACT on TBL_CONTACT.CONTACTID = TBL_CONTACT_HISTORY.CONTACTID where DATALENGTH(tbl_history.regarding) + DATALENGTH(tbl_history.details) >= 2000000 order by starttime", dataConnection);
                    dataConnection.Open();

                    // Create data adaptor and populate database list
                    SqlDataAdapter dataAdaptor = new SqlDataAdapter(command);
                    dataAdaptor.Fill(historiesTable);

                    // Close the connection and get rid of the data adaptor
                    dataConnection.Close();
                    dataAdaptor.Dispose();

                    //Convert all DateTimes in the grid from UTC to the local time zone
                    for (int i = 0; i < activitiesTable.Rows.Count; i++)
                    {
                        string startTimeString = historiesTable.Rows[i]["Start Time"].ToString();
                        string createDateString = historiesTable.Rows[i]["Create Date"].ToString();
                        DateTime startTime = Convert.ToDateTime(startTimeString);
                        DateTime createDate = Convert.ToDateTime(createDateString);
                        historiesTable.Rows[i]["Start Time"] = localTime.ToLocalTime(startTime);
                        historiesTable.Rows[i]["Create Date"] = localTime.ToLocalTime(createDate);
                    }

                    // Throw the DataTable at the UI to be displayed
                    historiesDataGrid.ItemsSource = historiesTable.DefaultView;

                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);

                    return false;
                }
            }
            else
            {
                MessageBox.Show("No database selected.");

                return false;
            }
        }
    }
}

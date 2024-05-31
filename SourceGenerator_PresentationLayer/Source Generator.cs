using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceGenerator_Core;
using SourceGenerator_Core.Business_Gen;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SourceGenerator_PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //setting the default value to the column type combo box 
            cbColumnType.SelectedIndex = 0;
        }

        clsMainComponents _MainComponents = new clsMainComponents();


        /// <summary>
        /// this function gets the number of PK in the main class "_MainComponents"
        /// </summary>
        /// <returns></returns>
        int GetPrimaryKeysCount()
        {
            int PK_Count = 0;
     
            foreach(DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (row.Cells[2].Value != null && (bool)row.Cells[2].Value == true)
                {
                    PK_Count++;
                }
            };


            return PK_Count;
        }

        bool ValidatePK()
        {

            int PK_Count = GetPrimaryKeysCount();

            if (PK_Count < 1)
            {
                MessageBox.Show("Please choose a primary key", "", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (PK_Count > 1)
            {
                MessageBox.Show("You can only choose one primary key", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;


        }

        /// <summary>
        /// this function validates the rows values if null or empty 
        /// </summary>
        /// <returns>
        /// true if the rows are valide. False if the rows are not valid
        /// </returns>
        bool ValidateDGVRows()
        {
            foreach (DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (row.Cells[0].Value != null && (string)row.Cells[0].Value != string.Empty && 
                    row.Cells[1].Value != null && (string)row.Cells[1].Value != string.Empty)
                {

                    //checking to make sure that a search by column cant be nullable
                    if (row.Cells[3].Value != null && row.Cells[4].Value != null &&
                    (bool)row.Cells[4].Value == true && (bool)row.Cells[3].Value == true)
                    {
                        MessageBox.Show("Column can not be nullable and can be searched by", "ERROR",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                else
                    return true;

                
            };

            MessageBox.Show("Please choose a valid column value", "ERROR",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        //columns functions
        bool ValidateColumnTextInput()
        {
            return

                clsGlobal.ValidateTxtBox(txtColumnName, string.Empty,
                "this field can't be empty", errorProvider1) && 
                cbColumnType.SelectedIndex != -1;
        }

        void AddColumnToDataGridView()
        {
            object[] rowInfo = new object[] {cbColumnType.SelectedItem.ToString(),
            txtColumnName.Text, cbIsPK.Checked, cbIsColumnNullable.Checked, cbSearchBy.Checked};

            dgvTableColumns.Rows.Add(rowInfo);
        }

        /// <summary>
        /// this functions adds all of the rows in the data grid view to the main class "_MainComponents"
        /// </summary>
        void AddParamertsFromDGVToMainComponentsClass()
        {
            foreach (DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    //init the value because the default val for a cell is null 
                    bool PK = false;
                    if (row.Cells[2].Value != null)               
                        PK = (bool)row.Cells[2].Value;
                    

                    bool Nullable = false;
                    if (row.Cells[3].Value != null)
                        Nullable = (bool)row.Cells[3].Value;

                    bool SearchBy = false;
                    if (row.Cells[4].Value != null)
                        SearchBy = (bool)row.Cells[4].Value;

                    string Name = "";
                    if (row.Cells[1].Value != null)
                        Name = (string)row.Cells[1].Value;

                    //making sure that each PK could by searched by
                    if (PK) SearchBy = true;

                    _MainComponents.AddParamerter(row.Cells[0].Value.ToString(),
                    Name, SearchBy, PK, Nullable);
                }
                
            }
        }

        void AddClassInfoFromFormToMainComponentsClass()
        {
            _MainComponents.ConnectionString = clsGlobal.CreateConnectionString(txtDatabaseName.Text.Trim(), 
                txtUserName.Text.Trim(), txtPassword.Text.Trim());
            _MainComponents.NameSpace = txtDataAccessNameSpace.Text.Trim();
            _MainComponents.ClassName = txtDataAccessClassName.Text.Trim();
            _MainComponents.TableName = txtTableName.Text.Trim();
        }

        bool ValidateMainComponents()
        {
            return
                 clsGlobal.ValidateTxtBox(txtDatabaseName, string.Empty,
                "this field can't be empty", errorProvider1) &&

                clsGlobal.ValidateTxtBox(txtUserName, string.Empty,
                "this field can't be empty", errorProvider1) &&

                clsGlobal.ValidateTxtBox(txtPassword, string.Empty,
                "this field can't be empty", errorProvider1) &&

                clsGlobal.ValidateTxtBox(txtTableName, string.Empty,
                "this field can't be empty", errorProvider1) &&

                clsGlobal.ValidateTxtBox(txtDataAccessNameSpace, string.Empty,
                "this field can't be empty", errorProvider1) &&

                clsGlobal.ValidateTxtBox(txtBuisnessClassName,
                string.IsNullOrEmpty(txtBuisnessClassName.Text)
                && cbGenBusinessLayer.Checked,
                "this field can't be empty", errorProvider1) &&

                clsGlobal.ValidateTxtBox(txtDataAccessClassName, string.Empty,
                "this field can't be empty", errorProvider1) && ValidateDGVRows() && ValidatePK();

        }

       



        private void btnGenerate_Click(object sender, EventArgs e)
        {
           
            if (ValidateMainComponents())
            {
                AddParamertsFromDGVToMainComponentsClass();
                AddClassInfoFromFormToMainComponentsClass();
                txtDataAccessLayer.Text = "";
                txtDataAccessLayer.Text = SourceGenerator_Core.DataAccessGen.Generate(this._MainComponents);

                if (cbGenBusinessLayer.Checked)
                {
                    _MainComponents.NameSpace = txtBusinessNameSpace.Text.Trim();
                    _MainComponents.ClassName = txtBuisnessClassName.Text.Trim();

                    txtBusinessLayer.Text = clsBusinessLayerGen.Generate(
                       this._MainComponents, txtDataAccessClassName.Text.Trim(),
                       txtDataAccessNameSpace.Text.Trim());
                }
                   


                this._MainComponents = new clsMainComponents();
               
            }

        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (ValidateColumnTextInput())
            {
                AddColumnToDataGridView();

                //resetting the text boxes
                txtColumnName.Text = string.Empty;
                cbIsPK.Checked = false;
                cbIsColumnNullable.Checked = false;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

            if (tabSource.SelectedTab.Name == "tabDataAccess")
            {
                if (!string.IsNullOrEmpty(txtDataAccessLayer.Text))
                {
                    Clipboard.SetText(txtDataAccessLayer.Text);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtBusinessLayer.Text))
                {
                    Clipboard.SetText(txtBusinessLayer.Text);
                }
            }

            
        }

        private void btnResetColumns_Click(object sender, EventArgs e)
        {
            dgvTableColumns.Rows.Clear();

            //resetting the text boxes
            txtColumnName.Text = string.Empty;
            cbIsPK.Checked = false;
            cbIsColumnNullable.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //resetting all the form (i am too lazy to wrapp it in a function :-) )
            btnResetColumns_Click(sender, e);
            txtDataAccessLayer.Text = "";
            txtBusinessLayer.Text = "";
            this._MainComponents = new clsMainComponents();
            txtDatabaseName.Text = string.Empty;
            txtDataAccessNameSpace.Text = string.Empty;
            txtTableName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtDataAccessClassName.Text = string.Empty;


        }
    }
}

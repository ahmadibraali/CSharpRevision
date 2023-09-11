using System.Data;
using System.Data.SqlClient;
using Business;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

            cmbDepartments.DataSource = BusinessService.GetDepartements;
            cmbDepartments.DisplayMember = "Name";
            cmbDepartments.ValueMember = "ID";
        }
    }
}
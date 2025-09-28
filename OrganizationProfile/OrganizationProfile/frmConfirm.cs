using System;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirm : Form
    {
        public frmConfirm()
        {
            InitializeComponent();
            this.Load += frmConfirm_Load;
            this.btnSubmit.Click += btnSubmit_Click;
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName.Text = StudentInformationClass.SetFullName;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblBirthday.Text = StudentInformationClass.SetBirthDay;
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = StudentInformationClass.SetContactNo.ToString();
            lblAge.Text = StudentInformationClass.SetAge.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
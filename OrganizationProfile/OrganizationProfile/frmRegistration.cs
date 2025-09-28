using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
       
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
           
            this.Load += frmRegistration_Load;
            
            this.btnRegister.Click += btnRegister_Click;
        }

        
        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            cbPrograms.Items.Clear();
            for (int i = 0; i < ListOfProgram.Length; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i]);
            }

            string[] ListOGender = new string[]{
                "Male",
                "Female",
                
            };

            cbGender.Items.Clear();
            for (int i = 0; i < ListOGender.Length; i++)
            {
                cbGender.Items.Add(ListOGender[i]);
            }

        }

        
        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }

        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                
                using (frmConfirm frm = new frmConfirm())
                {
                    frm.ShowDialog();
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message, "Input Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentNullException anex)
            {
                MessageBox.Show(anex.Message, "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OverflowException ofex)
            {
                MessageBox.Show(ofex.Message, "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IndexOutOfRangeException iorex)
            {
                MessageBox.Show(iorex.Message, "Range Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                
                txtStudentNo.Focus();
            }
        }
    }
}
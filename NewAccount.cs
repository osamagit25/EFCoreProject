using EFCoreProject.Context;
using EFCoreProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFCoreProject
{
    public partial class NewAccount : Form
    {
        private AppDbContext _context;


        public NewAccount()
        {
            InitializeComponent();
            _context = new AppDbContext();
            cmbUserType.Items.AddRange(new string[] { "Teacher", "Student Affairs" });

        }

        private void NewAccount_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUserType.SelectedItem.ToString() == "Teacher")
                {
                    var teacher = new Teacher
                    {
                        Name = txtName.Text,
                        Age = (int) txtAge.Value,
                        Address = txtAddress.Text,
                        Password = txtPassword.Text
                    };
                    _context.Teachers.Add(teacher);
                }
                else
                {
                    var studentAffairs = new StudentAffairs
                    {
                        Name = txtName.Text,
                        Age = (int)txtAge.Value,
                        Address = txtAddress.Text,
                        Password = txtPassword.Text
                    };
                    _context.StudentAffairs.Add(studentAffairs);
                }
                _context.SaveChanges();
                MessageBox.Show("Registration successful!");
                this.Close();
                LogIn logIn = new LogIn();
                logIn.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
    }


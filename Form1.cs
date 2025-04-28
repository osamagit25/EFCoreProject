using EFCoreProject.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EFCoreProject
{
    public partial class LogIn : Form
    {
        private AppDbContext _context;

        public LogIn()
        {
            InitializeComponent();
            _context = new AppDbContext();

            cmbUserType.Items.AddRange(new string[] { "Teacher", "Student Affairs" });


        }


        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUserType.SelectedItem.ToString() == "Teacher")
                {
                    var teacher = _context.Teachers
                        .FirstOrDefault(t => t.Name == txtName.Text && t.Password == txtPassword.Text);
                    if (teacher != null)
                    {
                        this.Hide();
                        new TeacherDashboard(teacher.Id).ShowDialog();
                        this.Show();
                    }
                    else
                        MessageBox.Show("Invalid credentials!");
                }
                else
                {
                    var studentAffairs = _context.StudentAffairs
                        .FirstOrDefault(sa => sa.Name == txtName.Text && sa.Password == txtPassword.Text);
                    if (studentAffairs != null)
                    {
                        this.Hide();
                        new StudentAffairsDashboard(studentAffairs.Id).ShowDialog();
                        this.Show();
                    }
                    else
                        MessageBox.Show("Invalid credentials!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new NewAccount().ShowDialog();
            this.Show();
        }
    }
}

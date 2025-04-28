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

namespace EFCoreProject
{
    public partial class StudentAffairsDashboard : Form
    {
        private int selectedStudentId = 0;
        private int selectedAttendanceId = 0;
        private int _studentaffairsId;
        private AppDbContext _context;
        public StudentAffairsDashboard(int id)
        {
            _context = new AppDbContext();
            this._studentaffairsId = id;
            InitializeComponent();
            LoadAttendance();
            LoadStudents();
            LoadStudentComboBox();
        }

        private void StudentAffairsDashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadStudents()
        {
            var students = _context.Students.Select(s => new { s.Id, s.Name, s.Age, s.Address }).ToList();
            dataGridViewStudents.DataSource = students;


        }
        private void LoadAttendance()
        {


            var attendance = _context.Attendances.Select(a => new { a.Id, a.StudentId, a.Status }).ToList();
            dataGridViewAttendance.DataSource = attendance;
        }

        private void btnaddstudent_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                Name = txtStudentName.Text,
                Age = int.Parse(txtStudentAge.Text),
                Address = txtStudentAddress.Text,
                Password = txtStudentPassword.Text
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            MessageBox.Show("Student added successfully.");
            LoadStudents();
        }

        private void LoadStudentComboBox()
        {
            var students = _context.Students.Select(s => new { s.Id, s.Name }).ToList();
            cbstudent.DataSource = students;
            cbstudent.DisplayMember = "Name";
            cbstudent.ValueMember = "Id";
        }

        private void btnaddattendence_Click(object sender, EventArgs e)
        {
            int studentId = (int)cbstudent.SelectedValue;
            string status = txtstatus.Text;

            var attendance = new Attendance
            {
                StudentId = studentId,
                Status = status,
                Date = DateTime.Now
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            MessageBox.Show("Attendance marked successfully.");
            LoadAttendance();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
} 


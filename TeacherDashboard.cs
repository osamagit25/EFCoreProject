using EFCoreProject.Context;
using EFCoreProject.Entities;
using Microsoft.EntityFrameworkCore;
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
    public partial class TeacherDashboard : Form
    {
        private AppDbContext _context;
        private int _teacherId;
        private int selectedCourseId = 0;
        private int selectedGradeId = 0;

        public TeacherDashboard(int teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _context = new AppDbContext();
            LoadData();


        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGradeId == 0)
                {
                    MessageBox.Show("Please select a grade to update");
                    return;
                }

                var grade = _context.Grades.Find(selectedGradeId);
                if (grade != null)
                {
                    grade.StudentId = (int)cmbStudent.SelectedValue;
                    grade.CourseId = (int)cmbCourse.SelectedValue;
                    grade.Score = int.Parse(txtgrade.Text);
                    _context.SaveChanges();
                    LoadData();
                    ClearGradeFields();
                    MessageBox.Show("Grade updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnaddgrade_Click(object sender, EventArgs e)
        {
            try
            {
                var grade = new Grade
                {
                    StudentId = (int)cmbStudent.SelectedValue,
                    CourseId = (int)cmbCourse.SelectedValue,
                    TeacherId = _teacherId,
                    Score = (int)txtgrade.Value
                };
                _context.Grades.Add(grade);
                _context.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                var course = new Course
                {
                    Name = txtCourseName.Text,
                    Duration = int.Parse(txtDuration.Text)
                };
                _context.Courses.Add(course);
                _context.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void LoadData()
        {
            var courses = _context.Courses.ToList();
            dgvCourses.DataSource = courses;

            var grades = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Where(g => g.TeacherId == _teacherId)
                .Select(g => new
                {
                    Student = g.Student.Name,
                    Course = g.Course.Name,
                    g.Score
                })
                .ToList();
            dgvGrades.DataSource = grades;

            cmbStudent.DataSource = _context.Students.ToList();
            cmbStudent.DisplayMember = "Name";
            cmbStudent.ValueMember = "Id";

            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCourses.Rows[e.RowIndex];
                selectedCourseId = (int)row.Cells["Id"].Value;
                txtCourseName.Text = row.Cells["Name"].Value.ToString();
                txtDuration.Text = row.Cells["Duration"].Value.ToString();
            }
        }

        private void dgvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvGrades.Rows[e.RowIndex];
                selectedGradeId = (int)row.Cells["Id"].Value;
                cmbStudent.SelectedValue = row.Cells["StudentId"].Value;
                cmbCourse.SelectedValue = row.Cells["CourseId"].Value;
                txtgrade.Value = (int)row.Cells["Score"].Value;

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCourseId == 0)
                {
                    MessageBox.Show("Please select a course to update");
                    return;
                }

                var course = _context.Courses.Find(selectedCourseId);
                if (course != null)
                {
                    course.Name = txtCourseName.Text;
                    course.Duration = int.Parse(txtDuration.Text);
                    _context.SaveChanges();
                    LoadData();
                    ClearCourseFields();
                    MessageBox.Show("Course updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCourseId == 0)
                {
                    MessageBox.Show("Please select a course to delete");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var course = _context.Courses.Find(selectedCourseId);
                    if (course != null)
                    {
                        _context.Courses.Remove(course);
                        _context.SaveChanges();
                        LoadData();
                        ClearCourseFields();
                        MessageBox.Show("Course deleted successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btndeletegrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGradeId == 0)
                {
                    MessageBox.Show("Please select a grade to delete");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this grade?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var grade = _context.Grades.Find(selectedGradeId);
                    if (grade != null)
                    {
                        _context.Grades.Remove(grade);
                        _context.SaveChanges();
                        LoadData();
                        ClearGradeFields();
                        MessageBox.Show("Grade deleted successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void ClearCourseFields()
        {
            selectedCourseId = 0;
            txtCourseName.Text = "";
            txtDuration.Text = "";
        }

        private void ClearGradeFields()
        {
            selectedGradeId = 0;
            cmbStudent.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            txtgrade.Text = "";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}

    
    
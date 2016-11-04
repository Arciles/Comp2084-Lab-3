using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week6
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    int studentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    var conn = new Entities();

                    var objSut = (from d in conn.Students
                                  where d.StudentID == studentID
                                  select d).FirstOrDefault();
                    if (objSut != null)
                    {
                        txtStudentFirstAndMidName.Text = objSut.FirstMidName;
                        txtStudentLastName.Text = objSut.LastName;
                        txtStudentEnrollmentDate.Text = objSut.EnrollmentDate.ToString("yyyy/MM/dd");
                    }
                }
            }
            // set the max value of the enrollment date field to today
            txtStudentEnrollmentDate.Attributes.Add("max" , DateTime.Today.ToString("dd/MM/yyyy"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // disable the button to prevent multiple user clicks
            btnSave.Enabled = false;

            // set the student id to -1 as default control
            int studentID = -1;

            // check the query string to find is there any parameters are passed
            if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
            {
                studentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            }

            // open data base connection
            var connection = new Entities();

            // create new entity
            Student student = new Student();

            // set the required fields
            student.LastName = txtStudentLastName.Text;
            student.FirstMidName = txtStudentFirstAndMidName.Text;
            student.EnrollmentDate = Convert.ToDateTime(txtStudentEnrollmentDate.Text);

            // create error handling for any kind of exceptions 
            try
            {   // this means we're creating a new student
                if(studentID == -1)
                {
                    // add the new entity to database and save the changes
                    connection.Students.Add(student);
                }
                // this means we're updating an existing record
                else
                {
                    student.StudentID = studentID;
                    connection.Students.Attach(student);
                    connection.Entry(student).State = System.Data.Entity.EntityState.Modified;
                }
                
                
                connection.SaveChanges();

                // redirect user to Students page
                Response.Redirect("students.aspx");
            } catch(System.Data.Entity.Infrastructure.DbUpdateException exception)
            {
                lblError.Visible = true;
                btnSave.Enabled = true;
            }
            
        }
    }
}
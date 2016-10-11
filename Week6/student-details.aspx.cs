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
            // set the max value of the enrollment date field to today
            txtStudentEnrollmentDate.Attributes.Add("max" , DateTime.Today.ToString("dd/MM/yyyy"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // disable the button to prevent multiple user clicks
            btnSave.Enabled = false;

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
            {
                // add the new entity to database and save the changes
                connection.Students.Add(student);
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
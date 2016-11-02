using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week6
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // bind data to the gridView
            bindData_Students();
        }

        protected void bindData_Students()
        {
            // open connection and get all of the students from the table
            var connection = new Entities();

            var students = from s in connection.Students
                           select s;
            // bind the students list to the gridView
            grdStudents.DataSource = students.ToList();
            grdStudents.DataBind();

        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // get the row index
            int rowIndex = (int)e.RowIndex;

            // use the row index as a reference to get the student ID
            int studentID = (int) grdStudents.DataKeys[rowIndex].Value;

            // open a db connection
            var conn = new Entities();

            // create a new object and set the student id
            Student s = new Student();
            s.StudentID = studentID;

            // attach the object to the database context then remove from record 
            conn.Students.Attach(s);
            conn.Students.Remove(s);

            conn.SaveChanges();

            // refresh the list after deletion
            bindData_Students();
        }
    }
}
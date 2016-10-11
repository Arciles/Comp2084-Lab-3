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
    }
}
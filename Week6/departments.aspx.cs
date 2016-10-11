using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// add 2 extra references
using System.Web.ModelBinding;

namespace Week6
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the departments and display in the gridView
            getDepartments();
        }

        protected void getDepartments()
        {
            // connect to the database 
            var connection = new Entities();

            // run the query using LINQ
            var Departments = from d in connection.Departments
                              select d;

            // display the result in gridView
            grdDepartments.DataSource = Departments.ToList();
            grdDepartments.DataBind();

        }
    }
}
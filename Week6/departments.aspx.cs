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

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int gridIndex = e.RowIndex;

            // 1. determine which row is gonna get deleted
            int DeparmantID = (int) grdDepartments.DataKeys[gridIndex].Value;

            // 2. find a deparmentID value in the selected row
            var conn = new Entities();

            // 3. connect to the db
            Department d = new Department();
            d.DepartmentID = DeparmantID; 

            // 4. delete the selected row
            conn.Departments.Attach(d);
            conn.Departments.Remove(d);
            conn.SaveChanges();

            // 5. refresh the page after deletion
            getDepartments();
        }
    }
}
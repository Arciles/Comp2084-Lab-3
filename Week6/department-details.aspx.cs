using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// database reference
using System.Web.ModelBinding;

namespace Week6
{
    public partial class department_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // disable btnSave to prevent user clicking the button again
            btnSave.Enabled = false;

            // connect to the database
            var connection = new Entities();

            // use the Department class to creat a new department object

            Department department = new Department();
            
            // fill the department object with values coming from Form
            department.Name = txtName.Text;
            department.Budget = Convert.ToDecimal(txtBudget.Text);
            
            // create error handling for any kind of exceptions 
            try
            {
                // save the new object to the database
                connection.Departments.Add(department);
                connection.SaveChanges();

                // redirect back to the departments page after successful save
                Response.Redirect("departments.aspx");
            } catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
            {
                lblError.Visible = true;
                btnSave.Enabled = true;
            }
            
        }
    }
}
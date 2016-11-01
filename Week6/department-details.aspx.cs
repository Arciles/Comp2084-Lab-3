using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// database reference
using System.Web.ModelBinding;
using System.Collections.Specialized;
using System.Data.Entity;

namespace Week6
{
    public partial class department_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["DepartmentId"]))
                {
                    int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentId"]);
                    var conn = new Entities();

                    var objDep = (from d in conn.Departments
                                  where d.DepartmentID == DepartmentID
                                  select d).FirstOrDefault();
                    if (objDep != null)
                    {
                        txtName.Text = objDep.Name;
                        txtBudget.Text = objDep.Budget.ToString();
                    }
                }
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Default value for deparment id
            int DepartmentID = -1;

            if (!String.IsNullOrEmpty(Request.QueryString["DepartmentId"]))
            {
                DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentId"]);
            }

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
                if(DepartmentID == -1)
                    // save the new object to the database
                    connection.Departments.Add(department);
                else
                {
                    // update the existing record
                    department.DepartmentID = DepartmentID;
                    connection.Departments.Attach(department);
                    connection.Entry(department).State = EntityState.Modified;
                }

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
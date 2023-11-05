using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StudentFeeWebPortal_Task.DAL
{
    public class Cls_Class
    {
        public void BindDataToDropdown(DropDownList dropdown, string dataTextField, string dataValueField)
        {
            using (var context = new Cls_DbContext())
            {                
                var data = context.Classes.ToList();

                dropdown.DataSource = data;
                dropdown.DataTextField = dataTextField;
                dropdown.DataValueField = dataValueField;
                dropdown.DataBind();
            }
        }
    }
}
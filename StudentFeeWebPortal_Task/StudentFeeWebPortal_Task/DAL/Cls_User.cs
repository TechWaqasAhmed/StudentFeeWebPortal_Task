using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace StudentFeeWebPortal_Task.DAL
{
    public class Cls_User
    {
        public string Fun_LogIn(string UserName,string Password, ref decimal UserID)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {                   

                    var user = context.Users.FirstOrDefault(u => u.Username == UserName && u.Password == Password);

                    if (user != null)
                    {
                         UserID = user.Id;
                         Res = "Successful login";
                    }
                    else
                    {
                        
                        Res = "Invalid login";
                    }
                }
            }
            catch (Exception ex)
            {

                return Res = "Exception happen, exception is " + ex.Message;
            }

            return Res;
        }
    }
}
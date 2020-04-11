using System;
using SQL;
using System.Data.SqlClient;
using Common.Framework.Tvbboy;
namespace OpenEvaluation
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwd = txtPwd.Text;
            SQLHelper sh = new SQLHelper();
            try
            {
                string sql = string.Format("select username,pwd,truename from tblStudentsForExercise where username='{0}'",username);
          
                SqlDataReader sdr;
                sh.RunSQL(sql,out sdr);
                if (sdr.Read())
                {
                    if (ClassMd5.Md5Hash32(pwd) == sdr[1].ToString())
                    {
                        Session["username"] = username;
                        Session["truename"] = sdr[2].ToString();
                        Response.Redirect("homework.aspx");
                    }
                    else
                    {
                        Response.Write("登录错误");
                    }
                }
                sdr.Close();
            }
            catch{
            }
            finally
            {
                if (sh != null)
                    sh.Close();
            }
        }
    }
}
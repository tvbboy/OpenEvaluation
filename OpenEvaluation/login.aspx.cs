using System;
using System.Data;
using SQL;
using System.Data.SqlClient;
using System.Collections.Generic;
using Common.Framework.Tvbboy;
using System.Linq;

namespace OpenEvaluation
{
    public partial class login : System.Web.UI.Page
    {
        private EnumerableRowCollection<DataRow> table = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from tblStudentsForExercise";
            if(table == null || !IsPostBack)
            {
                var sqlHelper = new SQLHelper();
                var dataSet = new DataSet();
                try
                {
                    sqlHelper.RunSQL(sql, ref dataSet);
                    var dataTable = dataSet.Tables[0];
                    table = dataTable.AsEnumerable();
                }
                catch(Exception ex)
                {
                    Response.Write("Something wrong when connect to the sql. Please try again later.</br>Please refresh.");

                }
                sqlHelper.Close();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwd = txtPwd.Text;
            List<Student> student = table.Where(p => p.Field<string>("username") == username && p.Field<string>("pwd") == ClassMd5.Md5Hash32(pwd)).Select(
                    p => new Student
                    (
                        username, ClassMd5.Md5Hash32(pwd), p.Field<string>("truename")
                    )
                ).ToList();
            if (student.Count != 1)
            {
                Response.Write("请输入正确的账号密码");
            }
            else
            {
                Session["username"] = username;
                Session["truename"] = student[0].truename;
                Response.Redirect("homework.aspx");
            }

        }
        private class Student
        {
            public string username { get; }
            public string pwd { get; }
            public string truename { get; }
            public Student(string username, string pwd, string truename)
            {
                this.username = username;
                this.pwd = pwd;
                this.truename = truename;
            }
        }
    }
}
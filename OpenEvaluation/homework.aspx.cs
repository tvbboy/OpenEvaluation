using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenEvaluation
{
    public partial class homework : System.Web.UI.Page
    {
        private string sql = string.Empty;
        private DataTable dtTeam;
        private DataSet ds;
        SQLHelper sh;
        protected void Page_Load(object sender, EventArgs e)
        {
            sh = new SQLHelper();
            if (null == Session["username"])
                Response.Redirect("login.aspx");
            lblUseranme.Text = Session["username"].ToString();
            lblTrueName.Text = Session["truename"].ToString();
            if (!IsPostBack)
            {

                dtTeam = new DataTable();
                try
                {
                    sql = "select top 1 id, homeWork from tblHomework order by id";
                    SqlDataReader sdr;
                    sh.RunSQL(sql, out sdr);
                    if (sdr.Read())
                    {
                        lblHomeworkID.Text = sdr[0].ToString();
                        lblHomework.Text = sdr[1].ToString();
                       
                    }
                    else
                    {
                        lblHomework.Text = ("没有作业信息!");
                        //return;
                    }
                    sdr.Close();

                    sql = "select count(*) from tblTeam";
                    lblTotal.Text = sh.RunSelectSQLToScalar(sql);
                    sql = "select count(*) from tblEvaluation where studentID='" + lblUseranme.Text + "' and homeworkID=" +lblHomeworkID.Text ;
                    string tmp = sh.RunSelectSQLToScalar(sql);

                    lblCount.Text = (int.Parse(lblTotal.Text) - int.Parse(tmp)).ToString();




                    sql = "select team as 排名不分先后,count(*) as 参与评价,max(myscore1+myscore2+myscore3+myscore4+myscore5) as 最高分,min(myscore1+myscore2+myscore3+myscore4+myscore5) as 最低分 from tblEvaluation,tblTeam where tblEvaluation.teamID=tblTeam.id group by Team";
                    ds = new DataSet();
                    sh.RunSQL(sql, ref ds);
                    DataTable dt = ds.Tables[0];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                    sql = $"select id from tblTeam where team LIKE \'%{lblTrueName.Text}%\'";
                    int teamId = int.Parse(sh.RunSelectSQLToScalar(sql));
                    sql = $"select AVG(myScore1)+AVG(myScore2)+AVG(myScore3)+AVG(myScore4)+AVG(myScore5) from tblEvaluation where teamID = {teamId} group by teamID ";
                    string score = sh.RunSelectSQLToScalar(sql);
                    teamScore.Text = score;
                }
                catch(Exception ex) {
                    Response.Write(ex.Message);
                }
                finally
                {
                    sh.Close();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Evaluation.aspx");
        }
    }
}
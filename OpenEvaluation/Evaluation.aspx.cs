using System;
using SQL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text.RegularExpressions;
namespace OpenEvaluation
{
    public partial class Evaluation : System.Web.UI.Page
    {
        private string sql = string.Empty;
        private DataTable dtTeam;
        private DataSet ds;
        private int currentTeamID=0;
        SQLHelper sh;
        protected void Page_Load(object sender, EventArgs e)
        {
            sh = new SQLHelper();
            if (null == Session["username"])
                Response.Redirect("login.aspx");
            lblUseranme.Text = Session["username"].ToString();
            lblTrueName.Text = Session["truename"].ToString();
            if(!IsPostBack)
            {
               
                dtTeam = new DataTable();
                try
                {
                    sql = "select * from tblTeam order by id";
                    sh.RunSQL(sql, ref ds);
                    if (null != ds)
                    {
                        dtTeam = ds.Tables[0];
                        Session["dtTeam"] = dtTeam;
                        lblTotal.Text = dtTeam.Rows.Count.ToString();
                        lblCurrentNo.Text = (currentTeamID + 1).ToString();
                        lblTeam.Text = dtTeam.Rows[currentTeamID]["team"].ToString();
                        lblTeamID.Text = dtTeam.Rows[currentTeamID]["ID"].ToString();
                    }
                    else
                    {
                        Response.Write("没有作业信息!");
                        return;
                    }
                }
                catch { }
                finally
                {
                    sh.Close();
                }

            }
            if (null != Session["dtTeam"] && dtTeam==null)
            {
                dtTeam = (DataTable)Session["dtTeam"];
            }
         



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool isinsert = true;
            double[] myscore={0,0,0,0,0};
            try
            {
                 myscore[0] = double.Parse(txtItem1.Text);
                 myscore[1] = double.Parse(txtItem2.Text);
                 myscore[2] = double.Parse(txtItem3.Text);
                 myscore[3] = double.Parse(txtItem4.Text);
                 myscore[4] = double.Parse(txtItem5.Text);
                 if (myscore[0] > 30 || myscore[0] < 0)
                 {
                     Response.Write("<script language='javascript'>alert('超出范围！')</script>");
                     return;
                 }
                 else if (myscore[1] > 20 || myscore[1] < 0 || myscore[2] > 20 || myscore[2] < 0 || myscore[3] > 20 || myscore[3] < 0)
                 {
                     Response.Write("<script language='javascript'>alert('2-4标准超出范围！')</script>");
                     return;
                 }
                 else if (myscore[4] > 10 || myscore[4] < 0)
                 {
                   
                         Response.Write("<script language='javascript'>alert('5标准超出范围！')</script>");
                         return;
                 }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('输入有误或者超出范围！')</script>");
                return;
            }
            //处理提交的分数
            SqlConnection conn = null;
            string sql = string.Format("select studentID from tblEvaluation where studentID='{0}' and teamID={1}", lblUseranme.Text, lblTeamID.Text);
            try
            {
                SqlDataReader sdr;
                sh.RunSQL(sql, out sdr);
                if (sdr.Read()) //该题目已经评价过
                {
                    isinsert = false;
                }
                sdr.Close();
                SqlCommand colList = new SqlCommand();
                conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                colList.Connection = conn;
                if (isinsert)
                {
                    colList.CommandText = "insert into tblEvaluation (homeworkID,studentID,myScore1,myScore2,myScore3,myScore4,myScore5,ScoreItemID,teamID) " +
                        "values(@homeworkID, '@username', @score0, @score1, @score2, @score3, @score4, @ScoreItemID, @teamID)";
                    colList.Parameters.AddRange
                    (
                        new SqlParameter[]
                        {
                            new SqlParameter("@homeworkID", SqlDbType.VarChar){ Value=0 },
                            new SqlParameter("@username", SqlDbType.VarChar){ Value=lblUseranme.Text },
                            new SqlParameter("@score0", SqlDbType.Int){ Value=myscore[0]},
                            new SqlParameter("@score1", SqlDbType.Int){ Value=myscore[1]},
                            new SqlParameter("@score2", SqlDbType.Int){ Value=myscore[2]},
                            new SqlParameter("@score3", SqlDbType.Int){ Value=myscore[3]},
                            new SqlParameter("@score4", SqlDbType.Int){ Value=myscore[4]},
                            new SqlParameter("@ScoreItemID", SqlDbType.VarChar){ Value=0 },
                            new SqlParameter("@teamID", SqlDbType.VarChar){ Value=lblTeamID.Text}
                        }
                      ) ;
                }
                else
                {
                    colList.CommandText = "update tblEvaluation set myScore1=@score0, myScore2=@score1, myScore3=@score2, " +
                        "myScore4=@score3, myScore5=@score4 where studentID='@studentID' and teamID=teamID";
                    colList.Parameters.AddRange
                    (
                        new SqlParameter[]
                        {
                            new SqlParameter("@score0", SqlDbType.Int){ Value=myscore[0]},
                            new SqlParameter("@score1", SqlDbType.Int){ Value=myscore[1]},
                            new SqlParameter("@score2", SqlDbType.Int){ Value=myscore[2]},
                            new SqlParameter("@score3", SqlDbType.Int){ Value=myscore[3]},
                            new SqlParameter("@score4", SqlDbType.Int){ Value=myscore[4]},
                            new SqlParameter("@username", SqlDbType.VarChar){ Value=lblUseranme.Text },
                            new SqlParameter("@teamID", SqlDbType.VarChar){ Value=lblTeamID.Text}
                        }
                    );
                }
                colList.Connection.Open();
                int rows = colList.ExecuteNonQuery();
                colList.Connection.Close();
                if (rows > 0)
                    Response.Write("<script language='javascript'>alert('评价成功！')</script>");
                else
                {
                    Response.Write("<script language='javascript'>alert('评价失败！')</script>");
                   // return;
                }


            }
            catch (System.ArgumentException ae)
            {
                Response.Write("<script language='javascript'>alert('不许玩注入')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script language='javascript'>alert('出现异常！评价失败！原因"+ex.Message+"')</script>");
            }
            finally
            {
                if (sh != null)
                    sh.Close();
            }

            currentTeamID = int.Parse(lblCurrentNo.Text) + 1;
            if (currentTeamID < dtTeam.Rows.Count+1)
            {
                lblCurrentNo.Text = currentTeamID.ToString();
                lblTeam.Text = dtTeam.Rows[currentTeamID - 1]["team"].ToString();
                lblTeamID.Text = dtTeam.Rows[currentTeamID-1]["ID"].ToString();
                txtItem1.Text = "";
                txtItem2.Text = "";
                txtItem3.Text = "";
                txtItem4.Text = "";
                txtItem5.Text = "";
            }
            else
            {
                Response.Write("<script language='javascript'>alert('已经是最后一组了，感谢您的关键支持！')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("homework.aspx");
        }
    }
}
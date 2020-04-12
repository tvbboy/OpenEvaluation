using System;
using SQL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
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
            string sql = string.Format("select studentID from tblEvaluation where studentID='{0}' and teamID={1}", lblUseranme.Text, lblTeamID.Text);
            try
            {
                SqlDataReader sdr;
                sh.RunSQL(sql, out sdr);
                if (sdr.Read()) //改题目已经评价过
                {
                    isinsert = false;
                }
                sdr.Close();
                // StringBuilder opSql = new StringBuilder();
                SqlCommand colList = new SqlCommand();
                if (isinsert)
                {
                    colList.CommandText = "insert into tblEvaluation (homeworkID,studentID,myScore1,myScore2,myScore3,myScore4,myScore5,ScoreItemID,teamID) " +
                        "values(@date, '@username', @score0, @score1, @score2, @score3, @score4, @date2, @teamID)";
                    colList.Parameters.AddRange
                    (
                        new SqlParameter[]
                        {
                            new SqlParameter("@date", 0),
                            new SqlParameter("@username", lblUseranme.Text),
                            new SqlParameter("@score0", myscore[0]),
                            new SqlParameter("@score1", myscore[1]),
                            new SqlParameter("@score2", myscore[2]),
                            new SqlParameter("@score3", myscore[3]),
                            new SqlParameter("@score4", myscore[4]),
                            new SqlParameter("@date2", 0),
                            new SqlParameter("@teamID", lblTeamID.Text)
                        }
                      ); 
                }
                else
                {
                    colList.CommandText = "update tblEvaluation set myScore1=@score0, myScore2=@score1, myScore3=@score2, " +
                        "myScore4=@score3, myScore5=@score4 where studentID='@studentID' and teamID=teamID";
                    colList.Parameters.AddRange
                    (
                        new SqlParameter[]
                        {
                            new SqlParameter("@score0", myscore[0]),
                            new SqlParameter("@score1", myscore[1]),
                            new SqlParameter("@score2", myscore[2]),
                            new SqlParameter("@score3", myscore[3]),
                            new SqlParameter("@score4", myscore[4]),
                            new SqlParameter("@studentID", lblUseranme.Text),
                            new SqlParameter("@teamID", lblTeamID.Text)
                        }
                    );
                }
                string opSql = colList.ToString();
                /**
                string colList = "homeworkID,studentID,myScore1,myScore2,myScore3,myScore4,myScore5,ScoreItemID,teamID";
                if (isinsert)
                {
                    opSql = new StringBuilder(string.Format("insert into tblEvaluation ({0})", colList));
                    opSql.Append("values(");
                    opSql.Append(string.Format("{0}", 1));//日期值必须使用单引号括起来
                    opSql.Append(",");        //逗号分隔     
                    opSql.Append(string.Format("'{0}'", lblUseranme.Text));//数字不需要单引号
                    opSql.Append(",");        //逗号分隔
                    opSql.Append(string.Format("{0}", myscore[0]));
                    opSql.Append(",");       //逗号分隔
                    opSql.Append(string.Format("{0}", myscore[1]));
                    opSql.Append(",");        //逗号分隔
                    opSql.Append(string.Format("{0}", myscore[2]));
                    opSql.Append(",");       //逗号分隔
                    opSql.Append(string.Format("{0}", myscore[3]));
                    opSql.Append(",");
                    opSql.Append(string.Format("{0}", myscore[4]));
                    opSql.Append(",");
                    opSql.Append(string.Format("{0}", 0));//日期值必须使用单引号括起来
                    opSql.Append(",");
                    opSql.Append(string.Format("{0}", lblTeamID.Text));//日期值必须使用单引号括起来
                    opSql.Append(")");      //逗号分隔
                }
                else
                {
                    opSql = new StringBuilder("update tblEvaluation set ");
                    opSql.Append(string.Format("myScore1={0}", myscore[0]));
                    opSql.Append(",");
                    opSql.Append(string.Format("myScore2={0}", myscore[1]));
                    opSql.Append(",");
                    opSql.Append(string.Format("myScore3={0}", myscore[2]));
                    opSql.Append(",");
                    opSql.Append(string.Format("myScore4={0}", myscore[3]));
                    opSql.Append(",");
                    opSql.Append(string.Format("myScore5={0}", myscore[4]));

                    opSql.Append(string.Format(" where studentID='{0}' and teamID={1}", lblUseranme.Text, lblTeamID.Text)); //condition,where前要有空格
                    
                }
                */
                int rows = sh.RunSQL(opSql.ToString());
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
                Response.Write("不许玩注入");
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
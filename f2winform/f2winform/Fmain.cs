using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;    // 和SQL相关的命名空间
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using System.IO;
using System.Text.RegularExpressions;

namespace f2winform
{
    public partial class Fmain : BorderlessForm
    {
        

        public Fmain()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;
            //// 设置父窗体背景色（可选，用于填充子窗体外的区域）
            //this.BackColor = Color.White;
            this.menu.Select(this.menu.Items[4], true);//打开窗口时默认选中“关于”
        }

        //声明一个数据库链接器对象
        private SqlConnection connection;
        //声明一个DataTable表对象
        public DataTable table;
        //声明选择变量
        private string rp, br;
        //声明统计变量
        private int counts;
        //正则表达式声明
        public string strict = @"^([1-9]\d*)$";

        private void Fmain_Load(object sender, EventArgs e)
        {
            //加载窗口时实例化链接器对象
            connection = new SqlConnection("Server=localhost;Database=coursedes;User Id=sa;Password=147369;");
            try
            {
                connection.Open();
                
            }
            catch (Exception error) {
                DialogResult quit = MessageBox.Show("数据库连接失败！已退出程序，请检查数据库正常与否"+error.ToString(),"异常",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (quit == DialogResult.OK)
                {
                    this.Close();//异常连接阻止程序打开
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.connection.Close();//关闭数据库链接
            this.Close();//关闭窗口按钮逻辑
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗口按钮逻辑
        }
        #region 侧边导航栏页面切换事件
        private void menu_SelectChanged(object sender, MenuSelectEventArgs e)
        {
            //this.menu.Items[0].Select = true;//未使用代码，但是有参考价值
            switch (e.Value.Text)
            {
                case "查询":
                    this.labelct.Text = $"库中总数{sqlToolClass.GetNum(connection)}件";
                    Tool_Class.setUnvisChild(this.textmodel);//禁止内容面板内其他模块
                    this.tablepanel1.Enabled = true;//生效表格
                    this.table = sqlToolClass.SearchAll(connection);//覆盖查询值到table
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Visible = true;//表格显示
                    this.tablepanel1.Refresh();//刷新表格显示
                    this.panelbrch.Enabled = false;//禁brpanel
                    this.panelbrch.Visible = false;
                    this.panelrpch.Enabled = false;//禁rppanel
                    this.panelrpch.Visible = false;
                    this.panelnb.Enabled = false;//禁nbpanel
                    this.panelnb.Visible = false;
                    this.pnedit.Visible = false;
                    Tool_Class.setVisself(this.panelTt);
                    Tool_Class.setVisAll(this.panel1);
                    Tool_Class.setVisAll(this.panel2);
                    Tool_Class.setVisAll(this.panel3);
                    Tool_Class.setVisAll(this.panel4);
                    Tool_Class.setVisAll(this.panel5);
                    Tool_Class.setVisAll(this.panelct);
                    break;
                case "借还管理":
                    this.labelct.Text = $"库中总数{sqlToolClass.GetNum(connection)}件";
                    Tool_Class.setUnvisChild(this.textmodel);//禁止内容面板内其他模块
                    this.tablepanel1.Enabled = true;//生效表格
                    this.table = sqlToolClass.SearchAll(connection);//覆盖查询值到table
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Visible = true;//表格显示
                    this.tablepanel1.Refresh();//刷新表格显示
                    Tool_Class.setVisself(this.panelTt);
                    Tool_Class.setUnvisChild(this.panelTt);//禁用面板中所有子面板
                    this.panelbrch.Enabled = true;//启动brpanel
                    this.panelbrch.Visible = true;
                    Tool_Class.setVisAll(this.panelct);

                    break;
                case "维修管理":
                    this.labelct.Text = $"库中总数{sqlToolClass.GetNum(connection)}件";
                    Tool_Class.setUnvisChild(this.textmodel);//禁止内容面板内其他模块
                    this.tablepanel1.Enabled = true;//生效表格
                    this.table = sqlToolClass.SearchAll(connection);//覆盖查询值到table
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Visible = true;//表格显示
                    this.tablepanel1.Refresh();//刷新表格显示
                    Tool_Class.setVisself(this.panelTt);
                    Tool_Class.setUnvisChild(this.panelTt);//禁用面板中所有子面板
                    this.panelrpch.Enabled = true;//启动rppanel
                    this.panelrpch.Visible = true;
                    Tool_Class.setVisAll(this.panelct);
                    break;
                case "新设备登记":
                    this.labelct.Text = $"库中总数{sqlToolClass.GetNum(connection)}件";
                    Tool_Class.setUnvisChild(this.textmodel);//禁止父容器内其他模块
                    this.tablepanel1.Enabled = true;//生效表格
                    this.table = sqlToolClass.SearchAll(connection);//覆盖查询值到table
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Visible = true;//表格显示
                    this.tablepanel1.Refresh();//刷新表格显示
                    Tool_Class.setUnvisChild(this.panelTt);//禁用面板中所有子面板
                    Tool_Class.setVisself(this.panelTt);
                    this.panelnb.Enabled = true;//启动nbpanel
                    this.panelnb.Visible = true;
                    this.pnedit.Visible = true;
                    Tool_Class.setVisAll(this.panelct);
                    break;
                case "关于":
                    Tool_Class.setUnvisChild(this.textmodel);//禁止父容器内其他模块
                    string contentPath = @"F:\\codeData\\C#\\GUI\\f2winform\\f2winform\\Resources\\关于.txt";
                    string content = File.ReadAllText(contentPath);
                    txt4.Enabled = true;
                    txt4.Text = content;
                    txt4.Visible = true;
                    
                    break;
                default:
                    //啥事也不干
                    break;
            }
        }
        #endregion

        private void Fmain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DraggableMouseDown();//允许主窗口拖动
            }
        }

        #region 查询界面按钮点击处理事件
        private void sebtnm_Click(object sender, EventArgs e)
        {
            this.table = sqlToolClass.SearchByName(this.inputnm.Text, connection);
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        private void sebtid_Click(object sender, EventArgs e)
        {
            this.table = sqlToolClass.SearchById(this.inputid.Text, connection);
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        private void sebtpn_Click(object sender, EventArgs e)
        {
            this.table = sqlToolClass.SearchByPn(this.inputpn.Text, connection);
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        private void sebtbr_Click(object sender, EventArgs e)
        {
            switch (this.select1.SelectedIndex)
            {
                case 0:
                    this.table = sqlToolClass.SearchByBorrowed("是", connection);
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Refresh();
                    break;
                case 1:
                    this.table = sqlToolClass.SearchByBorrowed("否", connection);
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Refresh();
                    break;
                default:
                    MessageBox.Show("请正确选择！");
                    break;
            }
        }

        private void sebtrp_Click(object sender, EventArgs e)
        {
            switch (this.select2.SelectedIndex)
            {
                case 0:
                    this.table = sqlToolClass.SearchByRp("是", connection);
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Refresh();
                    break;
                case 1:
                    this.table = sqlToolClass.SearchByRp("否", connection);
                    this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
                    this.tablepanel1.Refresh();
                    break;
                default:
                    MessageBox.Show("请正确选择！");
                    break;
            }
        }
        #endregion

        #region 借用管理界面按钮处理事件
        private void btbrchange_Click(object sender, EventArgs e)
        {
            try{
                this.table = sqlToolClass.ChangeBr(this.inputbrid.Text, "borrowed", "是", connection);
                this.table = sqlToolClass.ChangeBr(this.inputbrid.Text, "pname_br", this.inputbrpn.Text, connection);
                MessageBox.Show("借用成功！");
            }
            catch (SqlException sqlerror)
            {
                MessageBox.Show($"操作失败！\n错误信息如下:{sqlerror.Message}");
            }
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        private void bttkchange_Click(object sender, EventArgs e)
        {
            try
            {
                this.table = sqlToolClass.ChangeBr(this.inputbrid.Text, "borrowed", "否", connection);
                this.table = sqlToolClass.ChangeBr(this.inputbrid.Text, "pname_br", this.inputbrpn.Text, connection);
                MessageBox.Show("归还成功！");
            }
            catch (SqlException sqlerror)
            {
                MessageBox.Show($"操作失败！\n错误信息如下:{sqlerror.Message}");
            }
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        #endregion

        #region 修理状态界面按钮处理事件
        private void rpyesbt_Click(object sender, EventArgs e)
        {
            try
            {
                this.table = sqlToolClass.ChangeBr(this.inputrpid.Text, "repairing", "是", connection);
                this.table = sqlToolClass.ChangeBr(this.inputrpid.Text, "pname_br", this.inputrppn.Text, connection);
                MessageBox.Show("设置成功！");
            }
            catch (SqlException sqlerror)
            {
                MessageBox.Show($"操作失败！\n错误信息如下:{sqlerror.Message}");
            }
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        private void rpnobt_Click(object sender, EventArgs e)
        {
            try
            {
                this.table = sqlToolClass.ChangeBr(this.inputrpid.Text, "repairing", "否", connection);
                this.table = sqlToolClass.ChangeBr(this.inputrpid.Text, "pname_br", this.inputrppn.Text, connection);
                MessageBox.Show("设置成功！");
            }
            catch (SqlException sqlerror)
            {
                MessageBox.Show($"操作失败！\n错误信息如下:{sqlerror.Message}");
            }
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
        }

        private bool tablepanel1_CellEndEdit(object sender, TableEndEditEventArgs e)
        {
            
            //MessageBox.Show(e.Value+ e.Column.Title+e.RowIndex.ToString());//测试修改值是否到了table里
            this.table = this.tablepanel1.ToDataTable();//把tablepanel1的表导出覆盖给table
            //this.table.TableName = "Table_Total";
            this.table = sqlToolClass.UpCell(e,e.RowIndex.ToString(),e.Column.Title,e.Value,connection);
            if(this.table == null) { return false; }//如果返回空就结束修改
            //sqlToolClass.UpdateDT(this.table, "SELECT * FROM Table_Total",connection);
            //sqlToolClass.UpDataTable(this.table, this.connection);//编辑后更新数据到数据库
            this.tablepanel1.DataSource = this.table;
            this.tablepanel1.Refresh();
            return true;
        }

        private void switch1_CheckedChanged(object sender, BoolEventArgs e)
        {
            if(this.switchch.Checked == false)
            {
                this.tablepanel1.EditMode = TEditMode.None;
            }
            else
            {
                this.tablepanel1.EditMode = TEditMode.DoubleClick;
            }
        }

        public static bool IsInteger(string input)
        => Regex.IsMatch(input, @"^[1-9]\d*$");

        private void btdl_Click(object sender, EventArgs e)
        {
            //删除行按钮
            if (!IsInteger(this.inputnbid.Text))//this.inputnbid.Text.Trim() == "" || this.inputnbid.Text.Trim() == null
            {
                //Convert.ToInt32(this.inputnbid.Text) >= sqlToolClass.GetNum(connection)
                MessageBox.Show("输入不合规!");
            }
            else
            {
                try
                {
                    if (Convert.ToInt32(this.inputnbid.Text) > sqlToolClass.GetNum(connection))
                    {
                        MessageBox.Show("输入不合规!");
                        return;
                    }
                    this.table = sqlToolClass.DeleteRow(inputnbid.Text, connection);
                }
                catch (SqlException error)
                {
                    MessageBox.Show("删除失败！数据库操作出错！");
                }
            }
            this.tablepanel1.DataSource = this.table;
            this.tablepanel1.Refresh();
            this.labelct.Text = $"库中总数{sqlToolClass.GetNum(connection)}件";
        }
        #endregion

        #region 购入登记页面按钮处理事件
        private void btnb_Click(object sender, EventArgs e)
        {
             
            try
            {
                //先处理选择项
                if (this.selectnbbr.SelectedIndex == 0) 
                {
                    br = "是";
                }
                else if (this.selectnbbr.SelectedIndex == 1)
                {
                    br = "否";
                }
                else
                {
                    MessageBox.Show("请正确选择！");
                    return;
                }

                if (this.selectnbrp.SelectedIndex == 0)
                {
                    rp = "是";
                }
                else if (this.selectnbrp.SelectedIndex == 1)
                {
                    rp = "否";
                }
                else
                {
                    MessageBox.Show("请正确选择！");
                    return;
                }
                //正式进入插入数据
                counts = sqlToolClass.GetNum(connection);
                //MessageBox.Show(counts.ToString());//测试总数数据
                this.table = sqlToolClass.ChangeNb((counts+1).ToString(), this.inputnbnm.Text, br, rp, this.inputnbpn.Text, connection);
                MessageBox.Show("登记成功！");
            }
            catch (SqlException sqlerror)
            {
                MessageBox.Show($"操作失败！\n错误信息如下:{sqlerror.Message}");
            }
            this.tablepanel1.DataSource = this.table;//绑定数据到tablepanel1组件
            this.tablepanel1.Refresh();
            this.labelct.Text = $"库中总数{sqlToolClass.GetNum(connection)}件";
        }
        #endregion

    }
}

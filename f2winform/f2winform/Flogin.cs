using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f2winform
{
    public partial class Flogin : BorderlessForm


    {
        public Flogin()
        {
            InitializeComponent();
        }

        

        private void lgbt_Click(object sender, EventArgs e)//登录按钮逻辑
        {
            //模拟测试登录用户名和密码
            string user = "admin";
            string password = "12345";
            //判断逻辑
            if (this.txtus.Text.Trim() == user && this.txtpw.Text.Trim() == password)
            {
                this.DialogResult = MessageBox.Show("登录成功！", "提示",MessageBoxButtons.OK);
            }
            else {
                this.DialogResult  = MessageBox.Show("登录失败！", "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗口
        }

        private void Flogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//允许窗口拖动
            {
                DraggableMouseDown();
            }
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

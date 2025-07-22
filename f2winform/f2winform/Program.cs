using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f2winform
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            while (true)//登陆循环
            {
                using (Flogin loginform = new Flogin())
                {
                    DialogResult result = loginform.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Application.Run(new Fmain());//启动主窗口
                        break;
                    }
                    else if (result == DialogResult.Retry)
                    {
                        continue;//重试登录
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        break;//退出程序
                    }
                }

            }
            
        }
    }
}

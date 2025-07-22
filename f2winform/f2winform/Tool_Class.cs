using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f2winform
{
    internal static class Tool_Class
    {
        //禁用父容器内的组件
        public static void setUnvisChild(Control parent)
        {
            foreach (Control child in parent.Controls) {
                child.Visible = false;
                child.Enabled = false;
            }
        }

        //禁用父容器
        public static void setUnvis(Control parent)
        {
            parent.Visible = false;
            parent.Enabled = false;
        }

        //移除父容器内的组件
        public static void removeAll(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                parent.Controls.Remove(child);
            }
        }

        //启用父容器自身及其组件
        public static void setVisAll(Control parent)
        {
            parent.Visible = true;  // 确保父容器先可见
            parent.Enabled = true;
            foreach (Control child in parent.Controls)
            {
                child.Visible = true;
                child.Enabled = true;
            }
        }
        //仅启用父容器自身
        public static void setVisself(Control parent)
        {
            parent.Visible = true;
            parent.Enabled = true;
        }


        
    }
}

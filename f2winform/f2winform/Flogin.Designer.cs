namespace f2winform
{
    partial class Flogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelu = new AntdUI.Label();
            this.labelp = new AntdUI.Label();
            this.lgbt = new AntdUI.Button();
            this.OSname = new AntdUI.Label();
            this.txtus = new AntdUI.Input();
            this.txtpw = new AntdUI.Input();
            this.closebutton1 = new AntdUI.Button();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.SuspendLayout();
            // 
            // labelu
            // 
            this.labelu.Font = new System.Drawing.Font("钉钉进步体", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelu.Location = new System.Drawing.Point(128, 149);
            this.labelu.Name = "labelu";
            this.labelu.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.labelu.Size = new System.Drawing.Size(73, 23);
            this.labelu.TabIndex = 0;
            this.labelu.Text = "账户名:";
            // 
            // labelp
            // 
            this.labelp.Font = new System.Drawing.Font("钉钉进步体", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelp.Location = new System.Drawing.Point(128, 202);
            this.labelp.Name = "labelp";
            this.labelp.Size = new System.Drawing.Size(55, 23);
            this.labelp.TabIndex = 0;
            this.labelp.Text = "密码:";
            this.labelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lgbt
            // 
            this.lgbt.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lgbt.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.lgbt.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            this.lgbt.Font = new System.Drawing.Font("钉钉进步体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lgbt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lgbt.Location = new System.Drawing.Point(213, 257);
            this.lgbt.Name = "lgbt";
            this.lgbt.Radius = 8;
            this.lgbt.Size = new System.Drawing.Size(152, 51);
            this.lgbt.TabIndex = 2;
            this.lgbt.Text = "登录";
            this.lgbt.TextCenterHasIcon = true;
            this.lgbt.Click += new System.EventHandler(this.lgbt_Click);
            // 
            // OSname
            // 
            this.OSname.BackColor = System.Drawing.SystemColors.Control;
            this.OSname.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OSname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.OSname.Location = new System.Drawing.Point(169, 44);
            this.OSname.Name = "OSname";
            this.OSname.Size = new System.Drawing.Size(329, 74);
            this.OSname.TabIndex = 3;
            this.OSname.Text = "仪器仪表管理系统";
            // 
            // txtus
            // 
            this.txtus.Font = new System.Drawing.Font("钉钉进步体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtus.Location = new System.Drawing.Point(189, 135);
            this.txtus.MaxLength = 16;
            this.txtus.Name = "txtus";
            this.txtus.PlaceholderText = "请输入";
            this.txtus.Size = new System.Drawing.Size(239, 50);
            this.txtus.TabIndex = 4;
            // 
            // txtpw
            // 
            this.txtpw.Font = new System.Drawing.Font("钉钉进步体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpw.Location = new System.Drawing.Point(189, 191);
            this.txtpw.MaxLength = 16;
            this.txtpw.Name = "txtpw";
            this.txtpw.PasswordChar = '*';
            this.txtpw.PasswordPaste = false;
            this.txtpw.PlaceholderText = "请输入";
            this.txtpw.Size = new System.Drawing.Size(239, 50);
            this.txtpw.TabIndex = 4;
            // 
            // closebutton1
            // 
            this.closebutton1.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.closebutton1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebutton1.Icon = global::f2winform.Properties.Resources.close;
            this.closebutton1.Location = new System.Drawing.Point(521, 3);
            this.closebutton1.Name = "closebutton1";
            this.closebutton1.Shape = AntdUI.TShape.Circle;
            this.closebutton1.Size = new System.Drawing.Size(37, 35);
            this.closebutton1.TabIndex = 5;
            this.closebutton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.Content = "Ver\\ 0\\.1\\.0";
            this.cuiLabel1.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.cuiLabel1.Location = new System.Drawing.Point(475, 327);
            this.cuiLabel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(81, 22);
            this.cuiLabel1.TabIndex = 6;
            this.cuiLabel1.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // Flogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(562, 353);
            this.Controls.Add(this.cuiLabel1);
            this.Controls.Add(this.closebutton1);
            this.Controls.Add(this.txtpw);
            this.Controls.Add(this.txtus);
            this.Controls.Add(this.OSname);
            this.Controls.Add(this.lgbt);
            this.Controls.Add(this.labelp);
            this.Controls.Add(this.labelu);
            this.Font = new System.Drawing.Font("钉钉进步体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "Flogin";
            this.Opacity = 0.96D;
            this.Radius = 12;
            this.Resizable = false;
            this.Shadow = 16;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Flogin_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label labelu;
        private AntdUI.Label labelp;
        private AntdUI.Button lgbt;
        private AntdUI.Label OSname;
        private AntdUI.Input txtus;
        private AntdUI.Input txtpw;
        private AntdUI.Button closebutton1;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
    }
}


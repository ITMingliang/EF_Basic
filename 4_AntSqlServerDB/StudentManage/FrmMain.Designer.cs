namespace StudentManage
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学员管理SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加学员AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学员管理MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级管理CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级管理MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.官网WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wwwantprogramingcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClassName = new System.Windows.Forms.Button();
            this.btnCourseManage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStuManage = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.学员管理SToolStripMenuItem,
            this.班级管理CToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.系统SToolStripMenuItem.Name = "系统SToolStripMenuItem";
            this.系统SToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.系统SToolStripMenuItem.Text = "系统（S）";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.退出EToolStripMenuItem.Text = "退出（E)";
            // 
            // 学员管理SToolStripMenuItem
            // 
            this.学员管理SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加学员AToolStripMenuItem,
            this.学员管理MToolStripMenuItem});
            this.学员管理SToolStripMenuItem.Name = "学员管理SToolStripMenuItem";
            this.学员管理SToolStripMenuItem.Size = new System.Drawing.Size(91, 21);
            this.学员管理SToolStripMenuItem.Text = "学员管理（S)";
            // 
            // 添加学员AToolStripMenuItem
            // 
            this.添加学员AToolStripMenuItem.Name = "添加学员AToolStripMenuItem";
            this.添加学员AToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加学员AToolStripMenuItem.Text = "添加学员（A)";
            this.添加学员AToolStripMenuItem.Click += new System.EventHandler(this.添加学员AToolStripMenuItem_Click);
            // 
            // 学员管理MToolStripMenuItem
            // 
            this.学员管理MToolStripMenuItem.Name = "学员管理MToolStripMenuItem";
            this.学员管理MToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.学员管理MToolStripMenuItem.Text = "学员管理（M）";
            this.学员管理MToolStripMenuItem.Click += new System.EventHandler(this.学员管理MToolStripMenuItem_Click);
            // 
            // 班级管理CToolStripMenuItem
            // 
            this.班级管理CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.班级管理MToolStripMenuItem});
            this.班级管理CToolStripMenuItem.Name = "班级管理CToolStripMenuItem";
            this.班级管理CToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.班级管理CToolStripMenuItem.Text = "班级管理（C)";
            // 
            // 班级管理MToolStripMenuItem
            // 
            this.班级管理MToolStripMenuItem.Name = "班级管理MToolStripMenuItem";
            this.班级管理MToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.班级管理MToolStripMenuItem.Text = "班级管理（M)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.官网WToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.帮助HToolStripMenuItem.Text = "帮助（H)";
            // 
            // 官网WToolStripMenuItem
            // 
            this.官网WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wwwantprogramingcomToolStripMenuItem});
            this.官网WToolStripMenuItem.Name = "官网WToolStripMenuItem";
            this.官网WToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.官网WToolStripMenuItem.Text = "官网（W）";
            // 
            // wwwantprogramingcomToolStripMenuItem
            // 
            this.wwwantprogramingcomToolStripMenuItem.Name = "wwwantprogramingcomToolStripMenuItem";
            this.wwwantprogramingcomToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.wwwantprogramingcomToolStripMenuItem.Text = "www.antprograming.com";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClassName);
            this.splitContainer1.Panel1.Controls.Add(this.btnCourseManage);
            this.splitContainer1.Panel1.Controls.Add(this.btnExit);
            this.splitContainer1.Panel1.Controls.Add(this.btnStuManage);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 704);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnClassName
            // 
            this.btnClassName.Location = new System.Drawing.Point(55, 238);
            this.btnClassName.Name = "btnClassName";
            this.btnClassName.Size = new System.Drawing.Size(89, 31);
            this.btnClassName.TabIndex = 3;
            this.btnClassName.Text = "班级管理";
            this.btnClassName.UseVisualStyleBackColor = true;
            this.btnClassName.Click += new System.EventHandler(this.btnClassName_Click);
            // 
            // btnCourseManage
            // 
            this.btnCourseManage.Location = new System.Drawing.Point(55, 313);
            this.btnCourseManage.Name = "btnCourseManage";
            this.btnCourseManage.Size = new System.Drawing.Size(89, 31);
            this.btnCourseManage.TabIndex = 2;
            this.btnCourseManage.Text = "课程管理";
            this.btnCourseManage.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(55, 396);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 31);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出系统";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStuManage
            // 
            this.btnStuManage.Location = new System.Drawing.Point(55, 167);
            this.btnStuManage.Name = "btnStuManage";
            this.btnStuManage.Size = new System.Drawing.Size(89, 31);
            this.btnStuManage.TabIndex = 0;
            this.btnStuManage.Text = "学员管理";
            this.btnStuManage.UseVisualStyleBackColor = true;
            this.btnStuManage.Click += new System.EventHandler(this.btnStuManage_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StudentManage.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(1184, 729);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学员管理系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学员管理SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加学员AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学员管理MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级管理CToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 班级管理MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 官网WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwwantprogramingcomToolStripMenuItem;
        private System.Windows.Forms.Button btnClassName;
        private System.Windows.Forms.Button btnCourseManage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStuManage;
    }
}
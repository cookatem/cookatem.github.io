namespace TheChristor {
    partial class App {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.TextField = new System.Windows.Forms.RichTextBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoreInfoPanel = new System.Windows.Forms.Panel();
            this.LocationField = new System.Windows.Forms.Label();
            this.TabsGroup = new System.Windows.Forms.Panel();
            this.FieldContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripFieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripFieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripFieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripFieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.MoreInfoPanel.SuspendLayout();
            this.FieldContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextField
            // 
            this.TextField.AcceptsTab = true;
            this.TextField.AutoWordSelection = true;
            this.TextField.BackColor = System.Drawing.Color.White;
            this.TextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextField.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(200)))));
            this.TextField.Location = new System.Drawing.Point(0, 54);
            this.TextField.Margin = new System.Windows.Forms.Padding(10);
            this.TextField.Name = "TextField";
            this.TextField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextField.Size = new System.Drawing.Size(805, 387);
            this.TextField.TabIndex = 1;
            this.TextField.Text = "";
            this.TextField.TextChanged += new System.EventHandler(this.TextFieldUpdate);
            this.TextField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RightClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.White;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(805, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += this.NewEmptyFile;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += OpenContentFromFile;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += SaveContentToFile;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += SaveContentToCurrentFile;
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += CloseContent;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyContent);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteContent);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutContent);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllContent);
            // 
            // MoreInfoPanel
            // 
            this.MoreInfoPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MoreInfoPanel.Controls.Add(this.LocationField);
            this.MoreInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MoreInfoPanel.Location = new System.Drawing.Point(0, 441);
            this.MoreInfoPanel.Name = "MoreInfoPanel";
            this.MoreInfoPanel.Size = new System.Drawing.Size(805, 18);
            this.MoreInfoPanel.TabIndex = 3;
            // 
            // LocationField
            // 
            this.LocationField.AutoSize = true;
            this.LocationField.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LocationField.Location = new System.Drawing.Point(6, 2);
            this.LocationField.Name = "LocationField";
            this.LocationField.Size = new System.Drawing.Size(43, 13);
            this.LocationField.TabIndex = 0;
            this.LocationField.Text = "Line 1";
            // 
            // TabsGroup
            // 
            this.TabsGroup.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TabsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabsGroup.Location = new System.Drawing.Point(0, 24);
            this.TabsGroup.Name = "TabsGroup";
            this.TabsGroup.Size = new System.Drawing.Size(805, 30);
            this.TabsGroup.TabIndex = 4;
            // 
            // FieldContextMenu
            // 
            this.FieldContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripFieldMenu,
            this.pasteToolStripFieldMenu,
            this.cutToolStripFieldMenu,
            this.selectAllToolStripFieldMenu});
            this.FieldContextMenu.Name = "ContextMenu";
            this.FieldContextMenu.Size = new System.Drawing.Size(123, 92);
            // 
            // copyToolStripFieldMenu
            // 
            this.copyToolStripFieldMenu.Name = "copyToolStripFieldMenu";
            this.copyToolStripFieldMenu.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripFieldMenu.Text = "Copy";
            this.copyToolStripFieldMenu.Click += new System.EventHandler(this.CopyContent);
            // 
            // pasteToolStripFieldMenu
            // 
            this.pasteToolStripFieldMenu.Name = "pasteToolStripFieldMenu";
            this.pasteToolStripFieldMenu.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripFieldMenu.Text = "Paste";
            this.pasteToolStripFieldMenu.Click += new System.EventHandler(this.PasteContent);
            // 
            // cutToolStripFieldMenu
            // 
            this.cutToolStripFieldMenu.Name = "cutToolStripFieldMenu";
            this.cutToolStripFieldMenu.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripFieldMenu.Text = "Cut";
            this.cutToolStripFieldMenu.Click += new System.EventHandler(this.CutContent);
            // 
            // selectAllToolStripFieldMenu
            // 
            this.selectAllToolStripFieldMenu.Name = "selectAllToolStripFieldMenu";
            this.selectAllToolStripFieldMenu.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripFieldMenu.Text = "Select All";
            this.selectAllToolStripFieldMenu.Click += new System.EventHandler(this.SelectAllContent);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(805, 459);
            this.Controls.Add(this.TextField);
            this.Controls.Add(this.TabsGroup);
            this.Controls.Add(this.MoreInfoPanel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "App";
            this.Text = "TheChristor";
            this.SizeChanged += new System.EventHandler(this.AppSizeChanged);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.MoreInfoPanel.ResumeLayout(false);
            this.MoreInfoPanel.PerformLayout();
            this.FieldContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox TextField;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Panel MoreInfoPanel;
        private System.Windows.Forms.Label LocationField;
        private System.Windows.Forms.Panel TabsGroup;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip FieldContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripFieldMenu;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripFieldMenu;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripFieldMenu;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripFieldMenu;
    }
}


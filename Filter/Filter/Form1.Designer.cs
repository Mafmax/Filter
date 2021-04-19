
namespace Filter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.filteredData = new System.Windows.Forms.GroupBox();
            this.data = new System.Windows.Forms.ListBox();
            this.filteredData.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterGroup
            // 
            this.filterGroup.Location = new System.Drawing.Point(16, 13);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(360, 60);
            this.filterGroup.TabIndex = 0;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Фильтры";
            this.filterGroup.Enter += new System.EventHandler(this.filterGroup_Enter);
            // 
            // filteredData
            // 
            this.filteredData.Controls.Add(this.data);
            this.filteredData.Location = new System.Drawing.Point(13, 79);
            this.filteredData.Name = "filteredData";
            this.filteredData.Size = new System.Drawing.Size(363, 326);
            this.filteredData.TabIndex = 1;
            this.filteredData.TabStop = false;
            this.filteredData.Text = "Данные";
            // 
            // data
            // 
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.FormattingEnabled = true;
            this.data.Location = new System.Drawing.Point(3, 16);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(357, 307);
            this.data.TabIndex = 0;
            this.data.SelectedIndexChanged += new System.EventHandler(this.data_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 450);
            this.Controls.Add(this.filteredData);
            this.Controls.Add(this.filterGroup);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.filteredData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.GroupBox filteredData;
        private System.Windows.Forms.ListBox data;
    }
}


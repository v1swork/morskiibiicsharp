namespace MORSKOIBI
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
            this.PanelPlayer = new System.Windows.Forms.Panel();
            this.PanelEnemy = new System.Windows.Forms.Panel();
            this.labelstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PanelPlayer
            // 
            this.PanelPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelPlayer.Location = new System.Drawing.Point(40, 59);
            this.PanelPlayer.Name = "PanelPlayer";
            this.PanelPlayer.Size = new System.Drawing.Size(320, 320);
            this.PanelPlayer.TabIndex = 0;
            // 
            // PanelEnemy
            // 
            this.PanelEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEnemy.Location = new System.Drawing.Point(442, 59);
            this.PanelEnemy.Name = "PanelEnemy";
            this.PanelEnemy.Size = new System.Drawing.Size(320, 320);
            this.PanelEnemy.TabIndex = 1;
            // 
            // labelstatus
            // 
            this.labelstatus.AutoSize = true;
            this.labelstatus.Location = new System.Drawing.Point(364, 27);
            this.labelstatus.Name = "labelstatus";
            this.labelstatus.Size = new System.Drawing.Size(80, 13);
            this.labelstatus.TabIndex = 2;
            this.labelstatus.Text = "ХОД: ИГРОКА";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelstatus);
            this.Controls.Add(this.PanelEnemy);
            this.Controls.Add(this.PanelPlayer);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской Бiй";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelPlayer;
        private System.Windows.Forms.Panel PanelEnemy;
        private System.Windows.Forms.Label labelstatus;
    }
}


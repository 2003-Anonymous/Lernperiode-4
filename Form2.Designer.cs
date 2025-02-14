namespace LP_4_Wegwerfprojekt
{
    partial class Map
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
            back_btn = new Button();
            SuspendLayout();
            // 
            // back_btn
            // 
            back_btn.Location = new Point(17, 9);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(112, 34);
            back_btn.TabIndex = 0;
            back_btn.Text = "Back";
            back_btn.UseVisualStyleBackColor = true;
            back_btn.Click += back_btn_Click;
            // 
            // Map
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(back_btn);
            Name = "Map";
            Text = "Level 1";
            ResumeLayout(false);
        }

        #endregion

        private Button back_btn;
    }
}
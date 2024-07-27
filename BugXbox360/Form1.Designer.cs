namespace BugXbox360
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.main_timer = new System.Windows.Forms.Timer(this.components);
            this.headlight_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lobby_textbox = new System.Windows.Forms.TextBox();
            this.apply_button = new System.Windows.Forms.Button();
            this.headlight_anim1_timer = new System.Windows.Forms.Timer(this.components);
            this.lobby_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // main_timer
            // 
            this.main_timer.Interval = 1;
            this.main_timer.Tick += new System.EventHandler(this.main_run_Tick);
            // 
            // headlight_textbox
            // 
            this.headlight_textbox.Location = new System.Drawing.Point(131, 6);
            this.headlight_textbox.Name = "headlight_textbox";
            this.headlight_textbox.Size = new System.Drawing.Size(41, 20);
            this.headlight_textbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Headlight Trigger(ms) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lobby Trigger(ms) :";
            // 
            // lobby_textbox
            // 
            this.lobby_textbox.Location = new System.Drawing.Point(131, 34);
            this.lobby_textbox.Name = "lobby_textbox";
            this.lobby_textbox.Size = new System.Drawing.Size(41, 20);
            this.lobby_textbox.TabIndex = 2;
            // 
            // apply_button
            // 
            this.apply_button.Location = new System.Drawing.Point(97, 60);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(75, 23);
            this.apply_button.TabIndex = 4;
            this.apply_button.Text = "Apply";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.apply_button_Click);
            // 
            // headlight_anim1_timer
            // 
            this.headlight_anim1_timer.Tick += new System.EventHandler(this.headlight_anim1_timer_Tick);
            // 
            // lobby_timer
            // 
            this.lobby_timer.Tick += new System.EventHandler(this.lobby_timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 101);
            this.Controls.Add(this.apply_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lobby_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headlight_textbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer main_timer;
        private System.Windows.Forms.TextBox headlight_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lobby_textbox;
        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.Timer headlight_anim1_timer;
        private System.Windows.Forms.Timer lobby_timer;
    }
}


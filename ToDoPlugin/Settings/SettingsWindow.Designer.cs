namespace ToDoPlugin.Settings {
	partial class SettingsWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.StgsContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.CloseWindow = new System.Windows.Forms.Button();
			this.PresetName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// StgsContainer
			// 
			this.StgsContainer.AutoScroll = true;
			this.StgsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StgsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.StgsContainer.Location = new System.Drawing.Point(12, 12);
			this.StgsContainer.Name = "StgsContainer";
			this.StgsContainer.Size = new System.Drawing.Size(274, 426);
			this.StgsContainer.TabIndex = 8;
			this.StgsContainer.WrapContents = false;
			// 
			// CloseWindow
			// 
			this.CloseWindow.Location = new System.Drawing.Point(686, 408);
			this.CloseWindow.Name = "CloseWindow";
			this.CloseWindow.Size = new System.Drawing.Size(102, 30);
			this.CloseWindow.TabIndex = 9;
			this.CloseWindow.Text = "Закрыть";
			this.CloseWindow.UseVisualStyleBackColor = true;
			this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
			// 
			// PresetName
			// 
			this.PresetName.AutoSize = true;
			this.PresetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PresetName.Location = new System.Drawing.Point(293, 13);
			this.PresetName.Name = "PresetName";
			this.PresetName.Size = new System.Drawing.Size(188, 24);
			this.PresetName.TabIndex = 10;
			this.PresetName.Text = "Выберите элемент:";
			// 
			// SettingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.PresetName);
			this.Controls.Add(this.CloseWindow);
			this.Controls.Add(this.StgsContainer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "ToDo Highlight: Настройки";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel StgsContainer;
		private System.Windows.Forms.Button CloseWindow;
		private System.Windows.Forms.Label PresetName;
	}
}
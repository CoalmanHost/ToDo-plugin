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
			this.PresetActive = new System.Windows.Forms.CheckBox();
			this.PresetColor = new System.Windows.Forms.PictureBox();
			this.PresetChangeColor = new System.Windows.Forms.Button();
			this.PresetColorSelectDialog = new System.Windows.Forms.ColorDialog();
			this.LeftBackground = new System.Windows.Forms.Panel();
			this.CreateNewPresetButton = new System.Windows.Forms.Button();
			this.RightBackground = new System.Windows.Forms.Panel();
			this.SavePresetNameButton = new System.Windows.Forms.Button();
			this.PresetNameBox = new System.Windows.Forms.TextBox();
			this.PresetNameChangeButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PresetColor)).BeginInit();
			this.LeftBackground.SuspendLayout();
			this.RightBackground.SuspendLayout();
			this.SuspendLayout();
			// 
			// StgsContainer
			// 
			this.StgsContainer.AutoScroll = true;
			this.StgsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StgsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.StgsContainer.Location = new System.Drawing.Point(12, 12);
			this.StgsContainer.Name = "StgsContainer";
			this.StgsContainer.Size = new System.Drawing.Size(274, 405);
			this.StgsContainer.TabIndex = 8;
			this.StgsContainer.WrapContents = false;
			// 
			// CloseWindow
			// 
			this.CloseWindow.Location = new System.Drawing.Point(198, 408);
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
			this.PresetName.Location = new System.Drawing.Point(5, 12);
			this.PresetName.Name = "PresetName";
			this.PresetName.Size = new System.Drawing.Size(188, 24);
			this.PresetName.TabIndex = 10;
			this.PresetName.Text = "Выберите элемент:";
			// 
			// PresetActive
			// 
			this.PresetActive.AutoSize = true;
			this.PresetActive.Location = new System.Drawing.Point(9, 71);
			this.PresetActive.Name = "PresetActive";
			this.PresetActive.Size = new System.Drawing.Size(71, 17);
			this.PresetActive.TabIndex = 11;
			this.PresetActive.Text = "Включён";
			this.PresetActive.UseVisualStyleBackColor = true;
			this.PresetActive.Visible = false;
			this.PresetActive.CheckedChanged += new System.EventHandler(this.PresetActive_CheckedChanged);
			// 
			// PresetColor
			// 
			this.PresetColor.Location = new System.Drawing.Point(9, 106);
			this.PresetColor.Name = "PresetColor";
			this.PresetColor.Size = new System.Drawing.Size(40, 40);
			this.PresetColor.TabIndex = 12;
			this.PresetColor.TabStop = false;
			// 
			// PresetChangeColor
			// 
			this.PresetChangeColor.Location = new System.Drawing.Point(55, 116);
			this.PresetChangeColor.Name = "PresetChangeColor";
			this.PresetChangeColor.Size = new System.Drawing.Size(138, 30);
			this.PresetChangeColor.TabIndex = 13;
			this.PresetChangeColor.Text = "Выбрать цвет";
			this.PresetChangeColor.UseVisualStyleBackColor = true;
			this.PresetChangeColor.Visible = false;
			this.PresetChangeColor.Click += new System.EventHandler(this.PresetChangeColor_Click);
			// 
			// PresetColorSelectDialog
			// 
			this.PresetColorSelectDialog.Color = System.Drawing.Color.LimeGreen;
			// 
			// LeftBackground
			// 
			this.LeftBackground.Controls.Add(this.CreateNewPresetButton);
			this.LeftBackground.Controls.Add(this.StgsContainer);
			this.LeftBackground.Location = new System.Drawing.Point(0, 0);
			this.LeftBackground.Name = "LeftBackground";
			this.LeftBackground.Size = new System.Drawing.Size(291, 454);
			this.LeftBackground.TabIndex = 14;
			// 
			// CreateNewPresetButton
			// 
			this.CreateNewPresetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CreateNewPresetButton.Location = new System.Drawing.Point(12, 423);
			this.CreateNewPresetButton.Name = "CreateNewPresetButton";
			this.CreateNewPresetButton.Size = new System.Drawing.Size(25, 25);
			this.CreateNewPresetButton.TabIndex = 9;
			this.CreateNewPresetButton.Text = "+";
			this.CreateNewPresetButton.UseVisualStyleBackColor = true;
			this.CreateNewPresetButton.Click += new System.EventHandler(this.CreateNewPresetButton_Click);
			// 
			// RightBackground
			// 
			this.RightBackground.Controls.Add(this.SavePresetNameButton);
			this.RightBackground.Controls.Add(this.PresetNameBox);
			this.RightBackground.Controls.Add(this.PresetNameChangeButton);
			this.RightBackground.Controls.Add(this.label1);
			this.RightBackground.Controls.Add(this.PresetName);
			this.RightBackground.Controls.Add(this.CloseWindow);
			this.RightBackground.Controls.Add(this.PresetColor);
			this.RightBackground.Controls.Add(this.PresetChangeColor);
			this.RightBackground.Controls.Add(this.PresetActive);
			this.RightBackground.Location = new System.Drawing.Point(292, 0);
			this.RightBackground.Name = "RightBackground";
			this.RightBackground.Size = new System.Drawing.Size(316, 454);
			this.RightBackground.TabIndex = 15;
			// 
			// SavePresetNameButton
			// 
			this.SavePresetNameButton.Location = new System.Drawing.Point(199, 6);
			this.SavePresetNameButton.Name = "SavePresetNameButton";
			this.SavePresetNameButton.Size = new System.Drawing.Size(101, 30);
			this.SavePresetNameButton.TabIndex = 17;
			this.SavePresetNameButton.Text = "Сохранить";
			this.SavePresetNameButton.UseVisualStyleBackColor = true;
			this.SavePresetNameButton.Visible = false;
			this.SavePresetNameButton.Click += new System.EventHandler(this.SavePresetNameButton_Click);
			// 
			// PresetNameBox
			// 
			this.PresetNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PresetNameBox.Location = new System.Drawing.Point(9, 10);
			this.PresetNameBox.Name = "PresetNameBox";
			this.PresetNameBox.Size = new System.Drawing.Size(184, 26);
			this.PresetNameBox.TabIndex = 16;
			this.PresetNameBox.Visible = false;
			// 
			// PresetNameChangeButton
			// 
			this.PresetNameChangeButton.Location = new System.Drawing.Point(199, 6);
			this.PresetNameChangeButton.Name = "PresetNameChangeButton";
			this.PresetNameChangeButton.Size = new System.Drawing.Size(101, 30);
			this.PresetNameChangeButton.TabIndex = 15;
			this.PresetNameChangeButton.Text = "Изменить";
			this.PresetNameChangeButton.UseVisualStyleBackColor = true;
			this.PresetNameChangeButton.Visible = false;
			this.PresetNameChangeButton.Click += new System.EventHandler(this.PresetNameChangeButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(62, 379);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 26);
			this.label1.TabIndex = 14;
			this.label1.Text = "Некоторые изменения вступят в силу после \r\nперезагрузки проекта";
			// 
			// SettingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 450);
			this.Controls.Add(this.LeftBackground);
			this.Controls.Add(this.RightBackground);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "ToDo Highlight: Настройки";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsWindow_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.PresetColor)).EndInit();
			this.LeftBackground.ResumeLayout(false);
			this.RightBackground.ResumeLayout(false);
			this.RightBackground.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel StgsContainer;
		private System.Windows.Forms.Button CloseWindow;
		private System.Windows.Forms.Label PresetName;
		private System.Windows.Forms.CheckBox PresetActive;
		private System.Windows.Forms.PictureBox PresetColor;
		private System.Windows.Forms.Button PresetChangeColor;
		private System.Windows.Forms.ColorDialog PresetColorSelectDialog;
		private System.Windows.Forms.Panel LeftBackground;
		private System.Windows.Forms.Panel RightBackground;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button CreateNewPresetButton;
		private System.Windows.Forms.Button PresetNameChangeButton;
		private System.Windows.Forms.TextBox PresetNameBox;
		private System.Windows.Forms.Button SavePresetNameButton;
	}
}
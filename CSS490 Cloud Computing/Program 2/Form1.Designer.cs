namespace Program2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.locationPlaceholder = new System.Windows.Forms.Label();
            this.temperature = new System.Windows.Forms.Label();
            this.Humidity = new System.Windows.Forms.Label();
            this.tempMax = new System.Windows.Forms.Label();
            this.tempMin = new System.Windows.Forms.Label();
            this.country = new System.Windows.Forms.Label();
            this.Condition = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConditionDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min_Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HumidityDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitutde = new System.Windows.Forms.Label();
            this.latitude = new System.Windows.Forms.Label();
            this.Sunrise = new System.Windows.Forms.Label();
            this.Sunset = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.changeCity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationPlaceholder
            // 
            this.locationPlaceholder.AutoSize = true;
            this.locationPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationPlaceholder.Location = new System.Drawing.Point(14, 14);
            this.locationPlaceholder.Name = "locationPlaceholder";
            this.locationPlaceholder.Size = new System.Drawing.Size(173, 46);
            this.locationPlaceholder.TabIndex = 0;
            this.locationPlaceholder.Text = "Location";
            // 
            // temperature
            // 
            this.temperature.AutoSize = true;
            this.temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.temperature.Location = new System.Drawing.Point(415, 45);
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(147, 55);
            this.temperature.TabIndex = 1;
            this.temperature.Text = "Temp";
            // 
            // Humidity
            // 
            this.Humidity.AutoSize = true;
            this.Humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Humidity.Location = new System.Drawing.Point(602, 45);
            this.Humidity.Name = "Humidity";
            this.Humidity.Size = new System.Drawing.Size(87, 25);
            this.Humidity.TabIndex = 2;
            this.Humidity.Text = "Humidity";
            // 
            // tempMax
            // 
            this.tempMax.AutoSize = true;
            this.tempMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempMax.Location = new System.Drawing.Point(602, 70);
            this.tempMax.Name = "tempMax";
            this.tempMax.Size = new System.Drawing.Size(93, 25);
            this.tempMax.TabIndex = 3;
            this.tempMax.Text = "tempMax";
            // 
            // tempMin
            // 
            this.tempMin.AutoSize = true;
            this.tempMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempMin.Location = new System.Drawing.Point(602, 95);
            this.tempMin.Name = "tempMin";
            this.tempMin.Size = new System.Drawing.Size(87, 25);
            this.tempMin.TabIndex = 4;
            this.tempMin.Text = "tempMin";
            // 
            // country
            // 
            this.country.AutoSize = true;
            this.country.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.country.Location = new System.Drawing.Point(14, 65);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(160, 46);
            this.country.TabIndex = 5;
            this.country.Text = "Country";
            // 
            // Condition
            // 
            this.Condition.AutoSize = true;
            this.Condition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Condition.Location = new System.Drawing.Point(416, 96);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(164, 25);
            this.Condition.TabIndex = 6;
            this.Condition.Text = "weatherCondition";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.ConditionDay,
            this.Max_Temp,
            this.Min_Temp,
            this.HumidityDay});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(22, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(766, 260);
            this.dataGridView1.TabIndex = 7;
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            this.Day.Width = 51;
            // 
            // ConditionDay
            // 
            this.ConditionDay.HeaderText = "Condition";
            this.ConditionDay.Name = "ConditionDay";
            this.ConditionDay.ReadOnly = true;
            this.ConditionDay.Width = 76;
            // 
            // Max_Temp
            // 
            this.Max_Temp.HeaderText = "Max Temp.";
            this.Max_Temp.Name = "Max_Temp";
            this.Max_Temp.ReadOnly = true;
            this.Max_Temp.Width = 85;
            // 
            // Min_Temp
            // 
            this.Min_Temp.HeaderText = "Min. Temp.";
            this.Min_Temp.Name = "Min_Temp";
            this.Min_Temp.ReadOnly = true;
            this.Min_Temp.Width = 85;
            // 
            // HumidityDay
            // 
            this.HumidityDay.HeaderText = "Humidity";
            this.HumidityDay.Name = "HumidityDay";
            this.HumidityDay.ReadOnly = true;
            this.HumidityDay.Width = 72;
            // 
            // longitutde
            // 
            this.longitutde.AutoSize = true;
            this.longitutde.Location = new System.Drawing.Point(19, 115);
            this.longitutde.Name = "longitutde";
            this.longitutde.Size = new System.Drawing.Size(54, 13);
            this.longitutde.TabIndex = 9;
            this.longitutde.Text = "Longitude";
            // 
            // latitude
            // 
            this.latitude.AutoSize = true;
            this.latitude.Location = new System.Drawing.Point(19, 128);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(45, 13);
            this.latitude.TabIndex = 10;
            this.latitude.Text = "Latitude";
            // 
            // Sunrise
            // 
            this.Sunrise.AutoSize = true;
            this.Sunrise.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sunrise.Location = new System.Drawing.Point(602, 117);
            this.Sunrise.Name = "Sunrise";
            this.Sunrise.Size = new System.Drawing.Size(79, 25);
            this.Sunrise.TabIndex = 11;
            this.Sunrise.Text = "Sunrise";
            // 
            // Sunset
            // 
            this.Sunset.AutoSize = true;
            this.Sunset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sunset.Location = new System.Drawing.Point(602, 139);
            this.Sunset.Name = "Sunset";
            this.Sunset.Size = new System.Drawing.Size(74, 25);
            this.Sunset.TabIndex = 12;
            this.Sunset.Text = "Sunset";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeCity);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(411, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 155);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Weather";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 283);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Forecast";
            // 
            // changeCity
            // 
            this.changeCity.Location = new System.Drawing.Point(268, 0);
            this.changeCity.Name = "changeCity";
            this.changeCity.Size = new System.Drawing.Size(109, 27);
            this.changeCity.TabIndex = 15;
            this.changeCity.Text = "Change City";
            this.changeCity.UseVisualStyleBackColor = true;
            this.changeCity.Click += new System.EventHandler(this.changeCity_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Sunset);
            this.Controls.Add(this.Sunrise);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.longitutde);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Condition);
            this.Controls.Add(this.country);
            this.Controls.Add(this.tempMin);
            this.Controls.Add(this.tempMax);
            this.Controls.Add(this.Humidity);
            this.Controls.Add(this.temperature);
            this.Controls.Add(this.locationPlaceholder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Weather";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationPlaceholder;
        private System.Windows.Forms.Label temperature;
        private System.Windows.Forms.Label Humidity;
        private System.Windows.Forms.Label tempMax;
        private System.Windows.Forms.Label tempMin;
        private System.Windows.Forms.Label country;
        private System.Windows.Forms.Label Condition;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConditionDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min_Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn HumidityDay;
        private System.Windows.Forms.Label longitutde;
        private System.Windows.Forms.Label latitude;
        private System.Windows.Forms.Label Sunrise;
        private System.Windows.Forms.Label Sunset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button changeCity;
    }
}


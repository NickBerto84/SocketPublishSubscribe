namespace SocketBasedPublisher
{
    partial class Publisher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTopicName = new System.Windows.Forms.Label();
            this.labelEventData = new System.Windows.Forms.Label();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.txtEventData = new System.Windows.Forms.TextBox();
            this.btnSingleEventFire = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAutoFireStop = new System.Windows.Forms.Button();
            this.btnAutoFire = new System.Windows.Forms.Button();
            this.labelTotalEvents = new System.Windows.Forms.Label();
            this.txtEventCount = new System.Windows.Forms.TextBox();
            this.tmrEvent = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTopicName
            // 
            this.labelTopicName.AutoSize = true;
            this.labelTopicName.Location = new System.Drawing.Point(44, 62);
            this.labelTopicName.Name = "labelTopicName";
            this.labelTopicName.Size = new System.Drawing.Size(70, 15);
            this.labelTopicName.TabIndex = 0;
            this.labelTopicName.Text = "Topic Name";
            // 
            // labelEventData
            // 
            this.labelEventData.AutoSize = true;
            this.labelEventData.Location = new System.Drawing.Point(44, 117);
            this.labelEventData.Name = "labelEventData";
            this.labelEventData.Size = new System.Drawing.Size(63, 15);
            this.labelEventData.TabIndex = 1;
            this.labelEventData.Text = "Event Data";
            // 
            // txtTopicName
            // 
            this.txtTopicName.Location = new System.Drawing.Point(152, 54);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(100, 23);
            this.txtTopicName.TabIndex = 2;
            // 
            // txtEventData
            // 
            this.txtEventData.Location = new System.Drawing.Point(152, 105);
            this.txtEventData.Multiline = true;
            this.txtEventData.Name = "txtEventData";
            this.txtEventData.Size = new System.Drawing.Size(177, 132);
            this.txtEventData.TabIndex = 3;
            // 
            // btnSingleEventFire
            // 
            this.btnSingleEventFire.Location = new System.Drawing.Point(417, 54);
            this.btnSingleEventFire.Name = "btnSingleEventFire";
            this.btnSingleEventFire.Size = new System.Drawing.Size(200, 23);
            this.btnSingleEventFire.TabIndex = 4;
            this.btnSingleEventFire.Text = "Single Event Fire";
            this.btnSingleEventFire.UseVisualStyleBackColor = true;
            this.btnSingleEventFire.Click += new System.EventHandler(this.BtnSingleEventFire_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAutoFireStop);
            this.groupBox1.Controls.Add(this.btnAutoFire);
            this.groupBox1.Location = new System.Drawing.Point(417, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 153);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AutoEvent";
            // 
            // btnAutoFireStop
            // 
            this.btnAutoFireStop.Location = new System.Drawing.Point(31, 65);
            this.btnAutoFireStop.Name = "btnAutoFireStop";
            this.btnAutoFireStop.Size = new System.Drawing.Size(139, 23);
            this.btnAutoFireStop.TabIndex = 7;
            this.btnAutoFireStop.Text = "Stop";
            this.btnAutoFireStop.UseVisualStyleBackColor = true;
            this.btnAutoFireStop.Click += new System.EventHandler(this.BtnAutoFireStop_Click);
            // 
            // btnAutoFire
            // 
            this.btnAutoFire.Location = new System.Drawing.Point(33, 22);
            this.btnAutoFire.Name = "btnAutoFire";
            this.btnAutoFire.Size = new System.Drawing.Size(139, 23);
            this.btnAutoFire.TabIndex = 6;
            this.btnAutoFire.Text = "Auto Event Fire";
            this.btnAutoFire.UseVisualStyleBackColor = true;
            this.btnAutoFire.Click += new System.EventHandler(this.BtnAutoFire_Click);
            // 
            // labelTotalEvents
            // 
            this.labelTotalEvents.AutoSize = true;
            this.labelTotalEvents.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotalEvents.Location = new System.Drawing.Point(369, 282);
            this.labelTotalEvents.Name = "labelTotalEvents";
            this.labelTotalEvents.Size = new System.Drawing.Size(111, 15);
            this.labelTotalEvents.TabIndex = 6;
            this.labelTotalEvents.Text = "Total Events  Fired:";
            // 
            // txtEventCount
            // 
            this.txtEventCount.Location = new System.Drawing.Point(517, 279);
            this.txtEventCount.Name = "txtEventCount";
            this.txtEventCount.Size = new System.Drawing.Size(100, 23);
            this.txtEventCount.TabIndex = 7;
            // 
            // tmrEvent
            // 
            this.tmrEvent.Tick += new System.EventHandler(this.TmrEvent_Tick);
            // 
            // Publisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.txtEventCount);
            this.Controls.Add(this.labelTotalEvents);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSingleEventFire);
            this.Controls.Add(this.txtEventData);
            this.Controls.Add(this.txtTopicName);
            this.Controls.Add(this.labelEventData);
            this.Controls.Add(this.labelTopicName);
            this.Name = "Publisher";
            this.Text = "Publisher";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelTopicName;
        private Label labelEventData;
        private TextBox txtTopicName;
        private TextBox txtEventData;
        private Button btnSingleEventFire;
        private GroupBox groupBox1;
        private Button btnAutoFireStop;
        private Button btnAutoFire;
        private Label labelTotalEvents;
        private TextBox txtEventCount;
        private System.Windows.Forms.Timer tmrEvent;
    }
}
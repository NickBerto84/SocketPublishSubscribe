namespace SocketBasedSubscriber
{
    partial class Subscriber
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
            this.btnClearListView = new System.Windows.Forms.Button();
            this.labelEventsReceivedServer = new System.Windows.Forms.Label();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.labelTopicName = new System.Windows.Forms.Label();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClearListView
            // 
            this.btnClearListView.Location = new System.Drawing.Point(371, 349);
            this.btnClearListView.Name = "btnClearListView";
            this.btnClearListView.Size = new System.Drawing.Size(75, 23);
            this.btnClearListView.TabIndex = 0;
            this.btnClearListView.Text = "Clear List";
            this.btnClearListView.UseVisualStyleBackColor = true;
            this.btnClearListView.Click += new System.EventHandler(this.BtnClearListView_Click);
            // 
            // labelEventsReceivedServer
            // 
            this.labelEventsReceivedServer.AutoSize = true;
            this.labelEventsReceivedServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEventsReceivedServer.ForeColor = System.Drawing.Color.Navy;
            this.labelEventsReceivedServer.Location = new System.Drawing.Point(12, 69);
            this.labelEventsReceivedServer.Name = "labelEventsReceivedServer";
            this.labelEventsReceivedServer.Size = new System.Drawing.Size(157, 15);
            this.labelEventsReceivedServer.TabIndex = 1;
            this.labelEventsReceivedServer.Text = "Events Received Server";
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Location = new System.Drawing.Point(175, 25);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(93, 23);
            this.btnUnsubscribe.TabIndex = 2;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Visible = false;
            this.btnUnsubscribe.Click += new System.EventHandler(this.BtnUnsubscribe_Click);
            // 
            // labelTopicName
            // 
            this.labelTopicName.AutoSize = true;
            this.labelTopicName.Location = new System.Drawing.Point(290, 29);
            this.labelTopicName.Name = "labelTopicName";
            this.labelTopicName.Size = new System.Drawing.Size(70, 15);
            this.labelTopicName.TabIndex = 3;
            this.labelTopicName.Text = "Topic Name";
            // 
            // txtTopicName
            // 
            this.txtTopicName.Location = new System.Drawing.Point(371, 26);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(100, 23);
            this.txtTopicName.TabIndex = 4;
            // 
            // lstEvents
            // 
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstEvents.GridLines = true;
            this.lstEvents.Location = new System.Drawing.Point(175, 69);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(470, 265);
            this.lstEvents.TabIndex = 5;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item #";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Topic Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Event Data";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 300;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(175, 26);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(93, 23);
            this.btnSubscribe.TabIndex = 6;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.BtnSubscribe_Click);
            // 
            // Subscriber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 381);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.txtTopicName);
            this.Controls.Add(this.labelTopicName);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.labelEventsReceivedServer);
            this.Controls.Add(this.btnClearListView);
            this.Name = "Subscriber";
            this.Text = "Subscriber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnClearListView;
        private Label labelEventsReceivedServer;
        private Button btnUnsubscribe;
        private Label labelTopicName;
        private TextBox txtTopicName;
        private ListView lstEvents;
        private Button btnSubscribe;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
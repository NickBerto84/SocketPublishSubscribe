using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketBasedSubscriber
{
    public partial class Subscriber : Form
    {
        #region delegates

        public delegate void AddToTextBoxDelegate(string message);

        #endregion delegates

        #region members

        Socket _client;
        EndPoint _remoteEndPoint;
        byte[] _data;
        int _recv;
        bool _isReceivingStarted = false;

        #endregion members

        public Subscriber()
        {
            InitializeComponent();

            string serverIP = ConfigurationManager.AppSettings["ServerIP"];
            IPAddress serverIPAddress = IPAddress.Parse(serverIP);
            int serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //_client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Tcp);
            _remoteEndPoint = new IPEndPoint(serverIPAddress, serverPort);

            txtTopicName.Text = "Nick";
        }

        #region private methods

        /// <summary>
        /// This method handles the server data receiving.
        /// </summary>
        private void ReceiveDataFromServer()
        {
            EndPoint publisherEndPoint = _client.LocalEndPoint;
            while (true)
            {
                _recv = _client.ReceiveFrom(_data, ref publisherEndPoint);
                string msg = Encoding.ASCII.GetString(_data, 0, _recv) + "," + publisherEndPoint.ToString();
                lstEvents.Invoke(new AddToTextBoxDelegate(AddToTextBox), msg);
            }
        }

        /// <summary>
        /// This method handles the event add action to the list view.
        /// </summary>
        /// <param name="message"></param>
        public void AddToTextBox(string message)
        {
            string[] messageParts = message.Split(",".ToCharArray());
            int itemNum = (lstEvents.Items.Count < 1) ? 0 : lstEvents.Items.Count;
            lstEvents.Items.Add(itemNum.ToString());
            lstEvents.Items[itemNum].SubItems.AddRange(new string[] { messageParts[0], messageParts[1], messageParts[2] });
        }

        /// <summary>
        /// This method handles the list view clearing action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearListView_Click(object sender, EventArgs e)
        {
            lstEvents.Items.Clear();
        }

        /// <summary>
        /// This method handles the unsubscribtion click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                string topicName = txtTopicName.Text.Trim();
                if (string.IsNullOrEmpty(topicName))
                {
                    MessageBox.Show("Please Enter a Topic Name");
                    return;
                }
                string command = "UnSubscribe";

                string message = command + "," + topicName;
                _client.SendTo(Encoding.ASCII.GetBytes(message), _remoteEndPoint);
                ((Button)sender).Visible = false;
                btnSubscribe.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please Enter a Topic Name {ex.Message}");
            }
        }

        /// <summary>
        /// This method handles the subscribtion click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubscribe_Click(object sender, EventArgs e)
        {
            string topicName = txtTopicName.Text.Trim();
            if (string.IsNullOrEmpty(topicName))
            {
                MessageBox.Show("Please Enter a Topic Name");
                return;
            }
            ((Button)sender).Visible = false;
            btnUnsubscribe.Visible = true;

            string Command = "Subscribe";

            string message = Command + "," + topicName;
            _client.SendTo(Encoding.ASCII.GetBytes(message), _remoteEndPoint);

            if (_isReceivingStarted == false)
            {
                _isReceivingStarted = true;
                _data = new byte[1024];
                Thread thread1 = new Thread(new ThreadStart(ReceiveDataFromServer));
                thread1.IsBackground = true;
                thread1.Start();
            }
        }

        #endregion private methods
    }
}
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketBasedPublisher
{
    public partial class Publisher : Form
    {
        #region members

        Socket _client;
        EndPoint _remoteEndPoint;
        int _noOfEventsFired = 0;
        string _command = "Publish";

        #endregion members

        #region private methods

        /// <summary>
        /// This method handles the single event firing action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSingleEventFire_Click(object sender, EventArgs e)
        {
            string topicName = txtTopicName.Text.Trim();
            if (string.IsNullOrEmpty(topicName))
            {
                MessageBox.Show("Please Enter a Topic Name");
                return;
            }
            SendASingleEvent();
        }

        /// <summary>
        /// This method handles the single event sending.
        /// </summary>
        private void SendASingleEvent()
        {
            String topicName = txtTopicName.Text;
            string eventData = txtEventData.Text;
            string message = _command + "," + topicName + "," + eventData;
            _client.SendTo(Encoding.ASCII.GetBytes(message), _remoteEndPoint);
            _noOfEventsFired++;
            txtEventCount.Text = _noOfEventsFired.ToString();
        }

        /// <summary>
        /// This method handles the timer event tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrEvent_Tick(object sender, EventArgs e)
        {
            SendASingleEvent();
        }

        /// <summary>
        /// This method handles the automatic event firing stop action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAutoFireStop_Click(object sender, EventArgs e)
        {
            if (tmrEvent.Enabled)
                tmrEvent.Enabled = false;
        }

        /// <summary>
        /// This method handles the automatic event firing action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAutoFire_Click(object sender, EventArgs e)
        {
            string topicName = txtTopicName.Text.Trim();
            if (string.IsNullOrEmpty(topicName))
            {
                MessageBox.Show("Please Enter a Topic Name");
                return;
            }
            int interval = 1000;
            tmrEvent.Interval = interval;
            tmrEvent.Enabled = true;
        }

        #endregion private methods

        public Publisher()
        {
            InitializeComponent();
            txtEventData.Text = "Message to publish";

            string serverIP = ConfigurationManager.AppSettings["ServerIP"];
            IPAddress serverIPAddress = IPAddress.Parse(serverIP);
            int serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);

            _client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //_client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Tcp);
            _remoteEndPoint = new IPEndPoint(serverIPAddress, serverPort);

            txtTopicName.Text = "Nick";
            txtEventCount.Text = "0";
        }
    }
}
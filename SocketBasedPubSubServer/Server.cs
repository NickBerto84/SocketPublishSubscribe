namespace SocketBasedPubSubServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            HostPublishSubscribeServices();
        }

        private static void HostPublishSubscribeServices()
        {
            SubscriberService subscriberService = new SubscriberService();
            subscriberService.StartSubscriberService();

            PublisherService publisherService = new PublisherService();
            publisherService.StartPublisherService();
        }
    }
}
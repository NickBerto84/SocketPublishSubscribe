﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketBasedPubSubServer
{
    /// <summary>
    /// This class defines the publisher service.
    /// </summary>
    internal class PublisherService
    {
        #region private methods

        /// <summary>
        /// This method handles the publisher service hosting.
        /// </summary>
        private void HostPublisherService()
        {
            IPAddress ipV4 = IPAddress.Parse("127.0.0.1");// ReturnMachineIP(); if you need machine ip then use this method.            
            IPEndPoint localEP = new IPEndPoint(ipV4, 10002);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(localEP);
            StartListening(server);
        }

        /// <summary>
        /// This method returns the machine IP address.
        /// </summary>
        /// <returns></returns>
        private static IPAddress ReturnMachineIP()
        {
            String hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addr = ipEntry.AddressList;
            IPAddress ipV4 = null;
            foreach (IPAddress item in addr)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipV4 = item;
                    break;
                }
            }
            if (ipV4 == null)
            {
                MessageBox.Show("You have no IP of Version 4. Server can not run witout it!!!");
                Application.Exit();
            }
            return ipV4;
        }

        /// <summary>
        /// This method handles the socket server start listening.
        /// </summary>
        /// <param name="server">Socket server</param>
        private static void StartListening(Socket server)
        {
            EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            int recv = 0;
            byte[] data = new byte[1024];
            while (true)
            {
                try
                {
                    recv = 0;
                    data = new byte[1024];
                    recv = server.ReceiveFrom(data, ref remoteEP);
                    string messageSendFromClient = Encoding.ASCII.GetString(data, 0, recv);
                    string[] messageParts = messageSendFromClient.Split(",".ToCharArray());
                    String command = messageParts[0];
                    String topicName = messageParts[1];
                    if (!string.IsNullOrEmpty(command))
                    {
                        if (messageParts[0] == "Publish")
                        {
                            if (!string.IsNullOrEmpty(topicName))
                            {
                                List<string> eventParts = new List<string>(messageParts);
                                eventParts.RemoveRange(0, 1);
                                string message = MakeCommaSeparatedString(eventParts);
                                List<EndPoint> subscriberListForThisTopic = Filter.GetSubscribers(topicName);
                                WorkerThreadParameters workerThreadParameters = new WorkerThreadParameters();
                                workerThreadParameters.Server = server;
                                workerThreadParameters.Message = message;
                                workerThreadParameters.SubscriberListForThisTopic = subscriberListForThisTopic;

                                ThreadPool.QueueUserWorkItem(new WaitCallback(Publish), workerThreadParameters);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occured in publisher start listening: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// This method adds a comma to the event parts string.
        /// </summary>
        /// <param name="eventParts">Event parts</param>
        /// <returns></returns>
        private static string MakeCommaSeparatedString(List<string> eventParts)
        {
            string message = string.Empty;
            foreach (string item in eventParts)
            {
                message = message + item + ",";

            }
            if (message.Length != 0)
            {
                message = message.Remove(message.Length - 1, 1);
            }
            return message;
        }

        #endregion private methods

        #region public methods

        /// <summary>
        /// This method handles the publisher service start.
        /// </summary>
        public void StartPublisherService()
        {
            Thread th = new Thread(new ThreadStart(HostPublisherService));
            th.IsBackground = true;
            th.Start();
        }
        
        /// <summary>
        /// This method handles the publish action.
        /// </summary>
        /// <param name="stateInfo"></param>
        public static void Publish(object stateInfo)
        {
            WorkerThreadParameters workerThreadParameters = (WorkerThreadParameters)stateInfo;
            Socket server = workerThreadParameters.Server;
            string message = workerThreadParameters.Message;
            List<EndPoint> subscriberListForThisTopic = workerThreadParameters.SubscriberListForThisTopic;
            int messagelength = message.Length;

            if (subscriberListForThisTopic != null)
            {
                foreach (EndPoint endPoint in subscriberListForThisTopic)
                {
                    server.SendTo(Encoding.ASCII.GetBytes(message), messagelength, SocketFlags.None, endPoint);

                }
            }
        }

        #endregion public methods

        #region classes

        /// <summary>
        /// This class defines the worker thread parameters.
        /// </summary>
        class WorkerThreadParameters
        {
            #region members

            Socket _server;
            List<EndPoint> _subscriberListForThisTopic;
            string _message;

            #endregion members

            #region properties

            public Socket Server
            {
                get { return _server; }
                set { _server = value; }
            }

            public string Message
            {
                get { return _message; }
                set { _message = value; }
            }

            public List<EndPoint> SubscriberListForThisTopic
            {
                get { return _subscriberListForThisTopic; }
                set { _subscriberListForThisTopic = value; }
            }

            #endregion properties
        }

        #endregion classes
    }
}

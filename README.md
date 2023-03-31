# SocketPublishSubscribe
Implementation of a topic based Publisher-Subscriber design pattern using socket programming and a proprietary messaging protocol.

# What is topic based Publish Subscribe design pattern?
In a topic based Publish-Subscribe pattern, sender applications tag each message with the name of a topic, instead of referencing specific receivers. The messaging system then sends the message to all applications that have asked to receive messages on that topic. Message senders need only concern themselves with creating the original message, and can leave the task of servicing the receivers to the messaging infrastructure.

In this pattern, the publisher and subscriber can communicate only via messages. The Publish-Subscribe pattern solves the tight coupling problem. It is a very loosely coupled architecture, in which senders do not even know who their subscribers are.

# Basic idea about the implementation

**Requirement 1**: Subscriber applications subscribe in one or more topics and only receive messages that are of interest.
To implement this, we have to keep the record of which subscriber is interested in which topic, then based on these records, we decide where to relay an event for a particular topic. So we have to maintain the lists of subscribers, topic-wise. For every topic, there will be a list which contains the addresses of the subscribers who have interest in that topic. When a publisher application sends an event of a particular topic to pub/sub server, the pub/sub server needs to relay this event to subscribers who have interest in that topic. To make this happen, the pub/sub server will take the subscriber list of that topic and will send the event to the addresses in this list. To keep the lists of subscriber addresses topic-wise, dictionary is a good choice. The keys in the dictionary represent the topic name and the values represent the subscribers address' list.

**Requirement 2**: Loose coupling between the publisher and the subscriber. The publisher has no knowledge about the subscribers, including how many there are or where they live, as well as the subscriber has no knowledge about the publisher, including how many there are or where they live.
To implement this, direct communication between publishers and subscribers can not be allowed. So we have to place a separate entity among them which will keep the topic-wise subscribers address list and receive the event from the subscriber, and relay the event to the subscribers, and expose the methods for the subscriber to subscribe topic-wise. The subscribers and publisher only know this separate entity. This separate entity is called the Publish/Subscribe Service or Server. The functionality of this separate entity is divided between the publish service and subscribe service. The publish service will receive the event from the publisher and relay it to the subscribers. The subscriber service will expose the Subscribe/Unsubscribe operations for the subscribers. How do we filter out the subscribers to relay the event of a particular topic? To make filtering out the subscribers to relay an event of a particular topic, an entity named Filter is implemented. The Filter entity is used by both the Publish Service and the Subscriber Service.

# Why UDP is used to implement Publish/Subscribe design pattern and not TCP?
UDP is a connectionless protocol whereas TCP is a connection-oriented protocol. Connectionless means that a Pub/Sub Server can send a message to subscribers without first establishing a connection. The Pub/Sub server simply puts a message onto the network with a destination address and hopes that the message arrives. But if we use TCP, then before sending any message, we have to create a connection between the Pub/Sub server and the subscribers. Making a connection before every message is send complicates the entire system. UDP is faster than TCP. The Pub/Sub server does not need an acknowledgement that a packet was received. UDP uses less bandwidth than TCP as the TCP packet size is larger than UDP.

# Implementation of Publish/Subscribe using sockets
As we know, UDP allows directly sending and receiving messages without establishing any connection. Here, the UDP protocol is used for all the communication between the pub/sub server and the publisher/subscriber. When a sbscriber application sends a message for subscription to the pub/sub server, the pub/sub server keeps the address (IP, port) of the subscriber topic-wise. When an event message of a particular topic is sent to a pub/sub server by the publisher application, the pub/sub server takes the address list for the corresponding topic and sends the event to every address of the list.

# Deployment
- Start SocketBasedPubSubServer.exe
- Start SocketBasedPublisher.exe
- Start SocketBasedSubscriber.exe
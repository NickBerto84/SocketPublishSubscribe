# SocketPublishSubscribe
Implementation of a topic based Publish Subscribe design pattern using socket programming, and a proprietary messaging protocol.

# What is topic based Publish Subscribe design pattern?
In a topic based Publish-Subscribe pattern, sender applications tag each message with the name of a topic, instead of referencing specific receivers. The messaging system then sends the message to all applications that have asked to receive messages on that topic. Message senders need only concern themselves with creating the original message, and can leave the task of servicing the receivers to the messaging infrastructure.

In this pattern, the publisher and subscriber can communicate only via messages. The Publish-Subscribe pattern solves the tight coupling problem. It is a very loosely coupled architecture, in which senders do not even know who their subscribers are.

# Why UDP is used to implement Publish/Subscribe design pattern and not TCP?
UDP is a connectionless protocol whereas TCP is a connection-oriented protocol. Connectionless means that a Pub/Sub Server can send a message to subscribers without first establishing a connection. The Pub/Sub server simply puts a message onto the network with a destination address and hopes that the message arrives. But if we use TCP, then before sending any message, we have to create a connection between the Pub/Sub server and the subscribers. Making a connection before every message is send complicates the entire system. UDP is faster than TCP. The Pub/Sub server does not need an acknowledgement that a packet was received. UDP uses less bandwidth than TCP as the TCP packet size is larger than UDP.

# Implementation of Publish/Subscribe using sockets
As we know, UDP allows directly sending and receiving messages without establishing any connection. Here, the UDP protocol is used for all the communication between the pub/sub server and the publisher/subscriber. When a sbscriber application sends a message for subscription to the pub/sub server, the pub/sub server keeps the address (IP, port) of the subscriber topic-wise. When an event message of a particular topic is sent to a pub/sub server by the publisher application, the pub/sub server takes the address list for the corresponding topic and sends the event to every address of the list.
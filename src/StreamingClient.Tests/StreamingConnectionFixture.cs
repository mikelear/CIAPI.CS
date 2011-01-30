using System;
using CIAPI.Streaming;
using NUnit.Framework;

namespace StreamingClient.Tests
{
    [TestFixture]
    public class StreamingConnectionFixture
    {
        [Test]
        public void RaisesMessageEvents()
        {
            MessageEventArgs<object> recievedMessage = null;
            IStreamingClient connection = new MockStreamingConnection();
           
            connection.MessageRecieved += (s, message) =>
                                     {
                                         recievedMessage = message;
                                     };

            ((MockStreamingConnection)connection).RaiseMessageRecieved("topic1","message data");

            Assert.IsNotNull(recievedMessage);
            Assert.AreEqual("topic1", recievedMessage.Topic);
            Assert.AreEqual("message data", recievedMessage.Data);
        }
    }

    

    public class MockStreamingConnection : IStreamingClient
    {
        public event EventHandler<MessageEventArgs<object>> MessageRecieved;
        public event EventHandler<StatusEventArgs> StatusChanged;
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void RaiseMessageRecieved(string topic, string messageData)
        {
            if (MessageRecieved != null) MessageRecieved(this,new MessageEventArgs<object>(topic, messageData));
        }
    }


}
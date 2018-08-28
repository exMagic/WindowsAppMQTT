using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MyMqtt
{
    public class MyMqttClass

    {
        public MqttClient mqttClient;
        public bool ConnectMe()
        {
            mqttClient = new MqttClient("m21.cloudmqtt.com", 12004, false, null, null, MqttSslProtocols.None);
            mqttClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            mqttClient.Connect("PCname2", "uugymqbo", "pSUnBCfynYB8", false, 9999);
            if (mqttClient.IsConnected)
            {
                return true;
            }
            else
                return false;

        }
        //mqttClient.Subscribe(new string[] { topic }, new byte[] { 0 });

        //mqttClient.Publish(topic, System.Text.Encoding.UTF8.GetBytes("jest z kosoli"));


        public bool Send(string msg)
        {
            string topic = "b";
            mqttClient.Publish(topic, System.Text.Encoding.UTF8.GetBytes(msg));

            return true;
        }
        public string resivedMsg;
        public string Sub()
        {
            string topic = "b";
            mqttClient.Subscribe(new string[] { topic }, new byte[] { 2 });

            return "resivedMsg";

        }

        public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            resivedMsg = ReceivedMessage;

        }

        public string checkMsg()
        {
            return resivedMsg;
        }


    }
}


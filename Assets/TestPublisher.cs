using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class TestPublisher : UnityPublisher<MessageTypes.Test.Test>
    {
        private MessageTypes.Test.Test message = new MessageTypes.Test.Test();

        protected override void Start()
        {
            RosConnector ros_connector = GetComponent<RosConnector>();
            ros_connector.IsConnected.WaitOne(ros_connector.SecondsTimeout * 1000);
            base.Start();
        }

        private void Update()
        {
            bool maru = Input.GetButton("ds4_maru");
            bool batu = Input.GetButton("ds4_batu");


            if (maru == true){
                message.word = "Yes";
                message.number = 1;
            }
            else if (batu ==true){
                message.word = "NO";
                message.number = 0;
            }
            else {
                message.word = "None";
                message.number = 3;
            }
            Publish(message);
        }
    }
}
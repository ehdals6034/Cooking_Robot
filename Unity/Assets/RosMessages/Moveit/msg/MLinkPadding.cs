//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    public class MLinkPadding : Message
    {
        public const string RosMessageName = "moveit_msgs/LinkPadding";

        // name for the link
        public string link_name;
        //  padding to apply to the link
        public double padding;

        public MLinkPadding()
        {
            this.link_name = "";
            this.padding = 0.0;
        }

        public MLinkPadding(string link_name, double padding)
        {
            this.link_name = link_name;
            this.padding = padding;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(SerializeString(this.link_name));
            listOfSerializations.Add(BitConverter.GetBytes(this.padding));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            var link_nameStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.link_name = DeserializeString(data, offset, link_nameStringBytesLength);
            offset += link_nameStringBytesLength;
            this.padding = BitConverter.ToDouble(data, offset);
            offset += 8;

            return offset;
        }

        public override string ToString()
        {
            return "MLinkPadding: " +
            "\nlink_name: " + link_name.ToString() +
            "\npadding: " + padding.ToString();
        }
    }
}

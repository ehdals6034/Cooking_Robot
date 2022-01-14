//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.PandaMove
{
    public class MHandRequest : Message
    {
        public const string RosMessageName = "panda_move/Hand";

        public bool grasp_state;
        public string object_name;
        public double grasp_size;

        public MHandRequest()
        {
            this.grasp_state = false;
            this.object_name = "";
            this.grasp_size = 0.0;
        }

        public MHandRequest(bool grasp_state, string object_name, double grasp_size)
        {
            this.grasp_state = grasp_state;
            this.object_name = object_name;
            this.grasp_size = grasp_size;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.grasp_state));
            listOfSerializations.Add(SerializeString(this.object_name));
            listOfSerializations.Add(BitConverter.GetBytes(this.grasp_size));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.grasp_state = BitConverter.ToBoolean(data, offset);
            offset += 1;
            var object_nameStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.object_name = DeserializeString(data, offset, object_nameStringBytesLength);
            offset += object_nameStringBytesLength;
            this.grasp_size = BitConverter.ToDouble(data, offset);
            offset += 8;

            return offset;
        }

        public override string ToString()
        {
            return "MHandRequest: " +
            "\ngrasp_state: " + grasp_state.ToString() +
            "\nobject_name: " + object_name.ToString() +
            "\ngrasp_size: " + grasp_size.ToString();
        }
    }
}
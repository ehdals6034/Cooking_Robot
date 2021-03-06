//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    public class MDisplayRobotState : Message
    {
        public const string RosMessageName = "moveit_msgs/DisplayRobotState";

        //  The robot state to display
        public MRobotState state;
        //  Optionally, various links can be highlighted
        public MObjectColor[] highlight_links;

        public MDisplayRobotState()
        {
            this.state = new MRobotState();
            this.highlight_links = new MObjectColor[0];
        }

        public MDisplayRobotState(MRobotState state, MObjectColor[] highlight_links)
        {
            this.state = state;
            this.highlight_links = highlight_links;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(state.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(highlight_links.Length));
            foreach(var entry in highlight_links)
                listOfSerializations.Add(entry.Serialize());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.state.Deserialize(data, offset);
            
            var highlight_linksArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.highlight_links= new MObjectColor[highlight_linksArrayLength];
            for(var i = 0; i < highlight_linksArrayLength; i++)
            {
                this.highlight_links[i] = new MObjectColor();
                offset = this.highlight_links[i].Deserialize(data, offset);
            }

            return offset;
        }

        public override string ToString()
        {
            return "MDisplayRobotState: " +
            "\nstate: " + state.ToString() +
            "\nhighlight_links: " + System.String.Join(", ", highlight_links.ToList());
        }
    }
}

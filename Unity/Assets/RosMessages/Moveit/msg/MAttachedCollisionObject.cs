//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    public class MAttachedCollisionObject : Message
    {
        public const string RosMessageName = "moveit_msgs/AttachedCollisionObject";

        //  The CollisionObject will be attached with a fixed joint to this link
        public string link_name;
        // This contains the actual shapes and poses for the CollisionObject
        // to be attached to the link
        // If action is remove and no object.id is set, all objects
        // attached to the link indicated by link_name will be removed
        public MCollisionObject @object;
        //  The set of links that the attached objects are allowed to touch
        //  by default - the link_name is already considered by default
        public string[] touch_links;
        //  If certain links were placed in a particular posture for this object to remain attached 
        //  (e.g., an end effector closing around an object), the posture necessary for releasing
        //  the object is stored here
        public Trajectory.MJointTrajectory detach_posture;
        //  The weight of the attached object, if known
        public double weight;

        public MAttachedCollisionObject()
        {
            this.link_name = "";
            this.@object = new MCollisionObject();
            this.touch_links = new string[0];
            this.detach_posture = new Trajectory.MJointTrajectory();
            this.weight = 0.0;
        }

        public MAttachedCollisionObject(string link_name, MCollisionObject @object, string[] touch_links, Trajectory.MJointTrajectory detach_posture, double weight)
        {
            this.link_name = link_name;
            this.@object = @object;
            this.touch_links = touch_links;
            this.detach_posture = detach_posture;
            this.weight = weight;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(SerializeString(this.link_name));
            listOfSerializations.AddRange(@object.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(touch_links.Length));
            foreach(var entry in touch_links)
                listOfSerializations.Add(SerializeString(entry));
            listOfSerializations.AddRange(detach_posture.SerializationStatements());
            listOfSerializations.Add(BitConverter.GetBytes(this.weight));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            var link_nameStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.link_name = DeserializeString(data, offset, link_nameStringBytesLength);
            offset += link_nameStringBytesLength;
            offset = this.@object.Deserialize(data, offset);
            
            var touch_linksArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.touch_links= new string[touch_linksArrayLength];
            for(var i = 0; i < touch_linksArrayLength; i++)
            {
                var touch_linksStringBytesLength = DeserializeLength(data, offset);
                offset += 4;
                this.touch_links[i] = DeserializeString(data, offset, touch_linksStringBytesLength);
                offset += touch_linksStringBytesLength;
            }
            offset = this.detach_posture.Deserialize(data, offset);
            this.weight = BitConverter.ToDouble(data, offset);
            offset += 8;

            return offset;
        }

        public override string ToString()
        {
            return "MAttachedCollisionObject: " +
            "\nlink_name: " + link_name.ToString() +
            "\n@object: " + @object.ToString() +
            "\ntouch_links: " + System.String.Join(", ", touch_links.ToList()) +
            "\ndetach_posture: " + detach_posture.ToString() +
            "\nweight: " + weight.ToString();
        }
    }
}

//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.PandaMove
{
    public class MInitRequest : Message
    {
        public const string RosMessageName = "panda_move/Init";

        public string[] activated_object;
        public Geometry.MPoint[] position;
        public Geometry.MQuaternion[] orientation;
        public Geometry.MVector3[] scale;
        public double[] joint_state;

        public MInitRequest()
        {
            this.activated_object = new string[0];
            this.position = new Geometry.MPoint[0];
            this.orientation = new Geometry.MQuaternion[0];
            this.scale = new Geometry.MVector3[0];
            this.joint_state = new double[0];
        }

        public MInitRequest(string[] activated_object, Geometry.MPoint[] position, Geometry.MQuaternion[] orientation, Geometry.MVector3[] scale, double[] joint_state)
        {
            this.activated_object = activated_object;
            this.position = position;
            this.orientation = orientation;
            this.scale = scale;
            this.joint_state = joint_state;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            
            listOfSerializations.Add(BitConverter.GetBytes(activated_object.Length));
            foreach(var entry in activated_object)
                listOfSerializations.Add(SerializeString(entry));
            
            listOfSerializations.Add(BitConverter.GetBytes(position.Length));
            foreach(var entry in position)
                listOfSerializations.Add(entry.Serialize());
            
            listOfSerializations.Add(BitConverter.GetBytes(orientation.Length));
            foreach(var entry in orientation)
                listOfSerializations.Add(entry.Serialize());
            
            listOfSerializations.Add(BitConverter.GetBytes(scale.Length));
            foreach(var entry in scale)
                listOfSerializations.Add(entry.Serialize());
            
            listOfSerializations.Add(BitConverter.GetBytes(joint_state.Length));
            foreach(var entry in joint_state)
                listOfSerializations.Add(BitConverter.GetBytes(entry));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            
            var activated_objectArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.activated_object= new string[activated_objectArrayLength];
            for(var i = 0; i < activated_objectArrayLength; i++)
            {
                var activated_objectStringBytesLength = DeserializeLength(data, offset);
                offset += 4;
                this.activated_object[i] = DeserializeString(data, offset, activated_objectStringBytesLength);
                offset += activated_objectStringBytesLength;
            }
            
            var positionArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.position= new Geometry.MPoint[positionArrayLength];
            for(var i = 0; i < positionArrayLength; i++)
            {
                this.position[i] = new Geometry.MPoint();
                offset = this.position[i].Deserialize(data, offset);
            }
            
            var orientationArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.orientation= new Geometry.MQuaternion[orientationArrayLength];
            for(var i = 0; i < orientationArrayLength; i++)
            {
                this.orientation[i] = new Geometry.MQuaternion();
                offset = this.orientation[i].Deserialize(data, offset);
            }
            
            var scaleArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.scale= new Geometry.MVector3[scaleArrayLength];
            for(var i = 0; i < scaleArrayLength; i++)
            {
                this.scale[i] = new Geometry.MVector3();
                offset = this.scale[i].Deserialize(data, offset);
            }
            
            var joint_stateArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.joint_state= new double[joint_stateArrayLength];
            for(var i = 0; i < joint_stateArrayLength; i++)
            {
                this.joint_state[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MInitRequest: " +
            "\nactivated_object: " + System.String.Join(", ", activated_object.ToList()) +
            "\nposition: " + System.String.Join(", ", position.ToList()) +
            "\norientation: " + System.String.Join(", ", orientation.ToList()) +
            "\nscale: " + System.String.Join(", ", scale.ToList()) +
            "\njoint_state: " + System.String.Join(", ", joint_state.ToList());
        }
    }
}
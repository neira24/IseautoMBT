﻿/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Newtonsoft.Json;

namespace RosSharp.RosBridgeClient
{
    public class Message
    {
        [JsonIgnore]
        public string RosMessageType
        {
            get { return MessageTypes.RosMessageType(GetType()); }
        }
    }

    public class WaypointState : Message
    {
        public int aid;
        //public uint NULLSTATE;
        public uint lanechange_state;
        public uint steering_state;

        public uint STR_LEFT;
        public uint STR_RIGHT;
        public uint STR_STRAIGHT;

        public uint accel_state;
        public uint stopline_state;
        public uint event_state;
        public WaypointState()
        {


           aid=0;
           //NULLSTATE=0;
           lanechange_state=0;
           steering_state=0;

            STR_LEFT=1;
            STR_RIGHT=2;
           STR_STRAIGHT=3;

           accel_state=0;
          stopline_state=0;
       event_state=0;

    }
    }

    public class dtlane : Message
    {
        public float dist;
        public float dir;
        public float apara;
        public float r;
        public float slope;
        public float cant;
        public float lw;
        public float rw;
        public dtlane()
        {
         dist=0f;
         dir=0f;
         apara=0f;
         r=0f;
         slope=0f;
         cant=0f;
         lw=0f;
         rw=0f;
        }
    }

    public class waypoint : Message
    {
        
        public int gid;
        public int lid;
        public GeometryPoseStamped pose;
        public GeometryTwistStamped twist;
        public dtlane dtlane;
        public int change_flag;
        //public WaypointState wpstate;
        public waypoint()
        {
           
            gid = 0;
            lid = 0;
            pose = new GeometryPoseStamped();
            twist = new GeometryTwistStamped();
            dtlane = new dtlane();
            change_flag = 0;
           // wpstate = new WaypointState();
        }
    }

    public class lane : Message
    {
        public StandardHeader header;
        public int increment;
        public int lane_id;
        public waypoint[] waypoints;
        public lane()
        {
            header = new StandardHeader();
            increment = 0;
            lane_id = 0;
            waypoints =new waypoint[0];
        }
    }

    public class LaneArray : Message
    {
        public lane[] lane;
        public LaneArray()
        {
            lane= new lane[0];
          
        }
    }

    public class LinkState : Message
    {
        public string [] name;
        public GeometryPose[] pose;
        public GeometryTwist[] twist;
        
        public LinkState()
        {
            name = new string [0];
            pose = new GeometryPose[0];
            twist = new GeometryTwist[0];
           
        }
    }
    public class ModelState : Message
    {
        public string[] name;
        public GeometryPose[] pose;
        public GeometryTwist[] twist;
      

        public ModelState()
        {
            name = new string[0];
            pose = new GeometryPose[0];
            twist = new GeometryTwist[0];
         

        }
    }

    public class GeometryTwist : Message
    {
        public GeometryVector3 linear;
        public GeometryVector3 angular;
        public GeometryTwist()
        {
            linear = new GeometryVector3();
            angular = new GeometryVector3();
        }
    }
    public class StandardString : Message
    {
        public string data;
        public StandardString()
        {
            data = "";
        }
    }

    public class GeometryAccel : Message
    {
        public GeometryVector3 linear;
        public GeometryVector3 angular;
        public GeometryAccel()
        {
            linear = new GeometryVector3();
            angular = new GeometryVector3();
        }
    }

    public class SensorJointStates : Message
    {
        public StandardHeader header;
        public string[] name;
        public float[] position;
        public float[] velocity;
        public float[] effort;
        public SensorJointStates()
        {
            header = new StandardHeader();
            name = new string[0];
            position = new float[0];
            velocity = new float[0];
            effort = new float[0];
        }
    }
    public class GeometryVector3 : Message
    {
        public float x;
        public float y;
        public float z;
        public GeometryVector3()
        {
            x = 0f;
            y = 0f;
            z = 0f;
        }
    }
    public class SensorJoy : Message
    {
        public StandardHeader header;
        public float[] axes;
        public int[] buttons;

        public SensorJoy()
        {
            header = new StandardHeader();
            axes = new float[0];
            buttons = new int[0];
        }
    }

    public class NavigationOdometry : Message
    {
        public StandardHeader header;
        public string child_frame_id;
        public GeometryPoseWithCovariance pose;
        public GeometryTwistWithCovariance twist;
        public NavigationOdometry()
        {
            header = new StandardHeader();
            child_frame_id = "";
            pose = new GeometryPoseWithCovariance();
            twist = new GeometryTwistWithCovariance();
        }
    }
    public class StandardHeader : Message
    {
        public int seq;
        public StandardTime stamp;
        public string frame_id;
        public StandardHeader()
        {
            seq = 0;
            stamp = new StandardTime();
            frame_id = "";
        }
    }

    public class GeometryPoseWithCovariance : Message
    {
        public GeometryPose pose;
        public float[] covariance;
        public GeometryPoseWithCovariance()
        {
            pose = new GeometryPose();
            covariance = new float[32];
        }
    }
    public class GeometryTwistWithCovariance : Message
    {
        public GeometryTwist twist;
        public float[] covariance;
        public GeometryTwistWithCovariance()
        {
            twist = new GeometryTwist();
            covariance = new float[32];
        }
    }

    public class GeometryPose : Message
    {
        public GeometryPoint position;
        public GeometryQuaternion orientation;
        public GeometryPose()
        {
            position = new GeometryPoint();
            orientation = new GeometryQuaternion();
        }
    }
    
   
  

    public class GeometryPoseStamped : Message
    {
        public StandardHeader header;
        public GeometryPose pose;
        public GeometryPoseStamped()
        {
            header = new StandardHeader();
            pose = new GeometryPose();
        }
    }

    public class GeometryTwistStamped : Message
    {
        public StandardHeader header;
        public GeometryTwist twist;
        public GeometryTwistStamped()
        {
            header = new StandardHeader();
            twist = new GeometryTwist();
        }
    }
    public class RosGraphMsgsLog : Message
    {
        public StandardHeader header;
        public string name;
        public string msg;
        public string file;
        public string function;
        public int line;
        public string[] topics;

        public RosGraphMsgsLog()
        {
            header = new StandardHeader();
            name = "";
            msg = "";
            file = "";
            function = "";
            line=0;
        }
    }
    public class TurtlesimPose : Message
    {
        public float x;
        public float y;
        public float theta;
        public float linear_velocity;
        public float angular_velocity;

        public TurtlesimPose()
        {
            x = 0;
            y = 0;
            theta = 0;
            linear_velocity = 0;
            angular_velocity = 0;
        }
    }

    public class GeometryPoint : Message
    {
        public float x;
        public float y;
        public float z;
        public GeometryPoint()
        {
            x = 0;
            y = 0;
            z = 0;
        }
    }
    public class GeometryQuaternion : Message
    {
        public float x;
        public float y;
        public float z;
        public float w;
        public GeometryQuaternion()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }
    }
    public class SensorPointCloud2 : Message
    {
        public StandardHeader header;
        public int height;
        public int width;
        public SensorPointField[] fields;
        public bool is_bigendian;
        public int point_step;
        public int row_step;

        public byte[] data;
        public bool is_dense;
        public SensorPointCloud2()
        {
            header = new StandardHeader();
            height = 0;
            width = 0;
            fields = new SensorPointField[0];
            is_bigendian = false;
            point_step = 0;
            row_step = 0;
            is_dense = false;
            data = new byte[0];
        }
    }
    public class SensorPointField : Message
    {
        public int datatype;
        public string name;
        public int offset;
        public int count;
        public SensorPointField()
        {
            datatype = 0;
            name = "";
            offset = 0;
            count = 0;
        }
    }
    public class SensorImage : Message
    {
        public StandardHeader header;
        public int height;
        public int width;
        public string encoding;
        public bool is_bigendian;
        public int step;
        public byte[] data;
        public SensorImage()
        {
            header = new StandardHeader();
            height = 0;
            width = 0;
            encoding = "undefined";
            is_bigendian = false;
            step = 0;
            data = new byte[0];
        }
    }
    public class SensorCompressedImage : Message
    {
        public StandardHeader header;
        public string format;
        public byte[] data;
        public SensorCompressedImage()
        {
            header = new StandardHeader();
            format = "";
            data = new byte[0];
        }
    }

    public class StandardTime : Message
    {
        public int secs;
        public int nsecs;
        public StandardTime()
        {
            secs = 0;
            nsecs = 0;
        }
    }

    public class NavigationMapMetaData : Message
    {
        public StandardTime map_load_time;
        public float resolution;
        public uint width;
        public uint height;
        public GeometryPose origin;

        public NavigationMapMetaData()
        {
            map_load_time = null;
            resolution = 0;
            width = 0;
            height = 0;
            origin = new GeometryPose();
        }
    }

    public class NavigationOccupancyGrid : Message
    {
        public StandardHeader header;
        public NavigationMapMetaData info;
        public sbyte[] data;
        public NavigationOccupancyGrid()
        {
            header = new StandardHeader();
            info = new NavigationMapMetaData();
            data = null;
        }
    }

    public class ParamName : Message
    {
        public string name;
        public ParamName(string _name)
        {
            name = _name;
        }
    }

    public class SetParam : Message
    {
        public string name;
        public string value;
        public SetParam(string _name, string _value)
        {
            name = _name;
            value = _value;
        }
    }

    public class ParamValueString : Message
    {
        public string value;
    }

    public class ParamValueByte : Message
    {
        public byte[] value;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{   
    public  enum MsgsTypes
    {
        Credinitials = 1 ,
        OnlineUser = 2,
        Normal = 4,
        BroadCasting=8,
        Authenticated = 16,
        InValidCredinitials = 32,
        Error = 64,
        Unknown = 128

    }
    internal class Message
    {
        private string msg;
        public string Packet { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        private MsgsTypes msgType;
        public string CoreMsg { set { msg = value; } get { return msg; } }
        public Message(string _Packet) {
            this.Packet = _Packet;
            this.msgType = CheckReceivingMsgType(this);
            this.msg = GetMessage(Packet, msgType);
             }
        public Message(string _msg, MsgsTypes _msgType)
        {
            this.msg = _msg;
            Packet = GenerateSendindPacket(_msg, _msgType);
           
            msgType = _msgType;
        }

        /// <summary>
        /// Function To Retriecve Core Or Pure Msg From Packet 
        /// <see>
        /// <example>
        /// Message Has msg (Core Or Pure Msg From) and Packet (Segment + msg +Segment )
        /// </example>
        /// 
        /// </see>
        /// </summary>
        /// <param name="packet">Packet Which is Ready Send Or Receive</param>
        /// <param name="msgType">Message Type Which Represent the Way of Communications and use Defined Segemnt for Each Packet</param>
        /// <returns>
        /// <summary>
        /// return string of The Core or Pure Msg form after Removing Segments from Packet
        /// </summary>
        /// </returns>
        private string? GetMessage(string packet, MsgsTypes msgType)
        {
            
                switch (msgType)
                {
                    case MsgsTypes.Credinitials:
                        return RemoveSegments(packet,"##LOGIN##");
                        break;
                    case MsgsTypes.InValidCredinitials:
                        return RemoveSegments(packet, "##INVALIDCREDINITIALS##");
                        break;
                
                    case MsgsTypes.Normal:
                    default:
                        return RemoveSegments(packet, "##NORMAL##");
                        break;
                    case MsgsTypes.BroadCasting:
                        return RemoveSegments(packet, "##BROADCASTING##");
                        break;
                    case MsgsTypes.Authenticated:
                        return RemoveSegments(packet,"##AUTHENTICATED##");
                        break;
                    case MsgsTypes.OnlineUser:
                        return RemoveSegments(packet,"##ONLINE##");
                        break;
                    case MsgsTypes.Error:
                        return RemoveSegments(packet, "##ERROR##");
                        break;
                    case MsgsTypes.Unknown:
                        return RemoveSegments(packet,"##UNKNOWN##");
                        break;
                    
                 }


        }
        /// <summary>
        /// Removing The Extra Information From The Packet 
        /// </summary>
        /// <param name="packet">Packet (Segment + Message + Segment)</param>
        /// <param name="seg">Segment to be removed </param>
        /// <returns>returns string for the Purest Form Of Message </returns>
        private string? RemoveSegments(string packet, string seg)
        {
            string result = packet.Remove(0, seg.Length);
            result= result.Remove(result.Length-seg.Length,seg.Length);
            return result;
        }

        
        /// <summary>
        /// Generating Packet Depending Of Msg Type .
        /// </summary>
        /// <param name="msg">take Simple text or The Pure Version OF Message</param>
        /// <param name="msgType">Take The Tyepe Of The Message </param>
        /// <returns>Generates A String oF The Packet That We Use To Send In Network Stream Path </returns>
        private string? GenerateSendindPacket(string msg, MsgsTypes msgType)
        {
            string? value=MsgSendingProtcol(msgType);
            string result;
            if(msg is null)
                return null;
            else
            {
                result = $"{value}{msg}{value}";
                return result;
            }
            
        }
        /// <summary>
        /// Message Sending Protocol Function 
        /// The Way Of Communication Algorithm In Sending Messages
        /// </summary>
        /// <param name="msgType">
        ///  Enum Parameter 
        ///  which Can Specify The slot of the Word which We agee with
        ///  <example>
        ///     msg.MsgProtcol(MsgsTypes.Credinitials);
        /// </example>
        /// </param>
        /// <returns>
        /// returns a slot of string Type which we are Agree With
        /// </returns>
        private string? MsgSendingProtcol(MsgsTypes msgType)
        {
            switch(msgType)
            {
                case MsgsTypes.Credinitials:
                    return "##LOGIN##";
                    break;
                case MsgsTypes.InValidCredinitials:
                    return "##INVALIDCREDINITIALS##";
                    break;
                case MsgsTypes.Normal:
                default:
                    return "##NORMAL##";
                    break;
                case MsgsTypes.BroadCasting:
                    return "##BROADCASTING##";
                    break;
                case MsgsTypes.Authenticated:
                    return "##AUTHENTICATED##";
                    break;
                case MsgsTypes.OnlineUser:
                    return "##ONLINE##";
                    break;
                case MsgsTypes.Error:
                    return "##ERROR##";
                    break;
                case MsgsTypes.Unknown:
                    return "##UNKNOWN##";
                    break;

            }
        }
        /// <summary>
        /// Message Receiving Protocol Function 
        /// The Way Of Communication Algorithm In Receiveing Messages
        /// </summary>
        /// <param name="Msg">
        /// takes Receiving Msg and check The Receiving Packet 
        /// Using the agreement Protocol In the Way of Communication
        /// </param>
        /// <returns>
        /// Returns Msg Type and after Knowning The The We Can Choose The Way Of Viewing This Msg
        /// </returns>
        private MsgsTypes CheckReceivingMsgType(Message Msg)
        {
            if (Msg.Packet.StartsWith("##LOGIN##") && Msg.Packet.EndsWith("##LOGIN##"))
                return MsgsTypes.Credinitials;
            else if (Msg.Packet.StartsWith("##ONLINE##") && Msg.Packet.EndsWith("##ONLINE##"))
                return MsgsTypes.OnlineUser;
            else if (Msg.Packet.StartsWith("##NORMAL##") && Msg.Packet.EndsWith("##NORMAL##"))
                return MsgsTypes.Normal;
            else if (Msg.Packet.StartsWith("##BROADCASTING##") && Msg.Packet.EndsWith("##BROADCASTING##"))
                return MsgsTypes.BroadCasting;
            else if (Msg.Packet.StartsWith("##AUTHENTICATED##") && Msg.Packet.EndsWith(("##AUTHENTICATED##")))
                return MsgsTypes.Authenticated;
            else if (Msg.Packet.StartsWith("##INVALIDCREDINITIALS##") && Msg.Packet.EndsWith("##INVALIDCREDINITIALS##"))
                return MsgsTypes.InValidCredinitials;
            else if (Msg.Packet.StartsWith("##ERROR##") && Msg.Packet.EndsWith("##ERROR##"))
                return MsgsTypes.Error;
            else
                return MsgsTypes.Unknown;


        }
        /// <summary>
        /// Function To Retreive Message Data And Informations About Sender and Receiver
        /// </summary>
        /// <returns>return string Of Log About Message</returns>
        public override string ToString()=> $"├ Sender ┤> {this.From.UserName.ToUpper()}\n├ Receiver ┤> {this.To.UserName.ToUpper()}\n├ Message ┤>\"{this.msg}\"\n├ At ┤>\"{DateTime.Now}\"";
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
    public class Message
    {
        private string msg;
        public string Packet { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        
        public MsgsTypes msgType { get; set; }
        public string CoreMsg { set { msg = value; } get { return msg; } }
        

       

        public Message(string _msg, MsgsTypes _msgType,string _from,string to)
        {
            
            Packet = GenerateSendingPacket(_msg, _msgType,_from,to);
            this.msgType = _msgType;
            this.To= to;
            this.From = _from;
            this.CoreMsg = _msg;
            
        }
        public Message(string _Packet)
        {
            this.Packet = _Packet;
            string[] messageMembers = Regex.Split(_Packet, "##");
            this.From = messageMembers[0];
            this.To = messageMembers[1];
            this.msgType = GetMsgType(messageMembers[2]);
            this.CoreMsg = messageMembers[3];

            
        }
        private MsgsTypes GetMsgType(string type)
        {
            switch (type)
            {
                case "LOGIN":
                    return MsgsTypes.Credinitials;
                case "INVALIDCREDINITIALS":
                    return MsgsTypes.InValidCredinitials;
                case "NORMAL":
                    return MsgsTypes.Normal;
                case "BROADCASTING":
                    return MsgsTypes.BroadCasting;
                case "AUTHENTICATED":
                    return MsgsTypes.Authenticated;
                case "ONLINE":
                    return MsgsTypes.OnlineUser;
                case "ERROR":
                    return MsgsTypes.Error;
                case "UNKNOWN":
                default:
                    return MsgsTypes.Unknown;


            }
        }



        
        
        /// <summary>
        /// Generating Packet Depending Of Msg Type .
        /// </summary>
        /// <param name="msg">take Simple text or The Pure Version OF Message</param>
        /// <param name="msgType">Take The Tyepe Of The Message </param>
        /// <returns>Generates A String oF The Packet That We Use To Send In Network Stream Path </returns>
        private string? GenerateSendingPacket(string msg, MsgsTypes msgType,string from,string to)
        {
            string? value=MsgSendingProtcol(msgType);
            string result;
            result = $"{from}##{to}##{value}##{msg}";
            return result; 
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
                    return "LOGIN";
                case MsgsTypes.InValidCredinitials:
                    return "INVALIDCREDINITIALS";
                case MsgsTypes.Normal:
                default:
                    return "NORMAL";
                case MsgsTypes.BroadCasting:
                    return "BROADCASTING";
                case MsgsTypes.Authenticated:
                    return "AUTHENTICATED";
                case MsgsTypes.OnlineUser:
                    return "ONLINE";
                case MsgsTypes.Error:
                    return "ERROR";
                case MsgsTypes.Unknown:
                    return "UNKNOWN";
            }
        }
        
        
        /// <summary>
        /// Function To Retreive Message Data And Informations About Sender and Receiver
        /// </summary>
        /// <returns>return string Of Log About Message</returns>
        public override string ToString()=> $"├ Sender ┤> {From.ToUpper()}\n├ Receiver ┤> {To.ToUpper()}\n├ Message ┤>\"{this.msg}\"\n├ At ┤>\"{DateTime.Now}\"";
        
    }
}

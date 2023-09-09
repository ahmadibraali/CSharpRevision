using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public enum UserTypes
    {
        Client=1,
        Server=2,

    }
    public enum Userstatus
    {
        Online = 1,
        Offline = 2,

    }

    internal class User
    {

        public event EventHandler <Message> MsgHadSent;

        public string UserName { get; set; }
        public string Password { get; set; }

        

        public List<Message> AllMessages { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }
        public UserTypes UserType { get; set;}
        public Userstatus UserStatus { get; set;}
        
        public User(string _userName, string _password, UserTypes _userType)
        {
            UserName = _userName;
            Password = _password;
            UserStatus = Userstatus.Online;
            UserType = _userType;

        }
        public User(string _userName, string _password)
        {
            UserName = _userName;
            Password = _password;
            UserStatus = Userstatus.Offline;

        }
        
        public bool IsAuthenticated(string _username, string _password) => (this.UserName == _username && this.Password == _password);
        
        public void IsSendingOrReceivingMessage(Message _message,User _user,bool send)
        {
            if (send)
                SendMsgToAnthor(_message, _user, this);
            else
                SendMsgToAnthor(_message,this, _user);
        }

        private void SendMsgToAnthor(Message _message, User _receiver,User _sender)
        {
            _message.From = _sender;
            _message.To = _receiver;
            _sender.AllMessages.Add(_message);
            _sender.SentMessages.Add(_message);
            _receiver.AllMessages.Add(_message);
            _receiver.ReceivedMessages.Add(_message);

            if (MsgHadSent != null)
                MsgHadSent(this, _message);
        }

     
    }
}

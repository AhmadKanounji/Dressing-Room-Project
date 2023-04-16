using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Messages
{
    public class RefreshMessage : ValueChangedMessage<byte[]>
    {
        public RefreshMessage(byte[] value) : base(value)
        {
        }
    }
}

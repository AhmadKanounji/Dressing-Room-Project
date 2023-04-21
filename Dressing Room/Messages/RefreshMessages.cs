using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Dressing_Room.Messages
{
    public class RefreshMessage : ValueChangedMessage<byte[]>
    {
        public RefreshMessage(byte[] value) : base(value)
        {
        }
    }
}

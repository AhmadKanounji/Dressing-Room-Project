using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Messages
{
    public class RefreshOutfitMessage : ValueChangedMessage<string>
    {
        public RefreshOutfitMessage(string value) : base(value)
        {
        }
    }
}

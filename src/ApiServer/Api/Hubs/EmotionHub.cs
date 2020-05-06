using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class EmotionHub : Hub
    {
        public async Task SendEmotion(string groupNumber,string emotion)
        {
            // TODO
            // groupNumberをデスクトップアプリのクライアントIDに変換する
            // 変換したクライアントIDに対して配信する
            await Clients.All.SendAsync("ReceiveEmotion", emotion);
        }

        /*
        public Task JoinGroup(string groupNumber)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupNumber);
        }

        public Task LeaveGroup(string groupNumber)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupNumber);
        }
        */
    }
}

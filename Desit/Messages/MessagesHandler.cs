using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WebSocketManager;
using WebSocketManager.Common;

namespace Desit.Messages
{
    public class MessagesHandler : WebSocketHandler
    {
        public MessagesHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager, new ControllerMethodInvocationStrategy())
        {
            ((ControllerMethodInvocationStrategy)MethodInvocationStrategy).Controller = this;
        }

        public override Task OnConnected(WebSocket socket)
        {
            return base.OnConnected(socket);
        }

        public override Task OnDisconnected(WebSocket socket)
        {
            return base.OnDisconnected(socket);
        }
    }
}
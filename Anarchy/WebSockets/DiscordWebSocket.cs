using System;
using Newtonsoft.Json;
using WebSocketSharp;

namespace Discord.WebSockets
{
    public class DiscordWebSocket<TOpcode> : IDisposable where TOpcode : Enum
    {
        private WebSocket _socket;
        private object _socketLock;

        public delegate void MessageHandler(object sender, DiscordWebSocketMessage<TOpcode> message);
        public event MessageHandler OnMessageReceived;

        public delegate void CloseHandler(object sender, CloseEventArgs args);
        public event CloseHandler OnClosed;

        public DiscordWebSocket(string url)
        {
            _socketLock = new object();

            _socket = new WebSocket(url)
            {
                Origin = "https://discord.com",
            };
            _socket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            _socket.OnMessage += OnMessage;
            _socket.OnClose += OnClose;
        }

        public void Connect()
        {
            lock (_socketLock)
            {
                _socket.Connect();
            }
        }

        public void Close(ushort error, string reason)
        {
            lock (_socketLock)
            {
                _socket.Close(error, reason);
            }
        }

        public void Send<T>(TOpcode op, T data)
        {
            lock (_socketLock)
            {
                if (_socket != null)
                    _socket.Send(JsonConvert.SerializeObject(new DiscordWebSocketRequest<T, TOpcode>(op, data)));
                else
                    throw new InvalidOperationException("Socket is disposed of");
            }
        }

        private void OnClose(object sender, CloseEventArgs e)
        {
            OnClosed?.Invoke(this, e);
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            OnMessageReceived?.Invoke(this, JsonConvert.DeserializeObject<DiscordWebSocketMessage<TOpcode>>(e.Data));
        }

        public void Dispose()
        {
            lock (_socketLock)
            {
                _socket = null;
            }
        }
    }
}
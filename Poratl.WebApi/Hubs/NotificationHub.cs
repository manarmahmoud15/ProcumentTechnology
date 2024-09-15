
using Domain.Entities.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace Poratl.WebApi.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        //private readonly INotificationBusiness _notificationBusiness;
        //private readonly ICRMSettingBusiness _CRMSettingBusiness;

        private readonly static ConnectionMapping<string> _connections =
                new ConnectionMapping<string>();

        private bool disposedValue = false;
        //private SqlTableDependency<Post> _tableDependency;
        public NotificationHub(//INotificationBusiness notificationBusiness,
            )
        {
        //    _notificationBusiness = notificationBusiness;
        //    _CRMSettingBusiness = CRMSettingBusiness;
        }


       

        public override Task OnConnectedAsync()
        {
            var userId = "1"; // Context.User.Claims.First(t => t.Type == "UserId").Value;
            _connections.Add(userId, Context.ConnectionId);
            Groups.AddToGroupAsync(Context.ConnectionId, userId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception ex)
        {
            var userId = "1"; //Context.User.Claims.First(t => t.Type == "UserId").Value;
            _connections.Remove(userId, Context.ConnectionId);
            return base.OnDisconnectedAsync(ex);
        }

    }
    public class ConnectionMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> _connections =
            new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if (_connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }

  
}

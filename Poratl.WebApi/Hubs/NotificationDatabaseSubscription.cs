using System;
using TableDependency.SqlClient;
using Microsoft.AspNetCore.SignalR;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Base.Enums;
using Poratl.WebApi.Hubs;
using Domain.Entities.Entity;
using Poratl.WebApi.Hubs.Extensions;
using Library.Helpers.UnitOfWork;
using System.Collections.Generic;

namespace Poratl.WebApi.Hubs
{
    public class NotificationDatabaseSubscription : IDatabaseSubscription
    {
        private bool disposedValue = false;
        private IHubContext<NotificationHub> _hubContext;
        private SqlTableDependency<Notification> _tableDependency;
//       protected readonly IUnitOfWork<NotificationUser, int> _unitOfWorkNotificationUser;

        public NotificationDatabaseSubscription(IHubContext<NotificationHub> hubContext
        //    ,IUnitOfWork<NotificationUser, int> unitOfWorkNotificationUser
            )
        {
            _hubContext = hubContext;
          //  _unitOfWorkNotificationUser = unitOfWorkNotificationUser;
        }
        public void Configure(string connectionString)
        {
            _tableDependency = new SqlTableDependency<Notification>(
               connectionString,
              null, null, null, null, null,
                DmlTriggerType.Insert);

          

            _tableDependency.OnChanged += Changed;
            _tableDependency.OnError += TableDependency_OnError;
            _tableDependency.Start();

         
            Console.WriteLine("Waiting for receiving notifications...");
        }
        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"SqlTableDependency error: {e.Error.Message}");
        }

        private void Changed(object sender, RecordChangedEventArgs<Notification> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                //  TODO: manage the changed entity
                var changedEntity = e.Entity;
                //if (changedEntity.NotificationType == 1)
                //{

                //    var ess = new List<NotificationUser>(); //_unitOfWorkNotificationUser.Repository.FindAsync(q => q.NotificationId == changedEntity.Id).Result;
                //        foreach (var item in ess)
                //        {
                //            _hubContext.Clients.Group(item.UserId.ToString()).SendAsync("UpdateCatalog", changedEntity.MessageEn);

                //        }
                //}
                //else
                    _hubContext.Clients.All.SendAsync("UpdateCatalog", changedEntity.MessageEn);
            }
        }


        #region IDisposable

        ~NotificationDatabaseSubscription()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _tableDependency.Stop();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

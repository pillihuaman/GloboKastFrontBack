using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace globokas.com.Service
{
    public class Services: Hub<IServices>
    {

        const string Calificacion = "Calificacion";
        const string Cliente = "Cliente";
        const string Rol = "Rol";
        const string Usuario = "Usuario";
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Usuario);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Usuario);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SubscribeToGroup(string grupo)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, grupo);
        }

        public async Task UnsubscribeFromGroup(string grupo)
        {

        }

   
    }
}

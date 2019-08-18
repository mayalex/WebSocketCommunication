using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSocketCommunication.Models;
using Newtonsoft.Json;

namespace WebSocketCommunication.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task Get()
        {
            var context = ControllerContext.HttpContext;
            var isSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await GetMessages(context, webSocket);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        private async Task GetMessages(HttpContext context, WebSocket webSocket)
        {
            var tableModel = new TableModel(1000, 3);
            var table = tableModel.GenerateTable();

            foreach (var row in table)
            {
                var serializedRow = JsonConvert.SerializeObject(row);
                var bytes = Encoding.ASCII.GetBytes(serializedRow);
                var arraySegment = new ArraySegment<byte>(bytes);
                await webSocket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }

            await webSocket.SendAsync(new ArraySegment<byte>(null), WebSocketMessageType.Binary, false, CancellationToken.None);
        }
    }
}

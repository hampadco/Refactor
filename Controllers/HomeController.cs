using System.Diagnostics;
using System.IO.Ports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Refactor.Models;

namespace Refactor.Controllers;

public class HomeController : Controller
{
   private readonly IHubContext<DataHub> _hubContext;

        public HomeController(IHubContext<DataHub> hubContext)
        {
            _hubContext = hubContext;
        }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Gauge()
    {
        // TODO: Your code here
        return View();
    }
    public IActionResult Gaugetwo()
    {
        // TODO: Your code here
        return View();
    }
    

     public async Task StartReading()
        {
            using (SerialPort serialPort = new SerialPort("COM10"))
            {
                serialPort.Open();
                while(true)
                {
                    string data = serialPort.ReadLine();
                    await _hubContext.Clients.All.SendAsync("ReceiveData", data);
                }


            }
        }

    
}

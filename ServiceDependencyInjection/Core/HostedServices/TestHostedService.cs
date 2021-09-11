using Domain.App.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.HostedServices
{
    public class TestHostedService : BackgroundService
    {
        private readonly CancellationToken ct;

        private readonly IAppService objAppService;

        public TestHostedService(IAppService objAppService)
        {
            this.objAppService = objAppService;
            this.ct = new CancellationToken();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var run = Task.Factory.StartNew(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    Console.WriteLine(this.objAppService.HelloWorld());
                    Thread.Sleep(1000);
                }
            }, ct);

            //run.Wait();

            return run;
        }
    }
}

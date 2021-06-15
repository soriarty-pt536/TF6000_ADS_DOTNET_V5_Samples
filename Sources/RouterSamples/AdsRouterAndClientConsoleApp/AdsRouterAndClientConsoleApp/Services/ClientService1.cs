﻿using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace AdsRouterAndClientConsoleApp
{
    internal class ClientService1 : AdsBaseService
    {
        public ClientService1(AmsAddress address, ILogger logger) : base(address, logger)
        {
        }

        protected override async Task OnExecuteAsync(CancellationToken cancel)
        {
            string symbolName = "TwinCAT_SystemInfoVarList._AppInfo.ProjectName";
            ResultAnyValue result = await _client.ReadValueAsync(symbolName, typeof(string), cancel);

            if (result.Succeeded)
                _logger.LogInformation($"ProjectName of target '{_address}' is: '{result.Value}'");
            else
                _logger.LogError("Cannot get ProjectName from target '{address}'");
        }
    }
}
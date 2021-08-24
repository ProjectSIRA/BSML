using SiraUtil.Attributes;
using SiraUtil.Logging;
using SiraUtil.Zenject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeatSaberMarkupLanguage.Suite
{
    [Bind(Location.Menu)]
    public class Bootstrap : IAsyncInitializable
    {
        private readonly SiraLog _siraLog;
        private readonly MainFlowCoordinator _mainFlowCoordiantor;

        public Bootstrap(SiraLog siraLog, MainFlowCoordinator mainFlowCoordinator)
        {
            _siraLog = siraLog;
            _mainFlowCoordiantor = mainFlowCoordinator;
        }

        public async Task InitializeAsync(CancellationToken token)
        {
            await Task.Delay(1000);
            _siraLog.Info("Presenting UI");
        }
    }
}
using BeatSaberMarkupLanguage.Suite.FlowCoordinators;
using SiraUtil.Attributes;
using SiraUtil.Logging;
using SiraUtil.Zenject;
using System.Threading;
using System.Threading.Tasks;

namespace BeatSaberMarkupLanguage.Suite
{
    [Bind(Location.Menu)]
    internal class Bootstrap : IAsyncInitializable
    {
        private readonly SiraLog _siraLog;
        private readonly MainFlowCoordinator _mainFlowCoordiantor;
        private readonly TestingFlowCoordinator _testingFlowCoordinator;

        public Bootstrap(SiraLog siraLog, MainFlowCoordinator mainFlowCoordinator, TestingFlowCoordinator testingFlowCoordinator)
        {
            _siraLog = siraLog;
            _mainFlowCoordiantor = mainFlowCoordinator;
            _testingFlowCoordinator = testingFlowCoordinator;
        }

        public async Task InitializeAsync(CancellationToken token)
        {
            await Task.Delay(2000);

            _siraLog.Info("Presenting UI");
            _mainFlowCoordiantor.PresentFlowCoordinator(_testingFlowCoordinator);
            _siraLog.Info("Presented!");
        }
    }
}
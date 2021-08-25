using BeatSaberMarkupLanguage.Suite.ViewControllers.Testing;
using HMUI;
using SiraUtil.Attributes;
using SiraUtil.Logging;
using SiraUtil.Zenject;
using Zenject;

namespace BeatSaberMarkupLanguage.Suite.FlowCoordinators
{
    [Bind(Location.Menu)]
    internal class TestingFlowCoordinator : FlowCoordinator
    {
        [Inject]
        protected readonly SiraLog _siraLog = null!;

        [Inject]
        protected readonly MainTestViewController _mainTestViewController = null!;

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                _siraLog.Info("Activating for the first time");
                showBackButton = true;
                _siraLog.Info("Setting title");
                SetTitle("BSML Testing Suite");
                _siraLog.Info("Providing main view controller");
                ProvideInitialViewControllers(_mainTestViewController);
            }
        }
    }
}
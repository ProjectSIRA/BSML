using BeatSaberMarkupLanguage.Parsing;
using BeatSaberMarkupLanguage.Tags;
using IPA;
using SiraUtil.Attributes;
using SiraUtil.Logging;
using SiraUtil.Zenject;
using System.Threading;
using System.Threading.Tasks;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace BeatSaberMarkupLanguage
{
    [Plugin(RuntimeOptions.DynamicInit)]
    internal class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            zenjector.UseAutoBinder();
            zenjector.UseLogger(logger);

            zenjector.Install(Location.App, Container =>
            {
                Container.Bind<IBSMLParser>().To<SynchronousBSMLParser>().AsSingle();
                Container.Bind<BSMLTag>().To<TextTag>().AsCached();
            });
        }

        [OnEnable]
        public void OnEnable()
        {

        }

        [OnDisable]
        public void OnDisable()
        {

        }
    }

    [Bind(Location.Menu)]
    internal class EasyTester : IAsyncInitializable
    {
        [Inject]
        private readonly SiraLog _siraLog = null!;

        [Inject]
        private readonly IBSMLParser _bsmlParser = null!;

        public async Task InitializeAsync(CancellationToken token)
        {
            _siraLog.Info("starting up");
            var R = new UnityEngine.GameObject("AWOOGA");
            UnityEngine.Object.DontDestroyOnLoad(R);
            await _bsmlParser.Parse("<text><text><text><text><text></text></text></text></text></text>", R);
        }
    }
}
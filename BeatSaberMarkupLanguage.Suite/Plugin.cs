using IPA;
using SiraUtil.Attributes;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace BeatSaberMarkupLanguage.Suite
{
    [Plugin(RuntimeOptions.DynamicInit), Slog]
    public class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            zenjector.UseLogger(logger);
            zenjector.UseAutoBinder();
        }

        [OnEnable, OnDisable]
        public void OnState() => _ = true;
    }
}
using HMUI;
using SiraUtil.Logging;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Zenject;

namespace BeatSaberMarkupLanguage.ViewControllers
{
    /// <summary>
    /// A ViewController that supports BSML.
    /// </summary>
    public abstract class BSMLViewController : ViewController, INotifyPropertyChanged
    {
        [Inject]
        internal readonly SiraLog _bsmlSiraLog = null!;

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifies subscribes objects that a property on this instance has been changed.
        /// </summary>
        /// <param name="propertyName">The name of the property. If this is called within a property or method, the name of said property/method gets automatically assigned if nothing is specified.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                _bsmlSiraLog.Error($"Error Invoking PropertyChanged: {ex.Message}");
                _bsmlSiraLog.Error(ex);
            }
        }
    }
}
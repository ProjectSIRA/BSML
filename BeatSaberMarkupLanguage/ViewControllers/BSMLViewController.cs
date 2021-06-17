using BeatSaberMarkupLanguage.Parsing;
using HMUI;
using IPA.Utilities;
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
        private static readonly FieldAccessor<BSMLViewController, IBSMLParser>.Accessor BSMLVC_Parser = FieldAccessor<BSMLViewController, IBSMLParser>.GetAccessor(nameof(_bsmlParser)); 

        [Inject]
        internal readonly SiraLog _bsmlSiraLog = null!;

        /// <summary>
        /// The parser for this view controller.
        /// </summary>
        protected readonly IBSMLParser _bsmlParser = null!;

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Overrides the parser used by this view controller.
        /// </summary>
        /// <param name="bsmlParser">The new parser to use.</param>
        protected void OverrideParser(IBSMLParser bsmlParser)
        {
            if (bsmlParser is null)
                throw new ArgumentNullException(nameof(bsmlParser));

            BSMLViewController self = this;
            BSMLVC_Parser(ref self) = bsmlParser;
        }

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
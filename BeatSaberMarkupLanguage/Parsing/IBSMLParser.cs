using System.Threading.Tasks;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Parsing
{
    /// <summary>
    /// Defines a way for BSML to be parsed.
    /// </summary>
    public interface IBSMLParser
    {
        /// <summary>
        /// Parses an input into UI.
        /// </summary>
        /// <param name="content">The BSML input which is used to generate the object.</param>
        /// <param name="root">The parent to parse and render onto.</param>
        /// <param name="host">The object host used for interop with the view and code.</param>
        /// <returns></returns>
        Task Parse(string content, GameObject root, object? host = null);
    }
}
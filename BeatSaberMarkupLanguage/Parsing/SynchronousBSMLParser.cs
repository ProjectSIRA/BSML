using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Parsing
{
    /// <summary>
    /// Synchronously parses BSML.
    /// </summary>
    public class SynchronousBSMLParser : IBSMLParser
    {
        /// <inheritdoc />
        public Task Parse(string content, GameObject root, object? host = null)
        {
            throw new NotImplementedException();
        }
    }
}
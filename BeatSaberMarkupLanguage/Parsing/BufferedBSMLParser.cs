using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Parsing
{
    /// <summary>
    /// A pseudo-asynchronous parsing method which executes a defined number of parsing methods per frame.
    /// </summary>
    public class BufferedBSMLParser : IBSMLParser
    {
        /// <inheritdoc />
        public Task Parse(string content, GameObject root, object? host = null)
        {
            throw new NotImplementedException();
        }
    }
}
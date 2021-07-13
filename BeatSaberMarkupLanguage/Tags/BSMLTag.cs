using BeatSaberMarkupLanguage.Parsing.Building;
using System.Collections.Generic;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Tags
{
    /// <summary>
    /// An abstraction for a tag which represents an element.
    /// </summary>
    public abstract class BSMLTag
    {
        /// <summary>
        /// The ID(s) which identify this tag.
        /// </summary>
        public abstract IEnumerable<string> Aliases { get; }

        /// <summary>
        /// Gets the builder used to construct this tag.
        /// </summary>
        /// <param name="parent">The parent object to build onto.</param>
        /// <returns>The builder.</returns>
        public abstract IObjectBuilder GetBuilder(Transform parent);
    }
}
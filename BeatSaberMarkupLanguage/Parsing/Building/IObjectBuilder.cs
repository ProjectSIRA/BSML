using System.Threading.Tasks;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Parsing.Building
{
    /// <summary>
    /// Provides a way to build an object iteratively.
    /// </summary>
    public interface IObjectBuilder
    {
        /// <summary>
        /// Indicates if the object builder is completed.
        /// </summary>
        bool Completed { get; }

        /// <summary>
        /// Builds the next object.
        /// </summary>
        Task Next();

        /// <summary>
        /// Gets the result for this builder.
        /// </summary>
        /// <returns>If successfully built, returns the built object. If not, returns null.</returns>
        GameObject? GetResult();
    }
}
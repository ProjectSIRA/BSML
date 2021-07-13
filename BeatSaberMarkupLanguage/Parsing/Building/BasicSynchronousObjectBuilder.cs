using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Parsing.Building
{
    /// <summary>
    /// Builds an object synchronously in one step.
    /// </summary>
    public class BasicSynchronousObjectBuilder : IObjectBuilder
    {
        /// <inheritdoc/>
        public bool Completed { get; private set; }
        private readonly Func<Transform, GameObject> _buildAction;
        private readonly Transform _parent;
        private GameObject? _result;

        /// <summary>
        /// Constructs a new object builder.
        /// </summary>
        /// <param name="parent">The parent to build onto.</param>
        /// <param name="buildAction">called when an object is requested to be built.</param>
        public BasicSynchronousObjectBuilder(Transform parent, Func<Transform, GameObject> buildAction)
        {
            _parent = parent;
            _buildAction = buildAction;
        }

        /// <inheritdoc/>
        public Task Next()
        {
            _result = _buildAction.Invoke(_parent);
            Completed = true;
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public GameObject? GetResult()
        {
            return _result;
        }
    }
}
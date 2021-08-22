using BeatSaberMarkupLanguage.Parsing.Building;
using HMUI;
using SiraUtil.Logging;
using System.Collections.Generic;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Tags
{
    /// <summary>
    /// Creates a new text.
    /// </summary>
    public class TextTag : BSMLTag
    {
        /// <inheritdoc />
        public override IEnumerable<string> Aliases => new string[] { "text", "label" };
        private readonly SiraLog _siraLog;

        internal TextTag(SiraLog siraLog)
        {
            _siraLog = siraLog;
        }

        /// <summary>
        /// Generates a new text builder.
        /// </summary>
        public override IObjectBuilder GetBuilder(Transform parent)
        {
            return new BasicSynchronousObjectBuilder(parent, CreateText);
        }

        private GameObject CreateText(Transform parent)
        {
            GameObject gameObject = new("BSMLText");
            gameObject.transform.SetParent(parent, false);

            CurvedTextMeshPro text = gameObject.AddComponent<CurvedTextMeshPro>();
            text.text = "Default Text";
            text.color = Color.white;
            text.fontSize = 4;

            text.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            text.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

            return gameObject;
        }
    }
}
using BeatSaberMarkupLanguage.Tags;
using SiraUtil.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace BeatSaberMarkupLanguage.Parsing
{
    /// <summary>
    /// Synchronously parses BSML.
    /// </summary>
    public class SynchronousBSMLParser : IBSMLParser
    {
        private readonly SiraLog _siraLog;
        private readonly Dictionary<string, BSMLTag> _tags = new();
        private readonly XmlReaderSettings _xmlReaderSettings = new() { IgnoreComments = true };

        internal SynchronousBSMLParser(SiraLog siraLog, List<BSMLTag> tags)
        {
            _siraLog = siraLog;
            foreach (var tag in tags)
                foreach (var alias in tag.Aliases)
                    _tags.Add(alias, tag);
        }

        /// <inheritdoc />
        public Task Parse(string content, GameObject root, object? host = null)
        {
            _siraLog.Debug("Starting synchronous parsing of BSML.");
            XmlDocument document = new();
            document.Load(XmlReader.Create(new StringReader(content), _xmlReaderSettings));

            _siraLog.Debug("Starting node handling.");
            foreach (XmlNode node in document)
                HandleNode(node, root);

            return Task.CompletedTask;
        }

        private Task HandleNode(XmlNode node, GameObject parent)
        {
            if (!_tags.TryGetValue(node.Name, out BSMLTag tag))
            {
                throw new Exception("Tag type '" + node.Name + "' not found.");
            }

            _siraLog.Debug($"Constructing tag '{node.Name}'");
            var builder = tag.GetBuilder(parent.transform);
            while (!builder.Completed)
                builder.Next().RunSynchronously();

            _siraLog.Debug($"Completed parsing of '{node.Name}'");
            GameObject active = builder.GetResult()!;
            foreach (XmlNode child in node.ChildNodes)
            {
                _siraLog.Debug($"Processing child node: '{child.Name}'");
                HandleNode(child, active);
            }

            return Task.CompletedTask;
        }
    }
}
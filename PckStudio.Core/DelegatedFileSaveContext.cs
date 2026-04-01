using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PckStudio.Interfaces;
using PckStudio.Core;
using System.Diagnostics;

namespace PckStudio.Core
{
    public sealed class DelegatedFileSaveContext<T> : ISaveContext<T>
    {
        public delegate void SerializeDataToStreamDelegate(T value, Stream stream);

        public bool AutoSave { get; }
        public string Filepath { get; private set; }
        private SerializeDataToStreamDelegate _serializeDataDelegate;

        public DelegatedFileSaveContext(string filepath, bool autoSave, SerializeDataToStreamDelegate serializeDataDelegate)
        {
            AutoSave = autoSave;
            Filepath = filepath;
            _serializeDataDelegate = serializeDataDelegate;
        }

        public void Save(T value)
        {
            using (Stream stream = File.OpenWrite(Filepath))
            {
                _serializeDataDelegate(value, stream);
            }
        }
    }
}

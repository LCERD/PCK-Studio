using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PckStudio.Interfaces;
using System.IO;

namespace PckStudio.Controls
{
    internal class EditorControl<T> : UserControl, IEditor<T> where T : class
    {
        public T EditorValue { get; }

        public ISaveContext<T> SaveContext { get; private set; }

        public string TitleName { get; }

        public EditorControl()
        {
        }

        protected EditorControl(string titleName, T value, ISaveContext<T> saveContext)
        {
            _ = value ?? throw new ArgumentNullException(nameof(value));
            TitleName = titleName;
            EditorValue = value;
            SaveContext = saveContext;
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (SaveContext.AutoSave)
                Save();
            base.OnControlRemoved(e);
        }

        public void SetSaveContext(ISaveContext<T> saveContext) => SaveContext = saveContext;

        protected virtual void PreSave()
        { }
        
        protected virtual void PostSave()
        { }

        public void Save()
        {
            PreSave();
            SaveContext.Save(EditorValue);
            PostSave();
        }

        public virtual void Close() => throw new NotImplementedException();

        public virtual void UpdateView() => throw new NotImplementedException();
    }
}

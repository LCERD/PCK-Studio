using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Interfaces
{
    public interface IEditor<T> where T : notnull
    {
        string TitleName { get; }

        T EditorValue { get; }

        ISaveContext<T> SaveContext { get; }

        void SetSaveContext(ISaveContext<T> saveContext);

        void Save();

        void Close();

        void UpdateView();
    }
}
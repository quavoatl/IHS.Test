using System;
using System.Collections.Generic;
using System.Text;

namespace IHS.Test.Services
{
    public interface ITemplateService<T> where T: class
    {
        T LoadDocument(string path);

        void SaveDocument(string path, T input);

        bool ReplaceWord(T input, string wordToReplace, string newWord);
    }
}

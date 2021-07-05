using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IHS.Test.Models;

namespace IHS.Test.Services
{
    public class TemplateService : ITemplateService<LegalDocument>
    {
        public LegalDocument LoadDocument(string path)
        {
            return new LegalDocument
            {
                Content = File.ReadAllText(path)
            };
        }

        public void SaveDocument(string path, LegalDocument input)
        {
            File.WriteAllText(path, input.Content);
        }

        public bool ReplaceWord(LegalDocument input, string wordToReplace, string newWord)
        {
            var wordFound = false;
            var splitOptions = new[] { ' ' };
            var splitInput = input.Content.Split(splitOptions, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitInput.Length; i++)
            {
                if (splitInput[i].Equals(wordToReplace))
                {
                    splitInput[i] = newWord;
                    wordFound = true;
                }
            }

            if (wordFound)
            {
                input.Content = string.Join(" ", splitInput);
            }

            return wordFound;
        }
    }
}

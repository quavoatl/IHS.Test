using System;
using System.IO;
using IHS.Test.Models;
using IHS.Test.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IHS.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();
            var templateService = serviceProvider.GetService<ITemplateService<LegalDocument>>();

            var path = Path.Combine(Environment.CurrentDirectory, @"SourceFile\LegalDocument.txt");

            if (templateService != null)
            {
                var document = templateService.LoadDocument(path);
                templateService.ReplaceWord(document, "edited", "edited2");
            }
        }

        private static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<ITemplateService<LegalDocument>, TemplateService>()
                .BuildServiceProvider();
        }
    }
}

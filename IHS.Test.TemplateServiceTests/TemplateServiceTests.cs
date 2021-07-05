using FluentAssertions;
using IHS.Test.Models;
using IHS.Test.Services;
using Xunit;

namespace IHS.Test.TemplateServiceTests
{
    public class TemplateServiceTests
    {
        private readonly TemplateService _templateService;

        public TemplateServiceTests()
        {
            _templateService = new TemplateService();
        }

        [Theory]
        [InlineData("word1", "word2", "word1 should be replaced with word2", "word2 should be replaced with word2")]
        [InlineData("Word1", "word2", "Word1 should be replaced with word2", "word2 should be replaced with word2")]
        public void ReplaceWord_Should_ReturnExpectedValue(string wordToBeReplaced, string newWord, string input, string expectedValue)
        {
            var legalDocument = new LegalDocument { Content = input };
            _templateService.ReplaceWord(legalDocument, wordToBeReplaced, newWord);

            legalDocument.Content.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("word1", "word2", "word11 should be replaced with word2")]
        [InlineData("Word1", "word2", "Word11 should be replaced with word2")]
        public void ReplaceWord_Should_NotReplaceNotFoundWord(string wordToBeReplaced, string newWord, string input)
        {
            var legalDocument = new LegalDocument { Content = input };
            var result = _templateService.ReplaceWord(legalDocument, wordToBeReplaced, newWord);

            result.Should().Be(false);
        }
    }
}

using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Devpack.Extensions.Tests.Extensions
{
    public class StringExtensionsTests : UnitTestBase
    {
        [Theory(DisplayName = "Remove espaços em branco de uma string quando existem espaços em branco na mesma.")]
        [InlineData(" linha de  comando", "linhadecomando")]
        [InlineData("  ", "")]
        public void RemoveAllSpaces(string text, string result)
        {
            text.RemoveAllSpaces().Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar verdadeiro quando uma string é passada vazia ou nula.")]
        [InlineData(Empty)]
        [InlineData(null)]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrEmpty_BeTrue(string text)
        {
            text.IsNullOrEmpty().Should().BeTrue();
        }

        [Theory(DisplayName = "Deve retornar falso quando uma string é passada com algum preenchimento.")]
        [InlineData("abc")]
        [InlineData(Space)]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrEmpty_BeFalse(string text)
        {
            text.IsNullOrEmpty().Should().BeFalse();
        }

        [Fact(DisplayName = "Deve remover um trecho de texto quando ele estiver presente dentro de uma string.")]
        [Trait("Categoria", "Extensions")]
        public void RemoveText_UsingString()
        {
            //Arrange
            var replaceText = _faker.Random.String2(5);
            var notReplaceText = _faker.Random.String2(5);

            var strBuilder = new StringBuilder()
                .Append(replaceText)
                .Append(notReplaceText)
                .Append(replaceText)
                .Append(notReplaceText);

            //Act
            var aux = strBuilder.ToString().RemoveText(replaceText);


            //Assert
            aux.Should().Be(new StringBuilder().Append(notReplaceText).Append(notReplaceText).ToString());
        }

        [Fact(DisplayName = "Deve remover um trecho de texto quando ele estiver presente dentro de uma string usando Regex.")]
        [Trait("Categoria", "Extensions")]
        public void RemoveText_UsingRegex()
        {
            //Arrange
            var replaceText = _faker.Random.String2(5);
            var notReplaceText = _faker.Random.String2(5);

            var strBuilder = new StringBuilder()
                .Append(replaceText)
                .Append(notReplaceText)
                .Append(replaceText)
                .Append(notReplaceText);

            //Act
            var aux = strBuilder.ToString().RemoveText(new Regex(replaceText));

            //Assert
            aux.Should().Be(new StringBuilder().Append(notReplaceText).Append(notReplaceText).ToString());
        }

        [Fact(DisplayName = "Deve remover a primeira ocorrencia de um texto quando a string contém o texto informado.")]
        public void RemoveFirstOccurence()
        {
            //Arrange
            var removeText = _faker.Random.String2(5);
            var notRemoveText = _faker.Random.String2(5);

            var strBuilder = new StringBuilder()
                .Append(removeText)
                .Append(notRemoveText)
                .Append(removeText)
                .Append(notRemoveText);

            //Act
            var aux = strBuilder.ToString().RemoveFirstOccurence(new Regex(removeText));

            //Assert
            aux.Should().Be(new StringBuilder()
                .Append(notRemoveText)
                .Append(removeText)
                .Append(notRemoveText).ToString());
        }

        [Theory(DisplayName = "Deve remover a acentuação de uma string quando a mesma contiver qualquer tipo de acentuação.")]
        [InlineData(AlphaNumeric, AlphaNumeric)]
        [InlineData("asáçãàê", "asacaae")]
        [Trait("Categoria", "Extensions")]
        public void RemoveGrammarAccents(string text, string result)
        {
            text.RemoveGrammarAccents().Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar uma string vazia quando a mesma for nula.")]
        [InlineData(null, Empty)]
        [InlineData(AlphaNumeric, AlphaNumeric)]
        [Trait("Categoria", "Extensions")]
        public void NullAsEmpty(string text, string result)
        {
            text.NullAsEmpty().Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar nulo quando passado uma string vazia.")]
        [InlineData(Empty, null)]
        [InlineData(AlphaNumeric, AlphaNumeric)]
        [Trait("Categoria", "Extensions")]
        public void EmptyAsNull(string text, string result)
        {
            text.EmptyAsNull().Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar uma string com as primeiras letras de cada palavra em maiúsculo " +
            "quando uma string válida for passada")]
        [InlineData("paulo cesar de Coelho", "Paulo Cesar de Coelho")]
        [InlineData("tesTe", "Teste")]
        [InlineData(Empty, Empty)]
        [InlineData(null, Empty)]
        [Trait("Categoria", "Extensions")]
        public void Captalize_RetornaStringNoFormatoCaptalize(string text, string result)
        {
            "teste para o uso do método de capitalização.".Captalize();
            text.Captalize().Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar um texto com aplicação de máscara quando um tamanho fixo de máscara for passado.")]
        [InlineData("Afd125", "******")]
        [InlineData("1458-5885-6263-4554", "****-****-****-4554")]
        [InlineData(Empty, Empty)]
        [InlineData(null, Empty)]
        [Trait("Categoria", "Extensions")]
        public void MaskCharacters_WhenFixMask(string text, string result)
        {
            text.MaskCharacters('*', 12).Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar um texto com aplicação de máscara quando não for passado um tamanho fixo de máscara.")]
        [InlineData("Afd125", "******")]
        [InlineData("1458-5885-6263-4554", "****-****-****-****")]
        [InlineData(Empty, Empty)]
        [InlineData(null, Empty)]
        [Trait("Categoria", "Extensions")]
        public void MaskCharacters_WhenNotFixMask(string text, string result)
        {
            text.MaskCharacters('*').Should().Be(result);
        }

        [Theory(DisplayName = "Deve retornar um texto sem quebra de linhas, sendo possível as substituir por um caracter informado quando um texto for passado em 'text'.")]
        [InlineData("Texto\ncom 2 quebras\n de linha.", "$", 2)]
        [InlineData("Texto\tcom\t5 tabulações\tna\tlinha\t.", "@", 5)]
        public void RemoveLineBreaks_WhenRemoveBreaks(string text, string newCharacter, int countCharExpected)
        {
            //Arrange
            var originalText = text;
            text = text.RemoveLineBreaks(newCharacter);

            //Act
            var countCharFound = text.Count(c => newCharacter.Contains(c));

            //Assert
            countCharFound.Should().Be(countCharExpected);
            originalText.Should().NotBe(text);
        }

        [Theory(DisplayName = "Deve retornar um texto sem modificações quando um texto sem quebra de linha for passado em 'text'.")]
        [InlineData("Texto sem quebras de linha.", "", 0)]
        public void RemoveLineBreaks_WhenNotRemoveBreaks(string text, string newCharacter, int countCharExpected)
        {
            //Arrange
            var originalText = text;
            text = text.RemoveLineBreaks(newCharacter);

            //Act
            var countCharFound = text.Count(c => newCharacter.Contains(c));


            //Assert
            countCharFound.Should().Be(countCharExpected);
            originalText.Should().Be(text);
        }

        [Theory(DisplayName = "Deve retornar um texto sem os caracteres que devem ser removidos quando 'charsToRemove' contendo os caracteres for passado.")]
        [InlineData("Texto <> para -- $remover!@.", new string[] { "<", ">", "!", "@", "-" })]
        [InlineData("Outro texto <<<> p%ra -- $remover!@**.", new string[] { "<", ">", "!", "@", "-", "%", "**" })]
        public void ReplaceAll_WhenReplace(string text, string[] charsToRemove)
        {
            //Arrange
            var originalText = text;
            text = text.ReplaceAll(charsToRemove, string.Empty);

            //Act
            var countCharFound = text.Count(c => charsToRemove.Any(obj => obj.Contains(c)));

            //Assert
            countCharFound.Should().Be(0);
            originalText.Should().NotBe(text);
        }

        [Theory(DisplayName = "Deve retornar um texto sem modificações quando 'charsToRemove' não possuir nenhum caracter existente no texto ou for vazio.")]
        [InlineData("Texto <> para -- remover!@.", new string[] { "$", "%" })]
        [InlineData("Texto2 <> para -- remover!@.", new string[] { })]
        public void ReplaceAll_WhenNotReplace(string text, string[] charsToRemove)
        {
            //Arrange
            var originalText = text;
            text = text.ReplaceAll(charsToRemove, string.Empty);

            //Act
            var countCharFound = text.Count(c => charsToRemove.Any(obj => obj.Contains(c)));

            //Assert
            countCharFound.Should().Be(0);
            originalText.Should().Be(text);
        }

        [Theory(DisplayName = "Deve retornar uma string em base64 quando 'text' for passado.")]
        [InlineData("TextoParaBase64", "VGV4dG9QYXJhQmFzZTY0")]
        [InlineData("OutroTextoParaBase64", "T3V0cm9UZXh0b1BhcmFCYXNlNjQ=")]
        public void ToBase64_WhenConvert(string text, string expectedText)
        {
            expectedText.Should().Be(text.ToBase64());
        }

        [Fact(DisplayName = "Deve retornar uma string como guid inválida, quando feita uma verificação se a conversão resultou em um guid.")]
        public void ToBase64_WhenNotConvert()
        {
            //Arrange
            var text = "TextoParaBase64";
            text = text.ToBase64();

            //Act
            var isValidGuid = Guid.TryParse(text, out _);

            //Assert
            isValidGuid.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve retornar true quando as strings forem iguais.")]
        [InlineData("valor", "valor")]
        [InlineData("novoValor", "novoValor")]
        public void Match_WhenTrue(string value, string compare)
        {
            value.Match(compare).Should().BeTrue();
        }

        [Theory(DisplayName = "Deve retornar false quando as strings forem diferentes.")]
        [InlineData("valor", "valores")]
        [InlineData("novoValor", "novo valor")]
        public void Match_WhenFalse(string value, string compare)
        {
            value.Match(compare).Should().BeFalse();
        }

        [Theory(DisplayName = "Deve retornar somente os alfanuméricos quando o texto informado possuir caracteres especiais.")]
        [InlineData("v$a#l&*o(r", "v a l  o r")]
        [InlineData("1234##%567", "1234   567")]
        [InlineData("==oi==", "oi")]
        public void GetOnlyAlphanumeric_WhenSuccess(string value, string expectedValue)
        {
            value.GetOnlyAlphanumeric().Should().Be(expectedValue);
        }

        [Theory(DisplayName = "Deve retornar o texto sem modificações quando o texto informado não possuir caracteres especiais.")]
        [InlineData("valor", "valor")]
        [InlineData("1234567", "1234567")]
        [InlineData(Empty, Empty)]
        public void GetOnlyAlphanumeric_WhenFail(string value, string expectedValue)
        {
            value.GetOnlyAlphanumeric().Should().Be(expectedValue);
        }

        [Theory(DisplayName = "Deve retornar verdadeiro quando uma string é passada vazia, nula ou com espaços em branco.")]
        [InlineData(Empty)]
        [InlineData(Space)]
        [InlineData(null)]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrWhiteSpace_BeTrue(string text)
        {
            text.IsNullOrWhiteSpace().Should().BeTrue();
        }

        [Theory(DisplayName = "Deve retornar falso quando uma string é passada com algum preenchimento.")]
        [InlineData("abc")]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrWhiteSpace_BeFalse(string text)
        {
            text.IsNullOrWhiteSpace().Should().BeFalse();
        }

        [Theory(DisplayName = "Deve retornar falso quando a string informada contém caracteres que não são numéricos.")]
        [InlineData("abc")]
        [InlineData("125a")]
        [InlineData("12 5")]
        [InlineData("")]
        [InlineData(null)]
        [Trait("Categoria", "Extensions")]
        public void HasOnlyDigits_BeFalse(string text)
        {
            text.HasOnlyDigits().Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando a string informada contém caracteres que não são numéricos.")]
        [Trait("Categoria", "Extensions")]
        public void HasOnlyDigits_BeTrue()
        {
            var text = _faker.Random.Number(1000, 5000).ToString();
            text.HasOnlyDigits().Should().BeTrue();
        }

        [Theory(DisplayName = "Deve retornar falso quando a string informada contém caracteres que não são letras.")]
        [InlineData("125")]
        [InlineData("sda1")]
        [InlineData("dsda a")]
        [InlineData("")]
        [InlineData(null)]
        [Trait("Categoria", "Extensions")]
        public void HasOnlyLetters_BeFalse(string text)
        {
            text.HasOnlyLetters().Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando a string informada contém caracteres que não são letras.")]
        [Trait("Categoria", "Extensions")]
        public void HasOnlyLetters_BeTrue()
        {
            var text = _faker.Random.String2(10);
            text.HasOnlyLetters().Should().BeTrue();
        }
    }
}
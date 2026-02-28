using System;
using System.Globalization;
using ChessExample;
using JetBrains.Annotations;
using Xunit;

namespace Practice3.Tests;

[TestSubject(typeof(CheckerBoardPosition))]
public class CheckerBoardPositionTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(8, 8)]
    [InlineData(4, 5)]
    [InlineData(1, 8)]
    [InlineData(8, 1)]
    public void Constructor_PassValidCoordinates_Success(byte x, byte y)
    {
        // Act
        var position = new CheckerBoardPosition(x, y);
        
        // Assert
        Assert.Equal(x, position.X);
        Assert.Equal(y, position.Y);
    }
    
    [Theory]
    [InlineData(0, 1)]
    [InlineData(9, 1)]
    [InlineData(1, 0)]
    [InlineData(1, 9)]
    [InlineData(0, 0)]
    [InlineData(9, 9)]
    public void Constructor_PassInvalidCoordinates_ThrowsArgumentOutOfRangeException(byte x, byte y)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(x, y));
    }
    
    [Theory]
    [InlineData("khzjkhhjeihgiw")]
    [InlineData("TeSSt081k;sl")]
    [InlineData("!@#::$")]
    [InlineData("")]
    [InlineData(null)]
    public void Parse_InvalidString_ThrowsFormatException(string invalidString)
    {
        // Act & Assert
        Assert.Throws<FormatException>(() => 
            CheckerBoardPosition.Parse(invalidString, CultureInfo.InvariantCulture));
    }
    
    
    [Theory]
    [InlineData(1, 'A')]
    [InlineData(2, 'B')]
    [InlineData(3, 'C')]
    [InlineData(4, 'D')]
    [InlineData(5, 'E')]
    [InlineData(6, 'F')]
    [InlineData(7, 'G')]
    [InlineData(8, 'H')]
    public void Constructor_PassValidNumberForConvertingToLetter_Success(byte x, char expectedLetter)
    {
        // Arrange
        var position = new CheckerBoardPosition(x, 1);
        
        // Act & Assert
        Assert.Equal(expectedLetter, position.XLetter);
    }
    
    [Theory]
    [InlineData(1, 1, "A1")]
    [InlineData(8, 8, "H8")]
    [InlineData(4, 5, "D5")]
    [InlineData(2, 7, "B7")]
    public void ToString_ValidPosition_Success(byte x, byte y, string expected)
    {
        // Arrange
        var position = new CheckerBoardPosition(x, y);
        
        // Act
        var result = position.ToString();
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    
    
    [Theory]
    [InlineData("A1")]
    [InlineData("B2")]
    [InlineData("C5")]
    [InlineData("D4")]
    public void TryParse_ValidInput_Success(string input)
    {
        // Act & Assert
        Assert.True(CheckerBoardPosition.TryParse(input, CultureInfo.InvariantCulture, out var position));
        Assert.NotNull(position);
    }
    
    
    [Theory]
    [InlineData("Z9")]
    [InlineData("B9")]
    [InlineData("Y1")]
    [InlineData("X4")]
    public void TryParse_InvalidInput_Fail(string input)
    {
        // Act & Assert
        Assert.False(CheckerBoardPosition.TryParse(input, CultureInfo.InvariantCulture, out var position));
        Assert.Null(position);
    }

    [Theory]
    [InlineData("A5")]
    // Using .Parse().ToString should be equal to the original string input
    public void ParseAndToString_ValidInput_Success(string input)
    {
        
        // Act & Assert
        Assert.True(CheckerBoardPosition.Parse(input, CultureInfo.InvariantCulture).ToString() == input);
    }
}
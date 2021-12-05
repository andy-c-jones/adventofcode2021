﻿using NUnit.Framework;
using sonar.DayFour;

namespace sonar.tests.DayFour;

public class BingoReaderTests
{
    [Test]
    public async Task Should_parse_input_from_file()
    {
        var bingoReader = new BingoReader();

        var gameData = await bingoReader.ReadFrom("./DayHour/InputExample.txt");

        Assert.Multiple(() =>
        {
            CollectionAssert.AreEquivalent(
                new[]
                {
                    7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1
                },
                gameData.NumbersToDraw);

            CollectionAssert.AreEquivalent(new[]
                {
                    new Board(new[]
                    {
                        new[] {Item(22), Item(13), Item(17), Item(11), Item(0)},  
                        new[] {Item(8), Item(2), Item(23), Item(4), Item(24)},  
                        new[] {Item(21), Item(9), Item(14), Item(16), Item(7)},  
                        new[] {Item(6), Item(10), Item(3), Item(18), Item(5)},  
                        new[] {Item(1), Item(12), Item(20), Item(15), Item(19)},  
                    }),
                    new Board(new[]
                    {
                        new[] {Item(3), Item(15), Item(0), Item(2), Item(22)},  
                        new[] {Item(9), Item(18), Item(13), Item(17), Item(5)},  
                        new[] {Item(19), Item(8), Item(7), Item(25), Item(23)},  
                        new[] {Item(20), Item(11), Item(10), Item(24), Item(4)},  
                        new[] {Item(14), Item(21), Item(16), Item(12), Item(6)},  
                    }),
                    new Board(new[]
                    {
                        new[] {Item(14), Item(21), Item(17), Item(24), Item(4)},  
                        new[] {Item(10), Item(16), Item(15), Item(9), Item(19)},  
                        new[] {Item(18), Item(8), Item(23), Item(26), Item(20)},  
                        new[] {Item(22), Item(11), Item(13), Item(6), Item(5)},  
                        new[] {Item(2), Item(0), Item(12), Item(3), Item(7)},  
                    }),
                }
                , gameData.Boards);
        });
        
        
    }
    
    GridItem Item(int number) => new GridItem(13, false);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleships;
using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlay()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };
            Game.Play(ships, guesses).Should().Be(0);
        }

        [Fact]
        public void TestPlay_Positive()
        {
            var ships = new[] { "3:2,3:3", "1:1,3:1" };
            var guesses = new[] { "3:2", "3:3" };
            Game.Play(ships, guesses).Should().Be(1);
        }      

        [Fact]
        public void TestPlay_Multiple()
        {
            var ships = new[] { "3:2,3:4", "1:3,1:1", "0:0,0:1", "6:2,8:2" };
            var guesses = new[] { "3:2", "3:3", "3:4", "0:0", "7:2", "1:1", "1:2", "1:3" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        [Fact]
        public void TestPlay_MultipleNegative()
        {
            var ships = new[] { "3:2,3:5", "1:3,1:1", "0:0,0:1", "6:2,8:2" };
            var guesses = new[] { "3:2", "3:4", "0:0", "7:2", "1:2", "1:3" };
            Game.Play(ships, guesses).Should().Be(0);
        }

        [Fact]
        public void TestPlay_MultipleAllPositive()
        {
            var ships = new[] { "9:7,9:9", "4:4,4:5", "7:0,7:1" };
            var guesses = new[] { "9:7", "9:8", "9:9", "4:4", "4:5", "7:0", "7:1" };
            Game.Play(ships, guesses).Should().Be(3);
        }
    }
}

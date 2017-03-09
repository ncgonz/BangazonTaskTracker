using System;

namespace BangazonTaskTracker.Tests.DAL
{
    public class RandomAdder
    {
        readonly RandomNumberGenerator _randomNumberGenerator;

        public RandomAdder(RandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public int AddRandomly(int addToRandomNumber)
        {
            return addToRandomNumber + _randomNumberGenerator.RandomNumberToAdd;
        }
    }

    public class RandomNumberGenerator
    {
        public virtual int RandomNumberToAdd { get; set; }

        public RandomNumberGenerator()
        {
            Random rnd = new Random();
            RandomNumberToAdd = rnd.Next(1, 13);
        }
    }

    class MockedRandomNumberGenerator : RandomNumberGenerator
    {
        public override int RandomNumberToAdd { get { return 2; } set {Console.WriteLine(value);} }
    }
}
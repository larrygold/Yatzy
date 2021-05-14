namespace Yatzy
{
    public class Yatzy
    {
        protected int[] Dice;

        public Yatzy(int d1, int d2, int d3, int d4, int d5)
        {
            Dice = new int[5];
            Dice[0] = d1;
            Dice[1] = d2;
            Dice[2] = d3;
            Dice[3] = d4;
            Dice[4] = d5;
        }

        public static int Chance(int d1, int d2, int d3, int d4, int d5) => d1 + d2 + d3 + d4 + d5;

        public static int Yams(params int[] dice)
        {
            var value = dice[0];
            for (var i = 1; i < dice.Length; i++)
            {
                if (dice[i] != value)
                {
                    return 0;
                }
            }
            return 50;
        }

        public static int ComputeScoreForDiceWithValue(int value, int d1, int d2, int d3, int d4, int d5)
        {
            var sum = 0;
            var dice = new int[] { d1, d2, d3, d4, d5 };

            foreach (var die in dice)
            {
                if (die == value)
                {
                    sum += value;
                }
            }

            return sum;

        }

        public static int Ones(int d1, int d2, int d3, int d4, int d5) =>
            ComputeScoreForDiceWithValue(1, d1, d2, d3, d4, d5);

        public static int Twos(int d1, int d2, int d3, int d4, int d5) =>
            ComputeScoreForDiceWithValue(2, d1, d2, d3, d4, d5);

        public static int Threes(int d1, int d2, int d3, int d4, int d5) =>
            ComputeScoreForDiceWithValue(3, d1, d2, d3, d4, d5);

        public int ComputeScoreForDiceWithValue(int value)
        {
            var sum = 0;
            foreach (var die in Dice)
            {
                if (die == value)
                {
                    sum += value;
                }
            }

            return sum;
        }

        public int Fours() => ComputeScoreForDiceWithValue(4);

        public int Fives() => ComputeScoreForDiceWithValue(5);

        public int Sixes() => ComputeScoreForDiceWithValue(6);

        public static int[] CountDiceOccurrences(int d1, int d2, int d3, int d4, int d5)
        {
            var counts = new int[6];
            counts[d1 - 1] += 1;
            counts[d2 - 1] += 1;
            counts[d3 - 1] += 1;
            counts[d4 - 1] += 1;
            counts[d5 - 1] += 1;
            return counts;
        }

        public static int ScorePair(int d1, int d2, int d3, int d4, int d5)
        {
            var counts = CountDiceOccurrences(d1, d2, d3, d4, d5);

            for (var i = counts.Length - 1; i >= 0; i--)
            {
                if (counts[i] >= 2)
                {
                    return (i + 1) * 2;
                }
            }

            return 0;
        }

        public static int TwoPair(int d1, int d2, int d3, int d4, int d5)
        {
            var counts = CountDiceOccurrences(d1, d2, d3, d4, d5);
            var numberOfDiceAppearingMoreThanTwice = 0;
            var score = 0;

            for (var i = counts.Length - 1; i >= 0; i--)
            {
                if (counts[i] >= 2)
                {
                    numberOfDiceAppearingMoreThanTwice++;
                    score += i + 1;
                }
            }

            if (numberOfDiceAppearingMoreThanTwice == 2)
            {
                return score * 2;
            }

            return 0;
        }
        public static int ComputeXOfAKind(int value, int d1, int d2, int d3, int d4, int d5)
        {
            var counts = CountDiceOccurrences(d1, d2, d3, d4, d5);

            for (var i = 0; i < 6; i++)
            {
                if (counts[i] >= value)
                {
                    return (i + 1) * value;
                }
            }

            return 0;
        }

        public static int FourOfAKind(int d1, int d2, int d3, int d4, int d5) => ComputeXOfAKind(4, d1, d2, d3, d4, d5);

        public static int ThreeOfAKind(int d1, int d2, int d3, int d4, int d5) => ComputeXOfAKind(3, d1, d2, d3, d4, d5);

        public static int ComputeScoreForStraight(int minDieValue, int maxDieValue, int pointsGranted, int d1, int d2, int d3, int d4, int d5)
        {
            var counts = CountDiceOccurrences(d1, d2, d3, d4, d5);

            for (var i = minDieValue - 1; i <= maxDieValue - 1; i++)
            {
                if (counts[i] != 1)
                {
                    return 0;
                }
            }
            return pointsGranted;
        }
        public static int SmallStraight(int d1, int d2, int d3, int d4, int d5) => ComputeScoreForStraight(1, 5, 15, d1, d2, d3, d4, d5);

        public static int LargeStraight(int d1, int d2, int d3, int d4, int d5) => ComputeScoreForStraight(2, 6, 20, d1, d2, d3, d4, d5);

        public static int FullHouse(int d1, int d2, int d3, int d4, int d5)
        {

            var thereAreTwoIdenticalDice = false;
            var twoIdenticalDiceValue = 0;
            var thereAreThreeIdenticalDice = false;
            var threeIdenticalDiceValue = 0;

            var counts = CountDiceOccurrences(d1, d2, d3, d4, d5);

            for (var i = 0; i < counts.Length; i++)
            {
                if (counts[i] == 2)
                {
                    thereAreTwoIdenticalDice = true;
                    twoIdenticalDiceValue = i + 1;
                }

                if (counts[i] == 3)
                {
                    thereAreThreeIdenticalDice = true;
                    threeIdenticalDiceValue = i + 1;
                }
            }

            if (thereAreTwoIdenticalDice && thereAreThreeIdenticalDice)
                return twoIdenticalDiceValue * 2 + threeIdenticalDiceValue * 3;
            return 0;
        }
    }
}
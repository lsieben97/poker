using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace poker
{
    public class game
    {
        public static Size defaultCardSize = new Size(72, 96);
        // card positions
        public static Point deckPosition = new Point(880,255);
        public static Point fieldPosition1 = new Point(12,405);
        public static Point fieldPosition2 = new Point(199, 405);
        public static Point fieldPosition3 = new Point(386, 405);
        public static Point fieldPosition4 = new Point(573, 405);
        public static Point fieldPosition5 = new Point(760, 405);
        public List<card> cards = new List<card>();
        public List<card> fieldCards = new List<card>();
        public void loadcards()
        {
            // load card images
            string[] files = Directory.GetFiles("cards/");
            foreach(string file in files)
            {
                card c = new card();
                string name = Path.GetFileNameWithoutExtension(file);
                
                switch(name.Substring(0,1))
                {
                    case "h":
                        c.type = card.cardType.hearts;
                        break;
                    case "r":
                        c.type = card.cardType.diamonds;
                        break;
                    case "k":
                        c.type = card.cardType.clubs;
                        break;
                    case "s":
                        c.type = card.cardType.spades;
                        break;
                }

                c.value = int.Parse(name.Substring(1));
                c.image = Image.FromFile(file);
                this.cards.Add(c);
            }
        }

        public void calculatePayout()
        {
            this.fieldCards.Reverse();
            List<int> values = new List<int>();
            foreach(card c in this.fieldCards)
            {
                values.Add(c.value);
            }
            if(this.fieldCards.TrueForAll(c => c.type == card.cardType.hearts ||
                                               c.type == card.cardType.clubs ||
                                               c.type == card.cardType.diamonds ||
                                               c.type == card.cardType.spades))
            {
                // all cards have same type
                if(values.Zip(values.Skip(1), (a, b) => (a + 1) == b).All(x => x))
                {
                    // cards are consecutive
                    if(values[0] == 10)
                    {
                        // royal flush
                        //payout * 250
                    }
                    else
                    {
                        // straight flush
                        // payout * 50
                    }
                }
                else
                {
                    // flush
                    // payout * 6
                }
            }
            else
            {
                // cards don't have the same type
                IEnumerable<IGrouping<int, card>> cards = this.fieldCards.GroupBy(card => card.value).OrderByDescending(group => group.Count());
                if (cards.ElementAt<IGrouping<int, card>>(0).Key == 3 && cards.ElementAt<IGrouping<int, card>>(1).Key == 2)
                {
                    // full house
                }
                else if (values.Zip(values.Skip(1), (a, b) => (a + 1) == b).All(x => x))
                {
                    // straight
                    // payout * 4
                }
                else if(cards.ElementAt<IGrouping<int,card>>(0).Key == 4)
                {
                    // 4 of a kind

                }
                else if (cards.ElementAt<IGrouping<int, card>>(0).Key == 3)
                {
                    // 3 of a kind
                }
                else if(cards.ElementAt<IGrouping<int, card>>(0).Key == 2 && cards.ElementAt<IGrouping<int, card>>(1).Key == 2)
                {
                    // 2 pair
                }
                else if (cards.ElementAt<IGrouping<int, card>>(0).Key == 2)
                {
                    // pair
                }
                
            }

        }
    }
}

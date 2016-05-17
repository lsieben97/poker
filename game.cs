using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace poker
{
    public class game
    {
        public static Size defaultCardSize = new Size(72, 96);
        // card positions
        public static Point deckPosition = new Point(880,159);
        public static Point fieldPosition1 = new Point(12,309);
        public static Point fieldPosition2 = new Point(199, 309);
        public static Point fieldPosition3 = new Point(386, 309);
        public static Point fieldPosition4 = new Point(573, 309);
        public static Point fieldPosition5 = new Point(760, 309);
        public List<card> cards = new List<card>();
        public List<card> fieldCards = new List<card>();
        public int money = 10;
        public void loadcards()
        {
            // load card images
            string[] files = Directory.GetFiles("cards/");
            foreach(string file in files)
            {
                card c = new card();
                string name = Path.GetFileNameWithoutExtension(file);
                if (name != "back")
                {
                    switch (name.Substring(0, 1))
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
                    c.name = name;
                    this.cards.Add(c);
                }
            }
        }

        public void addCard(string data)
        {
            card c = new card();

            switch (data.Substring(0, 1))
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

            c.value = int.Parse(data.Substring(1));
            c.name = data;
            this.fieldCards.Add(c);
        }
        public int calculatePayout()
        {
            List<int> values = new List<int>();
            foreach(card c in this.fieldCards)
            {
                values.Add(c.value);
            }
            if (this.fieldCards.TrueForAll(c => c.type == card.cardType.hearts) == true || this.fieldCards.TrueForAll(c => c.type == card.cardType.clubs) == true || this.fieldCards.TrueForAll(c => c.type == card.cardType.diamonds) == true || this.fieldCards.TrueForAll(c => c.type == card.cardType.spades) == true)
            {
                // all cards have same type
                if(values.Zip(values.Skip(1), (a, b) => (a + 1) == b).All(x => x))
                {
                    // cards are consecutive
                    if(values[0] == 10)
                    {
                        MessageBox.Show("Royal Flush");
                        return 250;
                    }
                    else
                    {
                        MessageBox.Show("Straight Flush");
                        return 50;
                    }
                }
                else
                {
                    MessageBox.Show("Flush");
                    return 6;
                }
            }
            else
            {
                // cards don't have the same type
                IEnumerable<IGrouping<int, card>> cards = this.fieldCards.GroupBy(card => card.value).OrderByDescending(group => group.Count());
                if (cards.ElementAt<IGrouping<int, card>>(0).Count<card>() == 3 && cards.ElementAt<IGrouping<int, card>>(1).Count<card>() == 2)
                {
                    MessageBox.Show("Full house");
                    return 9;
                }
                else if (values.Zip(values.Skip(1), (a, b) => (a + 1) == b).All(x => x))
                {
                    MessageBox.Show("Straight");
                    return 4;
                }
                else if(cards.ElementAt<IGrouping<int,card>>(0).Count<card>() == 4)
                {
                    MessageBox.Show("4 of a kind");
                    return 25;
                }
                else if (cards.ElementAt<IGrouping<int, card>>(0).Count<card>() == 3)
                {
                    MessageBox.Show("3 of a kind");
                    return 3;
                }
                else if(cards.ElementAt<IGrouping<int, card>>(0).Count<card>() == 2 && cards.ElementAt<IGrouping<int, card>>(1).Count<card>() == 2)
                {
                    MessageBox.Show("2 pair");
                    return 2;
                }
                else if (cards.ElementAt<IGrouping<int, card>>(0).Count<card>() == 2)
                {
                    MessageBox.Show("pair");
                    return 1;
                }
                else
                {
                    MessageBox.Show("Junk");
                    return 0;
                }
                
            }
            this.fieldCards.Clear();
        }
    }
}

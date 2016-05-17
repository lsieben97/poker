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
                        c.type = card.cardType.harten;
                        break;
                    case "r":
                        c.type = card.cardType.ruiten;
                        break;
                    case "k":
                        c.type = card.cardType.klaveren;
                        break;
                    case "s":
                        c.type = card.cardType.schoppen;
                        break;
                }

                c.value = int.Parse(name.Substring(1));
                c.image = Image.FromFile(file);
                this.cards.Add(c);
            }
        }
    }
}

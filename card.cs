using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace poker
{
    public class card
    {
        public int value;
        public cardType type;
        public Image image;
        public string name;

        public card(int value, cardType type, Image image,string name)
        {
            this.value = value;
            this.type = type;
            this.image = image;
            this.name = name;
        }

        public card()
        {

        }

        public enum cardType
        {
            hearts,spades,clubs,diamonds
        }
    }
}

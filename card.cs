using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poker
{
    public class card
    {
        public int value;
        public cardType type;
        public enum cardType
        {
            harten,schoppen,klaveren,ruiten
        }
    }
}

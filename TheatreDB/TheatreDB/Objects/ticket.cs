using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreDB.Objects
{
    public class Ticket
    {
        public uint ID;
        public uint cost;
        public string discountName;
        public bool returned;
        public uint placeID;
        public uint loginID;
        public uint instanceID;
    }
}

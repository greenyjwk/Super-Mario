using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;
namespace Mario.XMLRead
{
    public class BlockXML
    {
        public string BlockType{ get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public String ItemContains { get; set; }
    }
}

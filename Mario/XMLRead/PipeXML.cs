using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;
namespace Mario.XMLRead
{
    public class PipeXML
    {
        public string BlockType { get; set; }
        public String IsToUnderground { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
    }
}

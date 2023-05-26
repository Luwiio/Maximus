using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Maximus
{
    internal class Card
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Element { get; set; }
        public int Cost { get; set; }
        public Image Art { get; set; }
       public void LoadImage(string filepath)
        {
            Art = Image.FromFile(filepath);
        }

    }
}

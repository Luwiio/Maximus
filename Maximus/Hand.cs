using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus
{
    internal class Hand
    {
        public int HandSize {  get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();      
    }



}

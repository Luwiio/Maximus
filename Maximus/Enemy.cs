using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Maximus
{

    internal class Enemy
    {

        #region Constructor
        /// <summary>
        /// Guy to beat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        #endregion Constructor

        #region Parameters
        public string Name { get; set; }
        public int Health { get; set; }
        #endregion Parameters

    }
}

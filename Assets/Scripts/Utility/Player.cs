using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class Player
    {
        public string PlayerName { get; set; }

        public Player(string name)
        {
            PlayerName = name;
        }
    }
}

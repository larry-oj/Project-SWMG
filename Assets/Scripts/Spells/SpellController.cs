using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class SpellController : MonoBehaviour
    {
        public string Name { get; set; }
        
        public enum SpellType
        {
            Projectile
        }
        public SpellType Type { get; set; }
        
        public enum SpellElement
        {
            Fire,
            Water,
            Earth,
            Air
        }
        public List<SpellElement> Elements { get; set; } = new();
        
        public enum SpellEffect
        {
            Damage
        }
        public SpellEffect Effect { get; set; }

        public int Damage { get; set; }
        public float Speed { get; set; }
        public float Range { get; set; }
    }
}
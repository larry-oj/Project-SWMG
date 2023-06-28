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
        
        // internal 
        private GameObject _spell;
        private SpriteRenderer _outlineRenderer;
        private SpriteRenderer _primaryRenderer;
        private SpriteRenderer _secondaryRenderer;

        void Start()
        {
            _spell = gameObject;
            _outlineRenderer = _spell.transform.GetChild(0)
                .GetComponent<SpriteRenderer>();
            _primaryRenderer = _spell.transform.GetChild(1)
                .GetComponent<SpriteRenderer>();
            _secondaryRenderer = _spell.transform.GetChild(2)
                .GetComponent<SpriteRenderer>();
        }
    }
}
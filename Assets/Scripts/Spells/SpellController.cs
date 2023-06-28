using UnityEngine;

namespace Spells
{
    public class SpellController : MonoBehaviour
    {
        public enum Bases
        {
            Projectile
        }
        public enum Elemets
        {
            Fire,
            Water,
            Earth,
            Air
        }
        
        public string Name { get; set; }
        public Bases Base { get; set; }
        public Elemets PrimaryElement { get; set; }
        public Elemets SecondaryElement { get; set; }
    }
}
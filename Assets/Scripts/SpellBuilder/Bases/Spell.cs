namespace SpellBuilder.Bases
{
    public class Spell
    {
        public string Name { get; set; } = "Spell";
        
        public enum Elements
        {
            Fire,
            Water,
            Earth,
            Air
        }
        public Elements Element { get; set; }
        
        public enum Effects
        {
            Damage,
            Heal,
            Buff,
            Debuff
        }
        public Effects Effect { get; set; }

        public Spell()
        {
        }

        protected Spell(Spell spell)
        {
            Name = spell.Name;
        }

        public virtual void Cast()
        {
            ApplyEffects();
            UnityEngine.Debug.Log($"Casting {Name}");
        }

        protected virtual void ApplyEffects()
        {
            UnityEngine.Debug.Log($"Applying effects to {Name}: {Element}, {Effect}");
        }
    }
}
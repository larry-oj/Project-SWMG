using SpellBuilder.Bases;

namespace SpellBuilder
{
    public sealed class SpellBuilder
    {
        private Spell _spell;

        public enum SpellBases
        {
            Projectile
        }

        public SpellBuilder()
        {
            _spell = new Spell();
        }
        
        public SpellBuilder AddName(string name)
        {
            _spell.Name = name;
            return this;
        }
        
        public SpellBuilder WithBase(SpellBases spellBases)
        {
            _spell = spellBases switch
            {
                _ => _spell
            };
            return this;
        }
        
        public SpellBuilder AddElement(Spell.Elements element)
        {
            _spell.Element = element;
            return this;
        }
        
        public SpellBuilder AddEffect(Spell.Effects effect)
        {
            _spell.Effect = effect;
            return this;
        }
        
        public Spell Build()
        {
            return _spell;
        }
    }
}
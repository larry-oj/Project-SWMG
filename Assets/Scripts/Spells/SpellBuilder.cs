using UnityEngine;

namespace Spells
{
    public sealed class SpellBuilder
    {
        private readonly GameObject _spell; // resulting spell
        private readonly SpellController _spellController; // spells controller
        private readonly SpellSpriteBuilder _spriteBuilder;
        
        private bool _isPrimaryElementSet = false;
        private bool _isSecondaryElementSet = false;

        public SpellBuilder(SpellController.Bases @base)
        {
            _spell = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/{@base}"));
            _spellController = _spell.AddComponent<SpellController>();
            _spellController.Base = @base;
            _spriteBuilder = new SpellSpriteBuilder(_spell);
        }

        public SpellBuilder WithName(string name)
        {
            _spellController.Name = name;
            return this;
        }

        public SpellBuilder AddElement(SpellController.Elemets element)
        {
            if (!_isPrimaryElementSet)
            {
                _spellController.PrimaryElement = element;
                _spriteBuilder.ApplyPrimaryElement(element);
                _isPrimaryElementSet = true;
            }
            else if (!_isSecondaryElementSet)
            {
                _spellController.SecondaryElement = element;
                _spriteBuilder.ApplySecondaryElement(element);
                _isSecondaryElementSet = true;
            }
            else
            {
                Debug.LogError("Spell can only have two elements");
            }

            return this;
        }
        
        public GameObject Build()
        {
            return _spell;
        }
    }
}
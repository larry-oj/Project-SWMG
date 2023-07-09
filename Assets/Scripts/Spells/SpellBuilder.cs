using Unity.VisualScripting;
using UnityEngine;

namespace Spells
{
    public sealed class SpellBuilder
    {
        private readonly GameObject _spell;
        private readonly SpellController _spellController;
        
        private GameObject _primary;
        private GameObject _secondary;

        public SpellBuilder(GameObject caster, SpellController.SpellType type)
        {
            var prefab = Resources.Load($"Prefabs/{type}Base");
            var position = caster.transform.GetChild(0).position;
            var rotation = caster.transform.rotation;
            _spell = Object.Instantiate(prefab as GameObject, position, rotation);
            
            _spellController = _spell.GetComponent<SpellController>();
            _spellController.Type = type;
        }
        
        public SpellBuilder WithName(string name)
        {
            _spellController.Name = name;
            _spell.name = name;
            return this;
        }

        public SpellBuilder WithEffect(SpellController.SpellEffect effect)
        {
            _spellController.Effect = effect;
            return this;
        }
        
        public SpellBuilder AddElement(SpellController.SpellElement element)
        {
            _spellController.Elements.Add(element);

            if (_spellController.Elements.Count == 1)
            {
                var primary = Object.Instantiate(Resources.Load($"Prefabs/{_spellController.Type}Primary"), _spell.transform) as GameObject;
                primary!.name = $"{element}Primary";
                _primary = primary;
                SetElementColor(_primary, element);
            }
            else
            {
                var secondary = Object.Instantiate(Resources.Load($"Prefabs/{_spellController.Type}Secondary"), _spell.transform) as GameObject;
                secondary!.name = $"{element}Secondary";
                _secondary = secondary;
                SetElementColor(_secondary, element, false);
            }

            return this;
        }
        
        public SpellBuilder WithDamage(int damage)
        {
            _spellController.Damage = damage;
            return this;
        }
        
        public SpellBuilder WithSpeed(float speed)
        {
            _spellController.Speed = speed;
            return this;
        }
        
        public SpellBuilder WithRange(float range)
        {
            _spellController.Range = range;
            return this;
        }
        
        private void SetElementColor(GameObject layer, SpellController.SpellElement element, bool isPrimary = true)
        {
            layer.GetComponent<SpriteRenderer>().color = element switch
            {
                SpellController.SpellElement.Fire => isPrimary ? Color.red : new Color32(245,178,39,255),
                SpellController.SpellElement.Water => isPrimary ? Color.blue : new Color32(137,207,240,255),
                SpellController.SpellElement.Earth => isPrimary ? new Color32(111, 72, 60, 255) : Color.green,
                SpellController.SpellElement.Air => isPrimary ? Color.white : Color.cyan,
                _ => new Color32(0, 0, 0, 0)
            };
        }
        
        public GameObject Build()
        {
            return _spell;
        }
    }
}
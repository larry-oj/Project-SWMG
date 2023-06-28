using UnityEngine;

namespace Spells
{
    public class SpellSpriteBuilder
    {
        private readonly SpriteRenderer _primaryElementSprite;
        private readonly SpriteRenderer _secondaryElementSprite;
        
        public SpellSpriteBuilder(GameObject obj)
        {
            _primaryElementSprite = obj.transform
                .Find("PrimaryElement")
                .GetComponent<SpriteRenderer>();
            
            _secondaryElementSprite = obj.transform
                .Find("SecondaryElement")
                .GetComponent<SpriteRenderer>();
        }
        
        public SpellSpriteBuilder ApplyPrimaryElement(SpellController.Elemets element)
        {
            _primaryElementSprite.color = element switch
            {
                SpellController.Elemets.Fire => Color.red,
                SpellController.Elemets.Water => Color.blue,
                SpellController.Elemets.Earth => new Color(91, 74, 20, 255),
                SpellController.Elemets.Air => Color.cyan,
                _ => new Color(0, 0, 0, 0)
            };
            return this;
        }
        
        public SpellSpriteBuilder ApplySecondaryElement(SpellController.Elemets element)
        {
            _secondaryElementSprite.color = element switch
            {
                SpellController.Elemets.Fire => new Color(255, 115, 0, 255),
                SpellController.Elemets.Water => new Color(0, 195, 255, 255),
                SpellController.Elemets.Earth => new Color(91, 74, 20, 255),
                SpellController.Elemets.Air => Color.white,
                _ => new Color(0, 0, 0, 0)
            };
            return this;
        }
    }
}
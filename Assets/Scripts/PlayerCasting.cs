using Spells;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;
    private GameObject _casterPointer; // from where we will cast spells
    private GameObject _castObject;

    [SerializeField] private GameObject caster;

    [Header("PH Spell")]
    [SerializeField] private string spellName;
    [SerializeField] private SpellController.SpellType spellType;
    [SerializeField] private SpellController.SpellElement spellPrimaryElement;
    [SerializeField] private SpellController.SpellElement spellSecondaryElement;
    [SerializeField] private SpellController.SpellEffect spellEffect;
    [SerializeField] private int spellDamage;
    [SerializeField] private float spellSpeed;
    [SerializeField] private float spellRange;

    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<Camera>();
        _casterPointer = caster.transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        var diff = _mousePosition - caster.transform.position;
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        
        caster.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    void OnFire()
    {
        var spell = new SpellBuilder(caster, spellType)
            .WithName(spellName)
            .AddElement(spellPrimaryElement)
            .AddElement(spellSecondaryElement)
            .WithEffect(spellEffect)
            .WithDamage(spellDamage)
            .WithSpeed(spellSpeed)
            .WithRange(spellRange)
            .Build();
        

        // new SpellBuilder().Build();
    }
}

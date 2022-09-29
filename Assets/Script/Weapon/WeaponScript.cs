using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon",menuName = "Scriptable",order = 1)]
public class WeaponScript : ScriptableObject
{
    [Header("Weapon info")]
    [SerializeField]
    private string weaponName;

    [SerializeField]
    private bool isARange;

    [SerializeField]
    private float damage;

    [SerializeField,Tooltip("Temps pendant laquelle on peut toucher (nul si range)")]
    private float m_attackActive;
    [SerializeField,Tooltip("Temps entre chaque attaque")]
    private float m_weaponCdr;

    [SerializeField]
    private int bind;

    [Header("Only if Cac Weapon")]
    [SerializeField, Tooltip("IdBox de l'arme")]
    private BoxCollider m_myWeapon;

    [Header("Only if Range Weapon")]
    [SerializeField]
    private float projectilSpeed;

    // Getter
    public float getDamage()
    {
        return damage;
    }
    public float getWeaponCdr()
    {
        return m_weaponCdr;
    }
    public float getAtkActiveT()
    {
        return m_attackActive;
    }
    public int getBind()
    {
        return bind;
    }
    public bool getIsRange()
    {
        return isARange;
    }   

    // Setter
    public void setBind(int p_bind)
    {
        bind = p_bind;
    }
}

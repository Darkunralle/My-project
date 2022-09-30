using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Foe : MonoBehaviour
{
    protected GameObject m_target;
    protected Detection aggroArea;
    protected Rigidbody rb;

    [SerializeField, Tooltip("Quantit� de vie, Float")]
    protected float m_lp;
    [SerializeField, Tooltip("Vitesse en m�tre par seconde")]
    protected float m_speed;
    [SerializeField, Tooltip("Mitigation des d�g�ts en pourcentage")]
    protected float m_res;
    [SerializeField, Tooltip("D�g�t brute du Foe")]
    protected float m_atk;
    [SerializeField, Tooltip("point d'exp�rience obtenu en le tuant")]
    protected float m_xp;
    [SerializeField]
    protected float atkSpeed;
    protected float compter=0;
    [SerializeField]
    protected float armorPen;

    private void Start()
    {
        if (aggroArea == null)
        {
            aggroArea = GetComponentInChildren<Detection>();
        }
        if (rb == null)
        { 
            rb = GetComponent<Rigidbody>();
        }
    }
    public void takeDamage(float damage)
    {
        m_lp -= damage * (1 - m_res);
        isAlive();
    }

    protected void isAlive()
    {
        if (m_lp<0)
        {
            PlayerStats.giveXp(m_xp);
            Destroy(gameObject);
        }
    }

    




}

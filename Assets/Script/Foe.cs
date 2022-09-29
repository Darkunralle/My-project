using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Foe : MonoBehaviour
{
    protected GameObject m_target;
    protected Detection aggroArea;
    protected Rigidbody rb;

    [SerializeField, Tooltip("Quantité de vie, Float")]
    protected float m_lp;
    [SerializeField, Tooltip("Vitesse en mètre par seconde")]
    protected float m_speed;
    [SerializeField, Tooltip("Mitigation des dégâts en pourcentage")]
    protected float m_res;
    [SerializeField, Tooltip("Dégât brute du Foe")]
    protected float m_atk;
    [SerializeField, Tooltip("point d'expérience obtenu en le tuant")]
    protected float m_xp;
    [SerializeField]
    protected float atkSpeed;
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

    protected void OnTriggerStay(Collider other)
    {
        if (CompareTag("Player"))
        {
            PlayerStats.hited(m_atk);
        }
    }

    public void takeDamage(float damage)
    {
        Debug.Log("here3");
        m_lp -= damage * (1 - m_res);
        Debug.Log(m_lp);
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

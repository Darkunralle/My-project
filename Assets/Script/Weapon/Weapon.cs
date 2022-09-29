using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponScript weaponInfo;

    private bool m_activeTrigger = false;

    private bool m_onAttack = false;

    // Gestion timer
    private float m_attackActive;
    private float m_weaponCdr;
    private float m_actualTimer;

    public Animator m_myAnim;

    private bool isARange;
    private int bind;

    void Start()
    {
        m_attackActive = weaponInfo.getAtkActiveT();
        m_weaponCdr = weaponInfo.getWeaponCdr();
        isARange = weaponInfo.getIsRange();
        bind = weaponInfo.getBind();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_activeTrigger)
        {
            if (other.CompareTag("FoeCac"))
            {
                Debug.Log("here2");
                other.GetComponent<FoeCac>().takeDamage(weaponInfo.getDamage() * (1+PlayerStats.getStr() / 100));
            }
            else if (other.CompareTag("RangeFoe"))
            {

            }
        }
    }

    private void attack()
    {
        m_myAnim.SetTrigger("playAnim");
        m_activeTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        key(bind);
        if (!isARange)
        {
            timerCac();
        } else timerRange();
    }

    private void timerCac()
    {
        if ((m_activeTrigger || m_onAttack) && m_actualTimer <= m_weaponCdr)
        {
            m_actualTimer += Time.deltaTime;
        }
        if (m_actualTimer >= m_attackActive)
        {
            m_activeTrigger = false;
        }
        if (m_actualTimer >= m_weaponCdr)
        {
            m_actualTimer = 0;
            m_onAttack = false;
        }
    }

    private void timerRange()
    {
        if (m_onAttack && m_actualTimer <= m_weaponCdr)
        {
            m_actualTimer += Time.deltaTime;
        }
        if (m_actualTimer >= m_weaponCdr)
        {
            m_actualTimer = 0;
            m_onAttack = false;
        }
    }

    private void key(int bind)
    {
        switch (weaponInfo.getBind())
        {
            case 1:
                
                if (Input.GetKeyDown(KeyCode.Mouse0) && !m_onAttack)
                {
                    Debug.Log("1");
                    attack();
                    m_onAttack = true;
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Mouse1) && !m_onAttack)
                {
                    
                    attack();
                    m_onAttack = true;
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.R) && !m_onAttack)
                {
                    
                    attack();
                    m_onAttack = true;
                }
                break;
            default:
                break;
        }
    }
}

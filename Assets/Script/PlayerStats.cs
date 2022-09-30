using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static private float m_life = 100;
    static private float m_maxLife = 100;
    static private float m_damageMiti = 0;
    static private int m_maxDamageMiti = 80;
    static private float m_speed = 5f;
    static private float m_str = 5;
    static private float m_xp = 0;
    static private float m_xpToLvlUp = 100;
    static private float m_xpMulti = 1;
    static private int m_lvl = 1;
    static private float m_atkSpeedBonus = 0;
    static private float m_crit = 0;

    //getter
    public static float getAtkSpeedBonus()
    {
        return m_atkSpeedBonus;
    }
    public static float getCrit()
    {
        return m_crit;
    }
    public static float getLife()
    {
        return m_life;
    }
    public static float getMaxLife()
    {
        return m_maxLife;
    }

    public static float getStr()
    {
        return m_str;
    }


    //Setter
    public static void setAtkSpeedBonus(float value)
    {
        m_atkSpeedBonus += value;
    }
    public static void setCrit(float value)
    {
        m_crit += value;
    }
    public static void setStr(float str)
    {
        m_str += str;
    }

    public static void setVita(float vita)
    {
        m_maxLife += vita;
        m_life += vita;
        Hub.hubMaxLife(vita);
    }

    public static void setSpeed(float speed)
    {
        m_speed += speed;
    }

    public static void setRes(float res)
    {
        m_damageMiti += res;
        if (m_damageMiti > m_maxDamageMiti)
        {
            m_damageMiti = m_maxDamageMiti;
        }
    }


    public static void hited(float damage)
    {
        //Debug.Log(m_life);
        m_life -= damage * (1 - m_damageMiti / 100);
    }

    public static void giveXp(float xp)
    {
        m_xp += xp;
        if (m_xp >= m_xpToLvlUp)
        {
            m_xp -= m_xpToLvlUp;
            m_lvl++;
        }
        Hub.setXp(m_xp);
        
    }

    private void Update()
    {
        if (m_life <= 0)
        {

        }

        Hub.setLife(m_life);
    }
}

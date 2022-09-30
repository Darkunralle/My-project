using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "Skill", menuName = "Skills", order = 2)]

public class Skill : ScriptableObject
{
    private enum statsChange { life, res, speed, str, crit, atkSpeed };
    [SerializeField]
    private string skillName;
    [SerializeField]
    private string desc;
    [SerializeField]
    private statsChange stats;
    [SerializeField,Tooltip("Modificateur")]
    private float value;
    [SerializeField]
    private int clickNumber;
    private int cpClick=0;
    private bool activate = true;
    private bool childOn = false;

    public void clic()
    {
        if (cpClick < clickNumber && activate)
        {
            switch (stats)
            {
                case statsChange.life:
                    PlayerStats.setVita(value);
                    break;
                case statsChange.res:
                    PlayerStats.setRes(value);
                    break;
                case statsChange.speed:
                    PlayerStats.setSpeed(value);
                    break;
                case statsChange.str:
                    PlayerStats.setStr(value);
                    break;
                case statsChange.crit:
                    PlayerStats.setCrit(value);
                    break;
                case statsChange.atkSpeed:
                    PlayerStats.setAtkSpeedBonus(value);
                    break;
                default:
                    break;
            }
            cpClick++;  
        }
        if (cpClick == clickNumber)
        {
            childOn = true;
        }
        Debug.Log($"{cpClick} & {activate}");
    }
    public void resetCompter()
    {
        cpClick = 0;
        activate = true;
        childOn = false;
    }

    public string getName()
    {
        return skillName;
    }
    public string getDesc()
    {
        return desc;
    }
    public int getClickNumber()
    {
        return clickNumber;
    }
    public int getCpClick()
    {
        return cpClick;
    }
    public void setActivate(bool value) { activate = value; }
    public bool gtChildOn()
    {
        return childOn;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSocket : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI desc;
    [SerializeField]
    private List<SkillSocket> child;

    [SerializeField]
    private Skill skill;
    void Start()
    {
        skill.resetCompter();
        title.text = skill.getName() +" "+skill.getCpClick()+"/"+skill.getClickNumber();
        desc.text = skill.getDesc();
        
        foreach (SkillSocket s in child)
        {
            s.changeBool(false);
        }
        
        Debug.Log(skill.getCpClick());
    }

    public void changeBool(bool value)
    {
        skill.setActivate(value);
    }

    public void Clic()
    {
        skill.clic();
        title.text = skill.getName() + " " + skill.getCpClick() + "/" + skill.getClickNumber();
        if (skill.gtChildOn())
        {
            foreach (SkillSocket row in child)
            {
                row.changeBool(true);
            }
        }
    }

    public void resetSkill()
    {
        skill.resetCompter();
        foreach (SkillSocket row in child)
        {
            row.resetSkill();                                                                                                                                                                                                                          
        }
    }



}

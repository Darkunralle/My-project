using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SkillTree : MonoBehaviour
{
    [SerializeField]
    private GameObject skilltree;
    [SerializeField]
    private List<GameObject> skillList;
    [SerializeField]
    private List<GameObject> onOff;

    private bool m_skillIsOpen = false;
    private int m_s0Clicked = 0;
    private int m_s1Clicked = 0;
    private int m_s2Clicked = 0;
    private int m_s3Clicked = 0;
    private int m_s4Clicked = 0;


    private bool swing = false;
    private bool str = false;
    private bool vit = false;


    // Start is called before the first frame update
    void Start()
    {
        skilltree.SetActive(false);
        foreach (GameObject row in onOff)
        {
            row.SetActive(false);
        }
    }

    private void openSkillTree()
    {
        if (m_skillIsOpen)
        {
            skilltree.SetActive(true);
        }
        else
        {
            skilltree.SetActive(false);
        }

    }
    /// <summary>
    /// #0 = Swing
    /// #1 = Force
    /// #2 = Life
    /// </summary>
    public void swingSkill()
    {
        if (m_s0Clicked < 1)
        {
            skillList[0].GetComponentInChildren<TextMeshProUGUI>().text = "Swing 1/1";
            m_s0Clicked++;
            Debug.Log("2");
        }
        if (m_s0Clicked == 1)
        {
            //Weapon.setBoolSwing();
            onOff[0].SetActive(true);
            swing = true;
            Debug.Log("3");
        }

        Debug.Log("1");

    }

    public void strenghSkill()
    {
        if (swing)
        {
            if (m_s1Clicked < 5)
            {
                skillList[1].GetComponentInChildren<TextMeshProUGUI>().text = "Force " + (m_s1Clicked + 1) + "/5";
                m_s1Clicked++;
                PlayerStats.setStr(10);
            }
            if (m_s1Clicked == 1)
            {
                onOff[1].SetActive(true);
                str = true;
            }
        }
    }

    public void vitaSkill()
    {
        if (swing)
        {
            if (m_s2Clicked < 5)
            {
                skillList[2].GetComponentInChildren<TextMeshProUGUI>().text = "Vitalité " + (m_s2Clicked + 1) + "/5";
                m_s2Clicked++;
                PlayerStats.setVita(20);
            }
            if (m_s2Clicked == 1)
            {
                onOff[2].SetActive(true);
                vit = true;
            }
        }
    }

    public void speedSkill()
    {
        if (str)
        {
            if (m_s3Clicked < 3)
            {
                skillList[3].GetComponentInChildren<TextMeshProUGUI>().text = "Speed " + (m_s3Clicked + 1) + "/3";
                m_s3Clicked++;
                PlayerStats.setSpeed(1);
            }
            
        }
    }

    public void resSkill()
    {
        if (vit)
        {
            if (m_s4Clicked < 5)
            {
                skillList[4].GetComponentInChildren<TextMeshProUGUI>().text = "Résistance " + (m_s4Clicked + 1) + "/5";
                m_s4Clicked++;
                PlayerStats.setRes(10);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            m_skillIsOpen = !m_skillIsOpen;
            openSkillTree();
        }
    }
}

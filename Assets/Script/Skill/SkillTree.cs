using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SkillTree : MonoBehaviour
{
    [SerializeField]
    private GameObject skilltree;
    [SerializeField]
    private List<SkillSocket> skillStarter;

    private bool m_skillIsOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        skilltree.SetActive(false);
        foreach (var skillSocket in skillStarter)
        {
            skillSocket.changeBool(true);
            skillSocket.resetSkill();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFoe : Foe
{
    [SerializeField, Tooltip("Blueprint projectil")]
    private GameObject m_objectShoot;
    private GameObject m_myShoot;
    private float velo;
    private void shoot()
    {
        m_myShoot = Instantiate(m_objectShoot,this.transform.position, Quaternion.identity);
        m_myShoot.GetComponent<Shoot>().setStats(m_atk,armorPen,velo);
    }

    private void Update()
    {

    }
}

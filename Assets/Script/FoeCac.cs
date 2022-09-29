using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCac : Foe
{
    private Vector3 m_Position;
    private float dist;

    private void Update()
    {
        if (aggroArea.getDetected())
        {
            dist = Vector3.Distance(transform.position, aggroArea.getPos());
            if (dist >= 1.5f)
            {
                m_Position = Vector3.MoveTowards(transform.position, aggroArea.getPos(), m_speed * Time.deltaTime);
                rb.MovePosition(m_Position);
            }
            
        }
        if (compter > 0)
        {
            compter -= Time.deltaTime;
        }
        if (compter < 0)
        {
            compter = 0;
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && compter == 0)
        {
            PlayerStats.hited(m_atk);
            compter = atkSpeed;
            Debug.Log(compter);
        }
    }

}

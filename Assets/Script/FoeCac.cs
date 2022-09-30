using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCac : Foe
{
    private Vector3 m_Position;
    private float dist;
    private Vector3 m_gravityEffect = new Vector3(0, 0, 0);
    private float m_gravity = -9.81f;
    [SerializeField]
    private Transform m_groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

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

        if (!isGrounded())
        {
            m_gravityEffect.y += m_gravity * Time.deltaTime;
        }

        Vector3 posi = new Vector3(rb.position.x, rb.position.y + m_gravityEffect.y * Time.deltaTime, rb.position.z);

        rb.transform.position = posi;
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
    public bool isGrounded()
    {
        // Crée une sphere invisible et check si elle colide avec un layer "Ground"
        bool isGrounded = Physics.CheckSphere(m_groundCheck.position, 0.5f, groundLayer);

        // Force reset de la gravité a -1
        if (isGrounded && m_gravityEffect.y < 0)
        {

            m_gravityEffect.y = -2f;
        }

        return isGrounded;
    }

}

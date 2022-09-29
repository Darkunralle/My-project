using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private float m_damage = 1;
    [SerializeField]
    private float m_penetration = 0;
    [SerializeField]
    private float m_velocity = 4;

    public Rigidbody m_thisCollider;

    public void setStats(float dmg, float pen, float vel)
    {
        m_damage = dmg;
        m_penetration = pen;
        m_velocity = vel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.hited(m_damage);
            Destroy(this);
        }
    }

    private void Start()
    {
        m_thisCollider.rotation = Quaternion.identity;
        m_thisCollider.velocity = transform.right * m_velocity * Time.deltaTime;
    }
}

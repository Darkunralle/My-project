using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private SphereCollider aggro;
    private bool detected = false;
    private Vector3 pos;


    void Start()
    {
        if (aggro == null)
        {
            aggro = GetComponent<SphereCollider>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Detector")){
            
            detected = true;
            pos = other.transform.position;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        detected = false;
    }

    public bool getDetected()
    {
        return detected;
    }

    public void AreaAggro(float range)
    {
        aggro.radius = range;
    }

    public Vector3 getPos()
    {
        return pos;
    }
}

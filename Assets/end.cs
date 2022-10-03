using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class end : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ui.SetActive(true);
    }




}

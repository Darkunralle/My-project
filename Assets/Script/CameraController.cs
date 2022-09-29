using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject myCam;
    private Camera cam;

    [SerializeField]
    private float offsetX = 0;
    [SerializeField]
    private float offsetY = 0;
    [SerializeField]
    private float offsetZ = 0;

    private Vector3 PlayerPos;
    private Vector3 mousePosToWorld;

    void Start()
    {
        setCamPos();
        cam = myCam.GetComponent<Camera>();
        
    }

    
    void Update()
    {
        setCamPos();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            //Debug.Log(hitData.point);
        }
        
    }

    private void setCamPos()
    {
        PlayerPos = player.transform.position;
        myCam.transform.position = new Vector3(PlayerPos.x + offsetX, PlayerPos.y + offsetY, PlayerPos.z + offsetZ);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController m_characterController;
    private Transform m_groundCheck;
    [SerializeField]
    private float m_speed = 1f;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask groundLayer;
    void Start()
    {
        if (m_characterController == null)
        {
            m_characterController = GetComponent<CharacterController>();
            if (m_characterController == null)
            {
                Debug.Log("Tardos il manque le CharactereController MERCI");
                throw new System.ArgumentNullException();
            }
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

   
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z ;

        m_characterController.Move(move * Time.deltaTime * m_speed);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitData, 1000 , groundLayer))
        {
            Vector3 pos = hitData.point;
            pos.y = 0;

            m_characterController.transform.LookAt(pos);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController m_characterController;
    [SerializeField]
    private Transform m_groundCheck;
    [SerializeField]
    private float m_speed = 1f;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask groundLayer;

    private Vector3 m_gravityEffect = new Vector3(0,0,0);
    private float m_gravity = -9.81f;

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

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z ;
        /*
        move *= Time.deltaTime * m_speed;
        move.x += m_characterController.transform.position.x;
        move.z += m_characterController.transform.position.z;

        m_characterController.transform.position = move;*/

        m_characterController.Move(move * Time.deltaTime * m_speed);

        if (!isGrounded())
        {
            m_gravityEffect.y += m_gravity * Time.deltaTime;
        }

        m_characterController.Move(m_gravityEffect * Time.deltaTime);



        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitData, 1000 , groundLayer))
        {
            Vector3 pos = hitData.point;
            pos.y = 0;

            m_characterController.transform.LookAt(pos);
        }
        
    }
}

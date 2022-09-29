using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCac : Foe
{
    private void Update()
    {
        if (aggroArea)
        {
            rb.MovePosition(aggroArea.getPos() * m_speed * Time.deltaTime);
        }
    }
}

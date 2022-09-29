using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hub : MonoBehaviour
{
    [SerializeField]
    private Slider ns_health;
    [SerializeField]
    private RectTransform ns_healtBorder;

    static private Slider health;
    static private RectTransform healtBorder;



    static private float sizeHpBorder = 500;
    static private float m_x = -700;

    private void Start()
    {
        health = ns_health;
        healtBorder = ns_healtBorder;

        health.maxValue = PlayerStats.getMaxLife();
        health.value = PlayerStats.getLife();
    }

    public static void hubMaxLife(float value)
    {
        health.maxValue += value;
        sizeHpBorder += 100;
        healtBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeHpBorder);
        m_x += 50;
        healtBorder.anchoredPosition = new Vector2(m_x, 475);
    }

    public static void setLife(float value)
    {
        health.value = value;
    }
}

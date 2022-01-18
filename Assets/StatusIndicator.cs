using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StatusIndicator : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private TextMeshProUGUI healthText;

    void Start()
    {
        if(healthBarRect == null)
        {
            Debug.LogError("StatusINDICAOTR");
        }
        if (healthText == null)
        {
            Debug.LogError("StatusINDICAOTR");
        }
    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = _cur + "/" + _max + "HP";
    }


}

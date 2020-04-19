using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopText : MonoBehaviour
{
    public Transform textTransform;

    public TMP_Text text;

    public Camera uiCamera;

    // Update is called once per frame
    void Update()
    {
        var point = uiCamera.WorldToViewportPoint(transform.position);
        textTransform.position = new Vector3(Screen.width * point.x, Screen.height * point.y, 0);
    }

    public void SetText(string text) {
        this.text.text = text;
    }
}

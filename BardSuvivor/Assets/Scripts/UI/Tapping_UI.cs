using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tapping_UI : MonoBehaviour
{
    private Transform UI;
    private Image[] tapImage;
    public Sprite iconTapOpen, iconTapClose;
    // Start is called before the first frame update
    void Start()
    {
        UI = transform.GetChild(0);
        UI.gameObject.SetActive(false);
        tapImage = new Image[4];
        for (int i = 0; i < tapImage.Length; i++)
        {
            tapImage[i] = UI.GetChild(i).GetComponent<Image>();
            tapImage[i].sprite = iconTapOpen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LoopBPM.customBeat)
        {
            UI.gameObject.SetActive(true);
            for (int i = 0; i < tapImage.Length; i++){
                if (i < LoopBPM.tap)
                {
                    tapImage[i].sprite = iconTapClose;
                }else
                {
                    tapImage[i].sprite = iconTapOpen;
                }
            }
        }else
        {
            UI.gameObject.SetActive(false);
        }
        
    }
}

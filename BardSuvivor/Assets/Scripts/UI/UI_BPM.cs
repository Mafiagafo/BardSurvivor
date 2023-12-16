using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_BPM : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI uiText;
    public LoopBPM loopBPM;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "BPM: " + loopBPM.gameLoopBPM.ToString();
    }
}

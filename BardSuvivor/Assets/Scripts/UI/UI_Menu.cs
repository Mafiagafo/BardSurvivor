using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI menuUiText;

    public PlayerStats playerStats;



    // Start is called before the first frame update
    void Start()
    {
        menuUiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        menuUiText.text = playerStats.currentMaxHealth.ToString();
    }
}

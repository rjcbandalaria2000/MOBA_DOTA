using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject debugPanel;
    public TextMeshProUGUI name;
    public Slider HP_Bar_Slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDebugPanel()
    {
        debugPanel.SetActive(true);
    }
    public void HideDebugPanel()
    {
        debugPanel.SetActive(false);
    }
}

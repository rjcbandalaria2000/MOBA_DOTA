using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject debugPanel;
    [SerializeField] GameObject debugButton;
    public TextMeshProUGUI name;
    public Slider HP_Bar_Slider;
    public Button DestroyTowerButton;

    [Header("Stats UI")]
    public Text AtkVal;
    public Text DefVal;
    public Text SpeedVal;
    public Text AttributeVal;

    // Start is called before the first frame update
    void Start()
    {
        debugPanel.SetActive(false);
        debugButton.SetActive(true);
        DestroyTowerButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDebugPanel()
    {
        debugPanel.SetActive(true);
        debugButton.SetActive(false);
    }
    public void HideDebugPanel()
    {
        debugPanel.SetActive(false);
        debugButton.SetActive(true);
    }
}

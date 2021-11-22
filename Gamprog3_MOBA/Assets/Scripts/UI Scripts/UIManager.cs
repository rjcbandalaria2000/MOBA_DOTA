using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject debugPanel;
    [SerializeField] GameObject debugButton;

    public TextMeshProUGUI radiantWin;
    public TextMeshProUGUI direWin;

    [Header("Basic Info UI")]
    public TextMeshProUGUI name;
    public Slider HP_Bar_Slider;
    public Slider Mana_Bar_Slider;
    public TextMeshProUGUI levelValue;
    public TextMeshProUGUI expValue;
    public TextMeshProUGUI goldValue;
    public Button DestroyTowerButton;

    [Header("Stats UI")]
    public Text AtkVal;
    public Text DefVal;
    public Text SpeedVal;
    public Text AttributeVal;

    [Header("Player image")]
    public GameObject heroImage;

    [Header("Player Skills Icon")]
    public GameObject skill1_icon;
    public GameObject skill2_icon;
    public GameObject skill3_icon;
    public GameObject skill4_icon;

    [Header("Player Skills Icon transparent")]
    public List<Image> skill_icon_Transparent;

    [Header("Player Skills Icon upgradeButton")]
    public List<Button> upgradeButtons;

    public DisplayUnitStats unitStatDisplay;

    public Canvas skillsCanvas;
    public Canvas basicStatsDisplayCanvas;
    public Canvas inDepthStatsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        debugPanel.SetActive(false);
        debugButton.SetActive(true);
        DestroyTowerButton.gameObject.SetActive(false);
        inDepthStatsCanvas.gameObject.SetActive(false);

        heroImage.SetActive(false);
        skillsCanvas.gameObject.SetActive(false);
        radiantWin.gameObject.SetActive(false);
        direWin.gameObject.SetActive(false);

        //skill1_icon.SetActive(false);
        //skill2_icon.SetActive(false);
        //skill3_icon.SetActive(false);
        //skill4_icon.SetActive(false);


    }

    private void Awake()
    {
        SingletonManager.Register(this);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject debugPanel;

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

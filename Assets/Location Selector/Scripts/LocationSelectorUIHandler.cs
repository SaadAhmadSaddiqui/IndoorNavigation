using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSelectorUIHandler : MonoBehaviour
{
    public GameObject controlsTint;
    public GameObject controlsPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideControlsPanel();
        }
    }

    public void ShowControlsPanel()
    {
        controlsPanel.SetActive(true);
        controlsTint.SetActive(true);
    }

    private void HideControlsPanel()
    {
        controlsPanel.SetActive(false);
        controlsTint.SetActive(false);
    }
}

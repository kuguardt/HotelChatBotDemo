using Inworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject checkInPanel;
    [SerializeField]
    private GameObject infoGatherPanel;
    [SerializeField]
    private GameObject scanPassportPanel;
    [SerializeField]
    private GameObject faceScanPanel;
    [SerializeField]
    private GameObject showRoomInfoPanel;

    void Start()
    {
        DeactivePanel();
        startPanel.SetActive(true);
    }

    public void SendText(string text)
    {
        InworldController.CurrentCharacter.SendText(text);
    }

    public void Emotion(string text1, string text2)
    {
        Debug.Log("text1 = " + text1);
        Debug.Log("text2 = " + text2);
    }

    public void GatherGoal(string goal)
    {
        PanelToggle(goal);
    }

    private void PanelToggle(string goal)
    {
        switch(goal)
        {
            case "Start":
                DeactivePanel();
                checkInPanel.SetActive(true);
                break;
            case "CheckIn":
                DeactivePanel();
                infoGatherPanel.SetActive(true);
                break;
            case "InformationGather":
                DeactivePanel();
                scanPassportPanel.SetActive(true);
                break;
            case "ScanPassport":
                DeactivePanel();
                faceScanPanel.SetActive(true);
                break;
            case "FaceScan":
                DeactivePanel();
                showRoomInfoPanel.SetActive(true);
                break;

            default:
                Debug.LogError("Goal is not valid : " + goal);
                break;
        }
    }

    public void DeactivePanel()
    {
        startPanel.SetActive(false);
        checkInPanel.SetActive(false);
        infoGatherPanel.SetActive(false);
        scanPassportPanel.SetActive(false);
        faceScanPanel.SetActive(false);
        showRoomInfoPanel.SetActive(false);
    }
}

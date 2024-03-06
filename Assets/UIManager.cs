using Inworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int failcounter = 0;

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
    [SerializeField]
    private TextMeshProUGUI failCounterText;


    void Start()
    {
        DeactivePanel();
        startPanel.SetActive(true);
        failCounterText.gameObject.SetActive(false);
    }
    public void SendText(string text)
    {
        InworldController.CurrentCharacter.SendText(text);
        StartCoroutine(Delay(1.0f,text));
    }

    public void Emotion(string text1, string text2)
    {
        Debug.Log("text1 = " + text1);
        Debug.Log("text2 = " + text2);
    }

    public void GatherGoal(string goal)
    {
        //PanelToggle(goal);
    }

    public IEnumerator Delay(float time, string text)
    {
        yield return new WaitForSeconds(time);
        PanelToggle(text);
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
            case "InformationGatherSuccess":
                DeactivePanel();
                scanPassportPanel.SetActive(true);
                failcounter = 0;
                UpdateFailCounter(failcounter);
                break;
            case "InformationGatherFail":
                DeactivePanel();
                infoGatherPanel.SetActive(true);
                UpdateFailCounter(++failcounter);
                break;
            case "ScanPassportSuccess":
                DeactivePanel();
                faceScanPanel.SetActive(true);
                failcounter = 0;
                UpdateFailCounter(failcounter);
                break;
            case "ScanPassportFail":
                DeactivePanel();
                scanPassportPanel.SetActive(true);
                UpdateFailCounter(++failcounter);
                break;
            case "FaceScanSuccess":
                DeactivePanel();
                showRoomInfoPanel.SetActive(true);
                failcounter = 0;
                UpdateFailCounter(failcounter);
                break;
            case "FaceScanFail":
                DeactivePanel();
                faceScanPanel.SetActive(true);
                UpdateFailCounter(++failcounter);
                break;
            case "ShowRoomInformationDone":
                DeactivePanel();
                checkInPanel.SetActive(true);
                break;

            default:
                Debug.LogError("Goal is not valid : " + goal);
                break;
        }
    }

    private void UpdateFailCounter(int amount)
    {
        if (amount <= 0)
        {
            failCounterText.gameObject.SetActive(false);
            return;
        }

        failCounterText.gameObject.SetActive(true);
        failCounterText.SetText("Fail count : " + amount.ToString());
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

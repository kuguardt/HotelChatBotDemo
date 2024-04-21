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

    [SerializeField]
    private TextMeshProUGUI currentEmotionText;
    [SerializeField]
    private TextMeshProUGUI emotionLevelText;

    [SerializeField]
    private float subtitleTime = 0.0f;
    [SerializeField]
    private GameObject subtitlePanel;
    [SerializeField]
    private TextMeshProUGUI subtitleText;
    [SerializeField]
    private TextMeshProUGUI subtitleText2;

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

    public void Emotion(string level, string emotion)
    {
        currentEmotionText.text = emotion;
        emotionLevelText.text = level;
    }

    public void Subtitle(string name, string dialog)
    {
        subtitleText2.text = name;
        if (name.Length == 36)
        {
            StartCoroutine(ShowSubtitle(dialog));
        }
        //subtitleText.text = dialog;
        //subtitleText.text = name;
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
            case "FailureToCheckIn":
                DeactivePanel();
                startPanel.SetActive(true);
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
        if (amount >= 3)
        {
            DeactivePanel();
            SendText("FailureToCheckIn");
        }
    }

    public void ToggleSubtitle()
    {
        if (subtitlePanel.activeSelf == false)
        {
            subtitlePanel.SetActive(true);
        }
        else
        {
            subtitlePanel.SetActive(false);
        }
    }

    private IEnumerator ShowSubtitle(string dialog)
    {
        subtitleText.text = dialog;
        //subtitlePanel.SetActive(true);
        yield return new WaitForSeconds(subtitleTime);
        //subtitlePanel.SetActive(false);
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

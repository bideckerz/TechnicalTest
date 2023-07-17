using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class GUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject panelOS;

    public TextMeshProUGUI textBox;

    private bool guiActivated;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        panel.SetActive(false);
        panelOS.SetActive(false);
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("menu", ActivateGUI);
        actions.Add("off", OffGUI);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            Left();

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            Right();

        }
        if(Input.GetKeyUp(KeyCode.M))
        {
            if (!guiActivated)
            {
                ActivateGUI();
            }
            else
            {
                OffGUI();
            }

        }

    }

    public void OnLeftButtonClick()
    {
        Left();
    }

    public void OnRighttButtonClick()
    {
        Right();
    }


    private void ActivateGUI()
    {
        if (!guiActivated)
        {
            guiActivated = true;
            panel.SetActive(true);
            panelOS.SetActive(true);
        }
    }

    private void OffGUI()
    {
        if (guiActivated)
        {
            guiActivated = false;
            panel.SetActive(false);
            panelOS.SetActive(false);
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }
    private void Left()
    {
        ActivateGUI();
        textBox.text = "Left";
    }
    private void Right()
    {
        ActivateGUI();
        textBox.text = "Right";

    }

}
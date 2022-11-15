using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject _uiPanel; 

    private void Start()
    {
        _mainCam = Camera.main; //quicker to cache in a private void
        _uiPanel.SetActive(false);
    }

    /*private void LateUpdate()
    {
        //var rotation = _mainCam.transform.rotation;
        //transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }*/

    public bool IsDisplayed = false; 

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true; 
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false; 
    }
}

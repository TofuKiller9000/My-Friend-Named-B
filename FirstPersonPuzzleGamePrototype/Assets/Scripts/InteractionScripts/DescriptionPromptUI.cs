using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionPromptUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private GameObject _uiPanel;



    public void UpdateDescription(string descriptionText)
    {
        _descriptionText.text = descriptionText;
        _uiPanel.SetActive(true);

    }

}

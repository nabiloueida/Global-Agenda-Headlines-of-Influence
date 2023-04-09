using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CountryVariable _lastCountrySelected;
    [SerializeField] private GameObject PublishButton;

    public bool pickingHeadline = true;
    public bool publishingHeadline = false;


    // Start is called before the first frame update
    void Awake()
    {
        _lastCountrySelected.Value = null;
        PublishButton.SetActive(false);
    }

    private void Update()
    {
        //Check if a country is selected then show pulish button
        if(_lastCountrySelected.Value != null)
        {
            PublishButton.SetActive(true);
            //Debug.Log(PublishButton.activeInHierarchy);
        }
    }

    public void PublishHeadline()
    {
        pickingHeadline = false;
        publishingHeadline = true;
        _lastCountrySelected._variableUpdate?.Invoke();

    }
}

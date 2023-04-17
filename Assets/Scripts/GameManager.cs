using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CountryVariable _lastCountrySelected;
    [SerializeField] private HeadlineBinding _headlineBinding;
    [SerializeField] private GameObject PublishButton;
    [SerializeField] private GameObject NextHeadlineButton;

    public bool pickingHeadline = true;
    public bool publishingHeadline = false;
    public bool nextHeadline = false;


    // Start is called before the first frame update
    void Awake()
    {
        _lastCountrySelected.Value = null;
        PublishButton.SetActive(false);
        NextHeadlineButton.SetActive(false);
    }

    private void Update()
    {
        //Check if a country is selected then show pulish button
        if(_lastCountrySelected.Value != null && pickingHeadline)
        {
            PublishButton.SetActive(true);
            //Debug.Log(PublishButton.activeInHierarchy);
        }
        else
        {
            PublishButton.SetActive(false);
        }

        //After Pubblishing Headline with picked country, display next button.
        if(_lastCountrySelected.Value != null && publishingHeadline)
        {
            NextHeadlineButton.SetActive(true);
        }
        else
        {
            NextHeadlineButton.SetActive(false);
        }
    }

    public void PublishHeadline()
    {
        pickingHeadline = false;
        publishingHeadline = true;
        // _lastCountrySelected.Value.updateRelationships(_headlineBinding);
        _headlineBinding.PublishHeadline();
        _lastCountrySelected._variableUpdate?.Invoke();

        //Here use method to affect relationships
       // _lastCountrySelected.Value.
       // _lastCountrySelected.Value = null;
        //Remove last country
        //_lastCountrySelected.Value = null;

    }

    public void NextHeadline()
    {
        pickingHeadline = true;
        publishingHeadline = false;
        _headlineBinding.UseHeadline();
        _lastCountrySelected._variableUpdate?.Invoke();
    }
}

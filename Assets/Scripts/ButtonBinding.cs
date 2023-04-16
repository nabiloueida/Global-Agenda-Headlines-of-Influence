using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonBinding : MonoBehaviour
{

    [SerializeField] private CountryVariable _lastCountrySelected;

    [SerializeField] private TextMeshProUGUI _displayText;

    [SerializeField] private Image image;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject countryButton;

    [SerializeField] private Country country;

    private void OnEnable()
    {
        country._countryUpdate += updateButtonDisplay;
        _lastCountrySelected._variableUpdate += updateButtonDisplay;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Total R Count " + country.relationshipDictionary.Count);
        //PrintRelationships();
    }


    private void OnDisable()
    {
        country._countryUpdate -= updateButtonDisplay;
        _lastCountrySelected._variableUpdate -= updateButtonDisplay;
    }

    
    // Update is called once per frame
    void Update()
    {
       
    }

    public void updateButtonDisplay()
    {
        //No country selected
        if(_lastCountrySelected.Value == null)
        {
            _displayText.text = country.Name;
            //Debug.Log("No the country selected");
            //image.color = new Color
        }else if (_lastCountrySelected.Value == country) //Is this country
        {
            _displayText.text = country.Name;
            //Debug.Log("the country selected = " + country);
        }
        else //is another country
        {
            _displayText.text = country.Name + " " + _lastCountrySelected.Value.relationshipDictionary[country];
            // Debug.Log("the country selected" + _lastCountrySelected.Value + ", This country" + country + "Their relationship Score: " + _lastCountrySelected.Value.relationshipDictionary[country]);
            //Debug.Log(_lastCountrySelected.Value.relationshipDictionary[country]);
        }
    }

    public void PrintRelationships()
    {
        foreach (KeyValuePair<Country, int> relationship in country.relationshipDictionary)
        {
            Debug.Log("Country: " + country + ", Relationship with: " + relationship.Key + ", Score " + relationship.Value);
        }
    }
}

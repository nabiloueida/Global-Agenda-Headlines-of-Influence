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

    private Color baseColor;
    public Color selectedColor;
    public Color warColor;
    public Color conflictColor;
    public Color neutralColor;
    public Color strategicColor;
    public Color alliedColor;

    private void OnEnable()
    {
        country._countryUpdate += updateButtonDisplay;
        _lastCountrySelected._variableUpdate += updateButtonDisplay;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Total R Count " + country.relationshipDictionary.Count);
        baseColor = image.color;
        updateButtonDisplay();
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
            baseColor.a = 1f;
            image.color = baseColor;
            //Debug.Log("No the country selected");
            //image.color = new Color
        }else if (_lastCountrySelected.Value == country) //Is this country
        {
            _displayText.text = country.Name;
            selectedColor.a = 1f;
            image.color = selectedColor;
            //Debug.Log("the country selected = " + country);
        }
        else //is another country
        {
            _displayText.text = country.Name + "\r\n" + _lastCountrySelected.Value.relationshipDictionary[country];
            relationshipColor(country, image);
            // Debug.Log("the country selected" + _lastCountrySelected.Value + ", This country" + country + "Their relationship Score: " + _lastCountrySelected.Value.relationshipDictionary[country]);
            //Debug.Log(_lastCountrySelected.Value.relationshipDictionary[country]);
        }
    }

    public void relationshipColor(Country country, Image image)
    {
        int relationshipScore = _lastCountrySelected.Value.relationshipDictionary[country];

        if(relationshipScore >= 80) //allied
        {
            alliedColor.a = 1f;
            image.color = alliedColor;
        }else if(relationshipScore >= 60) //strategic
        {
            strategicColor.a = 1f;
            image.color = strategicColor;
        }else if (relationshipScore >= 40) //neutral
        {
            neutralColor.a = 1f;
            image.color = neutralColor;
        }else if(relationshipScore >= 20) // conflict
        {
            conflictColor.a = 1f;
            image.color = conflictColor;
        }
        else //war
        {
            warColor.a = 1f;
            image.color = warColor;
        }
        //image.color.a = 1f;
    }

    public void PrintRelationships()
    {
        foreach (KeyValuePair<Country, int> relationship in country.relationshipDictionary)
        {
            Debug.Log("Country: " + country + ", Relationship with: " + relationship.Key + ", Score " + relationship.Value);
        }
    }
}

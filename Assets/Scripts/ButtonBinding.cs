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

    [SerializeField] private ArduinoManager arduinoManager;

    private Color baseColor;
    public Color selectedColor;
    public Color warColor;
    public Color conflictColor;
    public Color neutralColor;
    public Color strategicColor;
    public Color alliedColor;

    public List<int> allied = new List<int> { 0, 112, 192 };
    public List<int> strategic = new List<int> { 128, 172, 162 };
    public List<int> neutral = new List<int> { 255, 233, 132 };
    public List<int> conflic = new List<int> { 255, 139, 78 };
    public List<int> war = new List<int> { 255, 0, 0 };


    private void OnEnable()
    {
        country._countryUpdate += updateButtonDisplay;
        _lastCountrySelected._variableUpdate += updateButtonDisplay;
    }

    private void Awake()
    {
       
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
       // if (gameManager.pickingHeadline == false && gameManager.publishingHeadline == true)
      //  {
            updateButtonDisplay();
       // }
       
    }

    public void updateButtonDisplay()
    {
        //No country selected
        if(_lastCountrySelected.Value == null)
        {
            _displayText.text = country.Name;
            baseColor.a = 1f;
            image.color = baseColor;
            arduinoManager.changeLedColor(country.ledIndex, 50, 50, 50);
            //Debug.Log("No the country selected");
            //image.color = new Color
        }else if (_lastCountrySelected.Value == country) //Is this country
        {
            _displayText.text = country.Name;
            selectedColor.a = 1f;
            image.color = selectedColor;
            arduinoManager.changeLedColor(country.ledIndex, 100, 100, 100);
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

        if(relationshipScore >= 84) //allied
        {
            alliedColor.a = 1f;
            image.color = alliedColor;
            arduinoManager.changeLedColor(country.ledIndex, allied[0], allied[1], allied[2]);
        }
        else if(relationshipScore >= 67) //strategic
        {
            strategicColor.a = 1f;
            image.color = strategicColor;
            arduinoManager.changeLedColor(country.ledIndex, strategic[0], strategic[1], strategic[2]);
        }
        else if (relationshipScore >= 34) //neutral
        {
            neutralColor.a = 1f;
            image.color = neutralColor;
            arduinoManager.changeLedColor(country.ledIndex, neutral[0], neutral[1], neutral[2]);
        }
        else if(relationshipScore >= 17) // conflict
        {
            conflictColor.a = 1f;
            image.color = conflictColor;
            arduinoManager.changeLedColor(country.ledIndex, conflic[0], conflic[1], conflic[2]);
        }
        else //war
        {
            warColor.a = 1f;
            image.color = warColor;
            arduinoManager.changeLedColor(country.ledIndex, war[0], war[1], war[2]);
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

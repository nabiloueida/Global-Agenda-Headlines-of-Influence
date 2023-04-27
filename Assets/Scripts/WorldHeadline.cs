using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void HeadlineUpdated();

[CreateAssetMenu]
public class WorldHeadline : ScriptableObject
{

    public HeadlineUpdated headlineUpdated;

    [TextArea(5, 5)]
    public string HeadLineTextFormat = "";
    [TextArea(5, 5)]
    public string ConsequenceTextFormat = "";

    
    public string selectedHint = "";
    public int selectedHintIndex;
    // [TextArea(5, 5)]
    [SerializeField] private List<string> listOfHints;

    public List<string> usedHints;


    [SerializeField]
    public Country _selectedCountry;
    //TODO
    //Properties
    public Country SelectedCountry
    {
        get{
            return _selectedCountry;
        }

        set
        {
            _selectedCountry = value;
            headlineUpdated?.Invoke();
        }
    }

    public int EffectOnAllies = 0;
    public int EffectOnStrategic = 0;
    public int EffectOnNeutral = 0;
    public int EffectOnConflict = 0;
    public int EffectOnEnemies = 0;
    

    private void Awake()
    {
        _selectedCountry = null;
        //Debug.Log("Hello");
    }

    
    public string GetCurrentHeadlineText()
    {
        if (SelectedCountry == null)
        {
            return string.Format(HeadLineTextFormat, "______");
        }
        else
        {
            return string.Format(HeadLineTextFormat, SelectedCountry.Name);
        }
    }

    public string GetCurrentConsequenceText()
    {
        if (SelectedCountry == null)
        {
            return string.Format(ConsequenceTextFormat, "______");
        }
        else
        {
            Debug.LogWarning("No Selected country!");
            return string.Format(ConsequenceTextFormat, SelectedCountry.Name);
        }
    }

    public void setHint()
    {
        if (listOfHints.Count > 0)
        {
            
            selectedHintIndex = Random.Range(0, listOfHints.Count - 1);
            Debug.Log("we are in");
            selectedHint = listOfHints[selectedHintIndex];
        }
    }

    public void useHint()
    {
        if (selectedHint != "")
        {
            usedHints.Add(selectedHint);
            listOfHints.RemoveAt(selectedHintIndex);
            selectedHint = "";
        }
        

    }
}

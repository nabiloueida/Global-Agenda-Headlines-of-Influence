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
    public int EffectOnEnemies = 0;
    public int EffectOnNeutral = 0;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CountryUpdated();

[CreateAssetMenu]
public class Country : ScriptableObject
{
    public string Name;
    public int Index;

    public Dictionary<Country, int> relationshipDictionary;

    public Dictionary<Country, int> Allies;
    public Dictionary<Country, int> Enemies;
    public Dictionary<Country, int> Neutral;

    public List<Country> allCountries;

    public CountryUpdated _countryUpdate;

    [SerializeField] public ButtonBinding _buttonBinding;

    public void Awake()
    {
        //relationshipDictionary = new Dictionary<Country, int>();
        //foreach(Country country in allCountries)
        //{
        //    relationshipDictionary.Add(country, 0);
        //}
    }

    public void UpdateAllRelationships(int onAllies, int onEnemies, int onNeutral)
    {
        foreach (KeyValuePair<Country, int> country in Allies)
        {
            Allies[country.Key] = Allies[country.Key] + onAllies;
            country.Key.UpdateOneRelationship(onAllies, onEnemies, onNeutral, this);
        }

        foreach (KeyValuePair<Country, int> country in Enemies)
        {
            Enemies[country.Key] = Enemies[country.Key] + onEnemies;
            country.Key.UpdateOneRelationship(onAllies, onEnemies, onNeutral, this);
        }

        foreach (KeyValuePair<Country, int> country in Neutral)
        {
            Neutral[country.Key] = Neutral[country.Key] + onNeutral;
            country.Key.UpdateOneRelationship(onAllies, onEnemies, onNeutral, this);
        }
    }

    public void UpdateOneRelationship (int onAllies, int onEnemies, int onNeutral, Country affectedCountry)
    {
        if (Allies.ContainsKey(affectedCountry))
        {
            Allies[affectedCountry] = Allies[affectedCountry] + onAllies;
        }

        if (Enemies.ContainsKey(affectedCountry))
        {
            Enemies[affectedCountry] = Enemies[affectedCountry] + onEnemies;
        }

        if (Neutral.ContainsKey(affectedCountry))
        {
            Neutral[affectedCountry] = Neutral[affectedCountry] + onNeutral;
        }
    }

    public void updateRelationships(int onAllies, int onStrategic, int onNeutral, int onConflict, int onEnemies)
    {
        foreach(Country country in allCountries)
        {
            Debug.Log("Before" + this + " + " + country + " = " + relationshipDictionary[country]);
            Debug.Log("Before" + country +  " + " + this + " = " + country.relationshipDictionary[this]);
            if (relationshipDictionary[country] >= 84) //allied
            {
                if(relationshipDictionary[country] + onAllies > 100)
                {
                    relationshipDictionary[country] = 100;
                    country.relationshipDictionary[this] = 100;
                }
                else
                {
                    relationshipDictionary[country] += onAllies;
                    country.relationshipDictionary[this] += onAllies;
                }
            }
            else if(relationshipDictionary[country] >= 67) //strategic
            {
                relationshipDictionary[country] += onStrategic;
                country.relationshipDictionary[this] += onStrategic;
            }
            else if (relationshipDictionary[country] >= 34) //neutral
            {
                relationshipDictionary[country] += onNeutral;
                country.relationshipDictionary[this] += onNeutral;
            }
            else if (relationshipDictionary[country] >= 17) //Conflict
            {
                relationshipDictionary[country] += onConflict;
                country.relationshipDictionary[this] += onConflict;
            }
            else if(relationshipDictionary[country] == -1)  //same country
            {
                    relationshipDictionary[country] = -1;
                country.relationshipDictionary[this] += -1;
            }
            else // Enemies / War
            {
                if(relationshipDictionary[country] + onEnemies < 1)
                {
                    relationshipDictionary[country] = 1;
                    country.relationshipDictionary[this] = 1;
                }
                else
                {
                    relationshipDictionary[country] += onEnemies;
                    country.relationshipDictionary[this] += onEnemies;
                }
                
            }
            Debug.Log("After" + this + " + " + country + " = " + relationshipDictionary[country]);
            Debug.Log("After" + country + " + " + this + " = " + country.relationshipDictionary[this]);
        }
       // _countryUpdate += _buttonBinding.updateButtonDisplay;
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Country : ScriptableObject
{
    public string Name;
    public Dictionary<Country, int> Allies;
    public Dictionary<Country, int> Enemies;
    public Dictionary<Country, int> Neutral;

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
}

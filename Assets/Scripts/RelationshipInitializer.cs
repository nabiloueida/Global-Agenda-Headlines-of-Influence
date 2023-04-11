using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipInitializer : MonoBehaviour
{
    public List<Country> _allCountries;
    private int[,] relationships;

    // Start is called before the first frame update
    void Start()
    {
        AssignRelationships();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AssignRelationships()
    {
        int[,] relationshipMatrix = GenerateRandomMatrix(_allCountries.Count, _allCountries.Count);
        Debug.Log(relationshipMatrix);
        foreach(Country country in _allCountries)
        {
            country.allCountries = _allCountries;
        }
        for (int i = 0; i < _allCountries.Count; i++)
        {
            for (int j = 0; j < _allCountries.Count; i++)
            {
                if(i == j)
                {
                    continue;
                }
                else
                {
                    _allCountries[i].relationshipDictionary[_allCountries[j]] = relationshipMatrix[i, j];
                    _allCountries[j].relationshipDictionary[_allCountries[i]] = relationshipMatrix[j, i];
                }
            }
        }
        
    }

    public int[,] GenerateRandomMatrix(int rows, int columns)
    {
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = Random.Range(10,90); // Generates random integer between 10 and 90
            }
        }

        return matrix;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RelationshipInitializer : MonoBehaviour
{
    public List<Country> _allCountries;
    public int[,] relationships;

    public TMP_Text output;

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
        //Debug.Log(relationshipMatrix);
        foreach(Country country in _allCountries)
        {
            country.allCountries = _allCountries;
        }
        for (int i = 0; i < _allCountries.Count; i++)
        {

            _allCountries[i].relationshipDictionary = new Dictionary<Country, int>();
            for (int j = 0; j < _allCountries[i].allCountries.Count; j++)
            {
                
                if(i == j)
                {

                    _allCountries[i].relationshipDictionary.Add(_allCountries[j], -1);
                }
                else
                {
                    //_allCountries[i].relationshipDictionary[_allCountries[j]] = relationshipMatrix[i, j];
                    //_allCountries[j].relationshipDictionary[_allCountries[i]] = relationshipMatrix[j, i];

                    //trying this to add value to dictionary
                    _allCountries[i].relationshipDictionary.Add( _allCountries[j] , relationshipMatrix[i, j] );
                    //Debug.Log("Added");
                    //_allCountries[j].relationshipDictionary.Add(_allCountries[i], relationshipMatrix[j, i]);
                }

               //Debug.Log(_allCountries[i] + " : " + _allCountries[j] + " Score = " + _allCountries[i].relationshipDictionary[_allCountries[j]]);
               
                //output.text += _allCountries[i] + " : " + _allCountries[j] + " Score = " + _allCountries[i].relationshipDictionary[_allCountries[j]] + " Next: ";
                //Debug.Log(_allCountries[j] + " : " + _allCountries[i] + " Score = "  + _allCountries[j].relationshipDictionary[_allCountries[i]]);
            }
        }
       // Debug.Log("Relationship Matrix = " + relationshipMatrix);
    }

    public int[,] GenerateRandomMatrix(int rows, int columns)
    {
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if(i != j)
                {
                    matrix[i, j] = Random.Range(10, 90); // Generates random integer between 10 and 90
                    matrix[j, i] = matrix[i, j];
                }
                else
                {
                    matrix[i, j] = -1;
                }
                
            }
        }

        return matrix;
    }


}

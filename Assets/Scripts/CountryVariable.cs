using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void VariableUpdated();

[CreateAssetMenu]
public class CountryVariable : ScriptableObject
{

    [SerializeField] private Country _value;

    public VariableUpdated _variableUpdate;

    public Country Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
            _variableUpdate?.Invoke();
        }
    }
    
}

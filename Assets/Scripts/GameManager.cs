using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CountryVariable _lastCountrySelected;

    // Start is called before the first frame update
    void Awake()
    {
        _lastCountrySelected.Value = null;
    }
}

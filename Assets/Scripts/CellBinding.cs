using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CellBinding : MonoBehaviour
{

    public int rowCountryIndex;
    public int coloumnCountryIndex;

    [SerializeField] private TextMeshProUGUI _displayRelationshipScore;
    [SerializeField] private Image _cellColorImage;

    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

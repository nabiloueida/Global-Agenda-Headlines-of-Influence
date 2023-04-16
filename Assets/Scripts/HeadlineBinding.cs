using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class HeadlineBinding : MonoBehaviour
{
    [SerializeField] private WorldHeadline _observedHeadline;

    [SerializeField] private List<WorldHeadline> _allHeadlines;
    [SerializeField] private List<WorldHeadline> _usedHeadlines;
    public int currentHeadlineIndex;

    [SerializeField] private TextMeshProUGUI _displayText;

    [SerializeField] private CountryVariable _lastCountrySelected;

    [SerializeField] private GameManager gameManager;

    int totalHeadlines = 0;

    [SerializeField] private string publishedCountryName;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        SetHeadline();
        _lastCountrySelected._variableUpdate += UpdateDisplayText;
    }
    private void Start()
    {
        //SetHeadline();
        totalHeadlines = _allHeadlines.Count;
        UpdateDisplayText();
    }
    private void OnDisable()
    {
        _observedHeadline.headlineUpdated -= UpdateDisplayText;
        _lastCountrySelected._variableUpdate -= UpdateDisplayText;
    }
    #endregion

    private void SetHeadline()
    {
        if(_allHeadlines.Count > 0 && gameManager.pickingHeadline)
        {
            currentHeadlineIndex = Random.Range(0, _allHeadlines.Count);
            //Debug.Log(currentHeadlineIndex);
            _observedHeadline = _allHeadlines[currentHeadlineIndex];

            _observedHeadline.headlineUpdated += UpdateDisplayText;
        }
        else
        {
            Debug.Log("Out of Headlines, restarting scene");
            SceneManager.LoadScene(0);
        }
    }

    public void UseHeadline()
    {
        //_observedHeadline.HeadLineTextFormat = string.Format(_observedHeadline.HeadLineTextFormat, _lastCountrySelected.Value.Name);
       // _observedHeadline.ConsequenceTextFormat = string.Format(_observedHeadline.ConsequenceTextFormat, _lastCountrySelected.Value.Name);
       // _observedHeadline._selectedCountry = _lastCountrySelected.Value;
        _usedHeadlines.Add(_observedHeadline);
        _allHeadlines.RemoveAt(currentHeadlineIndex);
        _lastCountrySelected.Value = null;
        SetHeadline();
    }

    private void UpdateDisplayText()
    {
        if (_lastCountrySelected.Value == null)
        {
            _displayText.text = string.Format(_observedHeadline.HeadLineTextFormat, "______");
            //Debug.Log("Empty Headline");
        }
        else if(_lastCountrySelected.Value != null && gameManager.pickingHeadline == true)
        {
            _displayText.text = string.Format(_observedHeadline.HeadLineTextFormat, _lastCountrySelected.Value.Name);
            publishedCountryName = _lastCountrySelected.Value.Name;
           // Debug.Log("Filled Headline");
        }
        else if(_lastCountrySelected.Value != null && gameManager.pickingHeadline == false)
        {

           // _displayText.text = string.Format(_observedHeadline.ConsequenceTextFormat, _lastCountrySelected.Value.Name);
            _displayText.text = string.Format(_observedHeadline.ConsequenceTextFormat, publishedCountryName);
            //Debug.Log("Headline Published, now showing Consequence");
           // publishedCountryName = null;
        }
    }
}

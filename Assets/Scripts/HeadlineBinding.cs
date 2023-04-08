using TMPro;
using UnityEngine;

public class HeadlineBinding : MonoBehaviour
{
    [SerializeField] private WorldHeadline _observedHeadline;

    [SerializeField] private TextMeshProUGUI _displayText;

    [SerializeField] private CountryVariable _lastCountrySelected;

    [SerializeField] private GameManager gameManager;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _observedHeadline.headlineUpdated+= UpdateDisplayText;
        _lastCountrySelected._variableUpdate += UpdateDisplayText;
    }
    private void Start()
    {
        UpdateDisplayText();
    }
    private void OnDisable()
    {
        _observedHeadline.headlineUpdated -= UpdateDisplayText;
        _lastCountrySelected._variableUpdate -= UpdateDisplayText;
    }
    #endregion

    private void UpdateDisplayText()
    {
        if (_lastCountrySelected.Value == null)
        {
            _displayText.text = string.Format(_observedHeadline.HeadLineTextFormat, "______");
        }
        else if(_lastCountrySelected.Value != null && gameManager.pickingHeadline == true)
        {
            _displayText.text = string.Format(_observedHeadline.HeadLineTextFormat, _lastCountrySelected.Value.Name);
        }
        else if(_lastCountrySelected.Value != null && gameManager.pickingHeadline == false)
        {
            _displayText.text = string.Format(_observedHeadline.ConsequenceTextFormat, _lastCountrySelected.Value.Name);
        }
    }
}

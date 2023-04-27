using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintHint : MonoBehaviour
{
    // Start is called before the first frame update
    public TestPrinter testPrinter;
    [SerializeField] private HeadlineBinding headlineBinding;
    public string selectedHint = "";
    void Start()
    {
        selectedHint = headlineBinding.selectedHint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printHint()
    {
        if(selectedHint != "")
        {
            testPrinter.PrepareMessage(selectedHint);
        }
        
    }
}

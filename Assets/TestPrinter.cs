using UnityEngine;
using ESC_POS_USB_NET.Printer;
using System.IO.Ports;
using System;

//https://github.com/mtmsuhail/ESC-POS-USB-NET
public class TestPrinter : MonoBehaviour
{
    public string[] messages; //first word here is the word to be highlighed
    
    private Printer printer = new Printer("rongta");
    private string[] words;
    private float timer;
    private int next;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private HeadlineBinding _headlineBinding;

    // Start is called before the first frame update
    void Start()
    {
        //PrepareMessage(messages[0]);
    }

    public void PrepareMessage(string draft)
    {
        words = draft.Split(' ');
        next = 1; //skip the first word
        timer = 0;
    }

    bool StillPrinting()
    {
        if (next < words.Length)
        {
            if (words[next].Equals(words[0], StringComparison.OrdinalIgnoreCase))
                printer.UnderlineMode(words[next]);
            else printer.AppendWithoutLf(words[next]);
            printer.AppendWithoutLf(" ");
            //Debug.Log(words[next]);
            printer.PrintDocument();
            printer.Clear();
            next++;
            return true;
        }
        else 
        {
            //only cut once
            if (next < words.Length + 1)
            {
                printer.Append(" ");
                printer.FullPaperCut();
                printer.PrintDocument();
                printer.Clear();
                next++;
            }
            //just return false aftwards
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if (StillPrinting() && timer > 1) //print one word per second
        //        timer--;


        if (gameManager.publishingHeadline)
        {
            if (StillPrinting() && timer > 1) //print one word per second
                timer--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoManager : MonoBehaviour
{
    SerialPort serialPort;

    bool zeroIsOn = false;
    bool oneIsOn = false;
    bool twoIsOn = false;
    bool threeIsOn = false;
    bool fourIsOn = false;
    bool fiveIsOn = false;
    bool sixIsOn = false;
    bool sevenIsOn = false;
    bool eightIsOn = false;

    public float timer;
    public float writeRate = 1f;

    void Start()
    {
        serialPort = new SerialPort("COM4", 115200);
        serialPort.StopBits = StopBits.One;
        serialPort.DataBits = 8;
        serialPort.Open();

        //changeLedColor(0,255,0,0);
        // changeLedColor(0, 0, 255, 0);
        //hangeLedColor(1, 255, 0, 255);

        //int id = 0;
        //int r = 255;
        //int g = 0;
        //int b = 0;
        //string data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        //serialPort.Write(data);
    }

    void FixedUpdate()
    {
        timer = Time.time;
        //int id = 0;
        //int r = 255;
        //int g = 0;
        //int b = 0;
        //string data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        //serialPort.Write(data);

        //if (!zeroIsOn )
        //{

        if (!zeroIsOn)
        {
            changeLedColor(0, 255, 0, 0);
            changeLedColor(1, 255, 0, 0);
            changeLedColor(2, 255, 0, 0);
            changeLedColor(3, 255, 0, 0);
            changeLedColor(4, 255, 0, 0);
            changeLedColor(5, 255, 0, 0);
            changeLedColor(6, 255, 0, 0);
            changeLedColor(7, 255, 0, 0);
            changeLedColor(8, 255, 0, 0);
            Invoke(nameof(Finish), 1f);
        }
            
       

        // zeroIsOn = true;
        //}if(zeroIsOn && !oneIsOn)
        //{
        //    changeLedColor(1, 0, 255, 0);

        //    oneIsOn = true;
        //}
        //if (oneIsOn && !twoIsOn)
        //{

        //    changeLedColor(2, 0, 0, 255);


        //    twoIsOn = true;

        //}
        //if (twoIsOn && !threeIsOn)
        //{
        //    changeLedColor(3, 255, 0, 0);

        //    threeIsOn = true;
        //}
        //if (threeIsOn && !fourIsOn)
        //{
        //    changeLedColor(4, 0, 255, 0);


        //    fourIsOn = true;
        //}
        //if (fourIsOn && !fiveIsOn)
        //{
        //    changeLedColor(5, 0, 0, 255);


        //    fiveIsOn = true;
        //}
        //if (fiveIsOn && !sixIsOn)
        //{
        //    changeLedColor(6, 255, 0, 0);


        //    sixIsOn = true;
        //}
        //if (sixIsOn && !sevenIsOn)
        //{
        //    changeLedColor(7, 0, 255, 0);

        //    sevenIsOn = true;
        //}
        //if (sevenIsOn && !eightIsOn)
        //{
        //    changeLedColor(8, 0, 0, 255);
        //    eightIsOn = true;
        //}

    }

    void Update()
    {
        timer += Time.time;
        // 发送数据到串口
        //int id = 0;
        //int r = 255;
        //int g = 0;
        //int b = 0;
        //string data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        //serialPort.Write(data);

        if (!zeroIsOn)
        {
            //changeLedColor(0,255,0,0);
            Debug.Log("Zero is on");
            //zeroIsOn = true;
        }if(zeroIsOn && timer >= timer + writeRate)
        {
            //changeLedColor(1, 0, 255, 0);
            Debug.Log("One is on");
           // oneIsOn = true;
        }

        //if ()
        //{
        //    Debug.Log("Space was pressed");
        //    //changeLedColor(7, 0, 255, 0);
        //    //changeLedColor(8, 0, 0, 255);
        //    //changeLedColor(0, 255, 0, 0);
        //    //changeLedColor(1, 0, 255, 0);
        //    //changeLedColor(2, 0, 0, 255);
        //    //changeLedColor(3, 255, 0, 0);
        //    //changeLedColor(4, 0, 255, 0);
        //    //changeLedColor(5, 0, 0, 255);
        //    //changeLedColor(6, 255, 0, 0);
            
        //    //zeroIsOn = true;
        //}
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Space was pressed");
            //changeLedColor(8, 0, 255, 0);
            //changeLedColor(1, 0, 255, 0);
            //changeLedColor(2, 0, 0, 255);
            //changeLedColor(3, 255, 0, 0);
            //changeLedColor(4, 0, 255, 0);
            //changeLedColor(5, 0, 0, 255);
            //changeLedColor(6, 255, 0, 0);
            //changeLedColor(7, 0, 255, 0);
            //changeLedColor(8, 0, 0, 255);
           // zeroIsOn = true;
        }


        //timer += Time.deltaTime;

    }

    void OnDestroy()
    {
        serialPort.Close();
    }

    public void changeLedColor(int id, int r, int g, int b)
    {    
        string data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        Byte[] arrayOfChar = new Byte[10];

        //arrayOfChar[0] = (Byte) (id + 48);
        //arrayOfChar[1] = 44;
        //arrayOfChar[2] = (Byte)(2 + 48);
        //arrayOfChar[3] = (Byte)(5 + 48);
        //arrayOfChar[4] = (Byte)(5 + 48);
        //arrayOfChar[5] = 44;
        //arrayOfChar[6] = (Byte)(0 + 48);
        //arrayOfChar[7] = 44;
        //arrayOfChar[8] = (Byte)(0 + 48);
        //arrayOfChar[9] = 10;

        Debug.Log("Data: " + data);
        serialPort.Write(data);
    }

    public void changeLedColor2(int id, int r, int g, int b)
    {

    }

    public void setAllLedColors()
    {
        
    }

    private void Finish()
    {
        zeroIsOn = true;
    }

}

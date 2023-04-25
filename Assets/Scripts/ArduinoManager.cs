using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoManager : MonoBehaviour
{
    SerialPort serialPort;

    void Start()
    {
        serialPort = new SerialPort("COM4", 115200);
        serialPort.Open();

        changeLedColor(2,255,0,0);
        changeLedColor(0, 0, 255, 0);
        changeLedColor(1, 255, 0, 255);
    }

    void Update()
    {
        // 发送数据到串口
        //int id = 0;
        //int r = 255;
        //int g = 0;
        //int b = 0;
        //string data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        //serialPort.Write(data);
    }

    void OnDestroy()
    {
        serialPort.Close();
    }

    public void changeLedColor(int id, int r, int g, int b)
    {    
        string data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        Debug.Log(data);
        serialPort.Write(data);
    }
}

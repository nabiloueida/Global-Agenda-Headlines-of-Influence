using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoManager : MonoBehaviour
{
    SerialPort serialPort;

    public bool on = false;
    public string data;

    void Start()
    {
        serialPort = new SerialPort("COM5", 115200);
        serialPort.Open();

        changeCountryColor(0, 255, 0, 0); // 0 - America
        changeCountryColor(1, 0, 255, 0); // 1 - Brazil
        changeCountryColor(2, 0, 0, 255); // 2 -France
        changeCountryColor(3, 255, 0, 0); // 3 - Swiss
        changeCountryColor(4, 0, 255, 0); // 4 - UK
        changeCountryColor(5, 0, 0, 255); // 5 - India
        changeCountryColor(6, 255, 0, 0); // 6 - Russia
        changeCountryColor(7, 0, 255, 0); // 7 - Australia
        changeCountryColor(8, 255, 0, 0); // 8 - China
        Debug.Log(data);
        //serialPort.Write(data);
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

        //changeCountryColor(8, 255, 0, 0); // 0 - America

        //if(on == false)
        //{
        //    changeCountryColor(0, 0, 0, 0); // 0 - America
        //    changeCountryColor(1, 0, 255, 0); // 1 - Brazil
        //    changeCountryColor(2, 0, 0, 255); // 2 -France
        //    changeCountryColor(3, 255, 0, 0); // 3 - Swiss
        //    changeCountryColor(4, 0, 255, 0); // 4 - UK
        //    changeCountryColor(5, 0, 0, 255); // 5 - India
        //    changeCountryColor(6, 255, 0, 0); // 6 - Russia
        //    changeCountryColor(7, 0, 0, 0); // 7 - Australia
        //    changeCountryColor(8, 0, 0, 0); // 8 - China
        //    on = true;
        //}
       // serialPort.
    }

    void OnDestroy()
    {
        serialPort.Close();
    }

    public void changeCountryColor(int id, int r, int g, int b)
    {
        //if(data == "")
        //{
        //    data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        //}
        //else
        //{
            data = string.Format("{0},{1},{2},{3}\n", id, r, g, b);
        //}

        // Debug.Log(string.Format("{0},{1},{2},{3}\n", id, r, g, b));
        serialPort.Write(data);
    }
}

using System.Collections;
using System.IO.Ports;
using UnityEngine;
using System;
public class camMove : MonoBehaviour
{
    //public static int movespeed = 1;
    //public Vector3 userDirection = Vector3.right;

    SerialPort stream = new SerialPort("\\\\.\\COM4", 9600);
    float angleX = 0;
    float angleY = 0;
    float angleZ = 0;

    double accX = 0;
    double accY = 0;
    double accZ = 0;

    float startAngleX = 0;
    float startAngleY = 0;
    float startAngleZ = 0;

    double velX = 0;
    double velY = 0;
    double velZ = 0;

    double posX = 0;
    double posY = 0;
    double posZ = 0;

    Vector3 currentEulerAngles;

    void Start()
    {
        stream.Open();
        string value = stream.ReadLine();
        //print(value);
        string[] words = value.Split(' ');
        startAngleX = float.Parse(words[0]);
        startAngleY = float.Parse(words[1]);
        startAngleZ = float.Parse(words[2]);
        //print(startLocationX);
        //print(startLocationY);
        //print(startLocationZ);

    }

    // Update is called once per frame
    void Update()
    {
        string value = stream.ReadLine();
        string[] words = value.Split(' ');
        angleX = float.Parse(words[0]);
        angleY = float.Parse(words[1]);
        angleZ = float.Parse(words[2]);

        accX = double.Parse(words[3]);
        accY = float.Parse(words[4]);
        accZ = float.Parse(words[5]);
        currentEulerAngles = new Vector3(angleX - startAngleX, angleY - startAngleY, angleZ - startAngleZ);// * Time.deltaTime;

        transform.eulerAngles = currentEulerAngles;


        velX = velX + Math.Floor(accX);
        velY = velY + Math.Floor(accY);
        velZ = velZ + Math.Floor(accZ);

        posX = velX; //posX + velX;
        posY = velY; //posY + velY;
        posZ = velZ - 1;

        //transform.position =  new Vector3((float)posX,(float)posY,(float)posZ);
    }
}

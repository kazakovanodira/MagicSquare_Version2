using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Controller5 : MonoBehaviour
{
    public TextMeshProUGUI[] ButtonText = new TextMeshProUGUI[25];
    int[] ButtonNumber = new int[25];
    int[,] array = new int[5, 5];
    string[,] stringArray = new string[5, 5];

    public TextMeshProUGUI mSum;
    int centerNumber, firstNumber, mSumInt, n = 5, im = 0, jm = 2;
    bool isFull = false;

    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            ButtonNumber[i] = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = 0;
            }
        }
    }


    public void MagicSquare()
    {
        mSumInt = Int32.Parse(mSum.text);
        centerNumber = (mSumInt/n);
        firstNumber = centerNumber-(n*n-1)/2;

        for (int row=0; row<5; row++)
        {
            for (int col=0; col<5; col++)
            {
                stringArray[row, col] = "*";
            }
        }

        array[0, 2] = firstNumber;
        stringArray[0, 2] = firstNumber.ToString();
        
        im = (im+4)%5; 
        jm = (jm+6)%5;

        while (!isFull)
        {
            ++firstNumber;
            if (stringArray[im, jm] == "*")
            {
                array[im, jm] = firstNumber;
                stringArray[im, jm] = firstNumber.ToString();
            }
            else 
            {
                im = (im+6)%5; //returning its previous position
                jm = (jm+4)%5;

                im = (im+6)%5; //new position when diagonal isn't available
                if (stringArray[im, jm] != "*")
                {
                    isFull = true;
                    break;
                }
                array[im, jm] = firstNumber;
                stringArray[im, jm] = firstNumber.ToString();
            }
            im = (im+4)%5;
            jm = (jm+6)%5;
        }

        isFull = false;
        System.Buffer.BlockCopy(array, 0, ButtonNumber, 0, 100);
        for (int i = 0; i < 25; i++)
        {
            ButtonText[i].text = ButtonNumber[i].ToString();
        }
        Debug.Log(string.Join(", ", ButtonNumber));
    }

}
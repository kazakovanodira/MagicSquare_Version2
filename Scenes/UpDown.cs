using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class UpDown : MonoBehaviour
{
    public TextMeshProUGUI mSum;
    int mSumInt;

    public void OnClick(int direction)
    {
        mSumInt = Int32.Parse(mSum.text);
        if (direction > 0)
        {
            mSumInt += 5;
        }
        else
        {
            mSumInt -= 5;
        }
        mSum.text = mSumInt.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalite : MonoBehaviour
{
   public void low()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void med()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void high()
    {
        QualitySettings.SetQualityLevel(6);
    }
}

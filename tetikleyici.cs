using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tetikleyici : MonoBehaviour
{

    public Text trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger.text = "BA�LA";
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject.tag == "trigger")
        {
            trigger.text = "�SKELEY� SAVUN!";
        }
        if (this.gameObject.tag == "trigger1")
        {
            trigger.text = "R = Mermi yeniler";
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public TextMeshProUGUI tip;
    public List<string> tips;


    public void SetTip()
    {
        tip.text = "Tip: " + tips[Random.Range(0, tips.Count)];
    }
}

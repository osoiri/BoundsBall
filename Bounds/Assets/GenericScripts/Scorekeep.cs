using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scorekeep : MonoBehaviour
{
    public TextMeshProUGUI score1;
    // Start is called before the first frame update
    void Start()
    {
        score1.text = MatchManager.getscore().ToString() + " . " + MatchManager.getoppscore().ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{

    public Text userName;
    public Text currentBalanceTxt;
    public int currentBalance;
    // Start is called before the first frame update
    void Start()
    {
        currentBalanceTxt.text = currentBalance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

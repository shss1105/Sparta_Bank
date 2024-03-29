using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    [Header("ATM")]
    public Text userName;
    public Text currentBalanceTxt;
    public int currentBalance;

    //[Header("Player")]
    //public Text currentCashValueTxt;
    //public int currentCash;
    // Start is called before the first frame update
    void Start()
    {
        //currentCash = DataManager._playerCash;
        //currentCashValueTxt.text = currentCash.ToString();

        //currentBalance = DataManager._atmBalance;
        //currentBalanceTxt.text = currentBalance.ToString();
        DataManager.instance.LoadPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        //DataManager.instance.LoadPlayerInfo();
        currentBalance = DataManager._atmBalance;
        currentBalanceTxt.text = currentBalance.ToString("N0");
        userName.text = DataManager._playerName;
    }
}

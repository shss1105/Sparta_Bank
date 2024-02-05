using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text currentCashValueTxt;
    public int currentCash;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        //currentCash = DataManager._playerCash;
        //currentCashValueTxt.text = currentCash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentCash = DataManager._playerCash;
        currentCashValueTxt.text = currentCash.ToString();
    }
}

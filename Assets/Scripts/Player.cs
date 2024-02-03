using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text currentCashValueTxt;
    public int currentCash;
    // Start is called before the first frame update
    void Start()
    {
        currentCashValueTxt.text = currentCash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

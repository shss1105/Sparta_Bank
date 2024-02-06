using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ATMButton : MonoBehaviour
{
    private bool isdepositScene;
    //private Button _ATMButton;
    private int _buttonValue;
    
    [SerializeField] private InputField DepositAndWithdrawInputField;
    [SerializeField] private InputField RemittanceTargetInputField;
    [SerializeField] private InputField RemittanceValueInputField;
    [SerializeField] private GameObject insufficientPopup;
    //public GameObject ATM;
    // Start is called before the first frame update
    void Start()
    {
        //_ATMButton = GetComponentInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDeposit()
    {
        SceneManager.LoadScene("DepositScene");
    }

    public void OnClickWithdraw()
    {
        SceneManager.LoadScene("WithdrawScene");
    }

    public void OnClickBackStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnClickRemittance()
    {
        SceneManager.LoadScene("RemittanceScene");
    }

    public void OnClickManWonBtn()
    {
        CheckSceneName();
        UseATM(10000);
    }

    public void OnClickSamManWonBtn()
    {
        CheckSceneName();
        UseATM(30000);
    }

    public void OnClickOManWonBtn()
    {
        CheckSceneName();
        UseATM(50000);
    }

    public void OnClickDirectinputBtn()
    {
        CheckSceneName();
        UseInputATM(DepositAndWithdrawInputField.text);
    }

    public void OnClickClosePopup()
    {
        insufficientPopup.SetActive(false);
    }

    public void Deposit(int _buttonValue)
    {
        //int _Value = 0;
        //Text text = _ATMButton.GetComponentsInChildren<Text>();
        //string a = text.text;
        //_buttonValue = int.Parse(a);
        if (DataManager._playerCash > 0 && DataManager._playerCash >= _buttonValue)
        {
            DataManager._playerCash -= _buttonValue;
            DataManager._atmBalance += _buttonValue;

            if (PlayerPrefs.HasKey("playerCount") == true)
            {
                DataManager.playerIDCount = PlayerPrefs.GetInt("playerCount");
                PlayerPrefs.SetInt("playerCash"+ (DataManager.playerIDCount - 1), DataManager._playerCash);
                PlayerPrefs.SetInt("atmBalance"+ (DataManager.playerIDCount - 1), DataManager._atmBalance);
            }
        }
        else
        {
            insufficientPopup.SetActive(true);
            return;
        }

    }

    public void Withdraw(int _buttonValue)
    {
        if(DataManager._atmBalance > 0 && DataManager._atmBalance >= _buttonValue)
        {
            DataManager._playerCash += _buttonValue;
            DataManager._atmBalance -= _buttonValue;

            if (PlayerPrefs.HasKey("playerCount") == true)
            {
                DataManager.playerIDCount = PlayerPrefs.GetInt("playerCount");
                PlayerPrefs.SetInt("playerCash" + (DataManager.playerIDCount - 1), DataManager._playerCash);
                PlayerPrefs.SetInt("atmBalance" + (DataManager.playerIDCount - 1), DataManager._atmBalance);
            }
        }
        else
        {
            insufficientPopup.SetActive(true);
            return;
        }
    }

    public void Remittance()
    {
        // 송금기능
    }

    public void CheckSceneName()
    {
        if (SceneManager.GetActiveScene().name == "DepositScene")
        {
            isdepositScene = true;
        }
        else if (SceneManager.GetActiveScene().name == "WithdrawScene")
        {
            isdepositScene = false;
        }
    }


    public void UseATM(int Value)
    {
        if (isdepositScene)
        {
            _buttonValue = Value;
            Deposit(_buttonValue);
        }
        else
        {
            _buttonValue = Value;
            Withdraw(_buttonValue);
        }
    }

    public void UseInputATM(string inputValue)
    {
        if (isdepositScene)
        {
            inputValue = DepositAndWithdrawInputField.text;
            int Value = int.Parse(inputValue);
            _buttonValue = Value;
            Deposit(_buttonValue);
        }
        else
        {
            inputValue = DepositAndWithdrawInputField.text;
            int Value = int.Parse(inputValue);
            _buttonValue = Value;
            Withdraw(_buttonValue);
        }
    }
}

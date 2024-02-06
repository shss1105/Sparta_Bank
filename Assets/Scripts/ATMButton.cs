using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    [SerializeField] private Text errorMessage;
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

    public void OnClickRemittanceBtn()
    {
        if (RemittanceTargetInputField.text == "" || RemittanceValueInputField.text == "")
        {
            insufficientPopup.SetActive(true);
            errorMessage.text = "입력 정보를 확인해 주세요.";
            return;
        }
        else
        {
            if (DataManager._atmBalance <= 0)
            {
                insufficientPopup.SetActive(true);
                errorMessage.text = "잔액이 부족합니다.";
                return;
            }
            else
            {
                if(PlayerPrefs.HasKey("playerID"+0) != true)
                {
                    insufficientPopup.SetActive(true);
                    errorMessage.text = "대상이 없습니다.";
                    return;
                }
            }
            Remittance(RemittanceValueInputField.text);
        }

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

    public void Remittance(string inputValue)
    {
        if(PlayerPrefs.HasKey("playerCount") == true)
        {
            DataManager.playerIDCount = PlayerPrefs.GetInt("playerCount");
            int temp = DataManager.playerIDCount;
            int sentBalance = PlayerPrefs.GetInt("atmBalance" + (temp-1));
            int targetBalance = PlayerPrefs.GetInt("atmBalance" + (temp - 2));
            int Value = int.Parse(inputValue);

            string sent = PlayerPrefs.GetString("playerName" + (temp-1));
            string target = PlayerPrefs.GetString("playerName" + (temp - 2));

            if(DataManager._atmBalance > 0 && RemittanceTargetInputField.text == target)
            {
                DataManager._atmBalance -= Value;
                targetBalance += Value;

                PlayerPrefs.SetInt("atmBalance" + (temp - 1), DataManager._atmBalance);
                PlayerPrefs.SetInt("atmBalance" + (temp - 2), targetBalance);
                PlayerPrefs.Save();

            }
        }
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

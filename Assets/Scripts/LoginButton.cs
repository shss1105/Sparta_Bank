using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField ID;
    [SerializeField] private InputField Password;
    
    [Header("SignUp")]
    [SerializeField] private GameObject signUpMenuPopup;
    [SerializeField] private GameObject errorPopup;
    [SerializeField] private Text errorMessage;
    [SerializeField] private InputField signUpID;
    [SerializeField] private InputField signUpName;
    [SerializeField] private InputField signUpPassword;
    [SerializeField] private InputField signUpPsCofirm;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DataManager.instance.LoadPlayerInfo();
    }

    public void OnClickLoginBtn()
    {
        int savedPlayerIDCount = DataManager.playerIDCount;
        string savedID = PlayerPrefs.GetString("playerID" + (savedPlayerIDCount - 1));
        string savedPassword = PlayerPrefs.GetString("playerPassword" + (savedPlayerIDCount - 1));

        if (ID.text == "" || Password.text == "")
        {
            Debug.Log("아이디와 비밀번호를 입력해주세요.");
            return;
        }
        else
        {
            if (ID.text == savedID && Password.text == savedPassword)
            {
                SceneManager.LoadScene("StartScene");
            }
            else Debug.Log("아이디와 비밀번호를 확인하세요.");
        }

        //else
        //{
        //    if (DataManager.instance.playerData.ContainsKey(DataManager._playerID))
        //    {
        //        string savedPassword = DataManager.instance.playerData[DataManager._playerID];

        //        if (Password.text == savedPassword)
        //        {
        //            SceneManager.LoadScene("StartScene");
        //        }
        //        else
        //        {
        //            Debug.Log("비밀번호가 일치하지 않습니다.");
        //        }
        //    }
        //    else Debug.Log("아무 계정도 등록되어 있지 않습니다.");
        //}

    }

    public void OnClickSignUpBtn()
    {
        signUpMenuPopup.SetActive(true);
    }

    public void OnClickCancelBtn()
    {
        signUpMenuPopup.SetActive(false);
        errorMessage.text = "";
    }

    public void OnClickErrorPopupBtn()
    {
        errorPopup.SetActive(false);
    }
    public void OnClickPopupMenuSignUpBtn()
    {
        if(!(3 <= signUpID.text.Length && signUpID.text.Length <= 10) || !(2 <= signUpName.text.Length && signUpName.text.Length <= 5) || !(signUpPassword.text == signUpPsCofirm.text))
        {
            errorPopup.SetActive(true);
            errorMessage.text = "ID를 확인해 주세요.";
            return;
        }

        else
        {
            SignUp();
        }
    }

    public void SignUp()
    {
        DataManager.instance.SavePlayerInfo(signUpID.text, signUpName.text, signUpPassword.text);
        signUpMenuPopup.SetActive(false);
        //SceneManager.LoadScene("StartScene");
        //DataManager.playerName.Add(signUpName.text);
        //DataManager.playerPassword.Add(signUpPassword.text);
    }
}

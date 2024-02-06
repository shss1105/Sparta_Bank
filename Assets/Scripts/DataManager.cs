using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    //Player _player;
    //public Text playerCash;
    //public Text atmBalance;

    //public static List<string> playerID;
    //public static List<string> playerName;
    //public static List<string> playerPassword;

    //public Dictionary<string, string> playerData;

    public static string _playerID;
    public static string _playerName;
    public static string _playerPassword;

    public static int _playerCash;
    public static int _atmBalance;

    public static int playerIDCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //playerData = new Dictionary<string, string>();
        //PlayerPrefs.DeleteAll();
        //LoadCash();
        //LoadBalance();
        LoadPlayerInfo();
    }

    void Update()
    {
        //LoadPlayerInfo();
    }


    //public void SetPlayerDictionary(string _playerID)
    //{
    //    playerData.Add("PlayerIDDictionary" + playerIDCount, _playerID);
    //    playerIDCount++;

    //}
    //public void LoadPlayerList()
    //{
    //    if (PlayerPrefs.HasKey("playerCount") == true)
    //    {
    //        playerIDCount = PlayerPrefs.GetInt("playerCount");

    //        for (int i = 0; i < playerIDCount; i++)
    //        {

    //        }
    //    }
    //}
    public void SavePlayerInfo(string _playerID, string _playerName, string _playerPassword)
    {
        PlayerPrefs.SetString("playerID" + playerIDCount, _playerID);
        PlayerPrefs.SetString("playerName" + playerIDCount, _playerName);
        PlayerPrefs.SetString("playerPassword" + playerIDCount, _playerPassword);
        
        if (PlayerPrefs.HasKey("playerCash") == true)
        {
            _playerCash = PlayerPrefs.GetInt("playerCash" + playerIDCount);
        }
        else
        {
            _playerCash = 100000;
            PlayerPrefs.SetInt("playerCash" + playerIDCount, _playerCash);
        }

        if (PlayerPrefs.HasKey("atmBalance") == true)
        {
            _atmBalance = PlayerPrefs.GetInt("atmBalance" + playerIDCount);
        }
        else
        {
            _atmBalance = 50000;
            PlayerPrefs.SetInt("atmBalance" + playerIDCount, _atmBalance);
        }
        playerIDCount++;
        PlayerPrefs.SetInt("playerCount", playerIDCount);
        PlayerPrefs.Save();
        //playerData.Add(_playerID, _playerPassword);
    }

    public void LoadPlayerInfo()
    {
        if (PlayerPrefs.HasKey("playerCount") == true)
        {
            playerIDCount = PlayerPrefs.GetInt("playerCount");

            for (int i = 0; i < playerIDCount; i++)
            {
                if (PlayerPrefs.HasKey("playerID" + (playerIDCount-1)) == true)
                {
                    _playerID = PlayerPrefs.GetString("playerID" + (playerIDCount - 1));
                    _playerName = PlayerPrefs.GetString("playerName" + (playerIDCount - 1));
                    _playerPassword = PlayerPrefs.GetString("playerPassword" + (playerIDCount - 1));
                    _playerCash = PlayerPrefs.GetInt("playerCash" + (playerIDCount - 1));
                    _atmBalance = PlayerPrefs.GetInt("atmBalance" + (playerIDCount - 1));
                }
            }

        }
    }

    public void SaveCash()
    {
        //PlayerPrefs.SetInt("playerCash", _playerCash);
        PlayerPrefs.Save();
    }

    public void LoadCash()
    {
        if (PlayerPrefs.HasKey("playerCash") == true)
        {
            _playerCash = PlayerPrefs.GetInt("playerCash");
        }
        else
        {
            _playerCash = 100000;
            //SaveCash();
            _playerCash = PlayerPrefs.GetInt("playerCash");
        }
    }

    public int LoadPlayerCash()
    {
        return _playerCash;
    }

    public void SaveBalance()
    {
        PlayerPrefs.SetInt("atmBalance", _atmBalance);
        PlayerPrefs.Save();
    }

    public void LoadBalance()
    {
        if (PlayerPrefs.HasKey("atmBalance") == true)
        {
            _atmBalance = PlayerPrefs.GetInt("atmBalance");
        }
        else
        {
            _atmBalance = 50000;
            //SaveBalance();
            _atmBalance = PlayerPrefs.GetInt("atmBalance");
        }
    }
}

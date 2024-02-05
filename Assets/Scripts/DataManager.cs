using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    Player _player;
    public Text playerCash;
    public Text atmBalance;


    public static int _playerCash = 0;
    public static int _atmBalance = 50000;

    private void Awake()
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
        playerCash.text = PlayerPrefs.GetInt("playerCash").ToString();
        LoadCash();
        LoadBalance();
    }

    public void SaveCash()
    {
        PlayerPrefs.SetInt("playerCash", _playerCash);
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
            SaveCash();
            _playerCash = PlayerPrefs.GetInt("possessionGold");
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
            //SaveBalance();
        }
    }


}

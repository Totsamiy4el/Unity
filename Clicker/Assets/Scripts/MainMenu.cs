using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int money;
    public int total_money;
    public Text moneyText;
    public bool firstBuy;
    public bool thirdBuy;
    public bool fourthBuy;
    public int passivMoney;
    public GameObject effect;
    public GameObject button;
    public int clickMoney;
    public GameObject x;
    bool secondBuy;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        firstBuy = PlayerPrefs.GetInt("firstBuy") == 1 ? true : false;
        passivMoney = PlayerPrefs.GetInt("passivMoney");
        thirdBuy = PlayerPrefs.GetInt("thirdBuy") == 1 ? true : false;
        fourthBuy = PlayerPrefs.GetInt("fourthBuy") == 1 ? true : false;
        clickMoney = PlayerPrefs.GetInt("clickMoney");
        if (firstBuy || thirdBuy)
        {
            StartCoroutine(IdleFarm());
        }

        if (secondBuy)
        {
            
            clickMoney = 2;
            PlayerPrefs.SetInt("clickMoney", clickMoney);
        }
        else
        {
            
            clickMoney = 1;
            PlayerPrefs.SetInt("clickMoney", clickMoney);
        }
        if (fourthBuy)
        {
            clickMoney = 5;
            PlayerPrefs.SetInt("clickMoney", clickMoney);
        }
    }
    public void ButtonClick()
    {
        money+=clickMoney;
        total_money+= clickMoney;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        audioSource.Play();
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized,Quaternion.identity);

    }

    IEnumerator IdleFarm()
    {
            yield return new WaitForSeconds(5);
            money+=passivMoney;
            total_money+=passivMoney;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("total_money", total_money);
            StartCoroutine(IdleFarm());
    }
    public void ToAchievements()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMagaz()
    {
        SceneManager.LoadScene(2);
    }
    
    public void ResetAll()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        money = 0;
        total_money = 0;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        firstBuy = false;
        PlayerPrefs.SetInt("firstBuy", firstBuy ? 1 : 0);
        secondBuy = PlayerPrefs.GetInt("secondBuy") == 1 ? true : false;
        secondBuy = false;
        PlayerPrefs.SetInt("secondBuy", secondBuy ? 1 : 0);
        thirdBuy = PlayerPrefs.GetInt("thirdBuy") == 1 ? true : false;
        thirdBuy = false;
        PlayerPrefs.SetInt("thirdBuy", secondBuy ? 1 : 0);
        fourthBuy = PlayerPrefs.GetInt("fourthBuy") == 1 ? true : false;
        fourthBuy = false;
        PlayerPrefs.SetInt("fourthBuy", fourthBuy ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {
            x = GameObject.Find("money(Clone)");
            Destroy(x, 0.25f);
            moneyText.text = money.ToString();
    }

    
    
}

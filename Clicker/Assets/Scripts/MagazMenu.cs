using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MagazMenu : MonoBehaviour
{
    [SerializeField] Button firstProduct;
    [SerializeField] Button secondProduct;
    [SerializeField] Button thirdProduct;
    [SerializeField] Button fourthProduct;
    public int money;
    public int total_money;
    public bool firstBuy;
    public bool secondBuy;
    public bool thirdBuy;
    public bool fourthBuy;
    public int passivMoney;
    int clickMoney;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        firstBuy = PlayerPrefs.GetInt("firstBuy") == 1 ? true : false;
        secondBuy = PlayerPrefs.GetInt("secondBuy") == 1 ? true : false;
        thirdBuy = PlayerPrefs.GetInt("thirdBuy") == 1 ? true : false;
        fourthBuy = PlayerPrefs.GetInt("fourthBuy") == 1 ? true : false;
        passivMoney = PlayerPrefs.GetInt("passivMoney");
        clickMoney = PlayerPrefs.GetInt("clickMoney");

        if (firstBuy || thirdBuy)
        {
            StartCoroutine(IdleFarm());
            firstProduct.interactable = false;
            thirdProduct.interactable = false;
            
        }
        else
        {
            
            firstProduct.interactable = true;
        }
        if (secondBuy)
        {
            secondProduct.interactable = false;
        }
        else
        {
            secondProduct.interactable = true;
        }
        if (thirdBuy)
        {
            thirdProduct.interactable = false;
        }
        else
        {
            thirdProduct.interactable = true;
        }
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(5);
        money += passivMoney;
        total_money += passivMoney;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        StartCoroutine(IdleFarm());
    }

    public void GetFirst()
    {
        int money = PlayerPrefs.GetInt("money");
        if(money >= 100) {
            firstProduct.interactable = false;
            money -= 100;
            passivMoney = 1;
            PlayerPrefs.SetInt("passivMoney", passivMoney);
            PlayerPrefs.SetInt("money", money);
            firstBuy = true;
            PlayerPrefs.SetInt("firstBuy", firstBuy ? 1 : 0);
        }
    }

    public void GetSecond()
    {
        if(money >= 500) 
        {
            secondProduct.interactable = false;
            money -= 500;
            secondBuy = true;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("secondBuy", secondBuy ? 1 : 0);
        }
    }

    public void GetThird()
    {
        if(money >= 1000)
        {
            thirdProduct.interactable = false;
            money -= 1000;
            thirdBuy = true;
            passivMoney = 3;
            PlayerPrefs.SetInt("passivMoney", passivMoney);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("thirdBuy", thirdBuy ? 1 : 0);
        }
    }

    public void GetFourth()
    {
        if(money >= 5000)
        {
            fourthProduct.interactable = false;
            money -= 5000;
            fourthBuy = true;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("fourthBuy", fourthBuy ? 1 : 0);
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

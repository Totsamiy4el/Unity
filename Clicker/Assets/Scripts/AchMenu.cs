using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchMenu : MonoBehaviour
{
    public int money;
    public int total_money;
    [SerializeField] Button firstAch;
    [SerializeField] Button secondAch;
    [SerializeField] Button thirdAch;
    [SerializeField] Button fourthAch;
    int passivMoney;
    public bool thirdBuy;
    public bool firstBuy;


    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        passivMoney = PlayerPrefs.GetInt("passivMoney");
        firstBuy = PlayerPrefs.GetInt("firstBuy") == 1 ? true : false;
        thirdBuy = PlayerPrefs.GetInt("thirdBuy") == 1 ? true : false;
       
        if (total_money >= 100)
        {
            firstAch.interactable = true;
            
        }
        else
        {

            firstAch.interactable = false;

        }
        if (total_money >= 500)
        {
            secondAch.interactable = true;

        }
        else
        {

            secondAch.interactable = false;

        }
        if (total_money >= 1000)
        {
            thirdAch.interactable = true;

        }
        else
        {

            thirdAch.interactable = false;

        }

        if (total_money >= 5000)
        {
            fourthAch.interactable = true;

        }
        else
        {

            fourthAch.interactable = false;

        }

        if (firstBuy || thirdBuy)
        {
            StartCoroutine(IdleFarm());
        }

    }

    IEnumerator IdleFarm()
    {

            yield return new WaitForSeconds(5);
            money+= passivMoney;
            total_money+=passivMoney;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("total_money", total_money);
            StartCoroutine(IdleFarm());

    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);

    }

    void Update()
    {
        
    }
}

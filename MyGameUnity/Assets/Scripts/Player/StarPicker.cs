using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarPicker : MonoBehaviour
{

    [SerializeField] private int stars;
    [SerializeField] private TMP_Text countStars;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player_controller>()._starScore += stars;
        Destroy(gameObject);
        countStars.text = "X" + collision.gameObject.GetComponent<Player_controller>()._starScore;
    }
}

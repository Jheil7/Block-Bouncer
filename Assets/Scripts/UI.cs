using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI playerLives;
    int getAmmoText=0;
    int healthText=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getAmmoText=playerActions.GetAmmo();
        ammoText.text=getAmmoText.ToString();
        healthText=playerHealth.GetLives();
        playerLives.text=("x ")+healthText.ToString();
    }
}

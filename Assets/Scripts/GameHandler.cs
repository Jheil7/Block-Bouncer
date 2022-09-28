using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] PlayerHealth player1;
    [SerializeField] PlayerHealth player2;
    int player1Health;
    int player2Health;
    [SerializeField] TMP_Text winText;
    
    // Start is called before the first frame update
    void Start()
    {
        winText.text="";
    }

    // Update is called once per frame
    void Update()
    {
        player1Health=player1.GetLives();
        player2Health=player2.GetLives();
        CheckHp();
    }

    void CheckHp(){
        if(player1Health<=0){
            TimeScale();
            winText.text="Player 2 Wins!";
            //player 2 wins
        }

        if(player2Health<=0){
            TimeScale();
            winText.text="Player 1 Wins!";
            //player 1 wins
        }
    }

    void TimeScale(){
        Time.timeScale=0;
    }
}

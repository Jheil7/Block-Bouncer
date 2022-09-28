using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SideSelect : MonoBehaviour
{
    Vector2 startPos;
    [SerializeField] Transform leftSelect;
    [SerializeField] Transform rightSelect;
    Vector2 leftVector;
    Vector2 rightVector;
    Vector2 currentVector2;
    InputAction inputValue;
    public bool isPlayer1;
    public bool isPlayer2;
    public bool noneSelected;
    [SerializeField] SideSelect otherController;
    PlayerInput playerInput;
    PlayerInputManager inputManager;
    int playerIndex;
    
    void Start()
    {
        startPos=transform.position;
        leftVector=new Vector2(leftSelect.position.x,leftSelect.position.y);
        rightVector=new Vector2(rightSelect.position.x,rightSelect.position.y);
        playerInput=GetComponent<PlayerInput>();
        inputManager=GetComponent<PlayerInputManager>();
        playerIndex=playerInput.playerIndex;

    }

    private void Awake() {
        
    }


    void Update()
    {
        currentVector2=new Vector2(transform.position.x,transform.position.y);
        PlayerBool();

    }

    void OnLeft(InputValue value){
        if(value.isPressed&&(currentVector2==startPos&&!otherController.IsPlayer1())){
            transform.position=leftVector;
            IsPlayer1();
            Debug.Log(playerIndex+" is Player1");
        }
        else if(value.isPressed&&(currentVector2==rightVector)){
            transform.position=startPos;
        }
    }

    void OnRight(InputValue value){
        if(value.isPressed&&(currentVector2==startPos&&!otherController.IsPlayer2())){
            transform.position=rightVector;
            IsPlayer2();
            Debug.Log(playerIndex+" is Player2");
        }
        else if(value.isPressed&&(currentVector2==leftVector)){
            transform.position=startPos;
        }
    }

    void OnStart(InputValue value){
        if(value.isPressed){
            SceneManager.LoadScene("SampleScene");
        }
    }

    public bool IsPlayer1(){
        return isPlayer1;
    }
    public bool IsPlayer2(){
        return isPlayer2;
    }

    void PlayerBool(){
        if(currentVector2==leftVector){
            isPlayer1=true;
            isPlayer2=false;
            noneSelected=false;
        }
        else if(currentVector2==rightVector){
            isPlayer2=true;
            isPlayer1=false;
            noneSelected=false;
        }

        else{
            isPlayer1=false;
            isPlayer2=false;
            noneSelected=true;
        }
    }


}

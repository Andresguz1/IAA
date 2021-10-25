using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer renderer;
    public float SpeedUp = 4;
    public float Speed = 1;
    public float JumpSpeed = 2;
    public float Gravity = 1;
    public Sprite[] Idle, Walk;
    public Sprite[] HongoIdle, HongoWalk;
    private float Velocity,Fall;
    private int HorizontalDirection=0;
    private Sprite[] CurrentAnim;
    private int AnimState= -1;
    public bool IsBig = false;
    private float animclock;
    private int CurrentSprite;
    private bool Jump,IsGroungd;
    private static Transform p;
    private float VerticalVelocity = 1;
    public static Transform GetTransform() { return p; }
    

    void Start()
    {
        p = this.transform;
        SetAnim(0, IsBig);
        IsGroungd = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&IsGroungd) { 
            VerticalVelocity-= JumpSpeed;
            Jump = true;
            IsGroungd = false;
        }

        if (Input.GetKey(KeyCode.A)) { 
            HorizontalDirection = -1; 
        }
        else if (Input.GetKey(KeyCode.D)) { 
            HorizontalDirection = 1; 
        }
        else { 
            HorizontalDirection = 0; 
        }
        
        var pos = transform.position;
        //Colision
        RaycastHit hit;
        var margen = 0.5f;
        if (IsBig) { margen = 1; }
        var Origin = pos + new Vector3(0, margen, 0);

        if (Physics.Raycast(Origin, Vector3.right*HorizontalDirection, out hit, 0.4f)) { 
            if (hit.transform.tag == "Solido") {               
                HorizontalDirection = 0;
                Velocity = 0;
            }
        }

        var Origin2 = pos+new Vector3(0, 0.1f, 0);
        var margen2= 1f;
        if (Mathf.Sign(VerticalVelocity) <= 0) {
            Origin2 = pos + new Vector3(0, 0.5f, 0);
            margen2 = 0.5f;
        }

        VerticalVelocity += Time.deltaTime * Gravity;
        pos.y = VerticalVelocity * Time.deltaTime;

        if (Physics.Raycast(Origin2,Vector3.down,out hit,0.4f)){ //detecta       
            if (Mathf.Sign(VerticalVelocity) >= 0){
                if (hit.transform.tag == "Solido") {
                    if (!IsGroungd){
                        IsGroungd = true;
                        Jump = false;
                        pos.y = hit.transform.position.y + 0.5f;
                    }
                    else {
                        pos.y = hit.transform.position.y + 0.5f;
                        VerticalVelocity = 0;
                    }
                }

            //else { hit.transform.GetCompone }                                                                
            
            //aire
            }
        }
/*

        if (VerticalVelocity >= 15) { VerticalVelocity = 15;}
        Velocity = Mathf.MoveTowards(Velocity, HorizontalDirection, SpeedUp * Time.deltaTime);
            pos.x += (Speed * Velocity) * Time.deltaTime;
            transform.position=pos;
            if (HorizontalDirection == 1)
            {
                renderer.flipX = false;
            }
            else
           if (HorizontalDirection == -1)
            {
                renderer.flipX = true;
            }
            pos.x+=(Speed*Velocity)*Time.deltaTime;
            
        transform.position = pos;
        if (Velocity!= 0) {
            SetAnim(1, IsBig);        //Se mueve
        }
        else { SetAnim(0, IsBig); }                                  //Estatico

        animclock += Time.deltaTime * (Mathf.Abs(Velocity))*(Speed*2);         
        if (animclock >= 1)
        {
            CurrentSprite += 1;
            animclock = 0;
        }

        if (CurrentSprite >= CurrentAnim.Length){ CurrentSprite = 0;}

        renderer.sprite = CurrentAnim[CurrentSprite];
        */
    }

    void SetAnim(int state,bool big)
    {
        if (state!= AnimState) { 
            CurrentSprite = 0;
            animclock = 0;
            //MARIO PARADO
        {
            if (state == 0&&!big) { CurrentAnim = Idle; }
            if (state == 0&&big) { CurrentAnim = HongoIdle; }
            //MARIO MOVIMIENTO
            if (state == 1&&!big) { CurrentAnim = Walk; }
            if (state == 1&&big) { CurrentAnim = HongoWalk; }
            AnimState = state;
            }
        }
     
    }
}


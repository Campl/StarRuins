
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    Animator anim;
    public  int tran;
    public int direction;
    float horizontal = 0;
    Vector3 moveDirection = Vector3.zero;
    CharacterController characterController;
    public CapsuleCollider HeroColl;
    CalculateAttribute calAttribute;

    public float gravity = 10;  //重力                                
    public float speed = 5;//水平移动的速度                
    public float jumpHeight = 10;//弹跳高度 


    void Start()
    {
        anim = this.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        HeroColl = GetComponent<CapsuleCollider>();
        calAttribute = GameObject.Find("sceneManager").GetComponent<CalculateAttribute>();
    }

    void Update()
    {
        calAttribute.UpdateExp();
        calAttribute.UpdateAttribute();

        //移动
        characterController.Move(moveDirection * Time.deltaTime);
        if (ETCInput.GetAxisPressedLeft("Horizontal"))
        {
            anim.SetFloat("Direction", 0);
            tran = 0;
            moveDirection.x = horizontal * speed;
        }
        if (ETCInput.GetAxisPressedRight("Horizontal"))
        {
            anim.SetFloat("Direction", 1);
            tran = 1;
            moveDirection.x = horizontal * speed;
        }

        //跳跃
        moveDirection.y -= gravity * Time.deltaTime;
        if (characterController.isGrounded)
        {
			if (ETCInput.GetAxisPressedUp("Vertical"))
            {
                moveDirection.y = jumpHeight;
            }
        }
        direction = tran;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSkill : MonoBehaviour
{
    GameObject skill1;
    GameObject JianL;
    GameObject JianR;
    GameObject SkillTwoL;
    GameObject SkillTwoR;
    GameObject SkillThreeL;
    GameObject SkillThreeR;
    Animator anim;
    // Use this for initialization
    public float px;
    public float py;
    public float dis;
    float cd1 = 3;
    float cd2 = 5;
    float cd3 = 20;
    float cd4 = 15;
    float cd5 = 15;
    public float max = 60;
    public float cdplus = 0.1f;
    public float cost;
    Text cdTimeOne;
    Text cdTimeTwo;
    Text cdTimeThree;
    Text cdTime4;
    Text cdTime5;
    Image cdImageOne;
    Image cdImageTwo;
    Image cdImageThree;
    Image cdImage4;
    Image cdImage5;
    float currentTime0;
    float currentTime1;
    float currentTime2;
    float currentTime3;
    float currentTime4;
    float currentTime5;
    bool Shoot = false;
    bool isCude0 = false;
    bool isCude1 = false;
    bool isCude2 = false;
    bool isCude3 = false;
    bool isCude4 = false;
    bool isCude5 = false;
    int ShootDirec = 0;
    float Speed = 5.0f;
    float AttackCD = 1.0f;

    public bool music1=false;
    public bool music2=false;
    public bool music3=false;
    void Start()
    {
        //skill1 = GameObject.Find ("Skill1");
        skill1 = Resources.Load("SkillOne") as GameObject;
        JianL = Resources.Load("XingYuJianL") as GameObject;
        JianR = Resources.Load("XingYuJianR") as GameObject;
        SkillTwoL = Resources.Load("XingYuSkillTwoL") as GameObject;
        SkillTwoR = Resources.Load("XingYuSkillTwoR") as GameObject;
        SkillThreeL = Resources.Load("XingYuSkillThreeL") as GameObject;
        SkillThreeR = Resources.Load("XingYuSkillThreeR") as GameObject;
        cdImageOne = GameObject.Find("UI/EasyTouchControlsCanvas/SkillOne/cdImage1").GetComponent<Image>();
        cdImageTwo = GameObject.Find("UI/EasyTouchControlsCanvas/SkillTwo/cdImage2").GetComponent<Image>();
        cdImageThree = GameObject.Find("UI/EasyTouchControlsCanvas/SkillThree/cdImage3").GetComponent<Image>();
        cdImage4 = GameObject.Find("UI/EasyTouchControlsCanvas/HpSkill/cdImage4").GetComponent<Image>();
        cdImage5 = GameObject.Find("UI/EasyTouchControlsCanvas/MpSkill/cdImage5").GetComponent<Image>();
        cdTimeOne = GameObject.Find("UI/EasyTouchControlsCanvas/SkillOne/cdText1").GetComponent<Text>();
        cdTimeTwo = GameObject.Find("UI/EasyTouchControlsCanvas/SkillTwo/cdText2").GetComponent<Text>();
        cdTimeThree = GameObject.Find("UI/EasyTouchControlsCanvas/SkillThree/cdText3").GetComponent<Text>();
        cdTime4 = GameObject.Find("UI/EasyTouchControlsCanvas/HpSkill/cdText4").GetComponent<Text>();
        cdTime5 = GameObject.Find("UI/EasyTouchControlsCanvas/MpSkill/cdText5").GetComponent<Text>();
        cdImageOne.gameObject.SetActive(false);
        cdImageTwo.gameObject.SetActive(false);
        cdImageThree.gameObject.SetActive(false);
        cdImage4.gameObject.SetActive(false);
        cdImage5.gameObject.SetActive(false);
        anim = GetComponent<Animator>();



    }
    // Update is called once per frame
    void Update()
    {
        if (ETCInput.GetAxisPressedLeft("Horizontal"))
        {
            ShootDirec = 0;
        }
        if (ETCInput.GetAxisPressedRight("Horizontal"))
        {
            ShootDirec = 1;
        }
        if (ETCInput.GetButton("attackButton") && !isCude0)
        {
            isCude0 = true;
            currentTime0 = Time.time;
            Shoot = true;
        }
        if (Shoot && Time.time - currentTime0 > 0.5f)
        {
            Shoot = false;
            switch (ShootDirec)
            {
                case 0:
                    GameObject CreJianL = Instantiate(JianL, Vector3.zero, Quaternion.identity);
                    CreJianL.transform.position = new Vector3(this.transform.position.x - 1.3f, this.transform.position.y + 0.45f, 0);
                    break;
                case 1:
                    GameObject CreJianR = Instantiate(JianR, Vector3.zero, Quaternion.identity);
                    CreJianR.transform.position = new Vector3(this.transform.position.x + 1.3f, this.transform.position.y + 0.45f, 0);
                    break;
                default:
                    break;
            }
        }
        if (Time.time - currentTime0 > AttackCD)
        {
            isCude0 = false;
        }
        //技能1
        if (ETCInput.GetButton("SkillOne") && !isCude1)
        {
            music1 = true;
            currentTime1 = Time.time;
            isCude1 = true;
            anim.SetBool("Stand", false);
            anim.SetBool("Jump", false);
            anim.SetBool("Walk", false);
            anim.SetBool("StandAttack", false);
            anim.SetBool("HeroDie", false);
            anim.SetBool("Hurt", false);
            anim.SetBool("JumpAttack", false);
            anim.SetBool("SkillOne", true);
        }
        if (Time.time - currentTime1 >= 1.0f)
        {
            anim.SetBool("SkillOne", false);
        }
        if (Time.time - currentTime1 >= cd1)
        {
            isCude1 = false;
            cdTimeOne.text = ("");
            cdImageOne.fillAmount = 1.0f;
            cdImageOne.gameObject.SetActive(false);
        }
        if (isCude1)
        {
            cdImageOne.gameObject.SetActive(true);
            cdImageOne.fillAmount = 1.0f - (Time.time - currentTime1) / cd1;
            cdTimeOne.text = ("" + (int)(cd1 * cdImageOne.fillAmount + 1.0f));
        }
        //技能2
        if (ETCInput.GetButton("SkillTwo") && !isCude2)
        {
            music2 = true;
            currentTime2 = Time.time;
            isCude2 = true;
            switch (ShootDirec)
            {
                case 0:
                    GameObject CreSkillTwoL = Instantiate(SkillTwoL, Vector3.zero, Quaternion.identity);
                    CreSkillTwoL.transform.position = new Vector3(this.transform.position.x - 1.9f, this.transform.position.y + 0.05f, 0);
                    break;
                case 1:
                    GameObject CreSkillTwoR = Instantiate(SkillTwoR, Vector3.zero, Quaternion.identity);
                    CreSkillTwoR.transform.position = new Vector3(this.transform.position.x + 1.9f, this.transform.position.y + 0.05f, 0);
                    break;
                default:
                    break;
            }
        }
        if (Time.time - currentTime2 >= cd2)
        {
            isCude2 = false;
            cdTimeTwo.text = ("");
            cdImageTwo.fillAmount = 1.0f;
            cdImageTwo.gameObject.SetActive(false);
        }
        if (isCude2)
        {
            cdImageTwo.gameObject.SetActive(true);
            cdImageTwo.fillAmount = 1.0f - (Time.time - currentTime2) / cd2;
            cdTimeTwo.text = ("" + (int)(cd2 * cdImageTwo.fillAmount + 1.0f));
        }
        //技能3
        if (ETCInput.GetButton("SkillThree") && !isCude3)
        {
            music3 = true;
            currentTime3 = Time.time;
            isCude3 = true;
            switch (ShootDirec)
            {
                case 0:
                    GameObject CreSkillThreeL = Instantiate(SkillThreeL, Vector3.zero, Quaternion.identity);
                    CreSkillThreeL.transform.position = new Vector3(this.transform.position.x + 0.8f, this.transform.position.y + 0.05f, 0);
                    break;
                case 1:
                    GameObject CreSkillThreeR = Instantiate(SkillThreeR, Vector3.zero, Quaternion.identity);
                    CreSkillThreeR.transform.position = new Vector3(this.transform.position.x - 0.8f, this.transform.position.y + 0.05f, 0);
                    break;
                default:
                    break;
            }
        }
        if (Time.time - currentTime3 >= cd3)
        {
            isCude3 = false;
            cdTimeThree.text = ("");
            cdImageThree.fillAmount = 1.0f;
            cdImageThree.gameObject.SetActive(false);
        }
        if (isCude3)
        {
            cdImageThree.gameObject.SetActive(true);
            cdImageThree.fillAmount = 1.0f - (Time.time - currentTime3) / cd3;
            cdTimeThree.text = ("" + (int)(cd3 * cdImageThree.fillAmount + 1.0f));
        }

        if (ETCInput.GetButton("HpSkill") && !isCude4)
        {
            currentTime4 = Time.time;
            isCude4 = true;

        }
        if (Time.time - currentTime4 >= cd4)
        {
            isCude4 = false;
            cdTime4.text = ("");
            cdImage4.fillAmount = 1.0f;
            cdImage4.gameObject.SetActive(false);
        }
        if (isCude4)
        {
            cdImage4.gameObject.SetActive(true);
            cdImage4.fillAmount = 1.0f - (Time.time - currentTime4) / cd4;
            cdTime4.text = ("" + (int)(cd4 * cdImage4.fillAmount + 1.0f));
        }
        if (ETCInput.GetButton("MpSkill") && !isCude5)
        {
            currentTime5 = Time.time;
            isCude5 = true;
        }
        if (Time.time - currentTime5 >= cd5)
        {
            isCude5 = false;
            cdTime5.text = ("");
            cdImage5.fillAmount = 1.0f;
            cdImage5.gameObject.SetActive(false);
        }
        if (isCude5)
        {
            cdImage5.gameObject.SetActive(true);
            cdImage5.fillAmount = 1.0f - (Time.time - currentTime5) / cd5;
            cdTime5.text = ("" + (int)(cd5 * cdImage5.fillAmount + 1.0f));
        }

    }
}

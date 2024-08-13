using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static PlayerAttributes Instance;
    public PlayerInfors playerBase; // Thông số cơ bản
    public PlayerInfors playerExtra; //Thông số Player khi được nâng cấp chỉ số hay mặc trang bị
    public PlayerInfors playerInfor; // Thông số Player sau khi thay đổi

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            DestroyImmediate(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        setBase();
    }


    void setBase()
    {
        playerBase.level = 1;

        //Hp
        playerBase.hp = 100;
        playerBase.currentHp = playerBase.hp;

        //Mana
        playerBase.mana = 50;
        playerBase.currentMana = playerBase.mana;

        //Exp
        playerBase.curentExp = 0;
        playerBase.requireExp = 100  * Mathf.Pow(playerBase.level, 3);

        //STR - AGI - INT
        playerBase.str = 10;
        playerBase.intel = 20;
        playerBase.agi = 12;

        //ATK
        playerBase.pAtk = 10;
        playerBase.mAtk = 50;

        //DEF
        playerBase.pDef = 10;
        playerBase.mDef = 20;

        //AVOID - CRIT
        playerBase.avoid = 10;
        playerBase.critical = 5;

        //Speed
        playerBase.speedMove = 10;
    }
}

[System.Serializable]
public class PlayerInfors
{
    //Thông số cơ bản
    public int level;
    public float curentExp;
    public float requireExp;

    public int currentHp;
    public int currentMana;
    public int hp;
    public int mana;

    //Thông số kĩ năng
    public int str; //Tăng máu, tăng công vật lý, tăng thủ vật lý
    public int agi; //né tránh, chí mạng, tốc độ
    public int intel; //tăng mana, tăng công phép, tăng thủ phép
    public int pAtk; //physic attack
    public int mAtk; //magic attack
    public int pDef; //physic defence
    public int mDef; //magic defence
    public int avoid; // % né đòn đánh
    public int critical; //% tỉ lệ chí mạng
    public int speedMove;// tốc độ di chuyển

     
}

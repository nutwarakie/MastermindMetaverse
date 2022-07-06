using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BulbControl : MonoBehaviour
{
    /*
    To Change Bulb Status
    Call : [Variablename].L[Row]_[Column] = "[Status]";
        [Row] : 1 , 2 , 3 , 4
        [Column] : 1 , 2 , 3 , 4
        [Status] :  99 = off
                    1  = purple
                    2  = blue
                    3  = green
                    4  = yellow
                    5  = orange
                    6  = red

    Example :
        
        private BulbControl _bulbColor;

        private void Start(){
            _bulbColor = this.GetComponent<BulbControl>();
        }
        private void Update(){
            _bulbColor.L1_1_ColorNumber = 1;
        }

    */

    public int Motor_StatusNumber;
    public string Motor_Status;
    private int Motor_StatusNumber_Previous;

    public int L1_1_ColorNumber;
    public string L1_1;
    private int L1_1_ColorNumber_Previous;

    public int L1_2_ColorNumber;
    public string L1_2;
    private int L1_2_ColorNumber_Previous;

    public int L1_3_ColorNumber;
    public string L1_3;
    private int L1_3_ColorNumber_Previous;

    public int L1_4_ColorNumber;
    public string L1_4;
    private int L1_4_ColorNumber_Previous;

    public int L2_1_ColorNumber;
    public string L2_1;
    private int L2_1_ColorNumber_Previous;

    public int L2_2_ColorNumber;
    public string L2_2;
    private int L2_2_ColorNumber_Previous;

    public int L2_3_ColorNumber;
    public string L2_3;
    private int L2_3_ColorNumber_Previous;

    public int L2_4_ColorNumber;
    public string L2_4;
    private int L2_4_ColorNumber_Previous;

    public int L3_1_ColorNumber;
    public string L3_1;
    private int L3_1_ColorNumber_Previous;

    public int L3_2_ColorNumber;
    public string L3_2;
    private int L3_2_ColorNumber_Previous;

    public int L3_3_ColorNumber;
    public string L3_3;
    private int L3_3_ColorNumber_Previous;

    public int L3_4_ColorNumber;
    public string L3_4;
    private int L3_4_ColorNumber_Previous;

    public enum ColorNumber
    {
        off = 99,
        purple = 1,
        blue = 2,
        green = 3,
        yellow = 4,
        orange = 5,
        red = 6,
    }

    // Motor
    private string Motor_WH_CW = "https://maker.ifttt.com/trigger/Gate_off/json/with/key/eNTu1BN-q-6wyrPt_5r7kijIbrbacWxAkikaYLarNT2";
    private string Motor_WH_CCW = "https://maker.ifttt.com/trigger/Gate_on/json/with/key/eNTu1BN-q-6wyrPt_5r7kijIbrbacWxAkikaYLarNT2";

    // L1_1
    private string L1_1_WH_Off = "http://192.168.1.9:8123/api/webhook/L1_1_Off";
    private string L1_1_WH_Red = "http://192.168.1.9:8123/api/webhook/L1_1_Red";
    private string L1_1_WH_Green = "http://192.168.1.9:8123/api/webhook/L1_1_Green";
    private string L1_1_WH_Blue = "http://192.168.1.9:8123/api/webhook/L1_1_Blue";
    private string L1_1_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L1_1_Yellow";
    private string L1_1_WH_Orange = "http://192.168.1.9:8123/api/webhook/L1_1_Orange";
    private string L1_1_WH_Purple = "http://192.168.1.9:8123/api/webhook/L1_1_Purple";

    // L1_2
    private string L1_2_WH_Off = "http://192.168.1.9:8123/api/webhook/L1_2_Off";
    private string L1_2_WH_Red = "http://192.168.1.9:8123/api/webhook/L1_2_Red";
    private string L1_2_WH_Green = "http://192.168.1.9:8123/api/webhook/L1_2_Green";
    private string L1_2_WH_Blue = "http://192.168.1.9:8123/api/webhook/L1_2_Blue";
    private string L1_2_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L1_2_Yellow";
    private string L1_2_WH_Orange = "http://192.168.1.9:8123/api/webhook/L1_2_Orange";
    private string L1_2_WH_Purple = "http://192.168.1.9:8123/api/webhook/L1_2_Purple";

    // L1_3
    private string L1_3_WH_Off = "http://192.168.1.9:8123/api/webhook/L1_3_Off";
    private string L1_3_WH_Red = "http://192.168.1.9:8123/api/webhook/L1_3_Red";
    private string L1_3_WH_Green = "http://192.168.1.9:8123/api/webhook/L1_3_Green";
    private string L1_3_WH_Blue = "http://192.168.1.9:8123/api/webhook/L1_3_Blue";
    private string L1_3_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L1_3_Yellow";
    private string L1_3_WH_Orange = "http://192.168.1.9:8123/api/webhook/L1_3_Orange";
    private string L1_3_WH_Purple = "http://192.168.1.9:8123/api/webhook/L1_3_Purple";

    // L1_4
    private string L1_4_WH_Off = "http://192.168.1.9:8123/api/webhook/L1_4_Off";
    private string L1_4_WH_Red = "http://192.168.1.9:8123/api/webhook/L1_4_Red";
    private string L1_4_WH_Green = "http://192.168.1.9:8123/api/webhook/L1_4_Green";
    private string L1_4_WH_Blue = "http://192.168.1.9:8123/api/webhook/L1_4_Blue";
    private string L1_4_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L1_4_Yellow";
    private string L1_4_WH_Orange = "http://192.168.1.9:8123/api/webhook/L1_4_Orange";
    private string L1_4_WH_Purple = "http://192.168.1.9:8123/api/webhook/L1_4_Purple";

    // L2_1
    private string L2_1_WH_Off = "http://192.168.1.9:8123/api/webhook/L2_1_Off";
    private string L2_1_WH_Red = "http://192.168.1.9:8123/api/webhook/L2_1_Red";
    private string L2_1_WH_Green = "http://192.168.1.9:8123/api/webhook/L2_1_Green";
    private string L2_1_WH_Blue = "http://192.168.1.9:8123/api/webhook/L2_1_Blue";
    private string L2_1_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L2_1_Yellow";
    private string L2_1_WH_Orange = "http://192.168.1.9:8123/api/webhook/L2_1_Orange";
    private string L2_1_WH_Purple = "http://192.168.1.9:8123/api/webhook/L2_1_Purple";

    // L2_2
    private string L2_2_WH_Off = "http://192.168.1.9:8123/api/webhook/L2_2_Off";
    private string L2_2_WH_Red = "http://192.168.1.9:8123/api/webhook/L2_2_Red";
    private string L2_2_WH_Green = "http://192.168.1.9:8123/api/webhook/L2_2_Green";
    private string L2_2_WH_Blue = "http://192.168.1.9:8123/api/webhook/L2_2_Blue";
    private string L2_2_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L2_2_Yellow";
    private string L2_2_WH_Orange = "http://192.168.1.9:8123/api/webhook/L2_2_Orange";
    private string L2_2_WH_Purple = "http://192.168.1.9:8123/api/webhook/L2_2_Purple";

    // L2_3
    private string L2_3_WH_Off = "http://192.168.1.9:8123/api/webhook/L2_3_Off";
    private string L2_3_WH_Red = "http://192.168.1.9:8123/api/webhook/L2_3_Red";
    private string L2_3_WH_Green = "http://192.168.1.9:8123/api/webhook/L2_3_Green";
    private string L2_3_WH_Blue = "http://192.168.1.9:8123/api/webhook/L2_3_Blue";
    private string L2_3_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L2_3_Yellow";
    private string L2_3_WH_Orange = "http://192.168.1.9:8123/api/webhook/L2_3_Orange";
    private string L2_3_WH_Purple = "http://192.168.1.9:8123/api/webhook/L2_3_Purple";

    // L2_4
    private string L2_4_WH_Off = "http://192.168.1.9:8123/api/webhook/L2_4_Off";
    private string L2_4_WH_Red = "http://192.168.1.9:8123/api/webhook/L2_4_Red";
    private string L2_4_WH_Green = "http://192.168.1.9:8123/api/webhook/L2_4_Green";
    private string L2_4_WH_Blue = "http://192.168.1.9:8123/api/webhook/L2_4_Blue";
    private string L2_4_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L2_4_Yellow";
    private string L2_4_WH_Orange = "http://192.168.1.9:8123/api/webhook/L2_4_Orange";
    private string L2_4_WH_Purple = "http://192.168.1.9:8123/api/webhook/L2_4_Purple";

    // L3_1
    private string L3_1_WH_Off = "http://192.168.1.9:8123/api/webhook/L3_1_Off";
    private string L3_1_WH_Red = "http://192.168.1.9:8123/api/webhook/L3_1_Red";
    private string L3_1_WH_Green = "http://192.168.1.9:8123/api/webhook/L3_1_Green";
    private string L3_1_WH_Blue = "http://192.168.1.9:8123/api/webhook/L3_1_Blue";
    private string L3_1_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L3_1_Yellow";
    private string L3_1_WH_Orange = "http://192.168.1.9:8123/api/webhook/L3_1_Orange";
    private string L3_1_WH_Purple = "http://192.168.1.9:8123/api/webhook/L3_1_Purple";

    // L3_2
    private string L3_2_WH_Off = "http://192.168.1.9:8123/api/webhook/L3_2_Off";
    private string L3_2_WH_Red = "http://192.168.1.9:8123/api/webhook/L3_2_Red";
    private string L3_2_WH_Green = "http://192.168.1.9:8123/api/webhook/L3_2_Green";
    private string L3_2_WH_Blue = "http://192.168.1.9:8123/api/webhook/L3_2_Blue";
    private string L3_2_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L3_2_Yellow";
    private string L3_2_WH_Orange = "http://192.168.1.9:8123/api/webhook/L3_2_Orange";
    private string L3_2_WH_Purple = "http://192.168.1.9:8123/api/webhook/L3_2_Purple";

    // L3_3
    private string L3_3_WH_Off = "http://192.168.1.9:8123/api/webhook/L3_3_Off";
    private string L3_3_WH_Red = "http://192.168.1.9:8123/api/webhook/L3_3_Red";
    private string L3_3_WH_Green = "http://192.168.1.9:8123/api/webhook/L3_3_Green";
    private string L3_3_WH_Blue = "http://192.168.1.9:8123/api/webhook/L3_3_Blue";
    private string L3_3_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L3_3_Yellow";
    private string L3_3_WH_Orange = "http://192.168.1.9:8123/api/webhook/L3_3_Orange";
    private string L3_3_WH_Purple = "http://192.168.1.9:8123/api/webhook/L3_3_Purple";

    // L3_4
    private string L3_4_WH_Off = "http://192.168.1.9:8123/api/webhook/L3_4_Off";
    private string L3_4_WH_Red = "http://192.168.1.9:8123/api/webhook/L3_4_Red";
    private string L3_4_WH_Green = "http://192.168.1.9:8123/api/webhook/L3_4_Green";
    private string L3_4_WH_Blue = "http://192.168.1.9:8123/api/webhook/L3_4_Blue";
    private string L3_4_WH_Yellow = "http://192.168.1.9:8123/api/webhook/L3_4_Yellow";
    private string L3_4_WH_Orange = "http://192.168.1.9:8123/api/webhook/L3_4_Orange";
    private string L3_4_WH_Purple = "http://192.168.1.9:8123/api/webhook/L3_4_Purple";

    void Start(){

        L1_1_ColorNumber = 99;
        L1_2_ColorNumber = 99;
        L1_3_ColorNumber = 99;
        L1_4_ColorNumber = 99;

        L2_1_ColorNumber = 99;
        L2_2_ColorNumber = 99;
        L2_3_ColorNumber = 99;
        L2_4_ColorNumber = 99;

        L3_1_ColorNumber = 99;
        L3_2_ColorNumber = 99;
        L3_3_ColorNumber = 99;
        L3_4_ColorNumber = 99;

    }

    void Update(){
        if (Motor_StatusNumber != Motor_StatusNumber_Previous)
        {
            Motor_ChangeStatus();
            Motor_StatusNumber_Previous = Motor_StatusNumber;
        }
        if (L1_1_ColorNumber != L1_1_ColorNumber_Previous){
            L1_1_ChangeColor();
            L1_1_ColorNumber_Previous = L1_1_ColorNumber;
        }
        if (L1_2_ColorNumber != L1_2_ColorNumber_Previous){
            L1_2_ChangeColor();
            L1_2_ColorNumber_Previous = L1_2_ColorNumber;
        }
        if (L1_3_ColorNumber != L1_3_ColorNumber_Previous){
            L1_3_ChangeColor();
            L1_3_ColorNumber_Previous = L1_3_ColorNumber;
        }
        if (L1_4_ColorNumber != L1_4_ColorNumber_Previous){
            L1_4_ChangeColor();
            L1_4_ColorNumber_Previous = L1_4_ColorNumber;
        }
        if (L2_1_ColorNumber != L2_1_ColorNumber_Previous){
            L2_1_ChangeColor();
            L2_1_ColorNumber_Previous = L2_1_ColorNumber;
        }
        if (L2_2_ColorNumber != L2_2_ColorNumber_Previous){
            L2_2_ChangeColor();
            L2_2_ColorNumber_Previous = L2_2_ColorNumber;
        }
        if (L2_3_ColorNumber != L2_3_ColorNumber_Previous){
            L2_3_ChangeColor();
            L2_3_ColorNumber_Previous = L2_3_ColorNumber;
        }
        if (L2_4_ColorNumber != L2_4_ColorNumber_Previous){
            L2_4_ChangeColor();
            L2_4_ColorNumber_Previous = L2_4_ColorNumber;
        }
        if (L3_1_ColorNumber != L3_1_ColorNumber_Previous){
            L3_1_ChangeColor();
            L3_1_ColorNumber_Previous = L3_1_ColorNumber;
        }
        if (L3_2_ColorNumber != L3_2_ColorNumber_Previous){
            L3_2_ChangeColor();
            L3_2_ColorNumber_Previous = L3_2_ColorNumber;
        }
        if (L3_3_ColorNumber != L3_3_ColorNumber_Previous){
            L3_3_ChangeColor();
            L3_3_ColorNumber_Previous = L3_3_ColorNumber;
        }
        if (L3_4_ColorNumber != L3_4_ColorNumber_Previous){
            L3_4_ChangeColor();
            L3_4_ColorNumber_Previous = L3_4_ColorNumber;
        }
            
    }

    private void Motor_ChangeStatus()
    {
        switch (Motor_StatusNumber)
        {
            case 1:
                StartCoroutine(Motor_ChangeToCW());
                Motor_Status = "Clock Wise";
                break;
            case 2:
                StartCoroutine(Motor_ChangeToCCW());
                Motor_Status = "Counter Clock Wise";
                break;

            default:
                break;
        }
    }

    private void L1_1_ChangeColor(){
        switch (L1_1_ColorNumber)
        {
            case 99:
                StartCoroutine(L1_1_ChangeToOff());
                L1_1 = "Off";
                break;
            case 1:
                StartCoroutine(L1_1_ChangeToPurple());
                L1_1 = "Purple";
                break;
            case 2:
                StartCoroutine(L1_1_ChangeToBlue());
                L1_1 = "Blue";
                break;
            case 3:
                StartCoroutine(L1_1_ChangeToGreen());
                L1_1 = "Green";
                break;
            case 4:
                StartCoroutine(L1_1_ChangeToYellow());
                L1_1 = "Yellow";
                break;
            case 5:
                StartCoroutine(L1_1_ChangeToOrange());
                L1_1 = "Orange";
                break;
            case 6:
                StartCoroutine(L1_1_ChangeToRed());
                L1_1 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L1_2_ChangeColor(){
        switch (L1_2_ColorNumber)
        {
            case 99:
                StartCoroutine(L1_2_ChangeToOff());
                L1_2 = "Off";
                break;
            case 1:
                StartCoroutine(L1_2_ChangeToPurple());
                L1_2 = "Purple";
                break;
            case 2:
                StartCoroutine(L1_2_ChangeToBlue());
                L1_2 = "Blue";
                break;
            case 3:
                StartCoroutine(L1_2_ChangeToGreen());
                L1_2 = "Green";
                break;
            case 4:
                StartCoroutine(L1_2_ChangeToYellow());
                L1_2 = "Yellow";
                break;
            case 5:
                StartCoroutine(L1_2_ChangeToOrange());
                L1_2 = "Orange";
                break;
            case 6:
                StartCoroutine(L1_2_ChangeToRed());
                L1_2 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L1_3_ChangeColor(){
        switch (L1_3_ColorNumber)
        {
            case 99:
                StartCoroutine(L1_3_ChangeToOff());
                L1_3 = "Off";
                break;
            case 1:
                StartCoroutine(L1_3_ChangeToPurple());
                L1_3 = "Purple";
                break;
            case 2:
                StartCoroutine(L1_3_ChangeToBlue());
                L1_3 = "Blue";
                break;
            case 3:
                StartCoroutine(L1_3_ChangeToGreen());
                L1_3 = "Green";
                break;
            case 4:
                StartCoroutine(L1_3_ChangeToYellow());
                L1_3 = "Yellow";
                break;
            case 5:
                StartCoroutine(L1_3_ChangeToOrange());
                L1_3 = "Orange";
                break;
            case 6:
                StartCoroutine(L1_3_ChangeToRed());
                L1_3 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L1_4_ChangeColor(){
        switch (L1_4_ColorNumber)
        {
            case 99:
                StartCoroutine(L1_4_ChangeToOff());
                L1_4 = "Off";
                break;
            case 1:
                StartCoroutine(L1_4_ChangeToPurple());
                L1_4 = "Purple";
                break;
            case 2:
                StartCoroutine(L1_4_ChangeToBlue());
                L1_4 = "Blue";
                break;
            case 3:
                StartCoroutine(L1_4_ChangeToGreen());
                L1_4 = "Green";
                break;
            case 4:
                StartCoroutine(L1_4_ChangeToYellow());
                L1_4 = "Yellow";
                break;
            case 5:
                StartCoroutine(L1_4_ChangeToOrange());
                L1_4 = "Orange";
                break;
            case 6:
                StartCoroutine(L1_4_ChangeToRed());
                L1_4 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L2_1_ChangeColor(){
        switch (L2_1_ColorNumber)
        {
            case 99:
                StartCoroutine(L2_1_ChangeToOff());
                L2_1 = "Off";
                break;
            case 1:
                StartCoroutine(L2_1_ChangeToPurple());
                L2_1 = "Purple";
                break;
            case 2:
                StartCoroutine(L2_1_ChangeToBlue());
                L2_1 = "Blue";
                break;
            case 3:
                StartCoroutine(L2_1_ChangeToGreen());
                L2_1 = "Green";
                break;
            case 4:
                StartCoroutine(L2_1_ChangeToYellow());
                L2_1 = "Yellow";
                break;
            case 5:
                StartCoroutine(L2_1_ChangeToOrange());
                L2_1 = "Orange";
                break;
            case 6:
                StartCoroutine(L2_1_ChangeToRed());
                L2_1 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L2_2_ChangeColor(){
        switch (L2_2_ColorNumber)
        {
            case 99:
                StartCoroutine(L2_2_ChangeToOff());
                L2_2 = "Off";
                break;
            case 1:
                StartCoroutine(L2_2_ChangeToPurple());
                L2_2 = "Purple";
                break;
            case 2:
                StartCoroutine(L2_2_ChangeToBlue());
                L2_2 = "Blue";
                break;
            case 3:
                StartCoroutine(L2_2_ChangeToGreen());
                L2_2 = "Green";
                break;
            case 4:
                StartCoroutine(L2_2_ChangeToYellow());
                L2_2 = "Yellow";
                break;
            case 5:
                StartCoroutine(L2_2_ChangeToOrange());
                L2_2 = "Orange";
                break;
            case 6:
                StartCoroutine(L2_2_ChangeToRed());
                L2_2 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L2_3_ChangeColor(){
        switch (L2_3_ColorNumber)
        {
            case 99:
                StartCoroutine(L2_3_ChangeToOff());
                L2_3 = "Off";
                break;
            case 1:
                StartCoroutine(L2_3_ChangeToPurple());
                L2_3 = "Purple";
                break;
            case 2:
                StartCoroutine(L2_3_ChangeToBlue());
                L2_3 = "Blue";
                break;
            case 3:
                StartCoroutine(L2_3_ChangeToGreen());
                L2_3 = "Green";
                break;
            case 4:
                StartCoroutine(L2_3_ChangeToYellow());
                L2_3 = "Yellow";
                break;
            case 5:
                StartCoroutine(L2_3_ChangeToOrange());
                L2_3 = "Orange";
                break;
            case 6:
                StartCoroutine(L2_3_ChangeToRed());
                L2_3 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L2_4_ChangeColor(){
        switch (L2_4_ColorNumber)
        {
            case 99:
                StartCoroutine(L2_4_ChangeToOff());
                L2_4 = "Off";
                break;
            case 1:
                StartCoroutine(L2_4_ChangeToPurple());
                L2_4 = "Purple";
                break;
            case 2:
                StartCoroutine(L2_4_ChangeToBlue());
                L2_4 = "Blue";
                break;
            case 3:
                StartCoroutine(L2_4_ChangeToGreen());
                L2_4 = "Green";
                break;
            case 4:
                StartCoroutine(L2_4_ChangeToYellow());
                L2_4 = "Yellow";
                break;
            case 5:
                StartCoroutine(L2_4_ChangeToOrange());
                L2_4 = "Orange";
                break;
            case 6:
                StartCoroutine(L2_4_ChangeToRed());
                L2_4 = "Red";
                break;
            
            default:
                break;
        }
    }
    //
    private void L3_1_ChangeColor(){
        switch (L3_1_ColorNumber)
        {
            case 99:
                StartCoroutine(L3_1_ChangeToOff());
                L3_1 = "Off";
                break;
            case 1:
                StartCoroutine(L3_1_ChangeToPurple());
                L3_1 = "Purple";
                break;
            case 2:
                StartCoroutine(L3_1_ChangeToBlue());
                L3_1 = "Blue";
                break;
            case 3:
                StartCoroutine(L3_1_ChangeToGreen());
                L3_1 = "Green";
                break;
            case 4:
                StartCoroutine(L3_1_ChangeToYellow());
                L3_1 = "Yellow";
                break;
            case 5:
                StartCoroutine(L3_1_ChangeToOrange());
                L3_1 = "Orange";
                break;
            case 6:
                StartCoroutine(L3_1_ChangeToRed());
                L3_1 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L3_2_ChangeColor(){
        switch (L3_2_ColorNumber)
        {
            case 99:
                StartCoroutine(L3_2_ChangeToOff());
                L3_2 = "Off";
                break;
            case 1:
                StartCoroutine(L3_2_ChangeToPurple());
                L3_2 = "Purple";
                break;
            case 2:
                StartCoroutine(L3_2_ChangeToBlue());
                L3_2 = "Blue";
                break;
            case 3:
                StartCoroutine(L3_2_ChangeToGreen());
                L3_2 = "Green";
                break;
            case 4:
                StartCoroutine(L3_2_ChangeToYellow());
                L3_2 = "Yellow";
                break;
            case 5:
                StartCoroutine(L3_2_ChangeToOrange());
                L3_2 = "Orange";
                break;
            case 6:
                StartCoroutine(L3_2_ChangeToRed());
                L3_2 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L3_3_ChangeColor(){
        switch (L3_3_ColorNumber)
        {
            case 99:
                StartCoroutine(L3_3_ChangeToOff());
                L3_3 = "Off";
                break;
            case 1:
                StartCoroutine(L3_3_ChangeToPurple());
                L3_3 = "Purple";
                break;
            case 2:
                StartCoroutine(L3_3_ChangeToBlue());
                L3_3 = "Blue";
                break;
            case 3:
                StartCoroutine(L3_3_ChangeToGreen());
                L3_3 = "Green";
                break;
            case 4:
                StartCoroutine(L3_3_ChangeToYellow());
                L3_3 = "Yellow";
                break;
            case 5:
                StartCoroutine(L3_3_ChangeToOrange());
                L3_3 = "Orange";
                break;
            case 6:
                StartCoroutine(L3_3_ChangeToRed());
                L3_3 = "Red";
                break;
            
            default:
                break;
        }
    }

    private void L3_4_ChangeColor(){
        switch (L3_4_ColorNumber)
        {
            case 99:
                StartCoroutine(L3_4_ChangeToOff());
                L3_4 = "Off";
                break;
            case 1:
                StartCoroutine(L3_4_ChangeToPurple());
                L3_4 = "Purple";
                break;
            case 2:
                StartCoroutine(L3_4_ChangeToBlue());
                L3_4 = "Blue";
                break;
            case 3:
                StartCoroutine(L3_4_ChangeToGreen());
                L3_4 = "Green";
                break;
            case 4:
                StartCoroutine(L3_4_ChangeToYellow());
                L3_4 = "Yellow";
                break;
            case 5:
                StartCoroutine(L3_4_ChangeToOrange());
                L3_4 = "Orange";
                break;
            case 6:
                StartCoroutine(L3_4_ChangeToRed());
                L3_4 = "Red";
                break;
            
            default:
                break;
        }
    }

    IEnumerator Motor_ChangeToCW()
    {
        WWWForm form = new WWWForm();

        string URL = Motor_WH_CW;
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("Motor CW");
    }

    IEnumerator Motor_ChangeToCCW()
    {
        WWWForm form = new WWWForm();

        string URL = Motor_WH_CCW;
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("Motor CCW");
    }

    IEnumerator L1_1_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Off");
    }

    IEnumerator L1_1_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Red");
    }

    IEnumerator L1_1_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Green");
    }

    IEnumerator L1_1_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Blue");
    }

    IEnumerator L1_1_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Yellow");
    }

    IEnumerator L1_1_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Orange");
    }

    IEnumerator L1_1_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_1_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_1 Purple");
    }

    IEnumerator L1_2_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Off");
    }

    IEnumerator L1_2_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Red");
    }

    IEnumerator L1_2_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Green");
    }

    IEnumerator L1_2_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Blue");
    }

    IEnumerator L1_2_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Yellow");
    }

    IEnumerator L1_2_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Orange");
    }

    IEnumerator L1_2_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_2_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_2 Purple");
    }

    IEnumerator L1_3_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Off");
    }

    IEnumerator L1_3_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Red");
    }

    IEnumerator L1_3_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Green");
    }
    
    IEnumerator L1_3_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Blue");
    }

    IEnumerator L1_3_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Yellow");
    }

    IEnumerator L1_3_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Orange");
    }

    IEnumerator L1_3_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_3_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_3 Purple");
    }

    IEnumerator L1_4_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Off");
    }

    IEnumerator L1_4_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Red");
    }

    IEnumerator L1_4_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Green");
    }

    IEnumerator L1_4_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Blue");
    }

    IEnumerator L1_4_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Yellow");
    }

    IEnumerator L1_4_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Orange");
    }

    IEnumerator L1_4_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L1_4_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L1_4 Purple");
    }
    //
    IEnumerator L2_1_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Off");
    }
    
    IEnumerator L2_1_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Red");
    }

    IEnumerator L2_1_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Green");
    }

    IEnumerator L2_1_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Blue");
    }

    IEnumerator L2_1_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Yellow");
    }

    IEnumerator L2_1_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Orange");
    }

    IEnumerator L2_1_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_1_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_1 Purple");
    }
    //
    IEnumerator L2_2_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Off");
    }
    
    IEnumerator L2_2_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Red");
    }

    IEnumerator L2_2_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Green");
    }

    IEnumerator L2_2_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Blue");
    }

    IEnumerator L2_2_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Yellow");
    }

    IEnumerator L2_2_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Orange");
    }

    IEnumerator L2_2_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_2_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_2 Purple");
    }
    //
    IEnumerator L2_3_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Off");
    }
    
    IEnumerator L2_3_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Red");
    }

    IEnumerator L2_3_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Green");
    }

    IEnumerator L2_3_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Blue");
    }

    IEnumerator L2_3_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Yellow");
    }

    IEnumerator L2_3_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Orange");
    }

    IEnumerator L2_3_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_3_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_3 Purple");
    }
    //
    
    //
    IEnumerator L2_4_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Off");
    }
    
    IEnumerator L2_4_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Red");
    }

    IEnumerator L2_4_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Green");
    }

    IEnumerator L2_4_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Blue");
    }

    IEnumerator L2_4_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Yellow");
    }

    IEnumerator L2_4_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Orange");
    }

    IEnumerator L2_4_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L2_4_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L2_4 Purple");
    }
    //
    //
    IEnumerator L3_1_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Off");
    }
    
    IEnumerator L3_1_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Red");
    }

    IEnumerator L3_1_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Green");
    }

    IEnumerator L3_1_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Blue");
    }

    IEnumerator L3_1_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Yellow");
    }

    IEnumerator L3_1_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Orange");
    }

    IEnumerator L3_1_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_1_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_1 Purple");
    }
    //
    IEnumerator L3_2_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Off");
    }
    
    IEnumerator L3_2_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Red");
    }

    IEnumerator L3_2_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Green");
    }

    IEnumerator L3_2_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Blue");
    }

    IEnumerator L3_2_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Yellow");
    }

    IEnumerator L3_2_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Orange");
    }

    IEnumerator L3_2_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_2_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_2 Purple");
    }
    //
    IEnumerator L3_3_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Off");
    }
    
    IEnumerator L3_3_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Red");
    }

    IEnumerator L3_3_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Green");
    }

    IEnumerator L3_3_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Blue");
    }

    IEnumerator L3_3_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Yellow");
    }

    IEnumerator L3_3_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Orange");
    }

    IEnumerator L3_3_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_3_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_3 Purple");
    }
    //
    
    //
    IEnumerator L3_4_ChangeToOff(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Off;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Off");
    }
    
    IEnumerator L3_4_ChangeToRed(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Red;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Red");
    }

    IEnumerator L3_4_ChangeToGreen(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Green;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Green");
    }

    IEnumerator L3_4_ChangeToBlue(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Blue;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Blue");
    }

    IEnumerator L3_4_ChangeToYellow(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Yellow;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Yellow");
    }

    IEnumerator L3_4_ChangeToOrange(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Orange;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Orange");
    }

    IEnumerator L3_4_ChangeToPurple(){
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        string URL = L3_4_WH_Purple;
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }

        Debug.Log("L3_4 Purple");
    }
    //
}
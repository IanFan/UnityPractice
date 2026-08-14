using UnityEngine;

public class VariableTypes : MonoBehaviour
{ 
    // bool：布林值
    // 只有兩種狀態：true / false
    private bool b = true;

    // int：32-bit 有號整數
    // 範圍：-2,147,483,648 ~ 2,147,483,647
    // Unity 遊戲中最常用的整數型別：血量、分數、數量
    private int i = 10;

    // short：16-bit 有號整數
    // 範圍：-32,768 ~ 32,767
    // 比 int 小，較少使用
    private short s = 1;

    // long：64-bit 有號整數
    // 範圍：-9,223,372,036,854,775,808
    //      ~ 9,223,372,036,854,775,807
    // 超大型整數使用，需要加 L 後綴
    private long l = 100L;

    // double：64-bit 雙精度浮點數
    // 範圍：約 ±5.0 × 10^-324 ~ ±1.7 × 10^308
    // 精度比 float 高
    private double d = 1000000;

    // float：32-bit 單精度浮點數
    // 範圍：約 ±1.5 × 10^-45 ~ ±3.4 × 10^38
    // Unity Vector3、Transform 座標通常使用 float：位置、速度、時間
    // 數字後需要加 f
    private float f = 1.5f;

    // decimal：128-bit 高精度十進位數
    // 範圍：約 ±1.0 × 10^-28 ~ ±7.9 × 10^28
    // 常用於金融、精確小數計算
    // 數字後需要加 m
    private decimal m = 0.0001m;

    // char：單一 Unicode 字元
    // 範圍：Unicode U+0000 ~ U+FFFF
    // 使用單引號 ''
    private char c = '0';

    // string：字串
    // 可以存放多個 char
    // 最大長度約 2GB（受記憶體限制）
    // 使用雙引號 ""
    private string str = "my string";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(b);
        Debug.Log(i);
        Debug.Log(s);
        Debug.Log(l);
        Debug.Log(d);
        Debug.Log(f);
        Debug.Log(m);
        Debug.Log(c);
        Debug.Log(str);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
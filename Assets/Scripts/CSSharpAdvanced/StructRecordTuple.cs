using UnityEngine;

public class StructRecordTuple : MonoBehaviour
{
    MyStruct myStruct;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myStruct = new MyStruct();
        myStruct.Name = "Test1";
        Debug.Log(myStruct.Name);
        
        MyStruct myStruct2 = myStruct;
        myStruct2.Name = "Test2";
        Debug.Log(myStruct2.Name);
        
        MyRecord myRecord1 = new MyRecord();
        myRecord1.Name = "Test";
        myRecord1.Level = 1;
        MyRecord myRecord2 = new MyRecord();
        myRecord2.Name = "Test";
        myRecord2.Level = 1;
        Debug.Log(myRecord1 == myRecord2);

        MyRecord myRecord3 = myRecord1;
        myRecord3.Name = "Test3";
        Debug.Log(myRecord1.Name);
        Debug.Log(myRecord3.Name);
        
        var result = GetPLayerInfo();
        Debug.Log($"hp: {result.hp}, mp: {result.mp}");
    }
    
    (int hp, int mp) GetPLayerInfo()
    {
        return (100, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct MyStruct
{
    public string Name;
}

public record MyRecord
{
    public string Name;
    public int Level;
}
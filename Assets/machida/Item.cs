using System;

[Serializable]//inspectorで表示できるようにする
public class Item
{
    //アイテムの種類
    public enum Type
    {
        key,
        Cube,
        Circle,
        //アイテムを追加する場合ここに書き足す
    }
    public Type type;

    public Item(Item item) 
    {
        this.type = item.type;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Maze1 = 0,
    Maze2,
    Maze3,
    Park,
    Home,
}

[System.Serializable]
public class ItemData
{
    public string m_Name;
    public ItemType m_ItemType;
    public Texture2D m_DisplayImage;
    public string m_Description;
    public bool m_HasGotten;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Item Data", order = 1)]
public class Item : ScriptableObject
{
    public string _name;
    public ItemData m_ItemData;
}

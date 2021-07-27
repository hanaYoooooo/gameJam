using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Maze1 = 0,
    Maze2,
    Maze3,
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
    public ItemData m_ItemData;
}

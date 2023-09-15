using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public int MaxStats;
    public int CurrentStats = 1;

    public void Upgrade()
    {
        if (CurrentStats++ > MaxStats)
            return;
            
        CurrentStats++;
    }
}

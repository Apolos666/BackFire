using UnityEngine;

public static class Helper 
{
    public static string GetSelectedMap(int indexOfCurrentMap)
    {
        string mapSelectedName = "";
        
        switch (indexOfCurrentMap)
        {
            case 0:
                mapSelectedName = "Endless Scene";
                break;
            case 1:
                mapSelectedName = "Untitled Scene";
                break;
            default :
                Debug.LogError("Khong co scene thoa man");
                break;
        }

        return mapSelectedName;
    }
}

using UnityEngine;

public enum PassengerColor
{
    Red,
    Green,
    Blue,
    Purple,
    Cyan,
}

public static class ColorUtility
{
    public static Color GetColorFromType(PassengerColor type, int shiftColor = 0)
    {
        if (shiftColor != 0)
        {
            int colorCount = System.Enum.GetValues(typeof(PassengerColor)).Length;
            int newIndex = ((int)type + shiftColor) % colorCount;
            if (newIndex < 0)
                newIndex += colorCount;
            type = (PassengerColor)newIndex;
        }
        return type switch
        {
            PassengerColor.Red => new Color(1f, 0.2f, 0.2f),
            PassengerColor.Green => new Color(0.2f, 1f, 0.2f),
            PassengerColor.Blue => new Color(0.2f, 0.2f, 1f),
            PassengerColor.Purple => new Color(0.8f, 0.2f, 0.8f),
            PassengerColor.Cyan => new Color(0.2f, 0.8f, 0.8f),
            _ => Color.white
        };
    }
}

public enum GameState
{
    Playing,
    Failed,
    Won,
    Paused
}


[System.Serializable]
public class LevelData
{
    public int levelNumber;
    public SerializableVector2Int gridSize = new SerializableVector2Int(4,4);
    public Vector2Int[] invalidCells;
    public PassengerData[] passengers;
    public TunnelData[] tunnels;
    public ShipData[] busSequence;
    public float timeLimit = 30f;
    public int benchSlots = 5;
}

[System.Serializable]
public struct SerializableVector2Int
{
    public int x;
    public int y;

    public SerializableVector2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2Int ToVector2Int()
    {
        return new Vector2Int(x, y);
    }

    public static SerializableVector2Int FromVector2Int(Vector2Int v)
    {
        return new SerializableVector2Int(v.x, v.y);
    }
}

[System.Serializable]
public class PassengerData
{
    public int x;
    public int y;
    public PassengerColor color;
    public bool isHidden = false;
}

[System.Serializable]
public class TunnelData
{
    public int x;
    public int y;
    public int orientation;
    public TunnelPassenger[] passengers = null;
}

[System.Serializable]
public class TunnelPassenger
{
    public PassengerColor color;
}


[System.Serializable]
public class ShipData
{
    public PassengerColor color;
    public int arrivalOrder;
    public int capacity = 3;
}


//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/

using UnityEngine;

public class BenchSlot : MonoBehaviour
{
    private int slotId = -1;
    private bool isOccupied = false;
    private bool isFull = false;
    private Passenger passenger = null;

    public int SlotId => slotId;
    public bool IsFull => isFull;
    public bool IsOccupied => isOccupied;
    public Passenger Passenger => passenger;

    public void Initialize(int id)
    {
        slotId = id;
    }

    public void AssignPassenger(Passenger newPassenger)
    {
        passenger = newPassenger;
        isOccupied = true;
    }

    public void PassengerArrived(Passenger newPassenger)
    {
        isFull = true;
    }

    public void ClearSlot()
    {
        if (passenger != null)
        {
            passenger = null;
        }
        isOccupied = false;
        isFull = false;
    }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasingManager : MonoBehaviour
{
   public void OnPressDown(int i)
   {
      switch (i)
      {
         case 1:
            GameDataManager.Instance.playerData.AddDiamond(100);
             IAPManager.Instance.BuyProductID(IAPKey.PACK1);
            break;
         case 2:
            GameDataManager.Instance.playerData.AddDiamond(200);
            IAPManager.Instance.BuyProductID(IAPKey.PACK2);
            break;
         case 3:
            GameDataManager.Instance.playerData.AddDiamond(650);
            IAPManager.Instance.BuyProductID(IAPKey.PACK3);
            break;
         case 4:
            GameDataManager.Instance.playerData.AddDiamond(1000);
            IAPManager.Instance.BuyProductID(IAPKey.PACK4);
            break;
      }
   }

   public void Sub(int i)
   {
      GameDataManager.Instance.playerData.SubDiamond(i);
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

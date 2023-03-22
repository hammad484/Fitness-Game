
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    #region Instance
 
    private static ShopController _instance;

    public static ShopController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ShopController>();
            }

            return _instance;
        }
    }
 
    #endregion

  
    public TextMeshProUGUI Gold1Ad;
    public TextMeshProUGUI Gold2Ad;
    public TextMeshProUGUI Gold3Ad;
    public TextMeshProUGUI Gold4Ad;
    public TextMeshProUGUI Gold5Ad;
    public TextMeshProUGUI Gold6Ad;
    public int maxGold1Ad;
    public int maxGold2Ad;
    public int maxGold3Ad;
    public int maxGold4Ad;
    public int maxGold5Ad;
    public int maxGold6Ad;
    public Scrollbar _Shopslider;
    private SharedMenuController _sharedMenuController;
    
    private void Awake()
    {
        _instance = this;
  
    }

    public void Start()
    {
        _sharedMenuController= SharedMenuController.instance;
        
       
//        Gold1Ad.text = DataController.instance.getPref(RewardTriggers.Gold1.ToString()) + "/" + maxGold1Ad; 
//        Gold2Ad.text = DataController.instance.getPref(RewardTriggers.Gold2.ToString()) + "/" + maxGold2Ad; 
//        Gold3Ad.text = DataController.instance.getPref(RewardTriggers.Gold3.ToString()) + "/" + maxGold3Ad; 
//        Gold4Ad.text = DataController.instance.getPref(RewardTriggers.Gold4.ToString()) + "/" + maxGold4Ad; 
//        Gold5Ad.text = DataController.instance.getPref(RewardTriggers.Gold5.ToString()) + "/" + maxGold5Ad; 
//        Gold6Ad.text = DataController.instance.getPref(RewardTriggers.Gold6.ToString()) + "/" + maxGold6Ad; 
        
    }

    public void AddCoin(int amount)
    {
        _sharedMenuController.AddCoin(amount);
    }

    public void setShopSlider(float value)
    {

        _Shopslider.value = value;
    }

    public void BuyCash1()
    {
     //   InAppHandler.Instance.BuyCash1();
        
    }
    public void BuyCash2()
    {
    //    InAppHandler.Instance.BuyCash2();
    }
    public void BuyCash3()
    {
    //    InAppHandler.Instance.BuyCash3();
        
    }
    public void BuyCash4()
    {
   //     InAppHandler.Instance.BuyCash4();
        
    }  public void BuyCash5()
    {
      //  InAppHandler.Instance.BuyCash5();
        
    }  public void BuyCash6()
    {
       // InAppHandler.Instance.BuyCash6();
        
    }
    public void Gold1AdWatched()
    {
//        if (DataController.instance.getPref(RewardTriggers.Gold1.ToString()) <
//            maxGold1Ad-1)
//        {
//            DataController.instance.setPref(RewardTriggers.Gold1.ToString(),
//                DataController.instance.getPref(RewardTriggers.Gold1.ToString()) + 1);
//            Gold1Ad.text = DataController.instance.getPref(RewardTriggers.Gold1.ToString()) + "/" + maxGold1Ad; 
//
//            
//        }
//        else
//        {
//            Gold1Ad.text = "0/" + maxGold1Ad;
//            DataController.instance.setPref(RewardTriggers.Gold1.ToString(), 0);
//            DataController.instance.AddCoins(550);
//        }
    } 
    public void Gold2AdWatched()
    {
//        if (DataController.instance.getPref(RewardTriggers.Gold2.ToString()) <
//            maxGold2Ad-1)
//        {
//            DataController.instance.setPref(RewardTriggers.Gold2.ToString(),
//                DataController.instance.getPref(RewardTriggers.Gold2.ToString()) + 1);
//            Gold2Ad.text = DataController.instance.getPref(RewardTriggers.Gold2.ToString()) + "/" + maxGold2Ad; 
//
//        }
//        else
//        {
//            
//            Gold2Ad.text = "0/" + maxGold2Ad;
//            DataController.instance.setPref(RewardTriggers.Gold2.ToString(), 0);
//            DataController.instance.AddCoins(1100);
//        }
    } 
    public void Gold3AdWatched()
    {
//        if (DataController.instance.getPref(RewardTriggers.Gold3.ToString()) <
//            maxGold3Ad-1)
//        {
//            DataController.instance.setPref(RewardTriggers.Gold3.ToString(),
//                DataController.instance.getPref(RewardTriggers.Gold3.ToString()) + 1);
//            Gold3Ad.text = DataController.instance.getPref(RewardTriggers.Gold3.ToString()) + "/" + maxGold3Ad; 
//
//        }
//        else
//        {
//            Gold3Ad.text = "0/" + maxGold3Ad;
//            DataController.instance.setPref(RewardTriggers.Gold3.ToString(), 0);
//            DataController.instance.AddCoins(1650);
//        }
    } 
    public void Gold4AdWatched()
    {
//        if (DataController.instance.getPref(RewardTriggers.Gold4.ToString()) < maxGold4Ad-1)
//        {
//            DataController.instance.setPref(RewardTriggers.Gold4.ToString(),DataController.instance.getPref(RewardTriggers.Gold4.ToString())+1);
//            Gold4Ad.text = DataController.instance.getPref(RewardTriggers.Gold4.ToString()) + "/" + maxGold4Ad; 
//
//        }
//        else
//        {
//            Gold4Ad.text =  "0/" + maxGold4Ad;
//            DataController.instance.setPref(RewardTriggers.Gold4.ToString(), 0); 
//            DataController.instance.AddCoins(2200);
//        }
    } public void Gold5AdWatched()
    {
//        if (DataController.instance.getPref(RewardTriggers.Gold5.ToString()) < maxGold5Ad-1)
//        {
//            DataController.instance.setPref(RewardTriggers.Gold5.ToString(),DataController.instance.getPref(RewardTriggers.Gold5.ToString())+1);
//            Gold5Ad.text = DataController.instance.getPref(RewardTriggers.Gold5.ToString()) + "/" + maxGold5Ad; 
//
//        }
//        else
//        {
//            Gold5Ad.text =  "0/" + maxGold5Ad;
//            DataController.instance.setPref(RewardTriggers.Gold5.ToString(), 0); 
//            DataController.instance.AddCoins(2700);
//        }
    } public void Gold6AdWatched()
    {
//        if (DataController.instance.getPref(RewardTriggers.Gold6.ToString()) < maxGold6Ad-1)
//        {
//            DataController.instance.setPref(RewardTriggers.Gold6.ToString(),DataController.instance.getPref(RewardTriggers.Gold6.ToString())+1);
//            Gold6Ad.text = DataController.instance.getPref(RewardTriggers.Gold6.ToString()) + "/" + maxGold6Ad; 
//
//        }
//        else
//        {
//            Gold6Ad.text =  "0/" + maxGold6Ad;
//            DataController.instance.setPref(RewardTriggers.Gold6.ToString(), 0); 
//            DataController.instance.AddCoins(3000);
//        }
    }
    
}

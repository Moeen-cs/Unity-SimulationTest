using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject girlImg;

    [SerializeField]
    Text dialogBoxGirlT;


    [SerializeField]
    GameObject shopkeeperImg;

    [SerializeField]
    Text dialogBoxShopT;

    [SerializeField]
    string[] openingMassages;

    int countmassage = 0;

    [SerializeField]
    string[] shopkeeperMassages;

    [SerializeField]
    string[] girlMassages;

    [SerializeField]
    GameObject nextBtn;

    [SerializeField]
    GameObject cancelBtn;

    [SerializeField]
    GameObject girlBtn;


    int cash = 5000;
    [SerializeField]
    Text cashT;

    [System.Serializable]
    public struct ClothStruct
    {
        public int price;
        public Sprite sprite;
    }

    public ClothStruct[] clotheslist;


    [SerializeField]
    SpriteRenderer playerSprite;

    int countCovo=0;

    [SerializeField]
    GameObject Store;
    
    // Start is called before the first frame update
    void Start()
    {
        cashT.text = cash + "";
        showOpeningMsg();
    }
    public void showOpeningMsg()
    {
        nextBtn.SetActive(true);
        cancelBtn.SetActive(true);
        girlBtn.SetActive(false);
        endingNote = false;
        if (countmassage<openingMassages.Length)
        {
            girlImg.SetActive(true);
            dialogBoxGirlT.text = openingMassages[countmassage];
            countmassage++;
        }
        else
        {
            countmassage = 1;
            GoForShoping();
        }
    }
    void GoForShoping()
    {
        nextBtn.SetActive(false);
        cancelBtn.SetActive(false);
        girlBtn.SetActive(true);
        girlImg.SetActive(false);
        this.gameObject.GetComponent<PlayerMovement>().MoveToShop();
    }

    public void ShoppingCancel()
    {
        girlImg.SetActive(false);
        countmassage = 1; 
    }
    bool endingNote = false;

    int clothesBoughtCheck=0;
    [SerializeField]
    string[] endingMassageGirl;

    [SerializeField]
    string[] endingMassageShop;
    public void Startconvo(bool girl)
    {
        if (endingNote == false)
        {
            if (girl == true)
            {
                if (countCovo < girlMassages.Length)
                {
                    girlImg.SetActive(true);
                    shopkeeperImg.SetActive(false);
                    dialogBoxGirlT.text = girlMassages[countCovo];
                }
                else
                {
                    countCovo = 0;
                    shopkeeperImg.SetActive(false);
                    girlImg.SetActive(false);
                    ShowStore();
                }
            }
            else
            {
                
                    shopkeeperImg.SetActive(true);
                    girlImg.SetActive(false);
                    dialogBoxShopT.text = shopkeeperMassages[countCovo];
                    countCovo++;
                
            }
        }
        else
        {
            if(girl==true)
            {
                shopkeeperImg.SetActive(true);
                girlImg.SetActive(false);
                dialogBoxShopT.text = endingMassageShop[clothesBoughtCheck];
            }
            else
            {
                //Go Home
                shopkeeperImg.SetActive(false);
                girlImg.SetActive(false);
                clothesBoughtCheck = 0;
                this.gameObject.GetComponent<PlayerMovement>().MoveToHome();
            }
        }
    }

    void ShowStore()
    {
        endingNote = true;
        Store.SetActive(true);
    }

    public void ClothesBought(int ind)
    {
        if(clotheslist[ind].price<cash)
        {
            cash = cash - clotheslist[ind].price;
            cashT.text = cash+"";
            clothesBoughtCheck = 1;
            Store.SetActive(false);
            playerSprite.sprite = clotheslist[ind].sprite;
            shopkeeperImg.SetActive(false);
            girlImg.SetActive(true);
            dialogBoxGirlT.text = endingMassageGirl[clothesBoughtCheck];

        }
    }

    public void GoHomeithoutShoping()
    {
        clothesBoughtCheck = 0;
        Store.SetActive(false);

        shopkeeperImg.SetActive(false);
        girlImg.SetActive(true);
        dialogBoxGirlT.text = endingMassageGirl[clothesBoughtCheck];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

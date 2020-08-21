using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoSingleton<Shop>
{

    [System.Serializable] class ShopItem
    {
        public Sprite image;
        public Sprite priceImage;
        public int price;
        public bool isPurchased;
        public string priceType;
        
    }

    [SerializeField] List<ShopItem> itemsList; 

    GameObject itemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;

    private void Start()
    {
        itemTemplate = ShopScrollView.GetChild(0).gameObject;

        for(int i = 0; i < itemsList.Count; i++)
        {
            g = Instantiate(itemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = itemsList[i].image;
            g.transform.GetChild(1).GetComponent<Image>().sprite = itemsList[i].priceImage;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = itemsList[i].price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.transform.GetChild(1).GetComponent<Text>().text = itemsList[i].priceType;
            Debug.Log(buyBtn.transform.GetChild(1).GetComponent<Text>().text);
            buyBtn.interactable = !itemsList[i].isPurchased;
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(itemTemplate);
    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
        int itemPrice = itemsList[itemIndex].price;
        string priceType = buyBtn.transform.GetChild(1).GetComponent<Text>().text;
        Debug.Log(priceType);
        if (priceType == "Bones")
        {
            if (Player.Instance.HasEnoughBones(itemPrice))
            {
                Player.Instance.UseCurrency(itemPrice, "Bones");
                UIManager.Instance.SubtractCurrency(itemPrice, "Bones");
                itemsList[itemIndex].isPurchased = true;
                buyBtn.interactable = false;
                buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
            }
        }
        else if (priceType == "Bacon")
        {
            if (Player.Instance.HasEnoughBacon(itemPrice))
            {
                Player.Instance.UseCurrency(itemPrice, "Bacon");
                UIManager.Instance.SubtractCurrency(itemPrice, "Bacon");
                itemsList[itemIndex].isPurchased = true;
                buyBtn.interactable = false;
                buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
            }
        }
        else
        {
            Debug.Log("You don't have enough coins!");
        }
        

        
        
    }
}

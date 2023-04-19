using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadInformationFromResources : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemHangry;
    [SerializeField] private TMP_Text _itemHP;
    [SerializeField] private TMP_Text _itemWater;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void LoadInformation(Sprite _downladedSprite, string _downladedName, string _downladedHangry, string _downladedHp,string _waterIfEat)
    {
        _itemImage.sprite = _downladedSprite;
        _itemName.text = _downladedName;
        _itemHP.text = _downladedHp;
        _itemHangry.text = _downladedHangry;
        _itemWater.text = _waterIfEat;
    }
}

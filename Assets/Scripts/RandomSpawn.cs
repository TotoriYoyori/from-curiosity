using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;  // Уникальный идентификатор карты
    public SpriteRenderer spriteRenderer;

    // Словарь для соответствия между ID и объектом данных карты
    private Dictionary<int, CardData> idToCardDataMap = new Dictionary<int, CardData>();

    void Start()
    {
        // Инициализация словаря
        InitializeIdToCardDataMap();

        // Присваиваем случайный ID и обновляем спрайт и тэг
        AssignRandomID();
        UpdateCardAppearance();
    }

    // Инициализация словаря
    void InitializeIdToCardDataMap()
    {
        // Загрузка спрайтов и установка соответствий
        Sprite sprite0 = Resources.Load<Sprite>("Sprites/C");
        Sprite sprite1 = Resources.Load<Sprite>("Sprites/O");
        Sprite sprite2 = Resources.Load<Sprite>("Sprites/H");
        Sprite sprite3 = Resources.Load<Sprite>("Sprites/Na");
        Sprite sprite4 = Resources.Load<Sprite>("Sprites/Cl");
        Sprite sprite5 = Resources.Load<Sprite>("Sprites/N");
        Sprite sprite6 = Resources.Load<Sprite>("Sprites/S");

        // Установка соответствий между ID карты, спрайтом и тэгом
        idToCardDataMap.Add(0, new CardData(sprite0, "C"));
        idToCardDataMap.Add(1, new CardData(sprite1, "O"));
        idToCardDataMap.Add(2, new CardData(sprite2, "H"));
        idToCardDataMap.Add(3, new CardData(sprite3, "Na"));
        idToCardDataMap.Add(4, new CardData(sprite4, "Cl"));
        idToCardDataMap.Add(5, new CardData(sprite5, "N"));
        idToCardDataMap.Add(6, new CardData(sprite6, "S"));
    }

    // Присваиваем случайный ID и обновляем спрайт и тэг
    void AssignRandomID()
    {
        cardID = Random.Range(0, idToCardDataMap.Count);
    }

    // Обновляем спрайт и тэг в соответствии с ID
    void UpdateCardAppearance()
    {
        spriteRenderer.sprite = idToCardDataMap[cardID].sprite;
        gameObject.tag = idToCardDataMap[cardID].tag;
    }

    // Метод для изменения свойств карты
    public void ChangeCardProperties()
    {
        AssignRandomID();
        UpdateCardAppearance();
    }
}

// Класс для хранения данных карты
[System.Serializable]
public class CardData
{
    public Sprite sprite;
    public string tag;

    public CardData(Sprite sprite, string tag)
    {
        this.sprite = sprite;
        this.tag = tag;
    }
}

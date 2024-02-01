using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;  // ���������� ������������� �����
    public SpriteRenderer spriteRenderer;

    // ������� ��� ������������ ����� ID � �������� ������ �����
    private Dictionary<int, CardData> idToCardDataMap = new Dictionary<int, CardData>();

    void Start()
    {
        // ������������� �������
        InitializeIdToCardDataMap();

        // ����������� ��������� ID � ��������� ������ � ���
        AssignRandomID();
        UpdateCardAppearance();
    }

    // ������������� �������
    void InitializeIdToCardDataMap()
    {
        // �������� �������� � ��������� ������������
        Sprite sprite0 = Resources.Load<Sprite>("Sprites/C");
        Sprite sprite1 = Resources.Load<Sprite>("Sprites/O");
        Sprite sprite2 = Resources.Load<Sprite>("Sprites/H");
        Sprite sprite3 = Resources.Load<Sprite>("Sprites/Na");
        Sprite sprite4 = Resources.Load<Sprite>("Sprites/Cl");
        Sprite sprite5 = Resources.Load<Sprite>("Sprites/N");
        Sprite sprite6 = Resources.Load<Sprite>("Sprites/S");

        // ��������� ������������ ����� ID �����, �������� � �����
        idToCardDataMap.Add(0, new CardData(sprite0, "C"));
        idToCardDataMap.Add(1, new CardData(sprite1, "O"));
        idToCardDataMap.Add(2, new CardData(sprite2, "H"));
        idToCardDataMap.Add(3, new CardData(sprite3, "Na"));
        idToCardDataMap.Add(4, new CardData(sprite4, "Cl"));
        idToCardDataMap.Add(5, new CardData(sprite5, "N"));
        idToCardDataMap.Add(6, new CardData(sprite6, "S"));
    }

    // ����������� ��������� ID � ��������� ������ � ���
    void AssignRandomID()
    {
        cardID = Random.Range(0, idToCardDataMap.Count);
    }

    // ��������� ������ � ��� � ������������ � ID
    void UpdateCardAppearance()
    {
        spriteRenderer.sprite = idToCardDataMap[cardID].sprite;
        gameObject.tag = idToCardDataMap[cardID].tag;
    }

    // ����� ��� ��������� ������� �����
    public void ChangeCardProperties()
    {
        AssignRandomID();
        UpdateCardAppearance();
    }
}

// ����� ��� �������� ������ �����
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

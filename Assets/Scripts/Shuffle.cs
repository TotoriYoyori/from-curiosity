using UnityEngine;
using UnityEngine.UI;

public class Shuffle : MonoBehaviour
{
    public Card[] cards;  // ������ ����

    // ���������� ��� ������� ������
    public void ChangeCardProperties()
    {
        // �������� �� ���� ������ � ������� � �������� �� ��������
        foreach (Card card in cards)
        {
            if (card != null)
            {
                card.ChangeCardProperties();
            }
        }
    }
}

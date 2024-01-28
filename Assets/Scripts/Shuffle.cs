using UnityEngine;
using UnityEngine.UI;

public class Shuffle : MonoBehaviour
{
    public Card[] cards;  // Массив карт

    // Вызывается при нажатии кнопки
    public void ChangeCardProperties()
    {
        // Проходим по всем картам в массиве и изменяем их свойства
        foreach (Card card in cards)
        {
            if (card != null)
            {
                card.ChangeCardProperties();
            }
        }
    }
}

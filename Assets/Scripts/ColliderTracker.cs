using UnityEngine;

public class ColliderTracker : MonoBehaviour
{
    public TextMesh ElementName; // Ссылка на 3D текстовый объект из инспектора
    private string otherObjectTag; // Добавляем переменную для хранения тега другого объекта

    // Добавляем поле Tag
    public string Tag;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Этот метод вызывается, когда другой коллайдер входит в триггер-коллайдер.

        // Получаем тег объекта, находящегося в зоне триггера
        otherObjectTag = other.gameObject.tag;

        // Выводим сообщение в консоль для отладки
        //Debug.Log("Тег в ExampleScript: " + otherObjectTag);

        // Проверяем, успешно ли получен тег
        if (!string.IsNullOrEmpty(otherObjectTag))
        {
            // Если тег успешно получен, отображаем его в 3D текстовом объекте
            ElementName.text = otherObjectTag;

            // Проверяем различие тегов
            if (!string.IsNullOrEmpty(Tag) && !Tag.Equals(otherObjectTag))
            {
                Debug.Log("Теги объектов разные: " + Tag + " и " + otherObjectTag);
            }
        }
        else
        {
            // Если тег не успешно получен (например, внутри объекта нет коллайдеров), очищаем текстовое поле
            ElementName.text = "";
        }
    }
}

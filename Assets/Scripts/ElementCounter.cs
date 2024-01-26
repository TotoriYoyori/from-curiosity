using UnityEngine;
using System.Collections.Generic;

public class ObjectTracker : MonoBehaviour
{
    public TextMesh TextElements;
    public TextMesh ElementType;
    private List<GameObject> objectsInside = new List<GameObject>(); // Список объектов внутри триггера

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Добавляем объект в список при входе в триггер
        if (!objectsInside.Contains(other.gameObject))
        {
            objectsInside.Add(other.gameObject);
        }

        // Обновляем количество объектов
        UpdateObjectCount();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Удаляем объект из списка при выходе из триггера
        if (objectsInside.Contains(other.gameObject))
        {
            objectsInside.Remove(other.gameObject);
        }

        // Обновляем количество объектов
        UpdateObjectCount();
    }

    private void UpdateObjectCount()
    {
        // В этом методе вы можете использовать objectsInside.Count для получения текущего количества объектов
        int objectCount = objectsInside.Count;

        // Преобразуем int в строку перед присвоением TextMesh.text
        TextElements.text = objectCount.ToString();

        // Если внутри объекта нет других объектов, очищаем текстовые поля
        if (objectCount == 0)
        {
            TextElements.text = "";
            ElementType.text = "";
        }
    }
}

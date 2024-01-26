using UnityEngine;
using System.Collections.Generic;

public class ObjectTracker : MonoBehaviour
{
    public TextMesh TextElements;
    public TextMesh ElementType;
    private List<GameObject> objectsInside = new List<GameObject>(); // ������ �������� ������ ��������

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ������ � ������ ��� ����� � �������
        if (!objectsInside.Contains(other.gameObject))
        {
            objectsInside.Add(other.gameObject);
        }

        // ��������� ���������� ��������
        UpdateObjectCount();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ������� ������ �� ������ ��� ������ �� ��������
        if (objectsInside.Contains(other.gameObject))
        {
            objectsInside.Remove(other.gameObject);
        }

        // ��������� ���������� ��������
        UpdateObjectCount();
    }

    private void UpdateObjectCount()
    {
        // � ���� ������ �� ������ ������������ objectsInside.Count ��� ��������� �������� ���������� ��������
        int objectCount = objectsInside.Count;

        // ����������� int � ������ ����� ����������� TextMesh.text
        TextElements.text = objectCount.ToString();

        // ���� ������ ������� ��� ������ ��������, ������� ��������� ����
        if (objectCount == 0)
        {
            TextElements.text = "";
            ElementType.text = "";
        }
    }
}

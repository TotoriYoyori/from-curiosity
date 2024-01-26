using UnityEngine;

public class ColliderTracker : MonoBehaviour
{
    public TextMesh ElementName; // ������ �� 3D ��������� ������ �� ����������
    private string otherObjectTag; // ��������� ���������� ��� �������� ���� ������� �������

    // ��������� ���� Tag
    public string Tag;

    private void OnTriggerStay2D(Collider2D other)
    {
        // ���� ����� ����������, ����� ������ ��������� ������ � �������-���������.

        // �������� ��� �������, ������������ � ���� ��������
        otherObjectTag = other.gameObject.tag;

        // ������� ��������� � ������� ��� �������
        //Debug.Log("��� � ExampleScript: " + otherObjectTag);

        // ���������, ������� �� ������� ���
        if (!string.IsNullOrEmpty(otherObjectTag))
        {
            // ���� ��� ������� �������, ���������� ��� � 3D ��������� �������
            ElementName.text = otherObjectTag;

            // ��������� �������� �����
            if (!string.IsNullOrEmpty(Tag) && !Tag.Equals(otherObjectTag))
            {
                Debug.Log("���� �������� ������: " + Tag + " � " + otherObjectTag);
            }
        }
        else
        {
            // ���� ��� �� ������� ������� (��������, ������ ������� ��� �����������), ������� ��������� ����
            ElementName.text = "";
        }
    }
}

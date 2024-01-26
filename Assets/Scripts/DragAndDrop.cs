using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool mCanMove;
    public bool mDragging;
    public Collider2D mCollider;
    private Vector3 initialPosition;
    public Collider2D dropZoneCollider;
    public Collider2D SecondSlotCollider;
    public string Tag; 
    public string TagInZone;
    public string TagInZone1;
    public string CurrentTag;
    public TextMesh TextForCurrentTag;
    public TextMesh TextForCurrentTag1;

    void Start()
    {
        if (mCollider == null)
            mCollider = GetComponent<Collider2D>();

        mCanMove = false;
        mDragging = false;
        initialPosition = transform.position;
    }

    void Update()
    {
        TagInZone = TextForCurrentTag.text;
        //Debug.Log(TagInZone);
        TagInZone1 = TextForCurrentTag1.text;

        CurrentTag = this.tag;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (mCollider == Physics2D.OverlapPoint(mousePos))
            {
                mCanMove = true;
                mDragging = true; // Set mDragging to true when the mouse is clicked and over the collider
            }
            else
            {
                mCanMove = false;
                mDragging = false;
            }
        }

        if (mDragging)
        {
            this.transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mCanMove = false;
            mDragging = false;
           

            if (!(dropZoneCollider.OverlapPoint(mousePos) || SecondSlotCollider.OverlapPoint(mousePos)) || !(CurrentTag == TagInZone || CurrentTag == TagInZone1))
            {
                // Reset the position only if released outside the drop zone
                this.transform.position = initialPosition;
                
            }
            else
            {
                
            }
        }
    }
}

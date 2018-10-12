using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 10;
    private Vector3 dragOrigin;
    private Vector3 posOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            posOrigin = transform.position;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
        print(move);
        transform.position = new Vector3(posOrigin.x - move.x, posOrigin.y + move.y, posOrigin.z - move.z);
    }


}
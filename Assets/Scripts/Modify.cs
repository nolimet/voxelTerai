using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{

    Vector2 rot;

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                Terrain.SetBlock(hit, new BlockAir());
            }
        }

        if (Screen.lockCursor)
        {
            rot = new Vector2(
                rot.x + Input.GetAxis("Mouse X") * 3,
                rot.y + Input.GetAxis("Mouse Y") * 3);

            transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);
            if (Input.GetKeyDown(KeyCode.Escape))
                Screen.lockCursor = false;
        }
        else
            if (Input.GetMouseButton(1))
                Screen.lockCursor = true;
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 10f;
        else if (Input.GetKey(KeyCode.LeftControl))
            speed = 50f;
        else
            speed = 3f;
        transform.position += transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime ;
        transform.position += transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime ;
    }
}
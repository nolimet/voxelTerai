using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{
    public bool useFPS = false;
    public MouseLook[] lookscrips;
    public CharacterMotor move;
    Vector2 rot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                TerrainEdit.SetBlock(hit, new BlockAir());
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            useFPS = !useFPS;
            foreach (MouseLook m in lookscrips)
                m.enabled = useFPS;
            move.enabled = useFPS;
            if (useFPS)
            {
                transform.localPosition = new Vector3(0, 0.715f, 0);
                transform.localRotation = Quaternion.identity;
            }
        }
        if (!useFPS)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                rot = new Vector2(
                    rot.x + Input.GetAxis("Mouse X") * 3,
                    rot.y + Input.GetAxis("Mouse Y") * 3);

                transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
                transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            else if (Input.GetMouseButton(1))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            float speed;
            if (Input.GetKey(KeyCode.LeftShift))
                speed = 10f;
            else if (Input.GetKey(KeyCode.LeftControl))
                speed = 50f;
            else
                speed = 3f;

            transform.position += transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
    }
}
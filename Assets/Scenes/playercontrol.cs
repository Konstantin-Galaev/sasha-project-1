using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f;                 // скорость движения
    public bool rigidbodyEnabled = true;     // управление активностью

    void Update()
    {
        if (!rigidbodyEnabled)
            return;

        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f; // движение вперед по локальной оси Z
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 1f; // назад
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f; // вправо
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1f; // влево
        }

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;

        // перемещаем кубик по его локальным осям
        transform.Translate(move, Space.Self);
    }
}

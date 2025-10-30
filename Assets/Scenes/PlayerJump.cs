using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    public float jumpHeight = 4f;     // высота прыжка
    private float fallSpeed = 0f;     // текущая скорость падения
    public float gravity = -9.81f;    // сила гравитации
    private bool isJumping = false;

    void Start()
    {
        // Можно начать с прыжка или оставить так
        // Jump();
    }

    void Update()
    {
        // Прыжок по пробелу
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Обработка прыжка и падения
        if (isJumping)
        {
            fallSpeed += gravity * Time.deltaTime;
            transform.Translate(Vector3.up * fallSpeed * Time.deltaTime);

            if (transform.position.y <= 0f)
            {
                Vector3 pos = transform.position;
                pos.y = 0f;
                transform.position = pos;
                isJumping = false;
            }
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            // Расчёт начальной скорости для достижения jumpHeight
            fallSpeed = Mathf.Sqrt(2 * Mathf.Abs(gravity) * jumpHeight);
            isJumping = true;
        }
    }
}
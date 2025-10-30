using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallStartY;            // Высота, с которой началось падение
    public float minimumFallHeight = 8f; // Минимальная высота для урона
    public float maxDamage = 10f;        // Максимальный урон за большой падение

    private bool isFalling = false;
    private bool hasLanded = false;

    private PlayerHealth playerHealth; // ссылка на ваш скрипт здоровья

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth компонент не найден!");
        }
    }

    void Update()
    {
        // Проверяем, падает ли игрок
        if (IsGrounded())
        {
            if (isFalling)
            {
                float fallHeight = fallStartY - transform.position.y;
                if (fallHeight >= minimumFallHeight)
                {
                    // Рассчитываем урон пропорционально высоте падения
                    float damage = (fallHeight / 20f) * maxDamage; // делитель 20 для регулировки урона
                    damage = Mathf.Min(damage, maxDamage); // чтобы не было выше maxDamage
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damage);
                    }
                }
                isFalling = false;
            }
            hasLanded = true;
        }
        else
        {
            // Если не на земле и мы еще не зафиксировали падение
            if (!isFalling && hasLanded)
            {
                fallStartY = transform.position.y;
                isFalling = true;
                hasLanded = false;
            }
        }
    }

    // Простая проверка, на земле ли игрок
    bool IsGrounded()
    {
        // Можно заменить на более точную проверку
        RaycastHit hit;
        float rayDistance = 0.2f;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance + 0.1f))
        {
            return true;
        }
        return false;
    }
}
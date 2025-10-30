using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // максимальное здоровье
    public float currentHealth;    // текущее здоровье

    public Vector3 respawnPosition = new Vector3(0, 0, 0); // координаты для возрождения

    void Start()
    {
        // Инициализация текущего HP значением maxHealth
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Например, тест: уменьшение HP при нажатии клавиши H
        // Это только для теста, уберите или замените в реике
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }

        // Проверка, если HP <= 0
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Respawn()
    {
        // Деактивируем объект
        gameObject.SetActive(false);

        // Переносим на координаты возрождения
        transform.position = respawnPosition;

        // Восстанавливаем здоровье при возрождении
        currentHealth = maxHealth;

        // Обратно активируем объект
        gameObject.SetActive(true);
    }
}
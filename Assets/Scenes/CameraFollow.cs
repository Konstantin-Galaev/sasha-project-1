
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Объект, за которым будет следить камера
    public Transform player;
    
    // Смещение камеры относительно игрока
    public Vector3 offset;

    void LateUpdate()
    {
        if (player != null)
        {
            // Обновляем позицию камеры с учетом смещения
            transform.position = player.position + offset;
        }
    }
}
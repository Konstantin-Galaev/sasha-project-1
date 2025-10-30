using UnityEngine;

public class MinecraftCameraLook : MonoBehaviour
{
    public float sensitivity = 2f; // чувствительность вращения
    private float rotationY = 0f;

    void Update()
    {
        // Получаем движение мыши по оси X
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Накопление вращения по Y
        rotationY += mouseX;

        // Вращение камеры вокруг своей оси Y
        transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
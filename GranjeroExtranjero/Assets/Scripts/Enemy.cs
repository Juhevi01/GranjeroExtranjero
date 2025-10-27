using UnityEngine;

public class EnemyFollow2D : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float speed = 3f;            // Velocidad de movimiento
    [SerializeField] private float detectionRange = 5f;   // Distancia a la que detecta al jugador
    [SerializeField] private float stopDistance = 1.2f;   // Distancia mínima antes de detenerse

    [Header("References")]
    [SerializeField] private Transform player;            // Referencia al jugador

    private void Update()
    {
        if (player == null) return;

        // Calcular distancia solo en el plano X
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance <= detectionRange && distance > stopDistance)
        {
            // Dirección solo en X
            float directionX = Mathf.Sign(player.position.x - transform.position.x);

            // Mover al enemigo solo horizontalmente
            transform.position += new Vector3(directionX * speed * Time.deltaTime, 0f, 0f);

            // Voltear sprite según la dirección
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * directionX;
            transform.localScale = scale;
        }
    }
}
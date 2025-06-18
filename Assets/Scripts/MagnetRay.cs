using UnityEngine;

public class MagnetRay : MonoBehaviour
{
  GameObject player;
  Vector3 size;
  public float rayStrength = 20;
  bool pull;
  bool push;

  void Start()
  {
    size = Vector3.Scale(GetComponent<SpriteRenderer>().size, transform.localScale);
    player = GameObject.FindGameObjectWithTag("Character");
  }

  void Update()
  {
    pull = Input.GetKey(KeyCode.E);
    push = Input.GetKey(KeyCode.Q);
    Follow();
  }

  void OnTriggerStay2D(Collider2D collision)
  {
    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
    if (collision.CompareTag("Magnetic") && rb != null)
    {
      Vector2 direction = Vector2.left;
      direction *= pull ? 1 : push ? -1 : 0;
      rb.AddForce(direction * rayStrength, ForceMode2D.Force);

      // Vector2 direction = (player.transform.position - collision.transform.position).normalized;
      // float distance = Vector2.Distance(player.transform.position, collision.transform.position);
      // float forceMagnitude = rayStrength / (distance * distance);
      // direction *= pull ? 1 : push ? -1 : 0;
      // rb.AddForce(direction * forceMagnitude, ForceMode2D.Force);

    }
  }

  void Follow()
  {
    Vector2 newPosition = player.transform.position + (0.5f * size);
    transform.SetPositionAndRotation(newPosition, player.transform.rotation);
  }
}

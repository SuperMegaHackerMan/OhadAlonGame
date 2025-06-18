using UnityEngine;

public class ButtonController : MonoBehaviour
{
  int objectsOnButton = 0;
  Color originalColor = Color.red;
  Color pressedColor = Color.green;
  private SpriteRenderer spriteRenderer;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.color = originalColor;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    objectsOnButton++;
    spriteRenderer.color = pressedColor;
  }

  void OnTriggerExit2D(Collider2D other)
  {
    objectsOnButton--;
    if (objectsOnButton <= 0)
    {
      spriteRenderer.color = originalColor;
    }
  }
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed = 5f;

  void Start()
  {

  }


  void Update()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
    transform.Translate(movement);

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30; // Pelaajan nopeus jota voi s‰‰t‰‰ tarvittaessa
    private PlayerController playerControllerScript; // T‰m‰ on viittaus toiseen skriptiin nimelt‰ PlayerController
    private float leftBound = -15; // Vasen raja

    // Start is called before the first frame update
    void Start()
    {
        // Etsii pelin hahmoa nimelt‰ "Player" ja saa siit‰ PlayerController-komponentin k‰yttˆˆn
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Siirt‰‰ objektia vasemmalle, jos pelihahmon peli ei ole p‰‰ttynyt (gameOver on false).
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Poistaa esteen pelist‰, kun este on mennyt vasemman rajan yli (leftBound).
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}

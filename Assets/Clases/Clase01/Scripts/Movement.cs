using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Movement : MonoBehaviour
{
    // Visible en el inspector [SerializedField] || [Public]
    [SerializeField] private float moveSpeed = 5f;  
    [SerializeField] private float rotationStep = 10f;


    //Configurable desde el inspector
    // Sprite 1 -> WASD
    // Sprite 2 -> FLECHAS
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode moveRight = KeyCode.D;

    //FORMAS de acceder al <SpriteRenderer>

    //[SerializeField] private SpriteRenderer spriteRenderer;

    private SpriteRenderer sr;

    /*private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }*/

    void Start()            // Corre UNA vez, antes del primer frame
    {
        Debug.Log("Listo para moverme");

        // Referencia al componente del MISMO GameObject
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()    // Corre una vez por frame
    {
        // Multiplicar por Time.deltaTime hace que la velocidad sea “unidades por segundo”, sin importar los FPS.
        float step = moveSpeed * Time.deltaTime;


        // GetKey devuelve true mientras la tecla está apretada → ideal para movimiento continuo.
        if (Input.GetKey(moveUp)) { 
            transform.Translate(Vector2.up * step);
        }

        if (Input.GetKey(moveDown)) {
            transform.Translate(Vector2.down * step);
        }

        if (Input.GetKey(moveLeft)) {
            transform.Translate(Vector2.left * step);
        }

        if (Input.GetKey(moveRight)) {
            transform.Translate(Vector2.right * step);
        }



        // Rotacion de 10 grados con (GetKeyDown)
        if (Input.GetKeyDown(KeyCode.Q)){
            transform.Rotate(0f, 0f, rotationStep);
        }

        if (Input.GetKeyDown(KeyCode.E)) { 
            transform.Rotate(0f,0f,-rotationStep);
        }



        // FORMAS DE GENERAR UN VALOR RANDOM
  
        /* FORMA 1) Float aleatorio entre 0 y 1 (inclusive)

        float r = Random.value; */

        
        /* FORMA 2) Rango explícito: en float el máximo SÍ entra...
        
        float g = Random.Range(0f, 1f); */
        
        /* FORMA 3)...pero en int el máximo queda EXCLUIDO
        
        int dado = Random.Range(1, 7); // 1,2,3,4,5,6
                                       // TP: al SOLTAR la R -> color random */
        

        // Color RANDOM al soltar la R (GetKeyUp)
        if (Input.GetKeyUp(KeyCode.R)){
            sr.color = new Color(Random.value, Random.value, Random.value);
        }

    }
}

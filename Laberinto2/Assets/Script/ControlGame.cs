using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{
    public GameObject Testeo;
    [SerializeField]
    private string tag;//SpawnPoint
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject selectedSpawnPoint;

    [SerializeField]
    private GameObject menuCamera;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private float velocidad = 5;

    private Timer timer;
    private CharacterController _characterController;

    private void Awake()
    {
           //cargar cualquier cosa en la escena antes de hacer nada,
           //NO INICIA LA ESCENA HASTA QUE ESTE TODOLO DE AQUI DENTRO CARGADO 
    }
    private void FixedUpdate()
    {
        //100 FFP 100 100/100= 1 SEG
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();//inicializamos character controleer

        //placePlayerRandomly();
        timer = gameObject.GetComponent<Timer>();
        menuCamera.SetActive(true);//ok
        menuUI.SetActive(true);
        Debug.Log("Activa lo quee");
        gameUI.SetActive(false);

            }
    void Update()
    {
        //Movimiento();
        if (Input.GetKeyDown(KeyCode.Escape)) { EndGame(); }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

     public void StartGame()
    {
        timer.startTimer();
        menuCamera.SetActive(false);
        Debug.Log("Desacativo boton start");
        menuUI.SetActive(false);
        gameUI.SetActive(true);

        placePlayerRandomly();
    }


    public void Movimiento()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direccion = new Vector3(verticalInput, 0, horizontalInput);
        Vector3 velocity = direccion * velocidad;

        _characterController.Move(velocity * Time.deltaTime);
    }
    public void EndGame()   
    {
        timer.stopTimer();
        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameUI.SetActive(false);

        Destroy(player);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void placePlayerRandomly() {
        spawnPoints = GameObject.FindGameObjectsWithTag(tag);//SpawnPoint
        int rand = Random.Range(0, spawnPoints.Length);
        selectedSpawnPoint = spawnPoints[rand];
        player = Instantiate(playerPrefab, selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.localRotation);
    }
    
}

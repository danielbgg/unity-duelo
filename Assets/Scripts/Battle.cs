using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    Player[] players;
    int status;
    Vector3[] spawnPoints;
    Quaternion[] rotSpawnPoints;
    Color[] playerColors;
    public GameObject meuPrefab;
    Text titulo, info, lifePlayer1, lifePlayer2;

    public GameObject objBullet;
    Vector3 spawnBullet;

    // Start is called before the first frame update
    void Start() {
        players = new Player[2];
        status = -1;
        spawnPoints = new Vector3[] {
            new Vector3(3.96f, 1f, -3.96f), new Vector3(-4.04f, 1f, 4.04f)
        };
        rotSpawnPoints = new Quaternion[] {
            Quaternion.Euler(0.0f, -45f, 0f), Quaternion.Euler(0.0f, 135f, 0f)
        };
        playerColors = new Color[] {
            Color.blue, Color.red
        };
        titulo = GameObject.Find("Title").GetComponent<Text>();
        info = GameObject.Find("Info").GetComponent<Text>();
        lifePlayer1 = GameObject.Find("LifePlayer1").GetComponent<Text>();
        lifePlayer2 = GameObject.Find("LifePlayer2").GetComponent<Text>();
        spawnBullet = new Vector3(0.22f, 0.613f, 0.751f);

    }

    bool JogadoresCriados() {
        return (players[0] != null && players[1] != null);
    }

    bool JogoEmAndamento() {
        return (JogadoresCriados() && status == 0);
    }

    void DesligarTitulo() {
        titulo.enabled = false;
    }

    void LigarTitulo() {
        titulo.enabled = true;
    }

    void MudarTitulo(string novo) {
        titulo.text = novo;
        titulo.color = new Color(titulo.color.r, titulo.color.g, titulo.color.b, 255);
    }

    void Imprimir(string s) {
        print(s);
        info.enabled = true;
        info.text = s;
    }

    void AtualizarLifePlayer() {
        lifePlayer1.text = players[0].getLife().ToString();
        lifePlayer2.text = players[1].getLife().ToString();
    }

    void CreatePlayer(int nPlayer) {
        int index = nPlayer - 1;
        if (players[index] == null) {
            string name = "Player " + nPlayer;
            players[index] = new Player(name, 100, 14);
            players[index].obj3d = Instantiate(meuPrefab, spawnPoints[index], rotSpawnPoints[index]);
            players[index].obj3d.name = name;
            players[index].obj3d.GetComponent<MeshRenderer>().material.color = playerColors[index];
        }

        if (JogadoresCriados() && status == -1) {
            Imprimir("Jogo em andamento");
            status = 0;
            AtualizarLifePlayer();
            lifePlayer1.enabled = true;
            lifePlayer2.enabled = true;
        }

        ControlaInterface();
    }

    void ControlaInterface() {
        if (players[0] == null) {
            MudarTitulo("Aguardando Player 1!");
        }
        if (players[1] == null) {
            MudarTitulo("Aguardando Player 2!");
        }
        if (JogadoresCriados()) {
            DesligarTitulo();
        }
    }

    void ControlaCritico(Attack a, string n) {
        if (a.isCritical()) {
            titulo.enabled = true;
            titulo.text = n + " fez ataque critico!!";
            titulo.color = new Color(titulo.color.r, titulo.color.g, titulo.color.b, 255);
        } else {
            titulo.enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (status == -1) {
            titulo.color = new Color(titulo.color.r, titulo.color.g, titulo.color.b, (Mathf.Sin(Time.time * 2.0f) + 1.0f) / 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.F10)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.F1)) {
            CreatePlayer(1);
        }

        if (Input.GetKeyDown(KeyCode.F2)) {
            CreatePlayer(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && JogoEmAndamento()) {
            GameObject objTmp = Instantiate(objBullet, new Vector3(0f, 0f, 0f), Quaternion.identity);
            objTmp.transform.parent = players[0].obj3d.transform;
            objTmp.transform.localPosition = spawnBullet;

            Rigidbody tiro = objTmp.GetComponent<Rigidbody>();
            tiro.AddForce(new Vector3(-0.7f, 0f, 1f) * 500f, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && JogoEmAndamento()) {
            GameObject objTmp = Instantiate(objBullet, new Vector3(0f, 0f, 0f), Quaternion.identity);
            objTmp.transform.parent = players[1].obj3d.transform;
            objTmp.transform.localPosition = spawnBullet;

            Rigidbody tiro = objTmp.GetComponent<Rigidbody>();
            tiro.AddForce(new Vector3(0.5f, 0f, -0.5f) * 500f, ForceMode.Acceleration);
        }
    }


    public void HitDoPlayer1() {
        Attack a = players[0].Attack();
        Imprimir(players[0].Name + " atacou com " + a.getAttack() + " de dano");
        if (players[1].UpdateLife(a.getAttack())) {
            ControlaCritico(a, players[0].Name);
            AtualizarLifePlayer();
        } else {
            string s = players[0].Name + " vencedor! ";
            Imprimir(s);
            status = 1;
            LigarTitulo();
            MudarTitulo(s);
            lifePlayer2.enabled = false;
        }
    }

    public void HitDoPlayer2() {
        Attack a = players[1].Attack();
        Imprimir(players[1].Name + " atacou com " + a.getAttack() + " de dano");
        if (players[0].UpdateLife(a.getAttack())) {
            ControlaCritico(a, players[1].Name);
            AtualizarLifePlayer();
        } else {
            string s = players[1].Name + " vencedor! ";
            Imprimir(s);
            status = 2;
            LigarTitulo();
            MudarTitulo(s);
            lifePlayer1.enabled = false;
        }
    }
}

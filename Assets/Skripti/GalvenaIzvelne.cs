using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importē lai varētu ielādēt ainas
using UnityEngine.SceneManagement;

public class GalvenaIzvelne : MonoBehaviour
{
    //Izdarot klikšķi uz pogas "UzSpeli", tiks atvērta aina "PilsetasAina"
    public void uzPilsetu()
    {
        SceneManager.LoadScene("PilsetasAina", LoadSceneMode.Single);
    }
}

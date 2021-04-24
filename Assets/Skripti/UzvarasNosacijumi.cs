using System.Collections;
using System.Collections.Generic;
//Importē, lai varētu pārlādēt un ielādēt ainas
using UnityEngine.SceneManagement;
using UnityEngine;

public class UzvarasNosacijumi : MonoBehaviour
{
    //Uzglabā norādi uz Objektu skriptu
    public Objekti objektuSkripts;
    //Definē objektus, kas reprezentē pārlādes pogu, pogu, kas atgriež uz galveno izvēlni un uzvaras logu 
    public GameObject restartPoga;
    public GameObject atgriezPoga;
    public GameObject uzvarasLogs;
    //Skaita cik mašīnas novietotas pareizajā pozīcīja, hideininspector to paslēpj inspector logā.
    [HideInInspector]
    public int pareizasMasinas = 0;

    //Uz ainas uzsākšanas
    private void Awake()
    {
        //Spēli pārlādējot vai sākot uzvaras logs un pārstartēšanas poga paliek pārāk mazi, lai tos redzētu
        uzvarasLogs.transform.localScale = Vector2.zero;
        //Atgriešanās poga vienmēr aktīva, taču pārlādējot/sākot spēli tā atrodas stūrī
        atgriezPoga.transform.position = new Vector2(-600, -260);
        restartPoga.transform.localScale = Vector2.zero;
        pareizasMasinas = 0;
        Debug.Log("Ir " + pareizasMasinas + " pareizi novietotas mašīnas");
    }

    //Nostrādā katrā rāmī (frame)
    private void Update()
    {
        //Vislaik pārbauda vai pareizi salikto mašīnu skaits ir 11, ja skaits ir 11, tad veic darbību
        if (pareizasMasinas == 11)
        {
            Debug.Log("Uzvaras paziņošana");
            //Uzvaras logs un restartēšanas poga paliek atkal lieli, atgriešanās poga uzrodas uzvaras loga vidū
            uzvarasLogs.transform.localScale = new Vector2(0.5f, 0.5f);
            atgriezPoga.transform.position = new Vector2(-73, -61);
            restartPoga.transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

    //Izdarot klikšķi uz pogas "RestartPoga", tiek pārlādēta aktīvā aina (šoreiz pilsētas aina)
    public void RestartGame()
    {
        //Pārlādē aktīvo ainu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Izdarot klikšķi uz pogas "AtgrieztiesPoga", tiks atvērta aina "IzvelnesAina"
    public void uzIzvelni()
    {
        SceneManager.LoadScene("IzvelnesAina", LoadSceneMode.Single);
    }


}
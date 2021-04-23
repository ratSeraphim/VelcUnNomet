using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UzvarasNosacijumi : MonoBehaviour
{
    //Uzglabā norādi uz Objektu skriptu
    public Objekti objektuSkripts;
    public GameObject restartPoga;
    public GameObject atgriezPoga;
    public GameObject uzvarasLogs;
    //Skaita cik mašīnas novietotas pareizajā pozīcījā;
    [HideInInspector]
    public int pareizasMasinas = 0;

    private void Awake()
    {
        //Spēli pārlādējot un sākot uzvaras logs un pārstartēšanas poga paliek pārāk mazi, lai tos redzētu
        uzvarasLogs.transform.localScale = Vector2.zero;
        //Atgriešanās poga vienmēr aktīva, taču pārlādējot/sākot spēli tā atrodas stūrī
        atgriezPoga.transform.position = new Vector2(-600, -260);
        restartPoga.transform.localScale = Vector2.zero;
        pareizasMasinas = 0;
        Debug.Log("Ir " + pareizasMasinas + " pareizi novietotas mašīnas");
    }

    private void Update()
    {
        //Vislaik pārbauda vai pareizi salikto mašīnu skaits ir 11
        if (pareizasMasinas == 11)
        {
            Debug.Log("Uzvaras paziņošana");
            //Uzvaras logs un restartēšanas poga paliek atkal lieli, atgriešanās poga uzrodas uzvaras loga vidū
            uzvarasLogs.transform.localScale = new Vector2(0.5f, 0.5f);
            atgriezPoga.transform.position = new Vector2(-73, -61);
            restartPoga.transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

    public void RestartGame()
    {
        //Pārlādē aktīvo ainu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu piesaistīt IDropHandler interfeisu un lietot OnDrop funkciju
using UnityEngine.EventSystems;


public class NomesanasVieta : MonoBehaviour, IDropHandler
{
    //Uzglabās velkamā objekta rotāciju ap Z asi un noliekamās vietas rotāciju
    //Starpība uzglabās, cik liela Z ass rotācijas leņķa starpība starp abiem objektiem

    private float vietasZrot, velkamaObjeZrot, rotacijasStarpiba;
    //Uzglabās velkamā objekta, nomešanas vietas izmērus
    private Vector2 vietasIzm, velkObjIzm;
    //Starpība izmēram
    private float xIzmeruStarpiba, yIzmeruStarpiba;

    //Norāde uz skriptu Objekti
    public Objekti objektuSkripts;
    public UzvarasNosacijumi uzvara;

    //Nostrādā, ja objektu cenšas nomest uz nometamā lauka
    public void OnDrop(PointerEventData notikums)
    {
        //Pārbauda vai kāds objekts tiek vilkts un nomests 
        if(notikums.pointerDrag != null)
        {
            //Ja nomešanas laukā uzmestā attēla tags sakrīt ar lauka tagu
            if ((notikums.pointerDrag.tag.Equals(tag)))
            {
                //Iegūst objektu rotāciju grādos
                vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                velkamaObjeZrot = GetComponent<RectTransform>().transform.eulerAngles.z;
                //Aprēķina rotācijas strpību
                rotacijasStarpiba = Mathf.Abs(vietasZrot - velkamaObjeZrot);
                //Iegūst objektu izmērus
                vietasIzm = notikums.pointerDrag.GetComponent<RectTransform>().localScale;
                velkObjIzm = GetComponent<RectTransform>().localScale;
                xIzmeruStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
                yIzmeruStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);

                //Pārbauda vai objektu savstarpējā rotācija neatšķiras vairāk par 9 grādiem
                //un vai x un y izmēri neatšķiras vairāk par 0.15
                if((rotacijasStarpiba <=9 || (rotacijasStarpiba >= 351 && rotacijasStarpiba <=360))
                    && (xIzmeruStarpiba <=0.15 && yIzmeruStarpiba <= 0.15))
                {
                    objektuSkripts.vaiIstajaVieta = true;
                    //Nometamo objektu iecentrē nomešanas vietā
                    notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    //Pielāgo nomestā objekta rotāciju 
                    notikums.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
                    //Pielāgo nomestā objekta izmēru
                    notikums.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

                    //Pie objekta nolikšanas pareizajā vietā pieskaita uzvaras skaitītājam
                    uzvara.pareizasMasinas += 1;
                    Debug.Log("Ir " + uzvara.pareizasMasinas + " pareizi novietotas mašīnas");
                    
                    /*Pārbauda pēc tagiem, kurš no objektiem ir pareizi nomests, tad atskaņo atbilstošo skaņu*/
                    switch (notikums.pointerDrag.tag)
                    {
                        case "Atkritumi":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[1]);
                        break;

                        case "Atrie":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[2]);
                        break;

                        case "Skola":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[3]);
                        break;

                        case "B2":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[4]);
                        break;

                        case "Cements":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[5]);
                        break;

                        case "E46":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[6]);
                        break;

                        case "Eskavators":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[7]);
                        break;

                        case "Policija":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[8]);
                        break;

                        case "Trak1":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[9]);
                            break;

                        case "Trak2":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[10]);
                            break;

                        case "Ugunsdzes":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[11]);
                            break;

                        default:
                            Debug.Log("Nedefinēts tags!");
                        break;
                    }
                }
            //Ja objektu tagi nesakrīt un nomet nepareizajā vietā
            } else
            {
                objektuSkripts.vaiIstajaVieta = false;
                //Atskaņo skaņu
                objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[0]);

                //Atkarībā no objektu taga, kurš tika vilkts, objektu aizbīda uz tā sākotnējo pozīciju
                switch (notikums.pointerDrag.tag)
                {
                    case "Atkritumi":
                        objektuSkripts.atkritumuMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atkrKoord;
                        break;

                    case "Atrie":
                        objektuSkripts.atroMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atroKoord;
                        break;

                    case "Skola":
                        objektuSkripts.autobuss.GetComponent<RectTransform>().localPosition = objektuSkripts.bussKoord;
                        break;

                    case "B2":
                        objektuSkripts.b2Masina.GetComponent<RectTransform>().localPosition = objektuSkripts.b2Koord;
                        break;

                    case "Cements":
                        objektuSkripts.cementaMas.GetComponent<RectTransform>().localPosition = objektuSkripts.cementKoord;
                        break;

                    case "E46":
                        objektuSkripts.e46Masina.GetComponent<RectTransform>().localPosition = objektuSkripts.e46Koord;
                        break;

                    case "Eskavators":
                        objektuSkripts.eskavators.GetComponent<RectTransform>().localPosition = objektuSkripts.eskavKoord;
                        break;

                    case "Policija":
                        objektuSkripts.policijasMas.GetComponent<RectTransform>().localPosition = objektuSkripts.policKoord;
                        break;

                    case "Trak1":
                        objektuSkripts.traktors1.GetComponent<RectTransform>().localPosition = objektuSkripts.trak1Koord;
                        break;

                    case "Trak2":
                        objektuSkripts.traktors2.GetComponent<RectTransform>().localPosition = objektuSkripts.trak2Koord;
                        break;

                    case "Ugunsdzes":
                        objektuSkripts.ugunsdzeseji.GetComponent<RectTransform>().localPosition = objektuSkripts.ugunsKoord;
                        break;

                    default:
                        Debug.Log("Objektam nav noteikta pārvietošanas vieta!");
                        break;
                }
            }
        }
    }
}

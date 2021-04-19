using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour
{
    //GameObject, kas uzglabā visus velkamos objektus
    public GameObject atkritumuMasina;
    public GameObject atroMasina;
    public GameObject autobuss;

    //Uzglabā velkamo objektu sāk. pozīcijas koordinātas (lai zinātu kur aizmest objektu, ja tas nolikts nepareizajā vietā)
    //Objekti paliek public, taču paslēpj no Inspector loga
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    [HideInInspector]
    public Vector2 bussKoord;

    //Uzglabās ainā esošo kanvu
    public Canvas kanva;
    //Uzglabās skaņas avotu, kurā atskaņot audio failu
    public AudioSource skanasAvots;
    //Masīvs, kas uzglabās visas skaņas
    public AudioClip[] skanaKoAtskanot;

    //Uzglabās objektu, kurš ir pēdējais pārvietotais
    [HideInInspector]
    public GameObject pedejaisVilktais = null;

    //Mainīgais atbild par to, vai objektsi r nolikts pareizi vai nepareizi
    [HideInInspector]
    public bool vaiIstajaVieta = false;


    //Funkcija nostrādā tiklīdz nospiesa play poga
    private void Awake()
    {
        atkrKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atroKoord = atroMasina.GetComponent<RectTransform>().localPosition;
        bussKoord = autobuss.GetComponent<RectTransform>().localPosition;
    }
}

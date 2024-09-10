using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Xml : MonoBehaviour
{
    public GameObject coletavel;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("Gravou");
            gravar();

            
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("LEU");
            ler();
        }
    }


    public GameObject posicoes;
 

    public void gravar()
    {
        //o arquivo que contem as informações 
        string filePath = Path.Combine(Application.streamingAssetsPath, "posicao.xml");
      

        Save save1 = new Save();
        Vector3 position = posicoes.transform.position;

        save1.posicao_x = position.x;
        save1.posicao_y = position.y;
        save1.posicao_z = position.z;


        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);

        }

        if (!File.Exists(filePath))
        {
            //Seralizar = transformar arquivo em objeto 
            //Deseralizar = transformar objeto em arquivo
            XmlSerializer seralzier = new XmlSerializer(typeof(Save));
            StreamWriter stremWriter = new StreamWriter(filePath);
            seralzier.Serialize(stremWriter.BaseStream, save1);
            stremWriter.Close();
        }
        else
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
            StreamReader reader = new StreamReader(filePath);
            

            reader.Close(); 


            StreamWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer.BaseStream, save1);
            writer.Close();
        }

    }

    public void ler()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "posicao.xml");

        XmlSerializer xmlSerialzier = new XmlSerializer(typeof(Save));
        StreamReader reader = new StreamReader(filePath);
        Save save = (Save)xmlSerialzier.Deserialize(reader.BaseStream);
        reader.Close();



        coletavel.transform.position = new Vector3(save.posicao_x, save.posicao_y, save.posicao_z);
    }
}
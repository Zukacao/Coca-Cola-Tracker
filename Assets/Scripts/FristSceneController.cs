using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FristSceneController : MonoBehaviour
{
    #region Variables

    public string connection;
    public IDbConnection database;

    public DatabaseOutput databaseOutput;


    public GameObject inputMenu;
    public GameObject mainMenu;
    public GameObject outputMenu;

    #endregion

    private void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/" + "FatAss";
        database = new SqliteConnection(connection);

        databaseOutput = FindObjectOfType<DatabaseOutput>();
    }


    public void inputMenuActive()
    {
        mainMenu.SetActive(false);
        inputMenu.SetActive(true);
    }

    public void outputScene()
    {
        mainMenu.SetActive(false);
        databaseOutput.outputText();
        outputMenu.SetActive(true);
    }

    public void deleteLastInput()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "DELETE FROM Drink WHERE drink_id = (SELECT MAX(drink_id) FROM DRINK)";
        query.ExecuteReader();

        database.Close();
        
    }

    public void backButton()
    {
        outputMenu.SetActive(false);
        inputMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void exitButton()
    {
        Application.Quit();
    }

}

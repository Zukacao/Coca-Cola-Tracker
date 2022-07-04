using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class DatabaseInput : MonoBehaviour
{
    #region Variables 

    public string connection;
    public IDbConnection database;

    private int month = System.DateTime.Now.Month;

    public GameObject inputMenu;
    public GameObject mainMenu;

    #endregion


    private void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/" + "FatAss";
        database = new SqliteConnection(connection);      
    }

    public void back()
    {
        inputMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    #region Input

    public void inputVerySmall()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "INSERT INTO Drink (size, created_at) VALUES (0.33,'" + month + "')";
        query.ExecuteReader();

        database.Close();

        back();
    }

    public void inputSmall()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "INSERT INTO Drink (size, created_at) VALUES (0.5,'" + month + "')";
        query.ExecuteReader();

        database.Close();

        back();
    }

    public void inputMedium()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "INSERT INTO Drink (size, created_at) VALUES (1,'" + month + "')";
        query.ExecuteReader();

        database.Close();

        back();
    }

    public void inputLarge()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "INSERT INTO Drink (size, created_at) VALUES (1.5,'" + month + "')";
        query.ExecuteReader();

        database.Close();

        back();
    }

    public void inputExtraLarge()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "INSERT INTO Drink (size, created_at) VALUES (2,'" + month + "')";
        query.ExecuteReader();

        database.Close();

        back();
    }

    #endregion


}

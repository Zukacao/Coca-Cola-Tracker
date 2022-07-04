using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseCreate : MonoBehaviour
{

    #region Variables 

    public string connection;
    public IDbConnection database;


    #endregion


    private void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/" + "FatAss";
        database = new SqliteConnection(connection);

        createTable();
    }


    private void createTable()
    {
        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "CREATE TABLE IF NOT EXISTS Drink (drink_id INTEGER PRIMARY KEY, size REAL, created_at INTEGER)";
        query.ExecuteReader();

        database.Close();
    }


}

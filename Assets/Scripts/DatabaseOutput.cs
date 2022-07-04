using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;
using TMPro;
public class DatabaseOutput : MonoBehaviour
{
    #region Variables

    public string connection;
    public IDbConnection database;

    private IDataReader reader;

    private int month = System.DateTime.Now.Month;

    public TextMeshProUGUI outputTextMesh;

    #endregion

    private void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/" + "FatAss";
        database = new SqliteConnection(connection);
    }

    public void outputText()
    {
        double pom;
        double sum = 0;

        database.Open();

        IDbCommand query = database.CreateCommand();
        query.CommandText = "SELECT size FROM Drink WHERE created_at='" + month + "' ";
        reader = query.ExecuteReader();
        while (reader.Read())
        {
            double.TryParse(reader[0].ToString(),out pom);
            sum += pom;
        }

        outputTextMesh.text = "POPIO SI " + sum;

        database.Close();
    }


}

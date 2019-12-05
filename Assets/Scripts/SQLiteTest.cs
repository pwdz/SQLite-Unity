using System.Data;
using System.IO;
using UnityEngine;
using Mono.Data.Sqlite;

public class SQLiteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/My_Database";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable = 
        "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
        
        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();//Sends the CommandText to the Connection and builds a SqlDataReader.
        //the table is created: my_table

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

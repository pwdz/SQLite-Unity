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


		// Insert values in table
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
        cmnd.ExecuteNonQuery();


	    // Read and print all values in table   
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;string query ="SELECT * FROM my_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();while (reader.Read()){
        Debug.Log("id: " + reader[0].ToString());
        Debug.Log("val: " + reader[1].ToString());
        }
        
        // Close connection
        dbcon.Close();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

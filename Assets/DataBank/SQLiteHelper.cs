using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;

namespace DataBank{
    public class SQLiteHelper : MonoBehaviour
    {
        private const string Tag = "Ebi: SqliteHelper:\t";

        private string dbName;

        public string dbConnectionString;
        public IDbConnection dbConnection;
        public SQLiteHelper(string dbName)
        {
            this.dbName = dbName;
            dbConnectionString = "URI=file:" + Application.persistentDataPath + "/" + dbName;
            Debug.Log("dbConnectionString" + dbConnectionString);
            dbConnection = new SqliteConnection(dbConnectionString);
            dbConnection.Open();
        }
        ~SQLiteHelper()//what the fuck is ~ :|
        {
            dbConnection.Close();
        }
        public void CloseDb()
        {
            dbConnection.Close();
        }
        // virtual functions
        public virtual IDataReader GetDataById(int id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual IDataReader GetDataByString(string str)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual void DeleteDataById(int id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual void DeleteDataByString(string id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual IDataReader GetAllData()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public void DeleteTable(String tableName)
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText =  "DROP TABLE IF EXISTS " + tableName;
            dbCommand.ExecuteNonQuery();
        //     // Debug.Log(Tag + "This function is not implemented");
        //     // throw null;
        }
        public virtual IDataReader GetNumOfRows()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public IDbCommand GetDbCommand()
        {
            return dbConnection.CreateCommand();
        }
        public virtual bool UpdateData()
        {
            Debug.Log(Tag + "this function is not implemented");
            throw null;
        }
        public virtual void RenameTable(string tableName)
        {
            Debug.Log(Tag + "this funcotion is not implemented");
            throw null;
        }
        

    }

}

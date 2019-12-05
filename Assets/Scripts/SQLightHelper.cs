using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;

namespace DataBank{
    public class SQLiteHelper 
    {
        private const string Tag = "Ebi: SqliteHelper:\t";

        private const string database_name = "my_db";

        public string db_connection_string;
        public IDbConnection db_connection;
        public SQLiteHelper()
        {
            db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;
            Debug.Log("db_connection_string" + db_connection_string);
            db_connection = new SqliteConnection(db_connection_string);
            db_connection.Open();
        }
        ~SQLiteHelper()//what the fuck is ~ :|
        {
            db_connection.Close();
        }
        // virtual functions
        public virtual IDataReader GetDataById(int id)
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }
        public virtual IDataReader GetDataByString(string str)
        {
            Debug.Log(Tag + "This function is not implemnted");
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
        public virtual void DeleteAllData()
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }
        public virtual IDataReader GetNumOfRows()
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }
        public IDbCommand GetDbCommand()
        {
            return db_connection.CreateCommand();
        }
        

    }

}

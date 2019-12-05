﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class AwardsDb : SQLiteHelper
    {
        private const String Tag = "Ebi: AwardsDb:\t";
        
        private const String TABLE_NAME = "UserAwards";
        private const String KEY_ID = "id";
        private const String KEY_TYPE = "type";
        private const String KEY_IMGURL = "imageUrl";
        private const String KEY_NUM = "number";
        private const String KEY_PRIORITY = "priority";
        private const String KEY_ISLOCAL = "isLocal";
        private String[] COLUMNS = new String[] {KEY_ID, KEY_TYPE, KEY_IMGURL, KEY_NUM, KEY_PRIORITY,KEY_ISLOCAL};
        public AwardsDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();

            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
            KEY_ID + " INTEGER PRIMARY KEY, " +
            KEY_TYPE + " VARCHAR(20), " +//ask the size of VARCHAR OR TEXT instead
            KEY_IMGURL + " VARCHAR(40), " +
            KEY_NUM + " INT, " +
            KEY_PRIORITY + " INT, " +
            KEY_ISLOCAL + " INT )";

            dbcmd.ExecuteNonQuery();
        }
        public void AddData(AwardsEntity award)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_TYPE + ", "
                + KEY_IMGURL + ", "
                + KEY_NUM + ", "
                + KEY_PRIORITY + ", "
                + KEY_ISLOCAL + " ) "

                + "VALUES ( '"
                + award._id + "', '"
                + award._type + "', '"
                + award._Lat + "', '"
                + award._Lng + "' )";
            dbcmd.ExecuteNonQuery();
       	}
        public override IDataReader GetDataById(int id)
        {
            return base.GetDataById(id);
        }   
    }   
}

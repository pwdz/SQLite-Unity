using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
	public class LastTableEntity {

            public int _id;
            public String _type;
            public string _jwt;

            public LastTableEntity(int id, String type, string jwt)
            {
                _id = id;
                _type = type;
                _jwt = jwt;
            }

	}
}
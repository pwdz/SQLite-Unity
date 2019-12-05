using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataBank
{    
    public class AwardsEntity  
    {
        public string _id;
        public string _type;
        public string _imageUrl;
        public string _num;
        public string _priority;
        public string _isLocal;

        public AwardsEntity(string id, string type, string imageUrl, string num, string priority, string isLocal)
        {
            _id = id;
            _type = type;
            _imageUrl = imageUrl;
            _num = num;
            _priority = priority;
            _isLocal = isLocal;
        }
        public AwardsEntity GetFakeAwardEntity()
        {
            return new AwardsEntity("0","test_type","test_imgUrl","100","200","1");
        }

    }
}


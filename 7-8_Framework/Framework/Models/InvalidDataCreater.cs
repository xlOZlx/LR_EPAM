using Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Models
{
    class InvalidDataCreater
    {
        public string DriverAge;

        public InvalidDataCreater()
        {
            DriverAge = InfalidDataReader.GetData("DriverAge");
        }
    }
}

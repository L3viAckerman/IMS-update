using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Modules
{
    public class CommonService
    {
        protected IMSContext IMSContext;
        public CommonService()
        {
            IMSContext = new IMSContext();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightSwitchApplication.Helpers
{
    public static class ReferenceHelper
    {

        public static int SpecialCharacterCount(String pString)
        {
	        return 
                pString.Count(c => !char.IsLetterOrDigit(c));
        }


    }
}
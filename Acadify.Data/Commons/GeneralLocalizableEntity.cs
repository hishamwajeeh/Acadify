using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string textAr, string textEn)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if(currentCulture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return textAr;
            }
            return textEn;
        }
    }
}

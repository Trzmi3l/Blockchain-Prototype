using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Utils
{
    public class MiningUtils
    {
        public static int CalucateZeros(string s)
        {
            string _ = StringUtils.Reverse(s);
            char[] __ = _.ToCharArray();
            int ___ = 0;

            for(; ; )
            {

                if (__[___] == '0')
                {
                    ___++;
                } else
                {
                    break;
                }
                
            }

            return ___ ;
        }
    }
}

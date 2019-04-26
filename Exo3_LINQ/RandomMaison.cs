using System;
using System.Collections.Generic;
using System.Text;

namespace Exo3_LINQ
{
    class RandomMaison : Random
    {
        private static RandomMaison _Instance;
        public static RandomMaison Instance
        {
            get {
                if (_Instance == null)
                {
                    _Instance = new RandomMaison();
                }
                return _Instance;
            }
        }
    }
}

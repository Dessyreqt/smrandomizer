using System.Collections.Generic;

namespace SuperMetroidRandomizer.Rom
{
    public static class Controller
    {
        public static Dictionary<string, string> Buttons = new Dictionary<string, string>
                                                               {
                                                                   {"Up", "\x00\x08"},
                                                                   {"Down", "\x00\x04"},
                                                                   {"Left", "\x00\x02"},
                                                                   {"Right", "\x00\x01"},
                                                                   {"Select", "\x00\x20"},
                                                                   {"Start", "\x00\x10"},
                                                                   {"A", "\x80\x00"},
                                                                   {"B", "\x00\x80"},
                                                                   {"X", "\x40\x00"},
                                                                   {"Y", "\x00\x40"},
                                                                   {"L", "\x20\x00"},
                                                                   {"R", "\x10\x00"},
                                                                   {"None", "\x00\x00"},
                                                               };

        public static List<int> ShotAddresses = new List<int> 
                                                    { 
                                                        0xb331, 
                                                        0x1722d, 
                                                    };
        public static List<int> JumpAddresses = new List<int>
                                                    {
                                                        0xb325, 
                                                        0x17233,
                                                    };
        public static List<int> DashAddresses = new List<int>
                                                    {
                                                        0xb32b, 
                                                        0x17239,
                                                    };
        public static List<int> ItemSelectAddresses = new List<int>
                                                          {
                                                              0xb33d, 
                                                              0x17245,
                                                          };
        public static List<int> ItemCancelAddresses = new List<int>
                                                          {
                                                              0xb337, 
                                                              0x1723f,
                                                          };
        public static List<int> AngleUpAddresses = new List<int>
                                                       {
                                                           0xb343, 
                                                           0x1724b,
                                                       };
        public static List<int> AngleDownAddresses = new List<int>
                                                         {
                                                             0xb349, 
                                                             0x17251,
                                                         };
    }
}

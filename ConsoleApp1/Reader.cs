using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    static class Reader
    {
        public static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static int GetInt(string prompt, Predicate<int> validator, string failString) {
            int? outp = null;
            while (outp == null) {
                Console.Write(prompt);
                var read = 0;
                if (int.TryParse(Console.ReadLine(), out read)) {
                    if (validator(read)) {
                        outp = read;
                        continue;
                    }
                }
                Console.WriteLine(failString);
            }
            return (int)outp;
        }
        public static bool GetBool(string prompt, string failString) {
            bool? outp = null;
            while (outp == null) {
                Console.Write(prompt);
                var read = false;
                if (bool.TryParse(Console.ReadLine(), out read)) {
                    outp = read;
                } else {
                    Console.WriteLine(failString);
                }
            }
            return (bool)outp;
        }
        public static DateTime GetDate(string prompt, Predicate<DateTime> validator, string failString) {
            DateTime? outp = null;
            var reg = new Regex(@"(?<day>\d+)[./](?<month>\d+)[./](?<year>\d.)");
            while (outp == null) {
                try {
                    Console.Write(prompt);
                    var res = reg.Match(Console.ReadLine());
                    var day = int.Parse(res.Groups["day"].Value);
                    var month = int.Parse(res.Groups["month"].Value);
                    var year = int.Parse(res.Groups["year"].Value);
                    outp = new DateTime(year, month, day);
                } catch {
                    Console.WriteLine(failString);
                }
            }
            return (DateTime)outp;
        }

    }
}

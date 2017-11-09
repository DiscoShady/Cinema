using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Cinema.Extensions {
    public class Helper {

        private static Random random = new Random();


        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYabcdefghijklmnopqrstuvwxyzZ0123456789";
            return new string(Enumerable.Repeat(chars, length) .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomInt(int length) {
            const string numbs = "1234567890";
            return new string(Enumerable.Repeat(numbs, length).Select(s => s[random.Next(s.Length)]).ToArray());

        }


        public static string ReplaceAllSpaces(string str) {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            var replace = rgx.Replace(str, "");
            return replace.Replace(" ", "-");
        }

        public static string Truncate(string str, int maxLength, string suffix) {
            if (str.Length > maxLength) {
                var words = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var sb = new StringBuilder();
                for (int i = 0; sb.ToString().Length + words[i].Length <= maxLength; i++) {
                    sb.Append(words[i]);
                    sb.Append(" ");
                }
                str = sb.ToString().TrimEnd(' ') + suffix;
            }
            return str.Trim();
        }

    }

}
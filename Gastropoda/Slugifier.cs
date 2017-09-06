namespace Gastropoda
{
    using System.Text;

    public static class Slugifier
    {
        public static string Slugify(this string input)
        {
            if (input == null)
            {
                return null;
            }

            if (input == string.Empty)
            {
                return string.Empty;
            }

            int len = input.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);
            char c;

            for (int i = 0; i < len; i++)
            {
                c = input[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length)
                    {
                        prevdash = false;
                    }
                }
            }

            var str = sb.ToString();
            if (prevdash)
            {
                str = str.Substring(0, sb.Length - 1);
            }

            return str;
        }

        private static string RemapInternationalCharToAscii(char c)
        {
            string mappedCharacter = string.Empty;
            string s = c.ToString().ToLowerInvariant();

            if ("àåáâäãåą".Contains(s))
            {
                mappedCharacter = "a";
            }
            else if ("èéêëę".Contains(s))
            {
                mappedCharacter = "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                mappedCharacter = "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                mappedCharacter = "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                mappedCharacter = "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                mappedCharacter = "c";
            }
            else if ("żźž".Contains(s))
            {
                mappedCharacter = "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                mappedCharacter = "s";
            }
            else if ("ñń".Contains(s))
            {
                mappedCharacter = "n";
            }
            else if ("ýÿ".Contains(s))
            {
                mappedCharacter = "y";
            }
            else if ("ğĝ".Contains(s))
            {
                mappedCharacter = "g";
            }
            else if ("Œœ".Contains(s))
            {
                mappedCharacter = "oe";
            }
            else if ("Ææ".Contains(s))
            {
                mappedCharacter = "ae";
            }
            else if (c == 'ř')
            {
                mappedCharacter = "r";
            }
            else if (c == 'ł')
            {
                mappedCharacter = "l";
            }
            else if (c == 'đ')
            {
                mappedCharacter = "d";
            }
            else if (c == 'ß')
            {
                mappedCharacter = "ss";
            }
            else if (c == 'Þ')
            {
                mappedCharacter = "th";
            }
            else if (c == 'ĥ')
            {
                mappedCharacter = "h";
            }
            else if (c == 'ĵ')
            {
                mappedCharacter = "j";
            }
            else
            {
                mappedCharacter = string.Empty;
            }

            return mappedCharacter;
        }
    }
}

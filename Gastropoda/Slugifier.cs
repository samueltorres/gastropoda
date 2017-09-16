namespace Gastropoda
{
    using System.Text;

    public static class Slugifier
    {
        public static string Slugify(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            int inputLength = input.Length;
            bool prevdash = false;
            var slugBuilder = new StringBuilder(inputLength * 2);
            char c;

            for (int i = 0; i < inputLength; i++)
            {
                c = input[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    slugBuilder.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // Lowercase
                    slugBuilder.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' || c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && slugBuilder.Length > 0)
                    {
                        slugBuilder.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int)c >= 128)
                {
                    int prevlen = slugBuilder.Length;
                    slugBuilder.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != slugBuilder.Length)
                    {
                        prevdash = false;
                    }
                }
                else
                {
                    slugBuilder.Append(c);
                    prevdash = false;
                }
            }

            var str = slugBuilder.ToString();
            if (prevdash)
            {
                str = str.Substring(0, slugBuilder.Length - 1);
            }

            return str;
        }

        private static string RemapInternationalCharToAscii(char c)
        {
            if (CharMaps.InternationalToAscii.ContainsKey(c))
            {
                return CharMaps.InternationalToAscii[c];
            }

            return string.Empty;
        }
    }
}

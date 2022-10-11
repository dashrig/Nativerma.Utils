using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nativerma.Utils
{
    public static class Extensions
    {
        public static StringBuilder AppendWithSeparator(this StringBuilder sb, string value, string separator)
        {
            sb.Append(value);
            sb.Append(separator);
            return sb;
        }
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static byte[] ToUtf8Bytes(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        public static string ToUtf8String(this byte[] source)
        {
            return Encoding.UTF8.GetString(source);
        }

        public static byte[] ToSha256(this string source)
        {
            var buff = source.ToUtf8Bytes();

            using (var hasher = SHA256.Create())
            {
                return hasher.ComputeHash(buff);
            }
        }

        public static byte[] ToMD5(this string source)
        {
            var buff = source.ToUtf8Bytes();

            using (var hasher = MD5.Create())
            {
                return hasher.ComputeHash(buff);
            }
        }

        public static string ToHex(this byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }
    }
}

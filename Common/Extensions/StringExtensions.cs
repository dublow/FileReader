﻿using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;


namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static bool TryParse(this string value, out XElement result)
        {
            result = null;

            if (string.IsNullOrEmpty(value))
                return false;

            try
            {
                result = XElement.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TryParse(this string value, out JObject result)
        {
            result = null;

            if (string.IsNullOrEmpty(value))
                return false;

            try
            {
                result = JObject.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

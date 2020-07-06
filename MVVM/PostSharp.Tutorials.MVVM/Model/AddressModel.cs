﻿using System;
using System.ComponentModel;
using System.Text;

namespace PostSharp.Tutorials.MVVM.Model
{
    public class AddressModel : ModelBase
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

        public DateTime Expiration { get; set; }


        public string FullAddress
        {
            get
            {
                var stringBuilder = new StringBuilder();
                if (Line1 != null)
                {
                    stringBuilder.Append(Line1);
                }

                if (Line2 != null)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append("; ");
                    }

                    stringBuilder.Append(Line2);
                }
                if (Town != null)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append("; ");
                    }

                    stringBuilder.Append(Town);
                }
                if (Country != null)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append("; ");
                    }

                    stringBuilder.Append(Country);
                }


                return stringBuilder.ToString();
            }
        }
    }
}
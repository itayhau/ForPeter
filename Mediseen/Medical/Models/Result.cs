using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical.Models
{
    public class Result : IComparable<Result>
    {
        public string Term { get; set; }
        public int Count { get; set; }

        public int CompareTo(Result other)
        {
            return other.Count - this.Count;
        }
    }
}
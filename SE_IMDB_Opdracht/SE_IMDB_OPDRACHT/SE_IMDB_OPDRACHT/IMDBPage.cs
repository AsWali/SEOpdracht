using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_IMDB_OPDRACHT
{
    public class IMDBPage
    {
        private int PageNMR;
        private string description;
        private string name;
        private string pagekind;
        private int rating;


        public IMDBPage(int pagenmr, string desc, string name, string pagekind, int rating)
        {
            PageNMR = pagenmr;
            description = desc;
            this.name = name;
            this.pagekind = pagekind;
            this.rating = rating;
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedLib
{
    
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public Decimal Price { get; set; }
        public string Currency { get; set; }
        public int Pages { get; set; }

        
    }
    public enum BookType
    {
        Fantasy,
        Children,
        ScienceFiction,
        Thriller,
        Romance,
        History,
        Science,
        Horror
    }

    public enum Currency
    {
        PLN,
        EUR,
        USD,
        GBP,
        CHF,
        JPY,
        CNY,
        CAD,
        AUD,
        NZD,
        NOK,
        SEK,
        DKK,
        HKD,
        SGD,
        THB,
        IDR,
        PHP,
        ZAR,
        INR,
        MYR,
        BRL,
        RUB,
        KRW,
        CZK,
        HUF,
        TWD,
        CNH,
        CLP,
        PEN,
        COP,
        MXN,
        BOB,
        PYG,
        UYU,
        ARS,
        VEF,
        CUP,
        CUC,
    }


}

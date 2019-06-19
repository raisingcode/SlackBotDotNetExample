using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackTest.Models.RaisingCodeBotSmarts
{
    public static class InsultMe
    {
        private static List<Tuple<string, int>> used_quotes;
             static InsultMe()
            {
            used_quotes = new List<Tuple<string, int>>();
            used_quotes.Add(new Tuple<string, int>("You must be an experiment in Artificial Stupidity", 0));
     used_quotes.Add(new Tuple<string,int>("Shut up - you will never be the man your mother is.",0));
    used_quotes.Add(new Tuple<string,int>("You must have been born on a highway, because that is where most accidents happen.",0));

    used_quotes.Add(new Tuple<string,int>("It looks like your face caught on fire and someone tried to put it out with a fork.",0));

    used_quotes.Add(new Tuple<string,int>("You are so ugly Hello Kitty said goodbye to you.",0));
    used_quotes.Add(new Tuple<string,int>("You are so ugly that when your mama dropped you off at school she got a fine for littering.",0));
    used_quotes.Add(new Tuple<string,int>("If you were twice as smart, you would still be stupid.",0));
    used_quotes.Add(new Tuple<string,int>("Do you have to leave so soon I was just about to poison the tea.",0));

    used_quotes.Add(new Tuple<string,int>("I know you are but what am I",0));
    used_quotes.Add(new Tuple<string,int>("If I wanted to kill myself, I would climb up your ego and jump down to your IQ level.",0));



    used_quotes.Add(new Tuple<string, int>("It is better to let someone think you are an Idiot than to open your mouth and prove it.", 0));


            }
        public static string Quote { get {
                return ranQuote();
            } }

        static string ranQuote()
        {
            int i = used_quotes.Count;
            Random r = new Random(DateTime.Now.Millisecond);
            var quote = used_quotes[r.Next(0, i)].Item1;
            return quote;
        }
    }
}
using Generated;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Client
{
    class Program
    {
        static bool verificareZiNastere(string data)
        {
            string regex = @"((0?[1-9]|1[0-2])\/(0?[1-9]|[12][0-9]|3[01])\/([1-9][0-9]{0,3}))";
            if (data != string.Empty)
            {
                Match match = Regex.Match(data, regex);
               
                if (match.Value == data)
                {
                    string[] impartireDataNastere = data.Split('/');
                    int luna = int.Parse(impartireDataNastere[0]);
                    int zi = int.Parse(impartireDataNastere[1]);
                    int an = int.Parse(impartireDataNastere[2]);

                    
                    if (luna == 2)
                    {
                        if (an % 4 == 0 && zi > 28 && an %400==0 && an%100!=0)
                            return false;
                    }
                    
                    
                    if (luna == 4 || luna == 6 || luna == 9 || luna == 11)
                        if (zi > 30)
                            return false;
               
                    return true;
                }

            }
            return false;
        }
        static void Main(string[] args)
        {
            const string Host = "localhost";
            const int Port = 16973;

            var channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);

            Console.WriteLine("Scrie data pentru a vedea zodia (luna/zi/an)");

            var date = Console.ReadLine();

            if (verificareZiNastere(date))
            {
                var client = new Generated.ZodiacService.ZodiacServiceClient(channel);

                var output = client.GetZodie(new Generated.Date  {Date_ = date});

                Console.WriteLine("Zodia pentru data de nastere data este: {0}", output.Zodie_);
            }
            else
                Console.WriteLine("Data de nastere nu este valida!");

            channel.ShutdownAsync().Wait();
        }
    }
}

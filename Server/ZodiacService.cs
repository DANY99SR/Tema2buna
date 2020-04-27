using Generated;
using Grpc.Core;
using System.Threading.Tasks;

namespace Server
{
    internal class ZodiacService : Generated.ZodiacService.ZodiacServiceBase
    {
        public override Task<Zodie> GetZodie(Date request, ServerCallContext context)
        {
            System.Console.WriteLine("Data de nastere primita este: {0}", request.Date_);

            ListaZodii signList = new ListaZodii();
            string zodie = signList.FindSign(request.Date_);
            
            if (zodie != string.Empty)
                return Task.FromResult(new Zodie { Zodie_ = zodie });
            
            return Task.FromResult(new Zodie { Zodie_ = string.Empty });
        }
    }
}

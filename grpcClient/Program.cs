using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcClient;

namespace grpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new HistoricalFeed.HistoricalFeedClient(channel);
            var reply = await client.SubscribeAsync(
                new SubscribeRequest { Currency = "USD", Exchange = ExchangeType.Btc });
            Console.WriteLine("===========================================");
            Console.WriteLine("TimeStamp: " + reply.Timestamp);
            Console.WriteLine("New Response:");
            Console.WriteLine("Close: " + reply.Close);
            Console.WriteLine("High: " + reply.High);
            Console.WriteLine("Low: " + reply.Low);
            Console.WriteLine("Open: " + reply.Open);
            Console.WriteLine("VolumeBtc: " + reply.VolumeBtc);
            Console.WriteLine("VolumeCur: " + reply.VolumeCur);
            Console.WriteLine("WeightedPrice: " + reply.WeightedPrice);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
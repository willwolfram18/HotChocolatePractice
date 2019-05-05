using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using HotChocolateData;
using Newtonsoft.Json;

namespace HotChocolateClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var client = new GraphQLClient("http://localhost:5000");
                var request = new GraphQLRequest
                {
                    Query = @"query {
    characters {
        ...characterFragment,
        friends {
            ...characterFragment
        }
    }
}
fragment characterFragment on Character {
    id,
    name,
    jobs {
        level,
        class
    }
}"
                };

                var response = await client.GetAsync(request);
                var characters = response.GetDataFieldAs<IEnumerable<Character>>("characters");

                foreach (var character in characters)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(character, Formatting.Indented));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
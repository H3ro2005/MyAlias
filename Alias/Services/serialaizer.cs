using Alias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alias.Services
{
    public class serialaizer
    {
        List<wordsmodel> words = new();

        public async Task<List<wordsmodel>> GetMainwords()
        {
            if (words?.Count > 0)
                return words;

            var stream = await FileSystem.Current.OpenAppPackageFileAsync("jsconfigur.json");
            var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
           
            words = JsonSerializer.Deserialize<List<wordsmodel>>(contents);
            
            return words;
        }
    }
}

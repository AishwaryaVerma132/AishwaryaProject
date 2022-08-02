using Newtonsoft.Json;

namespace My_Pie_Shop.Models
{
    public static class PieAPIData
    {
        public static async Task<IEnumerable<Pie>> GetApiData(string ApiAddress)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            return pies;
        }

        public static async Task<IEnumerable<Category>> GetCategoryApiData(string ApiAddress)
        {
            IEnumerable<Category> categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(apiResponse);
                }
            }
            return categories;
        }

    }
}

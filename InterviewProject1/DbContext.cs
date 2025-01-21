using System.Text.Json;

namespace InterviewProject1
{
    /// <summary>
    /// The db context.
    /// </summary>
    public class DbContext
    {
        private readonly string dbFilePath = Path.Combine(Path.GetTempPath(), "db.json");

        /// <summary>
        /// Get data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<ICollection<T>> GetData<T>()
        {
            if (!File.Exists(this.dbFilePath))
            {
                return new List<T>();
            }

            string json = await File.ReadAllTextAsync(this.dbFilePath);
            ICollection<T> data = JsonSerializer.Deserialize<ICollection<T>>(json);
            return data;
        }

        /// <summary>
        /// Save data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task SaveData<T>(T data)
        {
            string json = JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(this.dbFilePath, json);
        }
    }
}

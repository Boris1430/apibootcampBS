﻿namespace EjemploEntity.DTOs
{
    // ChuckNorrisDTO myDeserializedClass = JsonConvert.DeserializeObject<ChuckNorrisDTO>(myJsonResponse);
    public class ChuckNorrisDTO
    {
        public List<object> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}

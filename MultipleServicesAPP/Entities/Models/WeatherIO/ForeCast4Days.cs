namespace MultipleServicesAPP.Entities.Models.WeatherIO
{
    public class ForeCast4Days
    {
        public DataWeather[] data { get; set; }
        public string city_name { get; set; }
        public float lon { get; set; }
        public string timezone { get; set; }
        public float lat { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
    }

    public class DataWeather
    {
        public string timestamp_local { get; set; }
        public string timestamp_utc { get; set; }
        public float ts { get; set; }
        public string datetime { get; set; }
        public float wind_gust_spd { get; set; }
        public float wind_spd { get; set; }
        public int wind_dir { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
        public float temp { get; set; }
        public float app_temp { get; set; }
        public float? pop { get; set; }
        public float? precip { get; set; }
        public float? snow { get; set; }
        public float? snow_depth { get; set; }
        public float slp { get; set; }
        public float pres { get; set; }
        public float dewpt { get; set; }
        public float rh { get; set; }
        public GeneralDescription weather { get; set; }
        public string pod { get; set; }
        public float clouds_low { get; set; }
        public float clouds_mid { get; set; }
        public float clouds_hi { get; set; }
        public float clouds { get; set; }
        public float vis { get; set; }
        public float dhi { get; set; }
        public float dni { get; set; }
        public float ghi { get; set; }
        public float solar_rad { get; set; }
        public float uv { get; set; }
        public float ozone { get; set; }
    }

    public class GeneralDescription
    {
        public string icon { get; set; }
        public float code { get; set; }
        public string description { get; set; }
    }

}

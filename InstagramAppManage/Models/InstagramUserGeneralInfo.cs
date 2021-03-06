﻿namespace InstagramAppManage.Models
{
    
    public class Counts
    {
        public int media { get; set; }
        public int follows { get; set; }
        public int followed_by { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string full_name { get; set; }
        public string bio { get; set; }
        public string website { get; set; }
        public Counts counts { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
    }

    public class InstagramGeneralInfo
    {
        public Data data { get; set; }
        public Meta meta { get; set; }
    }
    
   
}

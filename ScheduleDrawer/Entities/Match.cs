﻿namespace ScheduleDrawer.Entities
{
    public class Match
    {
        public string Home { get; set; }
        public string Away { get; set; }
        public int Round { get; set; }
        public int?[] Result { get; set; }
    }
}

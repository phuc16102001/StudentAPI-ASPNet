﻿namespace StudentAPI_ASPNet.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required bool IsMale { get; set; }
        public string? Email { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt_9._1
{
    struct Student
    {
        public Student(string name, string sername, string patronymic, string street, int house, int room)
        {
            Name = name;
            Sername = sername;
            Patronymic = patronymic;
            Street = street;
            House = house;
            Room = room;
        }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Patronymic { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Room { get; set; }
    }
}

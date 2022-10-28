using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Client
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Kid { get; set; }
        public string Division { get; set; }
        public string Post { get; set; }
        public int Prize { get; set; }


        public Client() { 
        }

        public Client(int ID, string Status, string Name, string Surname, int Age, int Kid, string Division, string Post, int Prize) {
            this.ID = ID;
            this.Status = Status;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Kid = Kid;
            this.Division = Division;
            this.Post = Post;
            this.Prize = Prize;
        }
    }
}

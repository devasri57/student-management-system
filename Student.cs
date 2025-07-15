namespace NewProj
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public float GPA { get; set; }

        public Student(int id, string name, string dept, float gpa)
        {
            Id = id;
            Name = name;
            Dept = dept;
            GPA = gpa;
        }

        public Student() { }
    }
}

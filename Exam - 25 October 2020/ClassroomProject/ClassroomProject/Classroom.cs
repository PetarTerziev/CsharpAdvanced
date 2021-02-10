using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;
        private int capacity;
        public Classroom(int capacity)
        {
            this.capacity = capacity;
            data = new List<Student>();
        }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Count => data.Count;

        public string RegisterStudent(Student student) 
        {
            if (Count < Capacity)
            {
                data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName) 
        {
            if (data.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                data.RemoveAll(s => s.FirstName == firstName && s.LastName == lastName);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject) 
        {
            StringBuilder result = new StringBuilder();

            if (!data.Any(s => s.Subject == subject))
            {
                result.AppendLine("No students enrolled for the subject");
            }
            else
            {
                result.AppendLine($"Subject: {subject}");
                result.AppendLine($"Students:");

                foreach (var std in data.Where(s => s.Subject == subject))
                {
                    result.AppendLine($"{std.FirstName} {std.LastName}");
                }
            }

            return result.ToString().Trim();
        }

        public string GetStudentsCount() 
        {
            return Count.ToString();
        }

        public Student GetStudent(string firstName, string lastName) 
        {

            return data.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}

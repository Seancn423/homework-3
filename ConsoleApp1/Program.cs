using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        [Serializable]
        public class Student
        {
            public int sno;
            public string sname;
            public Student() { }
            public Student(int sno, string sname)
            {
                this.sno = sno;
                this.sname = sname;
            }
            public int compareto(Student a)
            {
                if (a.sno > sno)
                {
                    return -1;
                }
                else if (a.sno < sno) return 1;
                else return 0;
            }
        }
        [Serializable]
        public partial class StudentSet
        {
            public List<Student> Students{ set; get; }

            public StudentSet()
            {
                Students = new List<Student>();
            }

            public void InitStudents()
            {
                
                Student student1 = new Student(1, "张三");
                Student student2 = new Student(2, "李四");
                Student student3 = new Student(3, "王五");

                Students.Add(student1);
                Students.Add(student2);
                Students.Add(student3);
            }
            public bool AddStudentSet(Student s)
            {
                Students.Add(s);
                return true;
             }
            public bool UpdateStudentSet(Student oldSt,Student newSt)
            {
                int i;
                for (i = 0; i < Students.Count; i++)
                {
                    if (Students[i] == oldSt) Students[i] = newSt;
                }
                return true;
            } 
            public bool DeleteStudentSet(int i)
            {
                Student t = Students.Find((c) => c.sno ==i);
                Students.Remove(t);
                return true;
            }
            public bool SortStudentSet(int i)
            {
                Students.Sort();
                return true;
            } 
            public void BianliStudentSet()
            {
                int i;
                for (i= 0;i<Students.Count;i++)
                {
                    Console.WriteLine(Students[i].sno+":"+ Students[i].sname);
                }
            }
            public string SerializableSet()
            {
                string s = JsonSerializer.Serialize<List<Student>>(Students);
                return s;
            }
            public bool SaveToFile(string filename,string s)
            {
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite); 
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8); 
                sw.Write(s); 
                sw.Close(); 
                fs.Close();
                return true;
            }
            public string GetToFile(string filepath) 
            { 
                string json = string.Empty; 
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite)) 
                { 
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8)) 
                    { 
                        json = sr.ReadToEnd().ToString(); 
                    } 
                } 
                return json; 
            }
        }
        
        static void Main(string[] args)
        {
            Student s = new Student(4, "王二麻子");
            Student s2 = new Student(2, "李四");
            Student s3 = new Student(2,"一修");
            
            StudentSet sset = new StudentSet();
            sset.InitStudents();
            sset.BianliStudentSet();
            Console.WriteLine();
            sset.AddStudentSet(s);
            sset.UpdateStudentSet(s2, s3);
            sset.BianliStudentSet();
            Console.WriteLine();
            Console.WriteLine( (sset.Students.Find((c) => c.sno == 2)).sname);
        }
    }
}
